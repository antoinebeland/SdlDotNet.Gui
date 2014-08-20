using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Primitives;
using Font = SdlDotNet.Graphics.Font;

namespace SdlDotNet.Gui.Control
{
    /// <summary>
    ///     Represents a standard label.
    /// </summary>
    public class Label : Control
    {
        /// <summary>
        ///     Initializes a new instance of the Label class.
        /// </summary>
        /// <param name="textConfiguration">Configuration of the label</param>
        /// <param name="location">Location of the label</param>
        public Label(TextConfiguration textConfiguration, Point location)
            : base(location, textConfiguration)
        {
            SetSurface();
        }

        /// <summary>
        ///     Creates a new surface for the label.
        /// </summary>
        /// <returns>New surface representing the label</returns>
        protected override sealed Surface CreateSurface()
        {
            var text = new Font(FontName, FontHeight).Render(Text, ForeColor, true);

            if (BackgroundImage == null && BackColor == Color.Transparent)
                return text;

            var surface = new Surface(text.Rectangle);
            if (BackgroundImage != null)
                surface.Blit(BackgroundImage);

            if (BackColor != Color.Transparent)
            {
                var box = new Box(new Point(), text.Size);
                box.Draw(surface, BackColor, true, true);
            }

            surface.Blit(text);
            return surface;
        }
    }
}