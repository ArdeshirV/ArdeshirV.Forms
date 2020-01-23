#region Header

// Form Input
// FormInput.cs : Gets user input values in string variable.
// Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under LGPLv3+

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion
//---------------------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
	/// <summary>
	/// Description of FormInput.
	/// </summary>
	public partial class FormInput : FormBase
	{
		#region Variables

		private const string stringDefaultInputMessage = "Enter input value: ";
		
		#endregion Variables
		//-------------------------------------------------------------------------------
		#region Constructor

		public FormInput(IWin32Window windowParent) : base(windowParent)
		{
			InitializeComponent();
			textBoxInput.Clear();
			FollowParentFormBase = true;
			labelInputMessage.Text = stringDefaultInputMessage;
			
			if(windowParent is Form)
				StartPosition = FormStartPosition.CenterParent;
			else
				StartPosition = FormStartPosition.CenterScreen;
		}
		
		#endregion Constructor
		//-------------------------------------------------------------------------------
		/// <summary>
		/// Displays an input box with the specified message and size.
		/// </summary>
		/// <param name="windowParent">Owner form.</param>
		/// <param name="Value">The text output.</param>
		/// <returns>One of DialogResult values</returns>
		public static DialogResult Show(IWin32Window windowParent, out string Value) {
			return Show(windowParent, out Value, stringDefaultInputMessage,
			            GetCaption(windowParent), Size.Empty);
		}
		//-------------------------------------------------------------------------------
		/// <summary>
		/// Displays an input box with the specified message and size.
		/// </summary>
		/// <param name="windowParent">Owner form.</param>
		/// <param name="Value">The text output.</param>
		/// <param name="InputMessage">The message in input box.</param>
		/// <returns>One of DialogResult values</returns>
		public static DialogResult Show(IWin32Window windowParent,
			out string Value, string InputMessage) {
			return Show(windowParent, out Value, InputMessage,
			            GetCaption(windowParent), Size.Empty);
		}
		//-------------------------------------------------------------------------------
		/// <summary>
		/// Displays an input box with the specified message and size.
		/// </summary>
		/// <param name="windowParent">Owner form.</param>
		/// <param name="Value">The text output.</param>
		/// <param name="InputMessage">The message in input box.</param>
		/// <param name="Caption">Form input caption.</param>
		/// <returns>One of DialogResult values</returns>
		public static DialogResult Show(IWin32Window windowParent,
			out string Value, string InputMessage, string Caption) {
			return Show(windowParent, out Value, InputMessage, Caption, Size.Empty);
		}
		//-------------------------------------------------------------------------------
		/// <summary>
		/// Displays an input box with the specified message and size.
		/// </summary>
		/// <param name="windowParent">Owner form.</param>
		/// <param name="Value">The text output.</param>
		/// <param name="InputMessage">The message in input box.</param>
		/// <param name="Caption">Form input caption.</param>
		/// <param name="formSize">Form input size.</param>
		/// <returns>One of DialogResult values</returns>
		public static DialogResult Show(IWin32Window windowParent,
			out string Value, string InputMessage, string Caption, Size formSize)
		{
			FormInput form = new FormInput(windowParent);
			form.labelInputMessage.Text = InputMessage;
			form.Text =  Caption;
			if(formSize != Size.Empty)
				form.Size = formSize;
			DialogResult result = form.ShowDialog(windowParent);
			Value = form.textBoxInput.Text;
			return result;
		}
		//-------------------------------------------------------------------------------
		private static string GetCaption(IWin32Window windowParent) {
			return (windowParent is Form && windowParent != null)?
				(windowParent as Form).Text: string.Empty;
		}
		//-------------------------------------------------------------------------------
		void FormInputShown(object sender, EventArgs e)
		{
			textBoxInput.Focus();
		}
	}
}
//---------------------------------------------------------------------------------------