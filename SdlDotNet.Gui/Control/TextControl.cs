using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Gui.Configurations;

namespace SdlDotNet.Gui.Control
{
    public abstract class TextControl : Control, ITextControl
    {
        protected readonly ControlConfiguration ControlConfiguration;

        protected TextControl(Point location, ControlConfiguration configuration) 
            : base(location)
        {
            ControlConfiguration = configuration;
        }

        // TODO: Add label contructor with 1 par.

        /// <summary>
        ///     Gets or sets the background color of the label.
        /// </summary>
        public override Color BackColor
        {
            get { return ControlConfiguration.BackColor; }
            set
            {
                ControlConfiguration.BackColor = value;
                Surface = CreateSurface(ControlConfiguration);
            }
        }

        /// <summary>
        ///     Gets or sets the text of the label.
        /// </summary>
        public string Text
        {
            get { return ControlConfiguration.Text; }
            set
            {
                ControlConfiguration.Text = value;
                Surface = CreateSurface(ControlConfiguration);
            }
        }

        /// <summary>
        ///     Gets or sets the font name of the label.
        /// </summary>
        public string FontName
        {
            get { return ControlConfiguration.FontName; }
            set
            {
                ControlConfiguration.FontName = value;
                Surface = CreateSurface(ControlConfiguration);
            }
        }

        /// <summary>
        ///     Gets or sets the font height of the label.
        /// </summary>
        public int FontHeight
        {
            get { return ControlConfiguration.FontHeight; }
            set
            {
                ControlConfiguration.FontHeight = value;
                Surface = CreateSurface(ControlConfiguration);
            }
        }

        /// <summary>
        ///     Gets or sets the fore color of the label.
        /// </summary>
        public Color ForeColor
        {
            get { return ControlConfiguration.ForeColor; }
            set
            {
                ControlConfiguration.ForeColor = value;
                Surface = CreateSurface(ControlConfiguration);
            }
        }
        
        protected abstract Surface CreateSurface(ControlConfiguration configuration);
    }
}
