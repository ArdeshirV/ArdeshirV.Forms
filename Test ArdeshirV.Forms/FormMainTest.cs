// Copyright© 2002-2019 ardeshirv@protonmail.com, Licensed under GPLv3+

using System;
using System.Drawing;
using ArdeshirV.Forms;
using System.Windows.Forms;
u
namespace Test_ArdeshirV.Forms
{
    public partial class FormMainTest : ArdeshirV.Forms.SpecialForm
    {
        private int intIncW = 50;
        private int intIncH = 50;
        private const string _stringEmail = "ardeshirv@protonmail.com";
        private const string _stringWebsite = "https://github.com/ArdeshirV/dotNetMySpecialForms";
        //-------------------------------------------------------------------------------
        public FormMainTest()
        {
            InitializeComponent();
            this.OnShrinkEnd += TestArdeshirV_Forms_OnShrinkEnd;
            this.StartPosition = FormStartPosition.CenterScreen;
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
            int i = 0, j = 10;
            try
            {
                i = j / i;  // Throw divide by zero exception
            }
            catch (Exception exp)
            {
                FormErrorHandler.Show(exp, this, _stringWebsite);
            }
        }
        //-------------------------------------------------------------------------------
        private void buttonFormAbout_Click(object sender, EventArgs e)
        {
            FormAbout.Show(this, _stringWebsite,
                _stringEmail, this.Icon.ToBitmap());
        }
        //-------------------------------------------------------------------------------
        private void UpdateMessageBar()
        {
            m_lblMessage.Text = string.Format("Width = {0}", Width);
        }
        //-------------------------------------------------------------------------------
        private void buttonSplashForm_Click(object sender, EventArgs e)
        {
            Image img = global::Test_ArdeshirV.Forms.Properties.Resources.SplashImage;
            FormSplash.Show(this, img);
        }
        //-------------------------------------------------------------------------------
        private void TestArdeshirV_Forms_Resize(object sender, EventArgs e)
        {
            UpdateMessageBar();
        }
    }
}
