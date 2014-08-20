using System;
using System.Drawing;
using SdlDotNet.Graphics;

namespace SdlDotNet.Gui.Control
{
    public class ProgressBar : Control
    {
        private Color _foreColor;
        private uint _value;

        public ProgressBar(Surface surface, Point location) : base(surface, location)
        {
            // TODO: Put this values into constant
            Minimum = 0;
            Maximum = 100;
        }

        /// <summary>
        ///     Gets or sets the minimum value of the progress bar.
        /// </summary>
        public uint Minimum { get; set; }

        /// <summary>
        ///     Gets or sets the maximum value of the progress bar.
        /// </summary>
        public uint Maximum { get; set; }

        /// <summary>
        ///     Gets or sets the amount by which a call to the PerformStep method increases
        ///     the current value of the progress bar.
        /// </summary>
        public int Step { get; set; }

        /// <summary>
        ///     Gets or sets the value of the progress bar.
        /// </summary>
        public uint Value
        {
            get { return _value; }
            set
            {
                if (value > Maximum)
                    throw new ArgumentException("The value specified is greater than the value of " +
                                                "the Maximum property.");

                if (value < Minimum)
                    throw new ArgumentException("The value specified is less than the value of " +
                                                "the Minimum property.");

                _value = value;
                Text = _value + "%";
            }
        }

        // TODO: Add display format for the value.

        /// <summary>
        ///     Gets or sets the fore color of the progress bar.
        /// </summary>
        public Color ForeColor
        {
            get { return _foreColor; }
            set
            {
                _foreColor = value;
                SetSurface();
            }
        }

        public void PerformStep()
        {
        
        }

        protected override Surface CreateSurface()
        {
            return null;
        }
    }
}