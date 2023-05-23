using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Collections.Generic;
using Parser.Tools.Annotations;

namespace Parser.Tools.Handlers
{
    public sealed class DataLoadHandler
    {

        /// <summary>
        /// Convert file content to list if objects
        /// </summary>
        /// <param name="filePath">Path to data file</param>
        /// <param name="containHeader">File has a header</param>
        /// <returns>List of <typeparamref name="T"/></returns>
        /// <exception cref="FileNotFoundException"/>

        public static List<T> Load<T>(string filePath, bool containHeader, Encoding encoding = null)
            where T : class, new()
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File {filePath} is not found");
            if (encoding is null) encoding = Encoding.GetEncoding(1252);
            var ret = new List<T>();

            using(var sr = new StreamReader(filePath,encoding))
            {
                // Make sure that file contain data
                if (sr.BaseStream.Length < 1) return ret;
                
                var line = string.Empty;
                if (containHeader) sr.ReadLine();
                while((line = sr.ReadLine()) != null)
                {
                    ret.Add(GetData<T>(line));
                }
            }

            return ret;
        }

        /// <summary>
        /// Convert data string to object
        /// </summary>
        /// <typeparam name="T"><typeparamref name="T"/></typeparam>
        /// <param name="data">String data</param>
        /// <returns><typeparamref name="T"/></returns>
        /// <exception cref="Exception"></exception>
        public static T GetData<T>(string data)
            where T : class, new()
        {
            
            var cAttr = Attribute.GetCustomAttributes(typeof(T)).Where(x => x.GetType() == typeof(DataSplitterAttribute)).FirstOrDefault();
            if(cAttr != null)
            {
                var splitter = (cAttr as DataSplitterAttribute);
                var arr = data.Split(splitter.Splitter.ToCharArray());
                return GetData<T>(arr, splitter.MinNumberOfFields);
            }

            var fields = typeof(T).GetProperties().Select(f => f.Name).ToList();
            if (fields.Count < 1)
                throw new Exception($"No property fields in {nameof(T)}");

            var ret = new T();

            foreach (var field in fields)
            {
                var f = typeof(T).GetProperty(field);
                if (f is null) continue;

                var attrs = Attribute.GetCustomAttributes(f);
                if (attrs.Length < 1) continue;

                string element = string.Empty;
                Attribute attr;
                if(attrs.Where(x=> x.GetType() == typeof(FieldFixedAttribute)).Any())
                {
                    attr = Attribute.GetCustomAttribute(f, typeof(FieldFixedAttribute));
                    if (attr is null) continue;
                    element = GetFromFixed(data, attr as FieldFixedAttribute);
                }
                else if(attrs.Where(x=> x.GetType() == typeof(FieldTagAttribute)).Any())
                {
                    attr = Attribute.GetCustomAttribute(f, typeof(FieldTagAttribute));
                    if(attr is null) continue;
                    element = GetFromTag(data, attr as FieldTagAttribute);
                }
                else
                {
                    continue;
                }

                f.SetValue(ret, ExtractVal(element, f));
            }

            return ret;
        }
        /// <summary>
        /// Convert a string array to oject
        /// </summary>
        /// <typeparam name="T"><typeparamref name="T"/></typeparam>
        /// <param name="data">String array</param>
        /// <param name="minNumberOfFields">
        /// Minimum numbers of fields in array. (-1 = no check)
        /// </param>
        /// <returns><typeparamref name="T"/></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="IndexOutOfRangeException"></exception>
        public static T GetData<T>(string[] data, int minNumberOfFields = -1)
            where T : class, new()
        {
            if(minNumberOfFields > -1)
            {
                if (data.Length < minNumberOfFields)
                    throw new Exception($"Invalid number of fields. Fund {data.Length} but expected {minNumberOfFields}");
            }
            var fields = typeof(T).GetProperties().Select(f => f.Name).ToList();
            if (fields.Count < 1)
                throw new Exception($"No property fields in {nameof(T)}");

            var ret = new T();
            foreach (var field in fields)
            {
                var f = typeof(T).GetProperty(field);
                if (f is null) continue;
                var attr = Attribute.GetCustomAttribute(f, typeof(FieldIndexAttribute)) as FieldIndexAttribute;
                if (attr is null) continue;
                if (data.Length > attr?.Index)
                {

                    var strElement = data[attr.Index].Trim();
                    object dataVal = ExtractVal(strElement, f);
                    f.SetValue(ret, dataVal);
                    continue;
                }
                throw new IndexOutOfRangeException();
            }

            return ret;
        }

        /// <summary>
        /// Extract string
        /// </summary>
        /// <param name="val">Data content</param>
        /// <param name="attr">FixedFieldAttribute</param>
        /// <returns>Extracted string</returns>
        /// <exception cref="Exception">Data out of range</exception>
        private static string GetFromFixed(string val, FieldFixedAttribute attr)
        {
            if ((attr.Offset + attr.Size) > val.Length)
                throw new Exception($"Data out of range. Offset: {attr.Offset}, Size {attr.Size}");
            var retVal = val.Substring(attr.Offset, attr.Size);
            return attr.Trim ? retVal.Trim() : retVal;

        }

        /// <summary>
        /// Extract string
        /// </summary>
        /// <param name="val">Data content</param>
        /// <param name="attr">FieldTagAttribute</param>
        /// <returns>Extracted string</returns>
        /// <exception cref="Exception">Tag not found</exception>
        private static string GetFromTag(string val, FieldTagAttribute attr )
        {
            var offset = val.IndexOf(attr.StartTag);
            if (offset < 0)
                throw new Exception($"Tag not found {attr.StartTag}");
            offset += attr.StartTag.Length;
            if ((offset + attr.EndTag.Length) >= val.Length)
                throw new Exception($"Tag not found {attr.EndTag}");
            var endpos = val.IndexOf(attr.EndTag);
            if (endpos < 0)
                throw new Exception($"Tag not found {attr.EndTag}");
            return val.Substring(offset, endpos - offset).Trim();
        }

        /// <summary>
        /// Convert string to desired standard object type
        /// </summary>
        /// <param name="val">Data string</param>
        /// <param name="field">PropertyInfo</param>
        /// <returns>object</returns>
        private static object ExtractVal(string val, PropertyInfo field)
        {
            var t = Type.GetTypeCode(field.PropertyType);
            switch (t)
            {
                case TypeCode.String:
                case TypeCode.Object:
                    return val;
                case TypeCode.UInt16:
                    return Convert.ToUInt16(val);
                case TypeCode.Int16:
                    return Convert.ToInt16(val);
                case TypeCode.UInt32:
                    return Convert.ToUInt32(val);
                case TypeCode.Int32:
                    return Convert.ToInt32(val);
                case TypeCode.UInt64:
                    return Convert.ToUInt64(val);
                case TypeCode.Int64:
                    return Convert.ToInt64(val);
                case TypeCode.Single:
                    return Convert.ToSingle(val);
                case TypeCode.Double:
                    return Convert.ToDouble(val);
                case TypeCode.DateTime:
                    return Convert.ToDateTime(val);
                case TypeCode.Decimal:
                    return Convert.ToDecimal(val);
                case TypeCode.Boolean:
                    return Convert.ToBoolean(val);
                case TypeCode.Byte:
                    return Convert.ToByte(val);
                default: return val;
            }
        }
    }
}
