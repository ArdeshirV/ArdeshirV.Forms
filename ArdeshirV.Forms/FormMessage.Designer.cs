/*
 * Created by SharpDevelop.
 * User: asha
 * Date: 12/11/2019
 * Time: 6:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ArdeshirV.Forms
{
	partial class FormMessage
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button ButtonOK;
		private System.Windows.Forms.Button ButtonCancel;
		private System.Windows.Forms.PictureBox pictureBoxIcon;
		private System.Windows.Forms.Button ButtonYes;
		private System.Windows.Forms.Button ButtonNo;
		private System.Windows.Forms.ImageList imageListIcons;
		private System.Windows.Forms.Label LabelMessage;
		
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
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessage));
			this.ButtonOK = new System.Windows.Forms.Button();
			this.ButtonCancel = new System.Windows.Forms.Button();
			this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
			this.ButtonYes = new System.Windows.Forms.Button();
			this.ButtonNo = new System.Windows.Forms.Button();
			this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
			this.LabelMessage = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.SuspendLayout();
			// 
			// ButtonOK
			// 
			this.ButtonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
			this.ButtonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
			this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxIcon.TabIndex = 2;
			this.pictureBoxIcon.TabStop = false;
			// 
			// ButtonYes
			// 
			this.ButtonYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonYes.Location = new System.Drawing.Point(294, 152);
			this.ButtonYes.Name = "ButtonYes";
			this.ButtonYes.Size = new System.Drawing.Size(75, 23);
			this.ButtonYes.TabIndex = 3;
			this.ButtonYes.Text = "&Yes";
			this.ButtonYes.UseVisualStyleBackColor = true;
			// 
			// ButtonNo
			// 
			this.ButtonNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ButtonNo.Location = new System.Drawing.Point(213, 152);
			this.ButtonNo.Name = "ButtonNo";
			this.ButtonNo.Size = new System.Drawing.Size(75, 23);
			this.ButtonNo.TabIndex = 4;
			this.ButtonNo.Text = "&No";
			this.ButtonNo.UseVisualStyleBackColor = true;
			// 
			// imageListIcons
			// 
			this.imageListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIcons.ImageStream")));
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
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(546, 189);
			this.ControlBox = false;
			this.Controls.Add(this.LabelMessage);
			this.Controls.Add(this.ButtonNo);
			this.Controls.Add(this.ButtonYes);
			this.Controls.Add(this.pictureBoxIcon);
			this.Controls.Add(this.ButtonCancel);
			this.Controls.Add(this.ButtonOK);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormMessage";
			this.Text = "FormMessage";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.ResumeLayout(false);

		}
	}
}
