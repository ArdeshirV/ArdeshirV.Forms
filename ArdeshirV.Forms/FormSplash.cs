#region Header

// Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under LGPLv3+

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion
//---------------------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
    public partial class FormSplash : FormBase
    {
    	public delegate void FormSplashProcess(ProgressBar pb);
    	
        private Form _formOwner;
        private Timer m_timTimer;
        //-------------------------------------------------------------------------------
        protected FormSplash(Form formOwner, Image imgSplashImage, int Delay) :
        	base(formOwner)
        {
            InitializeComponent();
            if (!DesignMode)
            {
	            //Visible = false;
            	//formOwner.Hide();
            	Size = new Size(imgSplashImage.Size.Width,
            	                imgSplashImage.Size.Height + progressBar.Height);
	            //FollowParentFormBase = true;
            	MoveFormWithMouse = false;
	            m_imgPictureBox.Image = imgSplashImage;
	            this.AutoSizeMode = AutoSizeMode.GrowOnly;
	            this.StartPosition = FormStartPosition.CenterScreen;
	            m_imgPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
	            m_timTimer = new Timer();
	            m_timTimer.Interval = 200;
	            m_timTimer.Tick += new EventHandler(m_timTimer_Elapsed);
	            //m_timTimer.Start();
	            Show(_formOwner = formOwner);
            }
        }
        //-------------------------------------------------------------------------------
        private bool Run() {
        	return true;
        }
        //-------------------------------------------------------------------------------
        private void m_timTimer_Elapsed(object sender, EventArgs e)
        {
            m_timTimer.Stop();
            //Close();
            //_formOwner.Show();
            
            Run();
			Application.DoEvents();
        }
        //-------------------------------------------------------------------------------
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
        //-------------------------------------------------------------------------------
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
        //-------------------------------------------------------------------------------
        public ProgressBar Progress
        {
        	get {
        		return progressBar;
        	}
        }
        //-------------------------------------------------------------------------------
        private void M_imgPictureBox_Click(object sender, EventArgs e)
        {
            Close();
        }
        //-------------------------------------------------------------------------------
        private void FormSplash_KeyPress(object sender, KeyPressEventArgs e)
        {
            Close();
        }
        //-------------------------------------------------------------------------------
		void FormSplashShown(object sender, EventArgs e)
		{
			m_timTimer.Start();
		}
    }
}
//---------------------------------------------------------------------------------------
