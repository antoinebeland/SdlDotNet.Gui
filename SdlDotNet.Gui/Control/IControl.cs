using System.Drawing;

namespace SdlDotNet.Gui.Control
{
    /// <summary>
    ///     Defines the base of a control.
    /// </summary>
    public interface IControl
    {
        /// <summary>
        ///     Gets or sets if the control is visible.
        /// </summary>
        bool Visible { get; set; }

        /// <summary>
        ///     Gets or sets if the control is enabled.
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the height of the control.
        /// </summary>
        int Height { get; set; }

        /// <summary>
        ///     Gets or sets the width of the control.
        /// </summary>
        int Width { get; set; }

        /// <summary>
        ///     Gets or sets the location of the control.
        /// </summary>
        Point Location { get; set; }

        /// <summary>
        ///     Gets or sets the background color of the control.
        /// </summary>
        Color BackColor { get; set; }

        /// <summary>
        ///     Gets or sets the text of the control.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        ///     Gets or sets the font name of the control.
        /// </summary>
        string FontName { get; set; }

        /// <summary>
        ///     Gets or sets the font height of the control.
        /// </summary>
        int FontHeight { get; set; }

        /// <summary>
        ///     Gets or sets the text color of the control.
        /// </summary>
        Color TextColor { get; set; }
    }
}