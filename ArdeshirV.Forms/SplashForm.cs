#region Header

// Copyright© 2002-2019 ardeshirv@protonmail.com, Licensed under GPLv3+

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion
//-----------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
    public partial class FormSplash : SpecialForm
    {
        private Timer m_timTimer;
        //---------------------------------------------------------------------
        protected FormSplash(Form formOwner, Image imgSplashImage, int Delay) : base()
        {
            InitializeComponent();
            if (DesignMode)
                return;
            Visible = false;
            FollowParentSpecialForm = false;
            this.StartPosition = FormStartPosition.CenterParent;
            Size = imgSplashImage.Size;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            m_imgPictureBox.Image = imgSplashImage;
            m_imgPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            m_timTimer = new Timer();
            m_timTimer.Interval = Delay;
            m_timTimer.Tick += new EventHandler(m_timTimer_Elapsed);
            m_timTimer.Start();
            ShowDialog(formOwner);
        }
        //---------------------------------------------------------------------
        private void m_timTimer_Elapsed(object sender, EventArgs e)
        {
            m_timTimer.Stop();
            Close();
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Create and show splash form 
        /// </summary>
        /// <param name="formOwner">Owner form</param>
        /// <param name="imgSplashImage">Image on the splash form</param>
        /// <returns>Reference to created splash form</returns>
        public static FormSplash Show(Form formOwner, Image imgSplashImage)
        {
        	return Show(formOwner, imgSplashImage, 3000);
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Create and show splash form 
        /// </summary>
        /// <param name="formOwner">Owner form</param>
        /// <param name="imgSplashImage">Image on the splash form</param>
        /// <param name="Delay">Delay time in miliseconds that splash form is present</param>
        /// <returns>Reference to created splash form</returns>
        public static FormSplash Show(Form formOwner, Image imgSplashImage, int Delay)
        {
        	FormSplash form = null;

            if (imgSplashImage != null)
                form = new FormSplash(formOwner, imgSplashImage, Delay);
            
            return form;
        }
        //---------------------------------------------------------------------
        private void M_imgPictureBox_Click(object sender, EventArgs e)
        {
            Close();
        }
        //---------------------------------------------------------------------
        private void FormSplash_KeyPress(object sender, KeyPressEventArgs e)
        {
            Close();
        }
    }
}
//-----------------------------------------------------------------------------
