using System;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Gui.Configurations;
using SdlDotNet.Gui.Control;
using System.Drawing;

namespace SdlDotNet.TestApplication
{
    class Program : IDisposable
    {
        private readonly Surface _video;
        private readonly SpriteCollection _spriteCollection;

        public Program()
        {
            _video = Video.SetVideoMode(320, 240, 32, false, false, false, true);
            _spriteCollection = new SpriteCollection();
        }

        public void Initialization()
        {
            Events.Quit += ApplicationQuitEventHandler;
            Events.TargetFps = 30;
            Events.Tick += EventsOnTick;
            ControlConfiguration controlConfiguration = new ControlConfiguration
            {
                ForeColor = Color.Black,
                BackColor = Color.White,
                FontHeight = 24,
                FontName = @"arial.ttf",
                Text = "Hello world!",
            };

            var label = new Label(controlConfiguration, new Point(0, 0));
            var button = new Button(new Size(50, 50), new Point(50, 50));

            controlConfiguration.Text = "";

            var textBox = new TextBox(new Size(200, 25), new Point(100, 100), controlConfiguration);
            textBox.FieldSize = new Size(300, 25);

            button.Click += (sender, eventArgs) => Console.WriteLine("Click on the button!");
            button.Surface.Fill(Color.SteelBlue);

            _spriteCollection.Add(label);
            _spriteCollection.Add(button);
            _spriteCollection.Add(textBox);

            Events.Run();
        }

        private void EventsOnTick(object sender, TickEventArgs tickEventArgs)
        {
            _video.Fill(Color.Black);
            _video.Blit(_spriteCollection);
            _video.Update();
        }

        private void ApplicationQuitEventHandler( object sender, QuitEventArgs args )
        {
            Events.QuitApplication();
        }

        public void Dispose()
        {
            _video.Dispose();
        }

        public static void Main()
        {
            using (var program = new Program())
            {
                program.Initialization();
            }
        }
    }
}
