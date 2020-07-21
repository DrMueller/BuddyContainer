using System.Drawing;
using System.IO.Abstractions;
using System.Windows;
using System.Windows.Forms;
using Lamar;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mlh.LanguageExtensions.Areas.Assemblies.Extensions;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;
using Mmu.Wb.BuddyContainer.WindowsTray.Areas.Services;

namespace Mmu.Wb.BuddyContainer.WindowsTray
{
    public partial class App
    {
        private IContainer _container;

        protected override void OnStartup(StartupEventArgs e)
        {
            var appAssembly = typeof(App).Assembly;

            var containerConfig = ContainerConfiguration.CreateFromAssembly(appAssembly);
            _container = ServiceProvisioningInitializer.CreateContainer(containerConfig);

            var fileSystem = _container.GetService<IFileSystem>();
            var assemblyBasePath = typeof(App).Assembly.GetBasePath();
            var iconPath = fileSystem.Path.Combine(assemblyBasePath, "Infrastructure", "Assets", "App.ico");

            var notifyIcon = new NotifyIcon
            {
                Text = "Windows Buddies",
                Icon = new Icon(iconPath),
                Visible = true,
            };

            var toolStripItemFactory = _container.GetService<IToolStripItemFactory>();
            var toolStripItems = toolStripItemFactory.CreateAll();

            notifyIcon.ContextMenuStrip = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip.Items.AddRange(toolStripItems);
        }
    }
}