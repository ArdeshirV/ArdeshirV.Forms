#region Header

// Form Message
// FormMessage.cs : Gets user input values in string variable.
// Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under LGPLv3+

using System;
using System.Drawing;
using System.Windows.Forms;
using ArdeshirV.Forms.Properties;

#endregion
//-----------------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
	/// <summary>
	/// Description of FormMessage.
	/// </summary>
	public partial class FormMessage : FormBase
	{
		protected FormMessage()
		{
			InitializeComponent();
			FollowParentFormBase = true;
			StartPosition = FormStartPosition.CenterParent;
		}
		//-------------------------------------------------------------------------------
		public static DialogResult Show(Form Owner) 
		{
			const string stringX = " try {" +
        			"// Create an error to test FormErrorHandler form" +
            		"File.Open(\"some-file.ext\", FileMode.Open);  // Throw an exception" +
            	"} catch (Exception exp) {" +
                	"FormErrorHandler.Show(exp, this, _stringWebsite);";
			MessageBox.Show(stringX, "Test MessageBox",
			                MessageBoxButtons.OKCancel,
			                MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1,
			                MessageBoxOptions.RightAlign);
			
			FormMessage form = new FormMessage();
			form.Text = Owner.Text;
			form.labelMessage.Text = stringX;
			form.SetKeys(MessageBoxButtons.OKCancel);
			form.SetIcon(MessageBoxIcon.Exclamation);
			form.ShowDialog(Owner);
			return form.DialogResult;
		}
		//-------------------------------------------------------------------------------
		private void SetIcon(MessageBoxIcon icon) 
		{
			switch(icon) {
				case MessageBoxIcon.None:
					pictureBoxIcon.Image = null;
					pictureBoxIcon.Visible = false;
					break;
				case MessageBoxIcon.Information:
				//case MessageBoxIcon.Asterisk:
					pictureBoxIcon.Image = Resources.IconInfo;
					break;
				case MessageBoxIcon.Error:
				//case MessageBoxIcon.Hand:
				//case MessageBoxIcon.Stop:
					pictureBoxIcon.Image = Resources.IconError;
					break;
				case MessageBoxIcon.Warning:
				//case MessageBoxIcon.Exclamation:
					pictureBoxIcon.Image = Resources.IconWarning;
					break;
				case MessageBoxIcon.Question:
					//pictureBoxIcon.Image = Resources.Question;
					break;
			}
		}
		//-------------------------------------------------------------------------------
		private void SetKeys(MessageBoxButtons buttons)
		{
			switch(buttons) {
				case MessageBoxButtons.OK:
					buttonOne.Visible = true;
					buttonOne.Text = "&OK";
					buttonOne.DialogResult = DialogResult.OK;
					buttonTwo.Visible = false;
					buttonThree.Visible = false;
					AcceptButton = buttonOne;
					break;
				case MessageBoxButtons.OKCancel:
					buttonOne.Visible = true;
					buttonOne.Text = "&OK";
					buttonOne.DialogResult = DialogResult.OK;
					buttonTwo.Visible = true;
					buttonTwo.Text = "&Cancel";
					buttonTwo.DialogResult = DialogResult.Cancel;
					buttonThree.Visible = false;
					AcceptButton = buttonOne;
					CancelButton = buttonTwo;
					break;
				case MessageBoxButtons.YesNo:
					buttonOne.Visible = true;
					buttonOne.Text = "&Yes";
					buttonOne.DialogResult = DialogResult.Yes;
					buttonTwo.Visible = true;
					buttonTwo.Text = "&No";
					buttonTwo.DialogResult = DialogResult.No;
					buttonThree.Visible = false;
					AcceptButton = buttonOne;
					CancelButton = buttonTwo;
					break;
				case MessageBoxButtons.YesNoCancel:
					buttonOne.Visible = true;
					buttonOne.Text = "&Yes";
					buttonOne.DialogResult = DialogResult.Yes;
					buttonTwo.Visible = true;
					buttonTwo.Text = "&No";
					buttonTwo.DialogResult = DialogResult.No;
					buttonThree.Visible = true;
					buttonThree.Text = "&Cancel";
					buttonThree.DialogResult = DialogResult.Cancel;
					AcceptButton = buttonOne;
					CancelButton = buttonThree;
					break;
				case MessageBoxButtons.RetryCancel:
					buttonOne.Visible = true;
					buttonOne.Text = "&Retry";
					buttonOne.DialogResult = DialogResult.Retry;
					buttonTwo.Visible = true;
					buttonTwo.Text = "&Cancel";
					buttonTwo.DialogResult = DialogResult.Retry;
					buttonThree.Visible = false;
					AcceptButton = buttonOne;
					CancelButton = buttonTwo;
					break;
				case MessageBoxButtons.AbortRetryIgnore:
					buttonOne.Visible = true;
					buttonOne.Text = "&Abort";
					buttonOne.DialogResult = DialogResult.Abort;
					buttonTwo.Visible = true;
					buttonTwo.Text = "&Retry";
					buttonTwo.DialogResult = DialogResult.Retry;
					buttonThree.Visible = true;
					buttonThree.Text = "&Ignore";
					buttonThree.DialogResult = DialogResult.Ignore;
					AcceptButton = buttonTwo;
					CancelButton = buttonOne;
					break;
			}
		}
	}
}
//---------------------------------------------------------------------------------------
