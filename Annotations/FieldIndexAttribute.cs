using System;

namespace Parser.Tools.Annotations
{
    /// <summary>
    /// Indexed field attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class FieldIndexAttribute : Attribute
    {
        /// <summary>
        /// Index in data
        /// </summary>
        public int Index { get; private set; }

        /// <summary>
        /// Unwanted characters
        /// </summary>
        public char[] UnwantedChars { get; private set; }
        public FieldIndexAttribute(int index, char[] unwantedChars=null)
        {
            Index = index;
            UnwantedChars = unwantedChars;
        }
    }
}
