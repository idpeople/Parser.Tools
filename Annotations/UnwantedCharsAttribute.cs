using System;

namespace Parser.Tools.Annotations
{
    /// <summary>
    /// Unwanted characters attribute for class
    /// </summary>
    public sealed class UnwantedCharsAttribute : Attribute
    {
        /// <summary>
        /// Array of unwanted characters
        /// </summary>
        public char[] UnwantedChars { get; private set; }
        public string Replacement { get; private set; }
        public UnwantedCharsAttribute(char[] unwantedChars, string replacement="")
        {
            UnwantedChars = unwantedChars;
            Replacement = replacement;
        }
    }
}
