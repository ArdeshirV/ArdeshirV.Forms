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
		private Button ButtonNo;
		private Button ButtonOK;
		private Button ButtonYes;
		private Label LabelMessage;
		private Button ButtonCancel;
		private ImageList imageListIcons;
		private PictureBox pictureBoxIcon;
		private System.ComponentModel.IContainer components = null;
		
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessage));
			this.ButtonOK = new Button();
			this.ButtonCancel = new Button();
			this.pictureBoxIcon = new PictureBox();
			this.ButtonYes = new Button();
			this.ButtonNo = new Button();
			this.imageListIcons = new ImageList(this.components);
			this.LabelMessage = new Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// ButtonOK
			// 
			this.ButtonOK.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.ButtonOK.Location = new System.Drawing.Point(456, 152);
			this.ButtonOK.Name = "ButtonOK";
			this.ButtonOK.Size = new System.Drawing.Size(75, 23);
			this.ButtonOK.TabIndex = 0;
			this.ButtonOK.Text = "&OK";
			this.ButtonOK.UseVisualStyleBackColor = true;
			this.ButtonOK.Click += new System.EventHandler(this.ButtonOKClick);
			// 
			// ButtonCancel
			// 
			this.ButtonCancel.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.ButtonCancel.Location = new System.Drawing.Point(375, 152);
			this.ButtonCancel.Name = "ButtonCancel";
			this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
			this.ButtonCancel.TabIndex = 1;
			this.ButtonCancel.Text = "&Cancel";
			this.ButtonCancel.UseVisualStyleBackColor = true;
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxIcon.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxIcon.Image")));
			this.pictureBoxIcon.Location = new System.Drawing.Point(12, 12);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(137, 137);
			this.pictureBoxIcon.SizeMode = PictureBoxSizeMode.StretchImage;
			this.pictureBoxIcon.TabIndex = 2;
			this.pictureBoxIcon.TabStop = false;
			// 
			// ButtonYes
			// 
			this.ButtonYes.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.ButtonYes.Location = new System.Drawing.Point(294, 152);
			this.ButtonYes.Name = "ButtonYes";
			this.ButtonYes.Size = new System.Drawing.Size(75, 23);
			this.ButtonYes.TabIndex = 3;
			this.ButtonYes.Text = "&Yes";
			this.ButtonYes.UseVisualStyleBackColor = true;
			// 
			// ButtonNo
			// 
			this.ButtonNo.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.ButtonNo.Location = new System.Drawing.Point(213, 152);
			this.ButtonNo.Name = "ButtonNo";
			this.ButtonNo.Size = new System.Drawing.Size(75, 23);
			this.ButtonNo.TabIndex = 4;
			this.ButtonNo.Text = "&No";
			this.ButtonNo.UseVisualStyleBackColor = true;
			// 
			// imageListIcons
			// 
			this.imageListIcons.ImageStream = ((ImageListStreamer)(resources.GetObject("imageListIcons.ImageStream")));
			this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListIcons.Images.SetKeyName(0, "Question");
			this.imageListIcons.Images.SetKeyName(1, "Information");
			this.imageListIcons.Images.SetKeyName(2, "Error");
			// 
			// LabelMessage
			// 
			this.LabelMessage.BackColor = System.Drawing.Color.Transparent;
			this.LabelMessage.Location = new System.Drawing.Point(155, 12);
			this.LabelMessage.Name = "LabelMessage";
			this.LabelMessage.Size = new System.Drawing.Size(376, 137);
			this.LabelMessage.TabIndex = 5;
			this.LabelMessage.Text = "Message";
			this.LabelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// FormMessage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(546, 189);
			this.ControlBox = false;
			this.Controls.Add(this.LabelMessage);
			this.Controls.Add(this.ButtonNo);
			this.Controls.Add(this.ButtonYes);
			this.Controls.Add(this.pictureBoxIcon);
			this.Controls.Add(this.ButtonCancel);
			this.Controls.Add(this.ButtonOK);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.Name = "FormMessage";
			this.Text = "FormMessage";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.ResumeLayout(false);

		}
		
		#endregion InitializeComponent
	}
}
