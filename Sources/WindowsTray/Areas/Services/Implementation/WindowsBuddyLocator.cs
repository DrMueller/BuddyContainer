using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Reflection;
using Mmu.Wb.BuddyContainer.Contracts;

namespace Mmu.Wb.BuddyContainer.WindowsTray.Areas.Services.Implementation
{
    public class WindowsBuddyLocator : IWindowsBuddyLocator
    {
        private readonly IFileSystem _fileSystem;

        public WindowsBuddyLocator(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public IReadOnlyCollection<IWindowsBuddyEntry> LocateBuddyEntries()
        {
            var allDlls = _fileSystem.Directory.GetFiles(@"C:\MyGit\Personal\WindowsBuddies\EncryptionBuddy\Mmu.Wb.EncryptionBuddy.Integration\bin\Debug\netcoreapp3.1", "*.dll", SearchOption.AllDirectories);

            var buddyEntryType = typeof(IWindowsBuddyEntry);

            var entries = new List<IWindowsBuddyEntry>();

            foreach (var dll in allDlls)
            {
                try
                {
                    var assembly = Assembly.LoadFile(dll);

                    if (dll.Contains(@"Mmu.Wb.EncryptionBuddy"))
                    {
                        Debugger.Break();
                        var types = assembly.GetTypes().First();

                        var tra = types == buddyEntryType;
                    }


                    var buddyType = assembly.GetTypes().FirstOrDefault(f => f == buddyEntryType);

                    if (buddyType != null)
                    {
                        var instance = (IWindowsBuddyEntry)Activator.CreateInstance(buddyType);
                        entries.Add(instance);
                    }
                }

                catch (Exception ex)
                {
                    // Best effort
                }
            }

            return entries;
        }
    }
}