using System.IO.Abstractions;
using Lamar;

namespace Mmu.Wb.BuddyContainer.WindowsTray.Infrastructure.DependencyInjcetion
{
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