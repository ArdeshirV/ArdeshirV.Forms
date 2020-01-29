#region Header

// ArdeshirV.Forms Project
// FormInput.Designer.cs : Provides a Cutomized InputBox
// Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under LGPLv3+

using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing.Drawing2D;

#endregion
//---------------------------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
	partial class FormInput		
	{
		#region Variables

		private Label labelInputMessage;
		private Button buttonCancel;
		private Button buttonOK;
		private TextBox textBoxInput;
		
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ErrorProvider errorProvider;
		
		#endregion
		//-----------------------------------------------------------------------------------------------
		#region Dispose
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		#endregion Dispose
		//-----------------------------------------------------------------------------------------------
		#region InitializeComponent

		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.buttonOK = new System.Windows.Forms.Button();
			this.labelInputMessage = new System.Windows.Forms.Label();
			this.textBoxInput = new System.Windows.Forms.TextBox();
			this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonCancel
			// 
			this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(142, 82);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 0;
			this.buttonCancel.Text = "&Cancel";
			this.buttonCancel.UseVisualStyleBackColor = true;
			// 
			// buttonOK
			// 
			this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOK.Location = new System.Drawing.Point(61, 82);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 1;
			this.buttonOK.Text = "&OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
			// 
			// labelInputMessage
			// 
			this.labelInputMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.labelInputMessage.BackColor = System.Drawing.Color.Transparent;
			this.labelInputMessage.Location = new System.Drawing.Point(22, 9);
			this.labelInputMessage.Name = "labelInputMessage";
			this.labelInputMessage.Size = new System.Drawing.Size(195, 19);
			this.labelInputMessage.TabIndex = 2;
			this.labelInputMessage.Text = "Enter Input Value: ";
			this.labelInputMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxInput
			// 
			this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxInput.Location = new System.Drawing.Point(22, 30);
			this.textBoxInput.Multiline = true;
			this.textBoxInput.Name = "textBoxInput";
			this.textBoxInput.Size = new System.Drawing.Size(195, 46);
			this.textBoxInput.TabIndex = 3;
			this.textBoxInput.Text = "Input value goes here";
			// 
			// errorProvider
			// 
			this.errorProvider.ContainerControl = this;
			// 
			// FormInput
			// 
			this.AcceptButton = this.buttonOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(239, 117);
			this.ControlBox = false;
			this.Controls.Add(this.textBoxInput);
			this.Controls.Add(this.labelInputMessage);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.buttonCancel);
			this.MinimumSize = new System.Drawing.Size(216, 133);
			this.Name = "FormInput";
			this.Text = "Input";
			this.Shown += new System.EventHandler(this.FormInputShown);
			((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		
		#endregion InitializeComponent
	}
}
