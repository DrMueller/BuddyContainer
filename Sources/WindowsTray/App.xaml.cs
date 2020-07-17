using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using Lamar;
using Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using Mmu.Wb.BuddyContainer.WindowsTray.Areas.Models;
using Mmu.Wb.BuddyContainer.WindowsTray.Areas.Services;

namespace Mmu.Wb.BuddyContainer.WindowsTray
{
    public partial class App
    {
        private IContainer _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(typeof(App).Assembly);
            _container = ServiceProvisioningInitializer.CreateContainer(containerConfig);

            var assemblyBasePath = typeof(App).Assembly.GetBasePath();
            var iconPath = Path.Combine(assemblyBasePath, "Infrastructure", "Assets", "App.ico");

            var notifyIcon = new NotifyIcon
            {
                Text = "Windows Buddies",
                Icon = new Icon(iconPath),
                Visible = true,
            };

            InitializeBuddyEntries(notifyIcon);
        }

        private static ToolStripItem CreateMenuItem(WindowsBuddyEntry buddyEntry)
        {
            var menuItem = new ToolStripMenuItem(buddyEntry.DisplayName);
            menuItem.Click += (sender, e) => Process.Start(buddyEntry.ExecutionPath);

            return menuItem;
        }

        private void InitializeBuddyEntries(NotifyIcon notifyIcon)
        {
            var locator = _container.GetInstance<IWindowsBuddyLocator>();

            var buddyEntries = locator.LocateBuddyEntries();
            var menuItems = buddyEntries.Select(CreateMenuItem).ToArray();

            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.AddRange(menuItems);
        }
    }
}