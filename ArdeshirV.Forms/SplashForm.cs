#region Header

// Copyright© 2002-2019 ardeshirv@protonmail.com, Licensed under GPLv3+

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion
//-----------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
    public partial class FormSplash : ArdeshirV.Forms.SpecialForm
    {
        private Timer m_timTimer;
        //---------------------------------------------------------------------
        protected FormSplash(Form formOwner, Image imgSplashImage)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            Size = imgSplashImage.Size;
            this.AutoSizeMode = AutoSizeMode.GrowOnly;
            m_imgPictureBox.Image = imgSplashImage;
            m_imgPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            m_timTimer = new Timer();
            m_timTimer.Interval = 3000;
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
        public static void Show(Form formOwner,Image imgSplashImage)
        {
            if (imgSplashImage != null)
                new FormSplash(formOwner, imgSplashImage);
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
