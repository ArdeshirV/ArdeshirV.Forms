#region Header

// Form Message
// FormMessage.cs : Gets user input values in string variable.
// Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under LGPLv3+

using System;
using System.Drawing;
using ArdeshirV.Utilities;
using System.Windows.Forms;
using System.Collections.Generic;
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
		private Button[] buttonArr = null;
		//-------------------------------------------------------------------------------	
		protected FormMessage(IWin32Window windowParent) : base(windowParent)
		{
			InitializeComponent();
			FollowParentFormBase = true;
			labelMessage.Text = "Message goes here.";
			StartPosition = FormStartPosition.CenterParent;
			buttonArr = new Button[] { buttonOne, buttonTwo, buttonThree };
		}
		//-------------------------------------------------------------------------------
		public static DialogResult Show(string Text)
		{
			return Show(null, Text, string.Empty,
			            MessageBoxButtons.OK, MessageBoxIcon.None);
		}
		//-------------------------------------------------------------------------------
		public static DialogResult Show(Form FormOwner, string Text)
		{
			return Show(FormOwner, Text, FormOwner.Text,
			            MessageBoxButtons.OK, MessageBoxIcon.None);
		}
		//-------------------------------------------------------------------------------
		public static DialogResult Show(Form FormOwner, string Text, string Caption)
		{
			return Show(FormOwner, Text, Caption,
			            MessageBoxButtons.OK, MessageBoxIcon.None);
		}
		//-------------------------------------------------------------------------------
		public static DialogResult Show(Form FormOwner, string Text,
		    string Caption, MessageBoxButtons buttons)
		{
			return Show(FormOwner, Text, Caption, buttons, MessageBoxIcon.None);
		}
		//-------------------------------------------------------------------------------
		public static DialogResult Show(Form FormOwner, string text,
			string Caption, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			FormMessage form = new FormMessage(FormOwner);
			form.Text = Caption;
			form.labelMessage.Text = text;
			form.SetKeys(buttons);
			form.SetIcon(icon);
			Font font = form.labelMessage.Font;
			Size sizeLabel = form.labelMessage.Size;
			Size sizeForm = form.Size;
			Rectangle screenRectangle = form.RectangleToScreen(form.ClientRectangle);
			int titleBarHeight = screenRectangle.Top - form.Top;
			Size sizeText = TextRenderer.MeasureText(text, font);
			form.Size = new Size(sizeText.Width + (sizeForm.Width - sizeLabel.Width),
			                     sizeText.Height + (sizeForm.Height - sizeLabel.Height) +
			                     titleBarHeight);
			form.StartPosition = (FormOwner ==  null)?
				FormStartPosition.CenterScreen:
				FormStartPosition.CenterParent;
			form.ShowDialog(FormOwner);
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
					pictureBoxIcon.Image = Resources.IconQuestion;
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
			List<Button> buttonActive = new List<Button>();
			int intGap = buttonOne.Left, intWidth = buttonOne.Width;
			foreach(Button b in buttonArr) {
				b.Width = intWidth;
				if(b.Visible)
					buttonActive.Add(b);
			}
			
			int intAllButtonsWidth = (intGap + intWidth) * buttonActive.Count;			
			int intLastLeft = (Width - intAllButtonsWidth / 2);
			foreach(Button b in buttonActive) {
				b.Left = intLastLeft;
				intLastLeft += intGap + intWidth;
				MessageBox.Show("Yes");
			}
		}
	}
}
//---------------------------------------------------------------------------------------
