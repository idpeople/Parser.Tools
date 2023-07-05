using System;

namespace Parser.Tools.Annotations
{
    /// <summary>
    /// Unwanted characters attribute for class
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class UnwantedCharsAttribute : Attribute
    {
        /// <summary>
        /// Array of unwanted characters
        /// </summary>
        public char[] UnwantedChars { get; private set; }

        public UnwantedCharsAttribute(char[] unwantedChars)
        {
            UnwantedChars = unwantedChars;
        }
    }
}
