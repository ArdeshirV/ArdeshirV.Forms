#region Header

// Special Form Project
// Special Form.cs : Provides Special Form
// Copyright© 2002-2019 ardeshirv@protonmail.com, Licensed under GPLv3+

using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

#endregion
//---------------------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
    /// <summary>
    /// Provide a special Form with special properties, form shrink ability and special color.
    /// </summary>
    public class SpecialForm : System.Windows.Forms.Form
    {
        #region Variables

        private Image m_imgSplash = null;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool m_blnActivated = true;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool m_blnMouseDown = false;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private double m_dblLastOpacity = 0.0;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private const int m_intShrinkValue = 5;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private EventHandler m_dlgShrinkEnd = null;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private EventHandler m_dlgShrinkBegan = null;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private Point m_pntLastLocation = Point.Empty;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool m_blnMoveWithMouseAbility = true;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool m_blnChangingOpacityAbility = true;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private Color m_clrEnd = SystemColors.Highlight;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private bool m_blnBackgroundGradientColor = true;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private Color m_clrEndInactive = SystemColors.Highlight;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private Color m_clrStart = SystemColors.GradientActiveCaption;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private EventHandler m_dlgBackgroundGradientColorChanged = null;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private Color m_clrStartInactive = SystemColors.GradientInactiveCaption;

        [EditorBrowsable(EditorBrowsableState.Never)]
        private LinearGradientMode m_lgmBackgroundActiveMode = LinearGradientMode.Vertical;
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        private LinearGradientMode m_lgmInactiveBackgroundActiveMode = LinearGradientMode.Vertical;

        #endregion
        //-------------------------------------------------------------------------------
        #region Constructor

        /// <summary>
        /// Create SpecialForm instance.
        /// </summary>
        protected SpecialForm()
        {
            Hide();

			if (Parent is SpecialForm)
				FollowSpecialForm(Parent as SpecialForm);
        }

        #endregion
        //-------------------------------------------------------------------------------
        #region Interface

        public void ShrinkWidthByTime(int intNewWidth)
        {
            if (WindowState == FormWindowState.Normal)
            {
                RaiseShrinkBegan();
                int intInc = 8, intIncHalf = intInc / 2;
                int l_intShrinkWidthSize = (intNewWidth - Width) / intInc;

                if(l_intShrinkWidthSize < 0)
                {
                    intInc = -intInc;
                    intIncHalf = -intIncHalf;
                    l_intShrinkWidthSize = -l_intShrinkWidthSize;
                }
                
                for (int i = 0; i < l_intShrinkWidthSize; i++)
                {
                    if (Width == intNewWidth ||
                        (intInc > 0 && MaximumSize != Size.Empty && Width >= MaximumSize.Width) ||
                        (intInc < 0 && MinimumSize != Size.Empty && Width <= MinimumSize.Width))
                        break;

                    Application.DoEvents();
                    System.Threading.Thread.Sleep(5);
                    Application.DoEvents();
                    Left -= intIncHalf;
                    Width += intInc;
                }

                Width = intNewWidth;
                RaiseShrinkEnd();
            }
        }
        //------------------------------------------------------------------------------
        public void ShrinkHeightByTime(int intNewHeight)
        {
            if (WindowState == FormWindowState.Normal)
            {
                RaiseShrinkBegan();
                int intInc = 8;
                int intIncHalf = intInc / 2;
                int l_intShrinkHeightSize = (intNewHeight - Height) / intInc;

                if (l_intShrinkHeightSize < 0)
                {
                    intInc = -intInc;
                    intIncHalf = -intIncHalf;
                    l_intShrinkHeightSize = -l_intShrinkHeightSize;
                }

                for (int i = 0; i < l_intShrinkHeightSize; i++)
                {
                    if (Height == intNewHeight ||
                        (intInc > 0 && MaximumSize != Size.Empty && Height >= MaximumSize.Height) ||
                        (intInc < 0 && MinimumSize != Size.Empty && Height <= MinimumSize.Height))
                        break;

                    Application.DoEvents();
                    System.Threading.Thread.Sleep(10);
                    Application.DoEvents();
                    Top -= intIncHalf;
                    Height += intInc;

                    if (Height == intNewHeight)
                        break;
                }

                Height = intNewHeight;
                RaiseShrinkEnd();
            }
        }
        //-------------------------------------------------------------------------------
        public void ShrinkWidth(int intNewWidth)
        {
            if (WindowState == FormWindowState.Normal)
            {
                int l_intShrinkWidthSize = intNewWidth - Width;

                RaiseShrinkBegan();
                Left -= l_intShrinkWidthSize / 2;
                Width += l_intShrinkWidthSize;
                Width = intNewWidth;
                RaiseShrinkEnd();
            }
        }
        //-------------------------------------------------------------------------------
        public void ShrinkHeight(int intNewHeight)
        {
            if (WindowState == FormWindowState.Normal)
            {
                int l_intShrinkHeightSize = intNewHeight - Height;

                RaiseShrinkBegan();
                Top -= l_intShrinkHeightSize / 2;
                Height += l_intShrinkHeightSize;
                Height = intNewHeight;
                RaiseShrinkEnd();
            }
        }
        //-------------------------------------------------------------------------------
        public void FollowSpecialForm(SpecialForm frmMasterSpecialForm)
        {
            OpacityChanger = frmMasterSpecialForm.OpacityChanger;
            MoveFormWithMouse = frmMasterSpecialForm.MoveFormWithMouse;
            BackgroundGradientMode = frmMasterSpecialForm.BackgroundGradientMode;
            BackgroundGradientColor = frmMasterSpecialForm.BackgroundGradientColor;
            BackgoundEndGradientColor = frmMasterSpecialForm.BackgoundEndGradientColor;
            BackgoundStartGradientColor = frmMasterSpecialForm.BackgoundStartGradientColor;
            BackgoundInactiveEndGradientColor = frmMasterSpecialForm.BackgoundInactiveEndGradientColor;
            BackgoundInactiveStartGradientColor = frmMasterSpecialForm.BackgoundInactiveStartGradientColor;
        }

        #endregion
        //-------------------------------------------------------------------------------
        #region External Methods

        //[DllImport("user32.dll", EntryPoint = "AnimateWindow", CharSet = CharSet.Unicode)]
        //static extern int AnimateWindow(IntPtr hWnd, long dwTime, long dwFlags);

        //protected void CreateRoundRect()
        //{
        //	IntPtr l_rgnRoundRect = CreateRoundRectRgn(0, 0, Width, Height, 30, 30);
        //	SetWindowRgn(Handle.ToPointer(), l_rgnRoundRect, 1);
        //	DeleteObject(l_rgnRoundRect);
        //}

        #endregion
        //-------------------------------------------------------------------------------
        #region Overrided functions

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AddSpecialMouseEvent(this);

            if (m_blnChangingOpacityAbility)
            {
                m_dblLastOpacity = Opacity;
                Opacity = 0.0;
            }
            
            if(m_imgSplash is Bitmap)
            {
            	Hide();
            	FormSplash.Show(this, m_imgSplash);
            }
            
            Show();
        }
        //-------------------------------------------------------------------------------
        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            m_blnActivated = true;
            Invalidate(true);
        }
        //-------------------------------------------------------------------------------
        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);
            m_blnActivated = false;
            Invalidate(true);
        }
        //-------------------------------------------------------------------------------
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            Invalidate(true);

            if (m_blnChangingOpacityAbility)
            {
                for (int l_intIndexer = 0; l_intIndexer < 10; l_intIndexer++)
                {
                    System.Threading.Thread.Sleep(90);
                    Application.DoEvents();
                    Opacity += 0.1;

                    if (Opacity >= m_dblLastOpacity)
                        break;
                }

                Opacity = m_dblLastOpacity;
            }
        }
        //-------------------------------------------------------------------------------
        protected override void OnClosed(EventArgs e)
        {
            if (m_blnChangingOpacityAbility)
            {
                for (int l_intIndexer = 0; l_intIndexer < 10; l_intIndexer++)
                {
                    Opacity -= 0.1;
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(90);
                }
            }

            base.OnClosed(e);
        }
        //-------------------------------------------------------------------------------
        protected override void OnResize(EventArgs e)
        {
            Invalidate(true);
            base.OnResize(e);
        }
        //-------------------------------------------------------------------------------
        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {
            if (m_blnBackgroundGradientColor && ClientRectangle.Width > 0 && ClientRectangle.Height > 0)
            {
                LinearGradientBrush l_brsGradient;

                if(m_blnActivated)
                    l_brsGradient = new LinearGradientBrush(ClientRectangle, m_clrStart, m_clrEnd, m_lgmBackgroundActiveMode);
                else
                    l_brsGradient = new LinearGradientBrush(ClientRectangle, m_clrStartInactive, m_clrEndInactive, m_lgmBackgroundActiveMode);

                try
                {
                    e.Graphics.FillRectangle(l_brsGradient, ClientRectangle);
                }
                finally
                {
                    l_brsGradient.Dispose();
                }
            }
            else
                base.OnPaintBackground(e);
        }

        #endregion
        //-------------------------------------------------------------------------------
        #region Utility Functions

        private void InitializeComponent() { }
        //-------------------------------------------------------------------------------
        public void AddSpecialMouseEvent(Control ctlDest)
        {
            AddMouseEvents(ctlDest);

            foreach (Control ctlOut in ctlDest.Controls)
                if (!(ctlOut is Button))
                    AddMouseEvents(ctlOut);
        }
        //-------------------------------------------------------------------------------
        public void RemoveSpecialMouseEvent(Control ctlDest)
        {
            RemoveMouseEvents(ctlDest);

            foreach (Control ctlOut in ctlDest.Controls)
                if (!(ctlOut is Button))
                    RemoveMouseEvents(ctlOut);
        }
        //-------------------------------------------------------------------------------
        private void RemoveMouseEvents(Control ctlDest)
        {
            ctlDest.MouseUp -= new MouseEventHandler(OnMouseUp_Event);
            ctlDest.MouseMove -= new MouseEventHandler(OnMouseMove_Event);
            ctlDest.MouseDown -= new MouseEventHandler(OnMouseDown_Event);
        }
        //-------------------------------------------------------------------------------
        private void AddMouseEvents(Control ctlDest)
        {
            ctlDest.MouseUp += new MouseEventHandler(OnMouseUp_Event);
            ctlDest.MouseMove += new MouseEventHandler(OnMouseMove_Event);
            ctlDest.MouseDown += new MouseEventHandler(OnMouseDown_Event);
        }

        #endregion
        //-------------------------------------------------------------------------------
        #region Event Handlers

        private void OnMouseDown_Event(object sender, MouseEventArgs e)
        {
            m_blnMouseDown = true;
            m_pntLastLocation = e.Location;
        }
        //-------------------------------------------------------------------------------
        private void OnMouseMove_Event(object sender, MouseEventArgs e)
        {
            if (m_blnMoveWithMouseAbility && m_blnMouseDown)
            {
                Top += e.Y - m_pntLastLocation.Y;
                Left += e.X - m_pntLastLocation.X;
            }
        }
        //-------------------------------------------------------------------------------
        private void OnMouseUp_Event(object sender, MouseEventArgs e)
        {
            m_blnMouseDown = false;
        }

        #endregion
        //-------------------------------------------------------------------------------
        #region Properties

        /// <summary>
        /// Sets or gets the ending lieaner background color when form is inactive.
        /// </summary>
        [Browsable(true)]
        [Category("Special")]
        [Description("Splash Image the best size is 400 * 250.")]
        public Image SplashImage
        {
            get
            {
                return m_imgSplash;
            }
            set
            {
                m_imgSplash = value;
            }
        }
        //-------------------------------------------------------------------------------
        /// <summary>
        /// Sets or gets the ending lieaner background color when form is inactive.
        /// </summary>
        [Browsable(true)]
        [Category("Special")]
        [Description("Ending lieaner background color when form is inactive.")]
        public Color BackgoundInactiveEndGradientColor
        {
            get
            {
                return m_clrEndInactive;
            }
            set
            {
                m_clrEndInactive = value;
                RaiseBackgroundGradientColorChanged();
                Invalidate();
            }
        }
        //-------------------------------------------------------------------------------
        /// <summary>
        /// Starting lieaner background color when form is inactive.
        /// </summary>
        [Browsable(true)]
        [Category("Special")]
        [Description("Starting lieaner background color when form is inactive.")]
        public Color BackgoundInactiveStartGradientColor
        {
            get
            {
                return m_clrStartInactive;
            }
            set
            {
                m_clrStartInactive = value;
                RaiseBackgroundGradientColorChanged();
                Invalidate();
            }
        }
        //-------------------------------------------------------------------------------
        /// <summary>
        /// Gets last form location when mouse down.
        /// </summary>
        [Browsable(false)]
        [Category("Special")]
        [Description("Last form location when mouse down.")]
        public Point LocationOnMouseDown
        {
            get
            {
                if (m_blnMouseDown)
                    return m_pntLastLocation;
                else
                    return Point.Empty;
            }
        }
        //-------------------------------------------------------------------------------
        /// <summary>
        /// Mouse is down?
        /// </summary>
        [Browsable(false)]
        [Category("Special")]
        [Description("Mouse is down?")]
        public bool MouseIsDown
        {
            get
            {
                return m_blnMouseDown;
            }
        }
        //-------------------------------------------------------------------------------
        /// <summary>
        /// Gets the true if form is activated.
        /// </summary>
        [Browsable(false)]
        [Category("Special")]
        [Description("Return true if current form is activated.")]
        public bool IsActivated
        {
            get
            {
                return m_blnActivated;
            }
        }
        //-------------------------------------------------------------------------------b
        /// <summary>
        /// Gets or sets the "move form with mouse" ability.
        /// </summary>
        [Browsable(true)]
        [Category("Special")]
        [Description("Move form with mouse ability.")]
        public bool MoveFormWithMouse
        {
            set
            {
                m_blnMoveWithMouseAbility = value;
            }
            get
            {
                return m_blnMoveWithMouseAbility;
            }
        }
        //-------------------------------------------------------------------------------
        /// <summary>
        /// Sets or gets the ending lieaner background color.
        /// </summary>
        [Browsable(true)]
        [Category("Special")]
        [Description("Ending lieaner background color.")]
        public Color BackgoundEndGradientColor
        {
            get
            {
                return m_clrEnd;
            }
            set
            {
                m_clrEnd = value;
                RaiseBackgroundGradientColorChanged();
                Invalidate();
            }
        }
        //-------------------------------------------------------------------------------
        /// <summary>
        /// Starting lieaner background color.
        /// </summary>
        [Browsable(true)]
        [Category("Special")]
        [Description("Starting lieaner background color.")]
        public Color BackgoundStartGradientColor
        {
            get
            {
                return m_clrStart;
            }
            set
            {
                m_clrStart = value;
                RaiseBackgroundGradientColorChanged();
                Invalidate();
            }
        }
        //-------------------------------------------------------------------------------
        /// <summary>
        /// Make gradient lieaner background color ability enable/disable.
        /// </summary>
        [Browsable(true)]
        [Category("Special")]
        [Description("Make gradient lieaner background color ability enable/disable.")]
        public bool BackgroundGradientColor
        {
            get
            {
                return m_blnBackgroundGradientColor;
            }
            set
            {
                m_blnBackgroundGradientColor = value;
                RaiseBackgroundGradientColorChanged();
                Invalidate();
            }
        }
        //-------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets opacity changer delay ability.
        /// </summary>
        [Browsable(true)]
        [Category("Special")]
        [Description("Gets or sets opacity changer delay ability.")]
        public bool OpacityChanger
        {
            get
            {
                return m_blnChangingOpacityAbility;
            }
            set
            {
                m_blnChangingOpacityAbility = value;
            }
        }
        //-------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets background drawing mode.
        /// </summary>
        [Browsable(true)]
        [Category("Special")]
        [Description("Gets or sets background drawing mode.")]
        public System.Drawing.Drawing2D.LinearGradientMode BackgroundGradientMode
        {
            get
            {
                return m_lgmBackgroundActiveMode;
            }
            set
            {
                m_lgmBackgroundActiveMode = value;
                RaiseBackgroundGradientColorChanged();
                Invalidate();
            }
        }
        //-------------------------------------------------------------------------------
        /// <summary>
        /// Gets or sets background drawing mode when form is inactive.
        /// </summary>
        [Browsable(true)]
        [Category("Special")]
        [Description("Gets or sets background drawing mode when form is inactive.")]
        public System.Drawing.Drawing2D.LinearGradientMode BackgroundInactiveGradientMode
        {
            get
            {
                return m_lgmInactiveBackgroundActiveMode;
            }
            set
            {
                m_lgmInactiveBackgroundActiveMode = value;
                RaiseBackgroundGradientColorChanged();
                Invalidate();
            }
        }

        #endregion
        //-------------------------------------------------------------------------------
        #region Events

        public event EventHandler OnBackgroundGradientColorChange
        {
            add
            {
                m_dlgBackgroundGradientColorChanged += value;
            }
            remove
            {
                m_dlgBackgroundGradientColorChanged -= value;
            }
        }
        //-------------------------------------------------------------------------------
        public event EventHandler OnShrinkBegan
        {
            add
            {
                m_dlgShrinkBegan += value;
            }
            remove
            {
                m_dlgShrinkBegan -= value;
            }
        }
        //-------------------------------------------------------------------------------
        public event EventHandler OnShrinkEnd
        {
            add
            {
                m_dlgShrinkEnd += value;
            }
            remove
            {
                m_dlgShrinkEnd -= value;
            }
        }
        //-------------------------------------------------------------------------------
        private void RaiseBackgroundGradientColorChanged()
        {
            if(m_dlgBackgroundGradientColorChanged != null)
                m_dlgBackgroundGradientColorChanged(this, null);
        }
        //-------------------------------------------------------------------------------
        private void RaiseShrinkEnd()
        {
            if (m_dlgShrinkEnd != null)
                m_dlgShrinkEnd(this, null);
        }
        //-------------------------------------------------------------------------------
        private void RaiseShrinkBegan()
        {
            if (m_dlgShrinkBegan != null)
                m_dlgShrinkBegan(this, null);
        }

        #endregion
    }
}
//---------------------------------------------------------------------------------------
