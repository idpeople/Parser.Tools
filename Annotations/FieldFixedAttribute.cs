
using System;

namespace Parser.Tools.Annotations
{
    /// <summary>
    /// Fixed field length attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class FieldFixedAttribute : Attribute
    {
        /// <summary>
        /// Offset position in data
        /// </summary>
        public int Offset { get; private set; }
        /// <summary>
        /// Size of data to extract
        /// </summary>
        public int Size { get; private set; }

        /// <summary>
        /// Trim field on load
        /// </summary>
        public bool Trim { get; private set; }
        
        /// <summary>
        /// Unwanted characters
        /// </summary>
        public char[] UnwantedChars { get; private set; }
        public FieldFixedAttribute(int offset, int size, bool trim = false, char[] unwantedChars = null)
        {
            Offset = offset;
            Size = size;
            Trim = trim;
            UnwantedChars = unwantedChars;
        }
    }
}
