using Lamar;
using Mmu.Wb.BuddyContainer.Contracts;

namespace Mmu.Wb.BuddyContainer.WindowsTray.Infrastructure.DependencyInjcetion
{
    public class RegistryCollection : ServiceRegistry
    {
        public RegistryCollection()
        {
            Scan(
                scanner =>
                {
                    scanner.AssembliesAndExecutablesFromPath(@"C:\MyGit\Personal\WindowsBuddies\EncryptionBuddy\Mmu.Wb.EncryptionBuddy.Integration\bin\Debug\netcoreapp3.1");
                    scanner.AddAllTypesOf<IWindowsBuddyEntry>();
                });
        }
    }
}