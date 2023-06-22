namespace Parser.Tools.Models
{

    internal class Track1ReplacementList : ReplacementList
    {
        public Track1ReplacementList()
        {
            this.Add(new ReplacementItem('Ø', '\\'));
            this.Add(new ReplacementItem('Æ', '['));
            this.Add(new ReplacementItem('Å', ']'));
            this.Add(new ReplacementItem('Ä', 'A'));
            this.Add(new ReplacementItem('Á', 'A'));
            this.Add(new ReplacementItem('Â', 'A'));
            this.Add(new ReplacementItem('À', 'A'));
            this.Add(new ReplacementItem('Ã', 'A'));
            this.Add(new ReplacementItem('Ă', 'A'));
            this.Add(new ReplacementItem('É', 'E'));
            this.Add(new ReplacementItem('È', 'E'));
            this.Add(new ReplacementItem('Ë', 'E'));
            this.Add(new ReplacementItem('Ê', 'E'));
            this.Add(new ReplacementItem('Ĕ', 'E'));
            this.Add(new ReplacementItem('Ē', 'E'));
            this.Add(new ReplacementItem('Ě', 'E'));
            this.Add(new ReplacementItem('\'', ' '));
            this.Add(new ReplacementItem('Þ', ' '));
            this.Add(new ReplacementItem('ß', ' '));
            this.Add(new ReplacementItem('Ó', 'O'));
            this.Add(new ReplacementItem('Ö', 'O'));
            this.Add(new ReplacementItem('Ò', 'O'));
            this.Add(new ReplacementItem('Ô', 'O'));
            this.Add(new ReplacementItem('Õ', 'O'));
            this.Add(new ReplacementItem('Ŏ', 'O'));
            this.Add(new ReplacementItem('Í', 'I'));
            this.Add(new ReplacementItem('Ï', 'I'));
            this.Add(new ReplacementItem('Î', 'I'));
            this.Add(new ReplacementItem('Ì', 'I'));
            this.Add(new ReplacementItem('İ', 'I'));
            this.Add(new ReplacementItem('Ĭ', 'I'));
            this.Add(new ReplacementItem('Ü', 'U'));
            this.Add(new ReplacementItem('Ú', 'U'));
            this.Add(new ReplacementItem('Ù', 'U'));
            this.Add(new ReplacementItem('Û', 'U'));
            this.Add(new ReplacementItem('Ý', 'Y'));
            this.Add(new ReplacementItem('Ÿ', 'Y'));
            this.Add(new ReplacementItem('Ð', 'D'));
            this.Add(new ReplacementItem('Đ', 'D'));
            this.Add(new ReplacementItem('Ď', 'D'));
            this.Add(new ReplacementItem('Ç', 'C'));
            this.Add(new ReplacementItem('Ć', 'C'));
            this.Add(new ReplacementItem('Č', 'C'));
            this.Add(new ReplacementItem('Š', 'S'));
            this.Add(new ReplacementItem('Ş', 'S'));
            this.Add(new ReplacementItem('Ž', 'Z'));
            this.Add(new ReplacementItem('Ź', 'Z'));
            this.Add(new ReplacementItem('Ñ', 'N'));
            this.Add(new ReplacementItem('Ĺ', 'L'));
            this.Add(new ReplacementItem('Ğ', 'G'));

        }
    }
}
