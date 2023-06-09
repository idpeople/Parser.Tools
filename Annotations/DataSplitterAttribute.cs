﻿using System;

namespace Parser.Tools.Annotations
{
    /// <summary>
    /// Data split value
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class DataSplitterAttribute : Attribute
    {
        /// <summary>
        /// Data splitter
        /// </summary>
        public string Splitter { get; private set; }
        public int MinNumberOfFields { get; private set; }
        public char[] UnwantedChars { get; private set; }
        public DataSplitterAttribute(string splitter, int minNumberOfFields=-1, char[] unWantedChars=null)
        {
            Splitter = splitter;
            MinNumberOfFields = minNumberOfFields;
            UnwantedChars = unWantedChars;
        }
    }
}
