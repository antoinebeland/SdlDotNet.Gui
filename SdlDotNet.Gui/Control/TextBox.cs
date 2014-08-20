using System;
using System.Drawing;
using System.Timers;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Gui.Utilities;
using SdlDotNet.Input;
using Font = SdlDotNet.Graphics.Font;
using Timer = System.Timers.Timer;

namespace SdlDotNet.Gui.Control
{
    public sealed class TextBox : Control
    {
        private readonly KeyboardListener _keyboardListener;
        private Size _fieldSize;
        private readonly Timer _timer;

        // TODO: Replace by: focused.
        private bool _displayFocusChar;
        private string _focusChar;

        public TextBox(Size fieldSize, Point location, TextConfiguration configuration) : 
            base(location, configuration)
        {
            _fieldSize = fieldSize;
            _displayFocusChar = false;
            _focusChar = "|";

            _timer = new Timer(500);
            _timer.Elapsed += TimerOnElapsed;

            _keyboardListener = new KeyboardListener();
            _keyboardListener.KeyboardEvent += KeyboardEvent;
            Events.MouseButtonDown += ClickEvent;

            BackColor = Color.White;
        }

        public Size FieldSize
        {
            get { return _fieldSize; }
            set
            {
                _fieldSize = value;
                SetSurface();
            }
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            _focusChar = (_displayFocusChar) ? "|" : String.Empty;
            _displayFocusChar = !_displayFocusChar;

            SetSurface();
        }

        private void ClickEvent(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            _keyboardListener.IsListening = IsSelected(mouseButtonEventArgs.Position);

            if (IsFocused && !_timer.Enabled)
            {
                _timer.Start();
                SetSurface();
            }
            else if(_timer.Enabled)
            {
                _timer.Stop();
                _displayFocusChar = false;
                _focusChar = "|";
                SetSurface();
            }
        }

        private void KeyboardEvent(object sender, string text)
        {
            Text = text;
        }

        protected override Surface CreateSurface()
        {
            Surface textSurface = new Font(FontName, FontHeight)
                .Render(Text, TextColor, true);

            // TODO: What whe doing in the case: Color.Transparent... 
            if (BackColor != Color.Transparent)
            {
                var backgroundSurface = new Surface(_fieldSize);
                backgroundSurface.Fill(BackColor);

                backgroundSurface.Blit(textSurface);

                if (IsFocused)
                {
                    var focusSurface = new Font(FontName, FontHeight)
                        .Render(_focusChar, TextColor, true);

                    backgroundSurface.Blit(focusSurface, new Point(textSurface.Width, 0));
                }

                return backgroundSurface;
            }

            return textSurface;
        }
    }
}
