#region Header

// Form Message
// FormMessage.cs : Gets user input values in string variable.
// Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under LGPLv3+

using System;
using System.Drawing;
using System.Windows.Forms;

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
		public static new FormMessage Show(Form Owner) 
		{
			//MessageBoxButtons.
			FormMessage form = new FormMessage();
			form.SetKeys(MessageBoxButtons.AbortRetryIgnore);
			form.ShowDialog(Owner);
			return form;
		}
		//-------------------------------------------------------------------------------
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
		//-------------------------------------------------------------------------------
		void ButtonOneClick(object sender, EventArgs e)
		{
		}
		//-------------------------------------------------------------------------------
		void ButtonTwoClick(object sender, EventArgs e)
		{
		}
		//-------------------------------------------------------------------------------
		void ButtonThreeClick(object sender, EventArgs e)
		{
		}
	}
}
//---------------------------------------------------------------------------------------
