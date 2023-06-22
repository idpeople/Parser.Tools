namespace Parser.Tools.Models
{
    internal class ReplacementItem
    {
        public ReplacementItem(){ }
        public ReplacementItem(char searchChar, char replaceChar) 
        {
            SearchChar = searchChar;
            ReplaceChar = replaceChar;
        }
        public char SearchChar { get; set; }
        public char ReplaceChar { get; set; }
    }
}
