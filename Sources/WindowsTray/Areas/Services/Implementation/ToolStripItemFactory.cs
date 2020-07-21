using System.Diagnostics;
using System.Drawing;
using System.IO.Abstractions;
using System.Linq;
using System.Windows.Forms;
using JetBrains.Annotations;
using Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions;
using Mmu.Wb.BuddyContainer.WindowsTray.Areas.Models;
using Mmu.Wb.BuddyContainer.WindowsTray.Areas.Services.Servants;

namespace Mmu.Wb.BuddyContainer.WindowsTray.Areas.Services.Implementation
{
    [UsedImplicitly]
    public class ToolStripItemFactory : IToolStripItemFactory
    {
        private readonly IFileSystem _fileSystem;
        private readonly IWindowsBuddyLocator _windowsBuddyLocator;

        public ToolStripItemFactory(IWindowsBuddyLocator windowsBuddyLocator, IFileSystem fileSystem)
        {
            _windowsBuddyLocator = windowsBuddyLocator;
            _fileSystem = fileSystem;
        }

        public ToolStripItem[] CreateAll()
        {
            var buddyEntries = _windowsBuddyLocator.LocateBuddyEntries();
            var menuItems = buddyEntries.Select(CreateMenuItem).ToArray();

            return menuItems;
        }

        private ToolStripItem CreateMenuItem(WindowsBuddyEntry buddyEntry)
        {
            var assemblyBasePath = typeof(App).Assembly.GetBasePath();
            var iconPath = _fileSystem.Path.Combine(assemblyBasePath, "Infrastructure", "Assets", $"{buddyEntry.IconLetter.LetterValue}.PNG");
            var menuItem = new ToolStripMenuItem(buddyEntry.DisplayName, new Bitmap(iconPath));

            menuItem.Click += (sender, e) => Process.Start(buddyEntry.ExecutionPath);

            return menuItem;
        }
    }
}