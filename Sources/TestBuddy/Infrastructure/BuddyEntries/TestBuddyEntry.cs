using System.Threading.Tasks;
using Mmu.Wb.BuddyContainer.Contracts;

namespace Mmu.Wb.BuddyContainer.TestBuddy.Infrastructure.BuddyEntries
{
    public class TestBuddyEntry : IWindowsBuddyEntry
    {
        public string DisplayName { get; } = "Test Buddy";

        public Task ExecuteAsync()
        {
            var window = new MainWindow();
            window.Show();
            return Task.CompletedTask;
        }
    }
}