using System.Drawing;
using SdlDotNet.Graphics;
using Font = System.Drawing.Font;

namespace SdlDotNet.Gui.Control
{
    public class Button : Control, ILabel
    {
        public Button(Size size, Point location)
            : base(new Surface(size), location)
        {
               
        }

        public string Text { get; set; }
        public string FontName { get; set; }
        public int FontHeight { get; set; }
        public Color ForeColor { get; set; }
        public Font Font { get; set; }
        public override Color BackColor { get; set; }
    }
}
