﻿#region Header

// Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under GPLv3+
using System;
using System.Drawing;
using ArdeshirV.Forms;
using ArdeshirV.Tools;
using System.Windows.Forms;
using res = ArdeshirV.Forms.Properties;
using ArdeshirV.Applications.TestForms;
using ArdeshirV.Applications.TestForms.Properties;

#endregion
//---------------------------------------------------------------------------------------
namespace ArdeshirV.Applications.TestForms
{
    public partial class FormMainTest : FormBase
    {
    	#region Variables
    	
    	private Button[] buttons;
        private int intIncH = 100;
        private int intIncW = 150;
        private const string _stringEmail = "ArdeshirV@protonmail.com";
        private const string _stringWebsite =
        	"https://ardeshirv.github.io/ArdeshirV.Forms";
        private const string _stringWebsiteErr =
        	"https://github.com/ArdeshirV/ArdeshirV.Forms/issues/new";
        
    	#endregion Variables
        //-------------------------------------------------------------------------------
        public FormMainTest()
        {
            InitializeComponent();
            BackgoundEndGradientColor = Color.Lime;
            BackgoundStartGradientColor = Color.White;
            BackgoundInactiveEndGradientColor = Color.LightBlue;
            BackgoundInactiveStartGradientColor = Color.White;
            StartPosition = FormStartPosition.CenterScreen;
            UpdateMessageBar();
            buttons = new Button[] {
            	buttonShrinkWidth, buttonShrinkHeight, buttonSplashForm,
            	ButtonFormMessage, ButtonInput, buttonErrorHandlerForm,
            	buttonFormAbout, buttonNewForm, buttonExit };
            
            OnShrinkEnd += TestArdeshirV_Forms_OnShrinkEnd;
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
        private void CreateError()
        {
        	try {
        		string s = null;
        		int i = s.Length;
        	} catch(Exception exp) {
        		throw new Exception("Can not retrieve null string length.", exp);
        	}
        }
        //-------------------------------------------------------------------------------
        private void buttonErrorHandlerForm_Click(object sender, EventArgs e)
        {
            try {
        		CreateError();  // Throw an error to test FormErrorHandler form
            } catch (Exception exp) {
                FormErrorHandler.Show(this, exp, _stringWebsiteErr);
            }
        }
        //-------------------------------------------------------------------------------
        private void buttonFormAbout_Click(object sender, EventArgs e)
        {
        	// AssemblyAttributeAccessors retrive all assembly data by reflection
			string stringAssemblyProductName = new AssemblyAttributeAccessors(this).AssemblyProduct;

			// TODO: You can add your donation addresses in your code like this:
			Donations[] donations = new Donations[] {
				new Donations(      // Donations belong to this component and you can specify 
				stringAssemblyProductName,// several donation lists for several different component in your app
				new Donation[] {    // All below donations addresses are linked to
				              	    // the component with stringAssemblyTitle title
					new Donation("Bitcoin",                             // Donation name
					             "1GtjrxH6t8om8KwHAHKpcG5SAwVSsm4PEi",  // Donation address
					             GlobalResouces.CurrencyLogos.Bitcoin), // Donation logo
					// if you use usual public cryptocurrency logos like bitcoin and etc...
					// then you can refer to ArdeshirV.Forms.Properties.Resources.Bitcoin image
					new Donation("Ethereum",  // Here another example about Ethereum
					             // You can use your own donation address in your app like this:
					             "0x6E6465394D14975956cd1BD37ab4E35F2C60300E",
					             // Predefined crypto currency logos, You can use other images.
					             GlobalResouces.CurrencyLogos.Ethereum), 
					new Donation("Nano", 
					             "nano_3feuiaogay8zbsfye5ob1xp7obwb4syfpmc4pcb7ctckhh5z8671q4uzm9tc",
					             GlobalResouces.CurrencyLogos.Nano),
					new Donation("USDTether", 
					             "0x6E6465394D14975956cd1BD37ab4E35F2C60300E",
					             GlobalResouces.CurrencyLogos.USDTether)
				})};
			
			Credits[] credits = new Credits[] {
				new Credits(stringAssemblyProductName, new Credit[] {
				            	DefaultCreditList.GetItem("ArdeshirV.Forms")
				            })
				// TODO: You can add your credit info in your code like this:
				//new Credits("Component Name", new Credit[] {
				//	            new Credit("Credit Name", "Credit Description...", CreditAvator)
				//	        })
			};
			
			// You can add your copyright data about your different components
			// that are present in your app like below code:
			Copyright[] copyrights = new Copyright[] {
				new Copyright(this, Resources.Logo)  // the first parameter is
				// one of your components and the Copyright constructor can retrive all
				// assembly data about title, version, copyright and description automatically
				// but you are still able to specify title, version, copyright and description
				// yourself with another constructor like below:
				//, new Copyright(Text, "2.0.0", "Company", "Copyleft", "Test", ImageAppLogo)
				// but I prefer the first professional constructor and I think it's better
				// to specify details about your component in your AssemblyInfo.cs file not here
				// You can use the first kind of constructor only if you set strongname with key
			};
			
			License[] licenses = new License[] {
				new License(stringAssemblyProductName,  // The component name
				            GlobalResouces.Licenses.GPLLicense,    // License Contents for specified component
				            GlobalResouces.Licenses.GPLLicenseLogo)      // License Logo
			};
			
        	FormAboutData data = new FormAboutData(this,
        	                                       copyrights,
        	                                       credits,
        	                                       licenses,
        	                                       donations,
        	                                       _stringWebsite,
        	                                       _stringEmail);
        	FormAbout.Show(data);
        }
        //-------------------------------------------------------------------------------
        private void buttonSplashForm_Click(object sender, EventArgs e)
        {
        	FormSplash.Show(this, Resources.Logo);
        }
        //-------------------------------------------------------------------------------
		void ButtonFormMessageClick(object sender, EventArgs e)
		{
			const string strMsg =
				@"lorem ipsum...
				This is a sample passage to test FormMessage abilities.
				FormMessage arrange and align text and buttons automatically.";
			
			m_lblMessage.Text = "Dialog Result: " +
				FormMessage.Show(this, strMsg, Text, MessageBoxButtons.YesNoCancel,
				                 MessageBoxIcon.Information).ToString();
		}
        //-------------------------------------------------------------------------------
		bool IsValidInput(string strInput, out string stringErrMsg) {
        	bool boolResult = true;
        	stringErrMsg = string.Empty;
        	
        	try {
        		int.Parse(strInput);
        	} catch(Exception) {
        		boolResult = false;
        		stringErrMsg = "Please enter an integer number.";
        	}
        	
        	return boolResult;
		}
        //-------------------------------------------------------------------------------
		void ButtonInputClick(object sender, EventArgs e)
		{
			string stringValue;
			const string stringInputMsg = "Enter floating point number: ";
			
			DialogResult result =
				FormInput.Show(this,
				               out stringValue,
				               IsValidInput,
				               stringInputMsg,
				               Text,
				               string.Empty,
				               new Size(Width, 0));
			
			if(result == DialogResult.OK)
				m_lblMessage.Text = stringValue;
		}
        //-------------------------------------------------------------------------------
        private void UpdateMessageBar()
        {
            m_lblMessage.Text = string.Format("W:{0}, H:{1}", Width, Height);
        }
        //-------------------------------------------------------------------------------
        private void TestArdeshirV_Forms_Resize(object sender, EventArgs e)
        {
            UpdateMessageBar();
        }
    }
}
//---------------------------------------------------------------------------------------
