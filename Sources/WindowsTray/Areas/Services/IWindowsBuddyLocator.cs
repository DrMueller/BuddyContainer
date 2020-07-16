using System.Collections.Generic;
using Mmu.Wb.BuddyContainer.Contracts;

namespace Mmu.Wb.BuddyContainer.WindowsTray.Areas.Services
{
    public interface IWindowsBuddyLocator
    {
        IReadOnlyCollection<IWindowsBuddyEntry> LocateBuddyEntries();
    }
}