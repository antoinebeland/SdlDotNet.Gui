using System;
using System.Drawing;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Input;
using Font = System.Drawing.Font;

namespace SdlDotNet.Gui.Control
{
    public class Button : Control, ITextControl
    {
        public Button(Size size, Point location)
            : base(new Surface(size), location)
        {
            Events.MouseButtonDown += ClickEvent;
        }

        private void ClickEvent(object sender, MouseButtonEventArgs e)
        {
            if(IsSelected(e.Position))
                Click.Invoke(sender, e);
        }

        public string Text { get; set; }
        public string FontName { get; set; }
        public int FontHeight { get; set; }
        public Color ForeColor { get; set; }
        public Font Font { get; set; }
        public override Color BackColor { get; set; }
        public event EventHandler Click;
    }
}
