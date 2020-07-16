using JetBrains.Annotations;
using Lamar;
using Mmu.Wb.BuddyContainer.Contracts;
using Mmu.Wb.BuddyContainer.TestBuddy.Infrastructure.BuddyEntries;

namespace Mmu.Wb.BuddyContainer.TestBuddy.Infrastructure.DependencyInjection
{
    [UsedImplicitly]
    public class TestBuddyServiceRegistryCollection : ServiceRegistry
    {
        public TestBuddyServiceRegistryCollection()
        {
            For<IWindowsBuddyEntry>().Use<TestBuddyEntry>();
        }
    }
}