using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using JetBrains.Annotations;
using Mmu.Mlh.ApplicationExtensions.Areas.Dropbox.Services;
using Mmu.Mlh.LanguageExtensions.Areas.Types.Maybes;
using Mmu.Wb.BuddyContainer.WindowsTray.Areas.Models;

namespace Mmu.Wb.BuddyContainer.WindowsTray.Areas.Services.Servants.Implementation
{
    [UsedImplicitly]
    public class WindowsBuddyLocator : IWindowsBuddyLocator
    {
        private readonly IFileSystem _fileSystem;

        public WindowsBuddyLocator(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public IReadOnlyCollection<WindowsBuddyEntry> LocateBuddyEntries()
        {
            const string PasePath = "C:\\MatthiasStuff\\WindowsBuddies";
            var locatorFiles = _fileSystem.Directory.GetFiles(PasePath, "Locator.txt", SearchOption.AllDirectories);

            var buddyEntries = locatorFiles
                .Select(ParseLocatorFile)
                .OrderBy(f => f.DisplayName)
                .ToList();

            return buddyEntries;
        }

        private WindowsBuddyEntry ParseLocatorFile(string filePath)
        {
            var fileLines = _fileSystem.File.ReadAllLines(filePath);

            var displayName = fileLines[0];
            var executionPath = fileLines[1];
            var iconLetterValue = fileLines[2];

            var iconLetter = IconLetter.CreateByLetterValue(iconLetterValue);

            return new WindowsBuddyEntry(displayName, executionPath, iconLetter);
        }
    }
}