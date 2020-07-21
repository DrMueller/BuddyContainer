using System.IO.Abstractions;
using JetBrains.Annotations;
using Lamar;

namespace Mmu.Wb.BuddyContainer.WindowsTray.Infrastructure.DependencyInjcetion
{
    [UsedImplicitly]
    public class WindowsTrayServiceRegistryCollection : ServiceRegistry
    {
        public WindowsTrayServiceRegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<WindowsTrayServiceRegistryCollection>();
                    scanner.WithDefaultConventions();
                });

            For<IFileSystem>().Use<FileSystem>();
        }
    }
}