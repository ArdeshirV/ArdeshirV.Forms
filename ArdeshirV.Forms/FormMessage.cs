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
		private int intKeyCount = 0;
		protected FormMessage(IWin32Window windowParent) : base(windowParent)
		{
			InitializeComponent();
			FollowParentFormBase = true;
			labelMessage.Text = "Message goes here.";
			StartPosition = FormStartPosition.CenterParent;
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
			//form.labelMessage.Size = sizeText;
			form.Size = new Size(sizeText.Width + (sizeForm.Width - sizeLabel.Width),
			                     sizeText.Height + (sizeForm.Height - sizeLabel.Height) +
			                     titleBarHeight);
			form.StartPosition = (FormOwner ==  null)?
				FormStartPosition.CenterScreen:
				FormStartPosition.CenterParent;
			int intMinWidth = form.GetMinimumWidth();
			if(form.Width < intMinWidth)
				form.Width = intMinWidth;
			int intMinHeight = (icon == MessageBoxIcon.None)? 118: 147;
			if(form.Height < intMinHeight)
				form.Height = intMinHeight;
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
					tableLayoutPanelIcon.Visible = false;
					labelMessage.Location = new Point(12, 12);
					labelMessage.Width = Width - 24;
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
					intKeyCount = 1;
					buttonTwo.Visible = true;
					buttonTwo.Text = "&OK";
					buttonTwo.DialogResult = DialogResult.OK;
					buttonOne.Visible = false;
					buttonThree.Visible = false;
					AcceptButton = buttonTwo;
					break;
				case MessageBoxButtons.OKCancel:
					intKeyCount = 2;
					buttonOne.Visible = true;
					buttonOne.Text = "&OK";
					buttonOne.DialogResult = DialogResult.OK;
					buttonThree.Visible = true;
					buttonThree.Text = "&Cancel";
					buttonThree.DialogResult = DialogResult.Cancel;
					buttonTwo.Visible = false;
					AcceptButton = buttonOne;
					CancelButton = buttonThree;
					break;
				case MessageBoxButtons.YesNo:
					intKeyCount = 2;
					buttonOne.Visible = true;
					buttonOne.Text = "&Yes";
					buttonOne.DialogResult = DialogResult.Yes;
					buttonThree.Visible = true;
					buttonThree.Text = "&No";
					buttonThree.DialogResult = DialogResult.No;
					buttonTwo.Visible = false;
					AcceptButton = buttonOne;
					CancelButton = buttonThree;
					break;
				case MessageBoxButtons.YesNoCancel:
					intKeyCount = 3;
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
					intKeyCount = 2;
					buttonOne.Visible = true;
					buttonOne.Text = "&Retry";
					buttonOne.DialogResult = DialogResult.Retry;
					buttonThree.Visible = true;
					buttonThree.Text = "&Cancel";
					buttonThree.DialogResult = DialogResult.Retry;
					buttonTwo.Visible = false;
					AcceptButton = buttonOne;
					CancelButton = buttonThree;
					break;
				case MessageBoxButtons.AbortRetryIgnore:
					intKeyCount = 3;
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
			
			if(intKeyCount == 2)
				HideCenterButton();
		}
		//-------------------------------------------------------------------------------
		private int GetMinimumWidth()
		{
			int intWidth = 269, intButtonWidth = 70;
			return intWidth - intButtonWidth * (3 - intKeyCount);
		}
		//-------------------------------------------------------------------------------
		private void HideCenterButton() {
			tableLayoutPanelBottom.ColumnStyles[1].SizeType = SizeType.Percent;
			tableLayoutPanelBottom.ColumnStyles[1].Width = 0;
		}
	}
}
//---------------------------------------------------------------------------------------
