using System;

namespace Parser.Tools.Annotations
{
    /// <summary>
    /// Tag based data attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class FieldTagAttribute : Attribute
    {
        /// <summary>
        /// Data start tag
        /// </summary>
        public string StartTag { get; private set; }
        /// <summary>
        /// Data end tag
        /// </summary>
        public string EndTag { get; private set; }

        public FieldTagAttribute(string startTag, string endTag)
        {
            StartTag = startTag;
            EndTag = endTag;
        }

    }
}
