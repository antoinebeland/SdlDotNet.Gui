using System;
using System.Drawing;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Input;

namespace SdlDotNet.Gui.Control
{
    /// <summary>
    ///     Defines the base class for controls.
    /// </summary>
    public abstract class Control : Sprite, IControl
    {
        private readonly object _surfaceLock = new object();
        private readonly TextConfiguration _textConfiguration;
        private Color _backColor;
        private Surface _backgroundImage;

        private bool _isFocused;
        private bool _isHovered;

        protected Control(Point location, TextConfiguration textConfiguration)
            : this(location)
        {
            _textConfiguration = textConfiguration;
            _backColor = Color.Transparent;
            _backgroundImage = null;
        }

        protected Control(Point location)
            : this(new Surface(new Size()), location)
        {
        }

        protected Control(Surface surface, Point location)
            : base(surface, location)
        {
            Events.MouseButtonDown += OnMouseClick;
            Events.MouseMotion += OnMouseMotion;
            // TODO: Subscribe to MouseHover event.
        }

        /// <summary>
        ///     Gets and sets the surface of the sprite.
        /// </summary>
        /// <remarks>Threading safe implementation.</remarks>
        public override Surface Surface
        {
            get
            {
                lock (_surfaceLock)
                {
                    return base.Surface;
                }
            }
            set { base.Surface = value; }
        }

        /// <summary>
        ///     Indicates if the control is focused.
        /// </summary>
        public bool IsFocused
        {
            get { return _isFocused; }

            private set
            {
                if (value != _isFocused)
                    InvokeEvent(value ? GotFocus : LostFocus, this, EventArgs.Empty);

                _isFocused = value;
            }
        }

        /// <summary>
        ///     Gets or sets the background image of the control.
        /// </summary>
        public Surface BackgroundImage
        {
            get { return _backgroundImage; }
            set
            {
                _backgroundImage = value;
                SetSurface();
            }
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
        ///     Gets or sets the background color of the label.
        /// </summary>
        public Color BackColor
        {
            get { return _backColor; }
            set
            {
                _backColor = value;
                SetSurface();
            }
        }

        /// <summary>
        ///     Gets or sets the text of the control.
        /// </summary>
        public string Text
        {
            get { return _textConfiguration.Text; }
            set
            {
                _textConfiguration.Text = value;
                SetSurface();
            }
        }

        /// <summary>
        ///     Gets or sets the font name of the control.
        /// </summary>
        public string FontName
        {
            get { return _textConfiguration.FontName; }
            set
            {
                _textConfiguration.FontName = value;
                SetSurface();
            }
        }

        /// <summary>
        ///     Gets or sets the font height of the control.
        /// </summary>
        public int FontHeight
        {
            get { return _textConfiguration.FontHeight; }
            set
            {
                _textConfiguration.FontHeight = value;
                SetSurface();
            }
        }

        /// <summary>
        ///     Gets or sets the text color of the control.
        /// </summary>
        public Color TextColor
        {
            get { return _textConfiguration.TextColor; }
            set
            {
                _textConfiguration.TextColor = value;
                SetSurface();
            }
        }

        /// <summary>
        ///     Occurs when the control is clicked.
        /// </summary>
        public event EventHandler Click;

        /// <summary>
        ///     Occurs when the control got focus.
        /// </summary>
        public event EventHandler GotFocus;

        /// <summary>
        ///     Occus when the control lost focus.
        /// </summary>
        public event EventHandler LostFocus;

        /// <summary>
        ///     Occurs when the mouse pointer enters the control.
        /// </summary>
        public event EventHandler MouseEnter;

        /// <summary>
        ///     Occurs when the mouse pointer rests on the control.
        /// </summary>
        public event EventHandler MouseHover;

        /// <summary>
        ///     Occurs when the mouse pointer leaves the control.
        /// </summary>
        public event EventHandler MouseLeave;

        /// <summary>
        ///     Checks if the control is already selected with the specified position.
        /// </summary>
        /// <param name="position">Specified position</param>
        /// <returns>TRUE if the control is selected. FALSE otherwise.</returns>
        protected bool IsSelected(Point position)
        {
            return IsFocused = IsHovered(position);
        }

        /// <summary>
        ///     Checks if the specified position is hovered the control.
        /// </summary>
        /// <param name="position">Specified position</param>
        /// <returns>TRUE if the control is hovered. FALSE otherwise.</returns>
        protected bool IsHovered(Point position)
        {
            return Rectangle.Contains(position);
        }

        /// <summary>
        ///     Sets the surface with the specified control configuration.
        /// </summary>
        /// <remarks>Threading safe method.</remarks>
        protected void SetSurface()
        {
            lock (_surfaceLock)
            {
                Surface.Dispose();
                Surface = null;
                Surface = CreateSurface();
                GC.Collect();
            }
        }

        /// <summary>
        ///     Creates a new surface with the specified control configuration.
        /// </summary>
        /// <returns>New surfaces</returns>
        protected abstract Surface CreateSurface();

        /// <summary>
        ///     Raises the Click event.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="mouseButtonEventArgs">Mouse button event arguments</param>
        private void OnMouseClick(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            if (IsSelected(mouseButtonEventArgs.Position))
                InvokeEvent(Click, sender, mouseButtonEventArgs);
        }

        /// <summary>
        ///     Raises the Hover events.
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="mouseMotionEventArgs">Mouse motion event arguments</param>
        private void OnMouseMotion(object sender, MouseMotionEventArgs mouseMotionEventArgs)
        {
            if (IsHovered(mouseMotionEventArgs.Position) && _isHovered)
                InvokeEvent(MouseHover, sender, mouseMotionEventArgs);

            else if (IsHovered(mouseMotionEventArgs.Position))
            {
                InvokeEvent(MouseEnter, sender, mouseMotionEventArgs);
                _isHovered = true;
            }
            else if (_isHovered)
            {
                InvokeEvent(MouseLeave, sender, mouseMotionEventArgs);
                _isHovered = false;
            }
        }

        /// <summary>
        ///     Invokes an event from the specified event handler with the specified sender and arguments.
        /// </summary>
        /// <param name="eventHandler">Event handler</param>
        /// <param name="sender">Sender</param>
        /// <param name="eventArgs">Event arguments</param>
        private void InvokeEvent(EventHandler eventHandler, object sender, EventArgs eventArgs)
        {
            if (eventHandler != null)
                eventHandler.Invoke(sender, eventArgs);
        }
    }
}