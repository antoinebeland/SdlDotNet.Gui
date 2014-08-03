using System;
using System.Drawing;
using System.Timers;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Gui.Configurations;
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

        public TextBox(Size fieldSize, Point location, ControlConfiguration configuration) : 
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

            SetSurface(ControlConfiguration);
        }

        public Size FieldSize
        {
            get { return _fieldSize; }
            set
            {
                _fieldSize = value;
                SetSurface(ControlConfiguration);
            }
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            _focusChar = (_displayFocusChar) ? "|" : String.Empty;
            _displayFocusChar = !_displayFocusChar;

            SetSurface(ControlConfiguration);
        }

        private void ClickEvent(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            _keyboardListener.IsListening = IsSelected(mouseButtonEventArgs.Position);

            if (Focused && !_timer.Enabled)
            {
                _timer.Start();
                SetSurface(ControlConfiguration);
            }
            else if(_timer.Enabled)
            {
                _timer.Stop();
                _displayFocusChar = false;
                _focusChar = "|";
                SetSurface(ControlConfiguration);
            }
        }

        private void KeyboardEvent(object sender, string text)
        {
            Text = text;
        }

        protected override Surface CreateSurface(ControlConfiguration configuration)
        {
            Surface textSurface = new Font(configuration.FontName, configuration.FontHeight)
                .Render(configuration.Text, configuration.ForeColor, true);

            // TODO: What whe doing in the case: Color.Transparent... 
            if (configuration.BackColor != Color.Transparent)
            {
                var backgroundSurface = new Surface(_fieldSize);
                backgroundSurface.Fill(configuration.BackColor);

                backgroundSurface.Blit(textSurface);

                if (Focused)
                {
                    var focusSurface = new Font(configuration.FontName, configuration.FontHeight)
                        .Render(_focusChar, configuration.ForeColor, true);

                    backgroundSurface.Blit(focusSurface, new Point(textSurface.Width, 0));
                }

                return backgroundSurface;
            }

            return textSurface;
            
        }
    }
}
