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
            get { return _labelConfiguration.Color; }
            set
            {
                _labelConfiguration.Color = value;
                Surface = CreateSurface(_labelConfiguration);
            }

        }

        private static Surface CreateSurface(LabelConfiguration labelConfiguration)
        {
            return new Graphics.Font(labelConfiguration.FontName, labelConfiguration.FontHeight)
                .Render(labelConfiguration.Text, labelConfiguration.Color, true);
        }
    }
}
