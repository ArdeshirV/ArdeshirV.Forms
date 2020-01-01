#region Header

// Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under GPLv3+
using System;
using System.IO;
using System.Drawing;
using ArdeshirV.Forms;
using ArdeshirV.Utilities;
using System.Windows.Forms;
using ArdeshirV.TestForms.Properties;

#endregion
//---------------------------------------------------------------------------------------------
namespace ArdeshirV.TestForms
{
    public partial class FormMainTest : FormBase
    {
        private int intIncH = 100;
        private int intIncW = 150;
        private const string _stringEmail = "ArdeshirV@protonmail.com";
        private const string _stringWebsite =
        	"https://ardeshirv.github.io/ArdeshirV.Forms";
        //-------------------------------------------------------------------------------------
        public FormMainTest()
        {
            InitializeComponent();
            OnShrinkEnd += TestArdeshirV_Forms_OnShrinkEnd;
            StartPosition = FormStartPosition.CenterScreen;
            BackgoundStartGradientColor = Color.Yellow;
            BackgoundEndGradientColor = Color.Firebrick;
            UpdateMessageBar();
        }
        //-------------------------------------------------------------------------------------
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
        //-------------------------------------------------------------------------------------
        private void buttonExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        //-------------------------------------------------------------------------------------
        private void buttonShrinkHeight_Click(object sender, EventArgs e)
        {
            buttonShrinkHeight.Enabled = false;
            this.ShrinkHeightByTime(Height - intIncH);
        }
        //-------------------------------------------------------------------------------------
        private void buttonShrinkWidth_Click(object sender, EventArgs e)
        {
            buttonShrinkWidth.Enabled = false;
            this.ShrinkWidthByTime(Width - intIncW);
        }
        //-------------------------------------------------------------------------------------
        private void buttonNewForm_Click(object sender, EventArgs e)
        {
            Form f = new FormMainTest();
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(Location.X + 10, Location.Y + 10);
            f.Show(this);
        }
        //-------------------------------------------------------------------------------------
        private void buttonErrorHandlerForm_Click(object sender, EventArgs e)
        {
            try {
            	File.Open("some-file.ext", FileMode.Open);  // Throw an exception
            } catch (Exception exp) {
                FormErrorHandler.Show(exp, this, _stringWebsite);
            }
        }
        //-------------------------------------------------------------------------------------
        private void buttonFormAbout_Click(object sender, EventArgs e)
        {
			AssemblyAttributeAccessors aaa = new AssemblyAttributeAccessors(this);
			Donations _donation = new Donations();

			// TODO: You are allowed to change donation addresses in your own code like this:
			_donations.Add(aaa.AssemblyTitle, new Donation[] {
				new Donation("Bitcoin", "1MjwviitdNC7ndvjXL3dG7mE9Pir3ZBSBP", Resources.Bitcoin),
				new Donation("Ethereum", "0x1DBED0B76d1070a47613EdEE58D9eD8afD6A206D", Resources.Ethereum),
				new Donation("TrueUSD", "0x1DBED0B76d1070a47613EdEE58D9eD8afD6A206D", Resources.TrueUSD),
				new Donation("Nano", "nano_1t7fg3drandk1crg363cn66px1adzsz3reeece8puuecbti4ysnyszbikry5", Resources.Nano),
				new Donation("Litecoin", "LWzeZqbn38AzYJTJg6yyDAbKi7i8EEUbqw", Resources.Litecoin)
			});
			
			_copyrights.Add(aaa.AssemblyTitle,
			                new Copyright(aaa.AssemblyTitle,
			                              aaa.AssemblyVersion,
			                              aaa.AssemblyCopyright,
			                              aaa.AssemblyDescription,
			                              Resources.ArdeshirV_Forms_Logo));
			
			_licenses.Add(aaa.AssemblyTitle,
			              new License("LGPLv3+", Resources.LICENSE, Resources.LGPLv3));
        	// TODO: Modify FormAbout.Show method
        	//FormAbout.Show(this, _stringWebsite, _stringEmail, Resources.Logo);
        	//FormAbout.Show(this, _stringWebsite, _stringEmail);
        	FormAboutData data = new FormAboutData(this,
				new Copyright[] { new Copyright(this, Resources.Logo) },
				new License[] { new License("GPLv3+", "GNU Public License Version 3+", Resources.GPLv3) },
				new Donation[] {}, _stringWebsite, _stringEmail);
        	FormAbout.Show(data);
        }
        //-------------------------------------------------------------------------------------
        private void UpdateMessageBar()
        {
            m_lblMessage.Text = string.Format("W:{0}, H:{1}", Width, Height);
        }
        //-------------------------------------------------------------------------------------
        private void buttonSplashForm_Click(object sender, EventArgs e)
        {
            FormSplash.Show(this, Resources.Logo);
        }
        //-------------------------------------------------------------------------------------
        private void TestArdeshirV_Forms_Resize(object sender, EventArgs e)
        {
            UpdateMessageBar();
        }
        //-------------------------------------------------------------------------------------
		void ButtonFormMessageClick(object sender, EventArgs e)
		{
			DialogResult drResult = FormMessage.Show().DialogResult;//this, "Message");
		}
        //-------------------------------------------------------------------------------------
		void ButtonInputClick(object sender, EventArgs e)
		{
			//string stringResult;
			FormInput.Show();//this, "Message", out stringResult);
		}
    }
}
