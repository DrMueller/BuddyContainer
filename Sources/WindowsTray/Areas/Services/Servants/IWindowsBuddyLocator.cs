using System.Collections.Generic;
using Mmu.Wb.BuddyContainer.WindowsTray.Areas.Models;

namespace Mmu.Wb.BuddyContainer.WindowsTray.Areas.Services.Servants
{
    public interface IWindowsBuddyLocator
    {
        IReadOnlyCollection<WindowsBuddyEntry> LocateBuddyEntries();
    }
}