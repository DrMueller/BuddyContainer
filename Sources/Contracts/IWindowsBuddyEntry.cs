using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Mmu.Wb.BuddyContainer.Contracts
{
    [PublicAPI]
    public interface IWindowsBuddyEntry
    {
        string DisplayName { get; }

        Task ExecuteAsync();
    }
}