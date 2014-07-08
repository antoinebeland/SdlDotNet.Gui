using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Gui.Configuration;
using SdlDotNet.Gui.Control;
using System.Drawing;

namespace SdlDotNet.TestApplication
{
    static class Program
    {
        public static void Main(string[] args)
        {
            using (var video = Video.SetVideoMode(320, 240, 32, false, false, false, true))
            {
                Events.Quit += ApplicationQuitEventHandler;
                var labelConfiguration = new LabelConfiguration
                {
                    ForeColor = Color.White,
                    BackColor = Color.Transparent,
                    FontHeight = 16,
                    FontName = @"arial.ttf",
                    Text = "Hello world"
                };
                var label = new Label(labelConfiguration, new Point(0, 0));
                video.Blit(label);
                video.Update();
                Events.Run();
            }
        }

        private static void ApplicationQuitEventHandler( object sender, QuitEventArgs args )
        {
            Events.QuitApplication();
        }        
        
    }
}
