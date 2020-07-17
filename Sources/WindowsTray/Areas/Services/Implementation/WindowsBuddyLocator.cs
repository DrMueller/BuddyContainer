using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using Mmu.Mlh.ApplicationExtensions.Areas.Dropbox.Services;
using Mmu.Wb.BuddyContainer.WindowsTray.Areas.Models;

namespace Mmu.Wb.BuddyContainer.WindowsTray.Areas.Services.Implementation
{
    public class WindowsBuddyLocator : IWindowsBuddyLocator
    {
        private readonly IDropboxLocator _dropboxLocator;
        private readonly IFileSystem _fileSystem;

        public WindowsBuddyLocator(IFileSystem fileSystem, IDropboxLocator dropboxLocator)
        {
            _fileSystem = fileSystem;
            _dropboxLocator = dropboxLocator;
        }

        public IReadOnlyCollection<WindowsBuddyEntry> LocateBuddyEntries()
        {
            var dropboxPath = _dropboxLocator.LocateDropboxPath().Reduce(() => throw new NotSupportedException("Dropbox path not found"));
            var locatorFiles = _fileSystem.Directory.GetFiles(dropboxPath, "Locator.txt", SearchOption.AllDirectories);

            var buddyEntries = locatorFiles
                .Select(ParseLocatorFile)
                .OrderBy(f => f.DisplayName)
                .ToList();

            return buddyEntries;
        }

        private WindowsBuddyEntry ParseLocatorFile(string filePath)
        {
            var fileLines = _fileSystem.File.ReadAllLines(filePath);

            return new WindowsBuddyEntry(fileLines[0], fileLines[1]);
        }
    }
}