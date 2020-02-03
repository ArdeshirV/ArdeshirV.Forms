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
    	/// <summary>
    	/// FormSplashProcess has been process loading app resources
    	/// and update progressbar below FormSplash
    	/// </summary>
    	/// <param name="pb">ProgressBar below the FormSplash
    	/// that demonstrat loading progress</param>
    	public delegate void FormSplashProcess(ProgressBar pb);
        //-------------------------------------------------------------------------------    	
        private Form _formOwner;
        private Timer m_timTimer;
        private FormSplashProcess localFormSplashProcess;
        private readonly long intTicks = DateTime.Now.Ticks + 4;
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
        protected FormSplash(Form formOwner, Image imgSplashImage, FormSplashProcess fsp) :
        	base(formOwner)
        {
            InitializeComponent();
            if (!DesignMode)
            {
	            //Visible = false;
            	//formOwner.Hide();
            	localFormSplashProcess += fsp;
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
        private void m_timTimer_Elapsed(object sender, EventArgs e)
        {
        	m_timTimer.Stop();
            if(localFormSplashProcess != null) {
            	localFormSplashProcess(progressBar);
            	Close();
            } else {
        		int intNow = DateTime.Now.Second + 4;
        		while(intNow < DateTime.Now.Second) {
        			Application.DoEvents();
        			Close();
        		}
            }
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
