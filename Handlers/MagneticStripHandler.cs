using Parser.Tools.Models;
using System.Linq;

namespace Parser.Tools.Handlers
{
    /// <summary>
    /// Handle magneticstrip data
    /// </summary>
    public class MagneticStripHandler
    {
        private const string _AllowedTrack1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 !#$%'()*+,-./;:<>=^]\\[\"&_";
        private const int _maxLengthTrack1 = 76;
        private const string _AllowedTrack2 = "0123456789:;<=>";
        private const int _maxLengthTrack2 = 37;
        private const string _AllowedTrack3 = "0123456789:;<=>";
        private const int _maxLengthTrack3 = 104;

        /// <summary>
        /// Data validation
        /// </summary>
        /// <param name="track">Track data</param>
        /// <param name="_allowed">Allowed characters</param>
        /// <param name="maxLength">Max track length</param>
        /// <returns></returns>
        private bool Validator(string track, string _allowed, int maxLength)
        {
            if(track.Length > maxLength) return false;
            foreach(var ch in track)
            {
                if (!_allowed.Contains<char>(ch)) return false;
            }
            return true;
        }

        /// <summary>
        /// Check if character is valid
        /// </summary>
        /// <param name="ch">Character</param>
        /// <param name="allowed">Allowed characters</param>
        /// <returns>boolean</returns>
        private bool IsCharValid(char ch, string allowed)
            => allowed.Contains<char>(ch);

        /// <summary>
        /// Check if track1 data is valid
        /// </summary>
        /// <param name="track1">Track data</param>
        /// <param name="caseSensitive">Use case sensitivity</param>
        /// <returns>boolean</returns>
        public bool IsTrack1Valid(string track1, bool caseSensitive=false)
            => Validator(caseSensitive ? track1 : track1.ToUpper(), _AllowedTrack1, _maxLengthTrack1);

        /// <summary>
        /// Check if track2 data is valid
        /// </summary>
        /// <param name="track2">Track data</param>
        /// <returns>boolean</returns>
        public bool IsTrack2Valid(string track2)
            => Validator(track2, _AllowedTrack2, _maxLengthTrack2);

        /// <summary>
        /// Check if track3 data is valis
        /// </summary>
        /// <param name="track3">Track data</param>
        /// <returns>boolean</returns>
        public bool IsTrack3Valid(string track3)
            => Validator(track3, _AllowedTrack3, _maxLengthTrack3);

        /// <summary>
        /// Fix data characters in track1 data
        /// </summary>
        /// <param name="track1">track1 data</param>
        /// <param name="fixedTrack1">Fixed track data</param>
        /// <returns>boolean</returns>
        public bool FixTrack1DataToDanishHealthFormat(string track1, out string fixedTrack1)
        {
            fixedTrack1 = string.Empty;
            if(track1.Length > _maxLengthTrack1) return false;
            track1 = track1.ToUpper();
            if (IsTrack1Valid(track1))
            {
                fixedTrack1 = track1;
                return true;
            }
            var replaceList = new Track1ReplacementList();
            foreach(var ch in track1)
            {
                if(IsCharValid(ch, _AllowedTrack1))
                {
                    fixedTrack1 += ch;
                    continue;
                }

                var replaceItem = replaceList.FirstOrDefault(x=> x.SearchChar == ch);
                fixedTrack1 += replaceItem is null ? ' ' : replaceItem.ReplaceChar;
            }
            return true;
        }
    }
}
