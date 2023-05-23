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

        public FieldIndexAttribute(int index)
        {
            Index = index;
        }
    }
}
