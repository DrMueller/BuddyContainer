using System.Collections.Generic;
using Mmu.Wb.BuddyContainer.WindowsTray.Areas.Models;

namespace Mmu.Wb.BuddyContainer.WindowsTray.Areas.Services
{
    public interface IWindowsBuddyLocator
    {
        IReadOnlyCollection<WindowsBuddyEntry> LocateBuddyEntries();
    }
}