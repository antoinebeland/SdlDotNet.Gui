using System.Drawing;

namespace SdlDotNet.Gui.Control
{
    public interface ILabel
    {
        string Text { get; set; }
        string FontName { get; set; }
        int FontHeight { get; set; }
        Color ForeColor { get; set; }
    }
}
