using System.Collections.Generic;
using System.Linq;
using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.BuddyContainer.WindowsTray.Areas.Models
{
    public class IconLetter
    {
        private static readonly IReadOnlyCollection<IconLetter> _knownLetters = new List<IconLetter>
        {
            new IconLetter("E"),
            new IconLetter("S"),
            new IconLetter("T"),
            new IconLetter("X")
        };

        private IconLetter(string letterValue)
        {
            LetterValue = letterValue;
        }

        public string LetterValue { get; }

        public static IconLetter CreateByLetterValue(string letterValue)
        {
            var letter = _knownLetters.SingleOrDefault(f => f.LetterValue == letterValue);
            Guard.That(() => letter != null, $"Letter for value {letterValue} not implemented.");

            return letter;
        }
    }
}