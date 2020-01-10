#region Header

// Form Input
// FormInput.cs : Gets user input values in string variable.
// Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under LGPLv3+

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion
//-----------------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
	/// <summary>
	/// Description of FormInput.
	/// </summary>
	public partial class FormInput : FormBase
	{
		public FormInput(IWin32Window windowParent) : base(windowParent)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------------
		public static new FormInput Show(IWin32Window windowParent)
		{
			FormInput form = new FormInput(windowParent);
            form.ShowDialog(windowParent);
			return form;
		}
	}
}
