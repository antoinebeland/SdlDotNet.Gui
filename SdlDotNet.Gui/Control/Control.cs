using System.Drawing;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;

namespace SdlDotNet.Gui.Control
{
    public abstract class Control : Sprite, IControl
    {
        protected Control(Point location)
            : base(new Surface(new Size()), location)
        {

        }

        protected Control(Surface surface, Point location)
            : base(surface, location)
        {

        }

        /// <summary>
        ///     Gets or sets if the control is visible.
        /// </summary>
        public new bool Visible
        {
            get { return base.Visible; }
            set { base.Visible = value; }
        }

        /// <summary>
        ///     Gets or sets if the control is enabled.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the location of the control.
        /// </summary>
        public Point Location
        {
            get { return Position; }
            set { Position = value; }
        }

        /// <summary>
        ///     Gets or sets the background color of the control.
        /// </summary>
        public abstract Color BackColor { get; set; }

        public bool Focused { get; private set; }

        protected bool IsSelected(Point position)
        {
            return Focused = Rectangle.Contains(position);
        }
    }
}