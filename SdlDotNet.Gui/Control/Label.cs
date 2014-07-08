using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Gui.Configuration;
using Font = SdlDotNet.Graphics.Font;

namespace SdlDotNet.Gui.Control
{
    /// <summary>
    ///     Represents a standard label.
    /// </summary>
    public class Label : Control, ILabel
    {
        private readonly LabelConfiguration _labelConfiguration;

        /// <summary>
        ///     Initializes a new instance of the Label class.
        /// </summary>
        /// <param name="labelConfiguration">Configuration of the label</param>
        /// <param name="location">Location of the label</param>
        public Label(LabelConfiguration labelConfiguration, Point location)
            : base(CreateSurface(labelConfiguration), location)
        {
            _labelConfiguration = labelConfiguration;
        }

        /// <summary>
        ///     Gets or sets the background color of the label.
        /// </summary>
        public override Color BackColor
        {
            get { return _labelConfiguration.BackColor; }
            set
            {
                _labelConfiguration.BackColor = value;
                Surface = CreateSurface(_labelConfiguration);
            }
        }

        /// <summary>
        ///     Gets or sets the text of the label.
        /// </summary>
        public string Text
        {
            get { return _labelConfiguration.Text; }
            set
            {
                _labelConfiguration.Text = value;
                Surface = CreateSurface(_labelConfiguration);
            }
        }

        /// <summary>
        ///     Gets or sets the font name of the label.
        /// </summary>
        public string FontName
        {
            get { return _labelConfiguration.FontName; }
            set
            {
                _labelConfiguration.FontName = value;
                Surface = CreateSurface(_labelConfiguration);
            }
        }

        /// <summary>
        ///     Gets or sets the font height of the label.
        /// </summary>
        public int FontHeight
        {
            get { return _labelConfiguration.FontHeight; }
            set
            {
                _labelConfiguration.FontHeight = value;
                Surface = CreateSurface(_labelConfiguration);
            }
        }

        /// <summary>
        ///     Gets or sets the fore color of the label.
        /// </summary>
        public Color ForeColor
        {
            get { return _labelConfiguration.ForeColor; }
            set
            {
                _labelConfiguration.ForeColor = value;
                Surface = CreateSurface(_labelConfiguration);
            }
        }

        /// <summary>
        ///     Creates a new surface for the label.
        /// </summary>
        /// <param name="labelConfiguration">Configuration of the label</param>
        /// <returns>New surface representing the label</returns>
        private static Surface CreateSurface(LabelConfiguration labelConfiguration)
        {
            Surface surface = new Font(labelConfiguration.FontName, labelConfiguration.FontHeight)
                .Render(labelConfiguration.Text, labelConfiguration.ForeColor, true);

            if (labelConfiguration.BackColor != Color.Transparent)
            {
                var backgroundSurface = new Surface(surface.Rectangle);
                backgroundSurface.Fill(labelConfiguration.BackColor);

                backgroundSurface.Blit(surface);

                return backgroundSurface;
            }

            return surface;
        }
    }
}