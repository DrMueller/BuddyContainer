using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.BuddyContainer.WindowsTray.Areas.Models
{
    public class WindowsBuddyEntry
    {
        public WindowsBuddyEntry(string displayName, string executionPath, IconLetter iconLetter)
        {
            Guard.StringNotNullOrEmpty(() => displayName);
            Guard.StringNotNullOrEmpty(() => executionPath);
            Guard.ObjectNotNull(() => iconLetter);

            DisplayName = displayName;
            ExecutionPath = executionPath;
            IconLetter = iconLetter;
        }

        public string DisplayName { get; }
        public string ExecutionPath { get; }
        public IconLetter IconLetter { get; }
    }
}