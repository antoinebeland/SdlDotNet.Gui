using System;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Gui.Control;
using System.Drawing;

namespace TestApplication
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
            var controlConfiguration = new TextConfiguration
            {
                ForeColor = Color.Black,
                FontHeight = 24,
                FontName = @"arial.ttf",
                Text = "Hello world!",
            };

            var label = new Label(controlConfiguration, new Point(0, 0));
            label.BackColor = Color.FromArgb(200, Color.White);
            label.BackgroundImage = new Surface(Resources.Surface);
            label.Click += (sender, args) => Console.WriteLine(@"Label clicked!");

            var button = new Button(new Size(50, 50), new Point(50, 50));

            controlConfiguration.Text = "";

            var textBox = new TextBox(new Size(200, 25), new Point(100, 100), controlConfiguration)
            {
                FieldSize = new Size(300, 25)
            };
            textBox.GotFocus += (sender, args) => Console.WriteLine(@"Textbox focus got!");
            textBox.LostFocus += (sender, args) => Console.WriteLine(@"Textbox focus lost!");


            button.Click += (sender, eventArgs) => Console.WriteLine(@"Click on the button!");
            button.MouseEnter += (sender, args) => Console.WriteLine(@"Mouse entered on the button!");
            button.MouseHover += (sender, args) => Console.WriteLine(@"Mouse hover the button!");
            button.MouseLeave += (sender, args) => Console.WriteLine(@"Mouse left the button!");
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
            GC.SuppressFinalize(this);
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
