using Mmu.Mlh.LanguageExtensions.Areas.Invariance;

namespace Mmu.Wb.BuddyContainer.WindowsTray.Areas.Models
{
    public class WindowsBuddyEntry
    {
        public WindowsBuddyEntry(string displayName, string executionPath)
        {
            Guard.StringNotNullOrEmpty(() => displayName);
            Guard.StringNotNullOrEmpty(() => executionPath);

            DisplayName = displayName;
            ExecutionPath = executionPath;
        }

        public string DisplayName { get; }

        public string ExecutionPath { get; }
    }
}