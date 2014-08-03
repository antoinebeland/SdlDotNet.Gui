using System;
using System.Drawing;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Gui.Configurations;
using SdlDotNet.Input;
using Font = System.Drawing.Font;

namespace SdlDotNet.Gui.Control
{
    public class Button : Control
    {
        public Button(Size size, Point location)
            : base(new Surface(size), location)
        {
            
        }



        protected override Surface CreateSurface(ControlConfiguration configuration)
        {
            throw new NotImplementedException();
        }
        
    }
}
