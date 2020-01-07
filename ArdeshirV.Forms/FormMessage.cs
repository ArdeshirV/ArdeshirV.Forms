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
			StartPosition = FormStartPosition.CenterParent;
		}
		//-------------------------------------------------------------------------------
		public static new FormMessage Show() 
		{
			//MessageBoxButtons.
			
			FormMessage form = new FormMessage();
			form.ShowDialog();
			return form;
		}
		//-------------------------------------------------------------------------------
		public void ButtonOKClick(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}
	}
}
