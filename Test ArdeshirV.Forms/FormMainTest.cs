// Copyright© 2002-2019 ArdeshirV@protonmail.com, Licensed under GPLv3+
using System;
using System.IO;
using System.Drawing;
using ArdeshirV.Forms;
using System.Windows.Forms;
using ArdeshirV.TestForms.Properties;
//---------------------------------------------------------------------------------------
namespace ArdeshirV.TestForms
{
    public partial class FormMainTest : FormBase
    {
        private int intIncH = 100;
        private int intIncW = 150;
        private const string _stringEmail = "ArdeshirV@protonmail.com";
        private const string _stringWebsite =
        	"https://ardeshirv.github.io/ArdeshirV.Forms";
        //-------------------------------------------------------------------------------
        public FormMainTest()
        {
            InitializeComponent();
            OnShrinkEnd += TestArdeshirV_Forms_OnShrinkEnd;
            StartPosition = FormStartPosition.CenterScreen;
            BackgoundStartGradientColor = Color.Yellow;
            BackgoundEndGradientColor = Color.Firebrick;
            UpdateMessageBar();
        }
        //-------------------------------------------------------------------------------
        private void TestArdeshirV_Forms_OnShrinkEnd(object sender, EventArgs e)
        {
            UpdateMessageBar();

            if(!buttonShrinkWidth.Enabled)
            {
                intIncW = -intIncW;
                buttonShrinkWidth.Enabled = true;
            }

            if (!buttonShrinkHeight.Enabled)
            {
                intIncH = -intIncH;
                buttonShrinkHeight.Enabled = true;
            }
        }
        //-------------------------------------------------------------------------------
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        //-------------------------------------------------------------------------------
        private void buttonShrinkHeight_Click(object sender, EventArgs e)
        {
            buttonShrinkHeight.Enabled = false;
            this.ShrinkHeightByTime(Height - intIncH);
        }
        //-------------------------------------------------------------------------------
        private void buttonShrinkWidth_Click(object sender, EventArgs e)
        {
            buttonShrinkWidth.Enabled = false;
            this.ShrinkWidthByTime(Width - intIncW);
        }
        //-------------------------------------------------------------------------------
        private void buttonNewForm_Click(object sender, EventArgs e)
        {
            Form f = new FormMainTest();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(Location.X + 10, Location.Y + 10);
            f.Show(this);
        }
        //-------------------------------------------------------------------------------
        private void buttonErrorHandlerForm_Click(object sender, EventArgs e)
        {
            try {
            	File.Open("some-file.ext", System.IO.FileMode.Open);  // Throw an exception
            } catch (Exception exp) {
                FormErrorHandler.Show(exp, this, _stringWebsite);
            }
        }
        //-------------------------------------------------------------------------------
        private void buttonFormAbout_Click(object sender, EventArgs e)
        {
            FormAbout.Show(this, _stringWebsite, _stringEmail, Resources.ImageFlower);
        }
        //-------------------------------------------------------------------------------
        private void UpdateMessageBar()
        {
            m_lblMessage.Text = string.Format("W:{0}, H:{1}", Width, Height);
        }
        //-------------------------------------------------------------------------------
        private void buttonSplashForm_Click(object sender, EventArgs e)
        {
            FormSplash.Show(this, Resources.ImageFlower);
        }
        //-------------------------------------------------------------------------------
        private void TestArdeshirV_Forms_Resize(object sender, EventArgs e)
        {
            UpdateMessageBar();
        }
        //-------------------------------------------------------------------------------
		void ButtonFormMessageClick(object sender, EventArgs e)
		{
			DialogResult drResult = FormMessage.Show().DialogResult;//this, "Message");
		}
        //-------------------------------------------------------------------------------
		void ButtonInputClick(object sender, EventArgs e)
		{
			//string stringResult;
			FormInput.Show();//this, "Message", out stringResult);
		}
    }
}
