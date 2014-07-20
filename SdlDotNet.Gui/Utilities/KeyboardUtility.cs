using SdlDotNet.Input;

namespace SdlDotNet.Gui.Utilities
{
    public static class KeyboardUtility
    {
        public static bool IsAlpha(Key key)
        {
            switch (key)
            {
                case Key.A:
                case Key.B:
                case Key.C:
                case Key.D:
                case Key.E:
                case Key.F:
                case Key.G:
                case Key.H:
                case Key.I:
                case Key.J:
                case Key.K:
                case Key.L:
                case Key.M:
                case Key.N:
                case Key.O:
                case Key.P:
                case Key.Q:
                case Key.R:
                case Key.S:
                case Key.T:
                case Key.U:
                case Key.V:
                case Key.W:
                case Key.X:
                case Key.Y:
                case Key.Z:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsNum(Key key)
        {
            switch (key)
            {
                case Key.Zero:
                case Key.One:
                case Key.Two:
                case Key.Three:
                case Key.Four:
                case Key.Five:
                case Key.Six:
                case Key.Seven:
                case Key.Eight:
                case Key.Nine:
                    return true;

                default:
                    return false;
            }
        }

        public static bool IsPunct(Key key)
        {
            // TODO: Implement this function.
            return false;
        }

        public static bool IsAlphaNum(Key key)
        {
            return IsAlpha(key) || IsNum(key);
        }

        public static bool IsAlphaNumPunct(Key key)
        {
            return IsAlphaNum(key) || IsPunct(key);
        }
    }
}
