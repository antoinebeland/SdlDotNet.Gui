using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Gui.Configuration;

namespace SdlDotNet.Gui.Control
{
    public class Label : Control, ILabel
    {
        private readonly LabelConfiguration _labelConfiguration;

        public Label(LabelConfiguration labelConfiguration, Point location)
            : base(CreateSurface(labelConfiguration), location)
        {
            _labelConfiguration = labelConfiguration;
        }

        public string Text
        {
            get { return _labelConfiguration.Text; }
            set
            {
                _labelConfiguration.Text = value;
                Surface = CreateSurface(_labelConfiguration);
            }
        }

        public string FontName
        {
            get { return _labelConfiguration.FontName; }
            set
            {
                _labelConfiguration.FontName = value;
                Surface = CreateSurface(_labelConfiguration);
            }

        }

        public int FontHeight
        {
            get { return _labelConfiguration.FontHeight; }
            set
            {
                _labelConfiguration.FontHeight = value;
                Surface = CreateSurface(_labelConfiguration);
            }
           
        }

        public Color ForeColor
        {
            get { return _labelConfiguration.ForeColor; }
            set
            {
                _labelConfiguration.ForeColor = value;
                Surface = CreateSurface(_labelConfiguration);
            }

        }

        private static Surface CreateSurface(LabelConfiguration labelConfiguration)
        {
            var surface = new Graphics.Font(labelConfiguration.FontName, labelConfiguration.FontHeight)
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

        public override Color BackColor
        {
            get { return _labelConfiguration.BackColor; }
            set
            {
                _labelConfiguration.BackColor = value;
                Surface = CreateSurface(_labelConfiguration);
            } 
            
        }
    }
}
