#region Header

// ArdeshirV.Forms Project
// FormMessage.Designer.cs : Provides a Cutomized MessageBox
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
	partial class FormMessage
	{
		#region Variables

		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		private Button buttonOne;
		private Button buttonThree;
		private Label labelMessage;
		private Button buttonTwo;
		private PictureBox pictureBoxIcon;
		
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
			this.buttonOne = new System.Windows.Forms.Button();
			this.buttonTwo = new System.Windows.Forms.Button();
			this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
			this.buttonThree = new System.Windows.Forms.Button();
			this.labelMessage = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonOne
			// 
			this.buttonOne.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonOne.Location = new System.Drawing.Point(75, 95);
			this.buttonOne.Name = "buttonOne";
			this.buttonOne.Size = new System.Drawing.Size(75, 23);
			this.buttonOne.TabIndex = 1;
			this.buttonOne.Text = "One";
			this.buttonOne.UseVisualStyleBackColor = true;
			// 
			// buttonTwo
			// 
			this.buttonTwo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonTwo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonTwo.Location = new System.Drawing.Point(156, 95);
			this.buttonTwo.Name = "buttonTwo";
			this.buttonTwo.Size = new System.Drawing.Size(75, 23);
			this.buttonTwo.TabIndex = 2;
			this.buttonTwo.Text = "Two";
			this.buttonTwo.UseVisualStyleBackColor = true;
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.pictureBoxIcon.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxIcon.Image = global::ArdeshirV.Forms.Properties.Resources.IconInfo;
			this.pictureBoxIcon.Location = new System.Drawing.Point(12, 27);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(48, 48);
			this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxIcon.TabIndex = 2;
			this.pictureBoxIcon.TabStop = false;
			// 
			// buttonThree
			// 
			this.buttonThree.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonThree.Location = new System.Drawing.Point(237, 95);
			this.buttonThree.Name = "buttonThree";
			this.buttonThree.Size = new System.Drawing.Size(75, 23);
			this.buttonThree.TabIndex = 3;
			this.buttonThree.Text = "Three";
			this.buttonThree.UseVisualStyleBackColor = true;
			// 
			// labelMessage
			// 
			this.labelMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.labelMessage.BackColor = System.Drawing.Color.Transparent;
			this.labelMessage.Location = new System.Drawing.Point(66, 9);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(306, 83);
			this.labelMessage.TabIndex = 0;
			this.labelMessage.Text = "Message";
			this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormMessage
			// 
			this.AcceptButton = this.buttonOne;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonTwo;
			this.ClientSize = new System.Drawing.Size(383, 130);
			this.ControlBox = false;
			this.Controls.Add(this.labelMessage);
			this.Controls.Add(this.buttonThree);
			this.Controls.Add(this.pictureBoxIcon);
			this.Controls.Add(this.buttonTwo);
			this.Controls.Add(this.buttonOne);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MinimumSize = new System.Drawing.Size(276, 140);
			this.Name = "FormMessage";
			this.Text = "FormMessage";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.ResumeLayout(false);

		}
		
		#endregion InitializeComponent
	}
}
