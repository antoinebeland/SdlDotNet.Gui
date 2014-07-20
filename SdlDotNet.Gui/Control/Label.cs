using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Gui.Configurations;
using Font = SdlDotNet.Graphics.Font;

namespace SdlDotNet.Gui.Control
{
    /// <summary>
    ///     Represents a standard label.
    /// </summary>
    public sealed class Label : TextControl
    {
        /// <summary>
        ///     Initializes a new instance of the Label class.
        /// </summary>
        /// <param name="controlConfiguration">Configuration of the label</param>
        /// <param name="location">Location of the label</param>
        public Label(ControlConfiguration controlConfiguration, Point location)
            : base(location, controlConfiguration)
        {
            Surface = CreateSurface(controlConfiguration);
        }

        /// <summary>
        ///     Creates a new surface for the label.
        /// </summary>
        /// <param name="labelConfiguration">Configuration of the label</param>
        /// <returns>New surface representing the label</returns>
        protected override Surface CreateSurface(ControlConfiguration labelConfiguration)
        {
            Surface surface = new Font(labelConfiguration.FontName, labelConfiguration.FontHeight)
                .Render(labelConfiguration.Text, labelConfiguration.ForeColor, true);

            if (labelConfiguration.BackColor != Color.Transparent)
            {
                // TODO: Add background surface method into Control (static)...
                var backgroundSurface = new Surface(surface.Rectangle);
                backgroundSurface.Fill(labelConfiguration.BackColor);

                backgroundSurface.Blit(surface);

                return backgroundSurface;
            }

            return surface;
        }
    }
}