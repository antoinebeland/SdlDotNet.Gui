using System;
using System.Drawing;
using SdlDotNet.Graphics;

namespace SdlDotNet.Gui.Control
{
    public class Button : Control
    {
        public Button(TextConfiguration textConfiguration, Surface backgroundImage, Point location) 
            : base(backgroundImage, location)
        {
        
        }


        public Button(Size size, Point location)
            : base(new Surface(size), location)
        {
            
        }

        protected override Surface CreateSurface()
        {
            throw new NotImplementedException();
        }
    }
}
