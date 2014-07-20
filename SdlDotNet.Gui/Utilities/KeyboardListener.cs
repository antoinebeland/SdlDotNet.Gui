using System;
using SdlDotNet.Core;
using SdlDotNet.Input;

namespace SdlDotNet.Gui.Utilities
{
    public class KeyboardListener
    {
        public KeyboardListener()
        {   
            IsListening = false;
            Text = String.Empty;
            
            Events.KeyboardDown += KeyboardDown;
            Events.KeyboardUp += KeyboardUp;
        }

        public event KeyboardEvent KeyboardEvent;

        public bool IsListening { get; set; }

        public string Text { get; private set; }

        private void KeyboardDown(object sender, KeyboardEventArgs keyboardEventArgs)
        {
            if (!IsListening)
                return;

            KeyboardDispatcher(keyboardEventArgs);
            KeyboardEvent.Invoke(this, Text);
        }

        private void KeyboardUp(object sender, KeyboardEventArgs e)
        {
            
        }

        private void KeyboardDispatcher(KeyboardEventArgs keyboardEvent)
        {
            switch (keyboardEvent.Key)
            {
                case Key.Backspace:
                    Backspace();
                    break;

                case Key.Space:
                    Text += " ";
                    break;
            }

            if (KeyboardUtility.IsAlphaNumPunct(keyboardEvent.Key))
                Text += keyboardEvent.KeyboardCharacter;
        }

        private void Backspace()
        {
            if (Text == String.Empty)
                return;

            Text = Text.Length == 1 ? String.Empty : Text.Remove(Text.Length - 1);
        }
    }

    public delegate void KeyboardEvent(object sender, string text);
}