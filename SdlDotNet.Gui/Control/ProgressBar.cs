using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Gui.Configurations;

namespace SdlDotNet.Gui.Control
{
    public class ProgressBar : Control
    {
        public ProgressBar(Surface surface, Point location) : base(surface, location)
        {

        }

        public uint Value { get; set; }

        protected override Surface CreateSurface(ControlConfiguration configuration)
        {
            throw new System.NotImplementedException();
        }
    }
}
