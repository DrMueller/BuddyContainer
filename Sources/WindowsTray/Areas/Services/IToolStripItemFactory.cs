using System.Windows.Forms;

namespace Mmu.Wb.BuddyContainer.WindowsTray.Areas.Services
{
    public interface IToolStripItemFactory
    {
        ToolStripItem[] CreateAll();
    }
}