using System.Drawing;
using SdlDotNet.Graphics;

namespace SdlDotNet.Gui.Control
{
    public class ProgressBar : Control
    {
        public ProgressBar(Surface surface, Point location) : base(surface, location)
        {

        }

        public uint Value { get; set; }
        public override Color BackColor { get; set; }
    }
}
