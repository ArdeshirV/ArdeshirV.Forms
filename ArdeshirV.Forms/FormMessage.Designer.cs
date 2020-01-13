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
		private Button buttonTwo;
		private Button buttonThree;
		private Label labelMessage;
		private PictureBox pictureBoxIcon;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// buttonOne
			// 
			this.buttonOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonOne.Location = new System.Drawing.Point(5, 3);
			this.buttonOne.Name = "buttonOne";
			this.buttonOne.Size = new System.Drawing.Size(75, 23);
			this.buttonOne.TabIndex = 1;
			this.buttonOne.Text = "One";
			this.buttonOne.UseVisualStyleBackColor = true;
			// 
			// buttonTwo
			// 
			this.buttonTwo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonTwo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonTwo.Location = new System.Drawing.Point(86, 3);
			this.buttonTwo.Name = "buttonTwo";
			this.buttonTwo.Size = new System.Drawing.Size(69, 23);
			this.buttonTwo.TabIndex = 2;
			this.buttonTwo.Text = "Two";
			this.buttonTwo.UseVisualStyleBackColor = true;
			// 
			// pictureBoxIcon
			// 
			this.pictureBoxIcon.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.pictureBoxIcon.BackColor = System.Drawing.Color.Transparent;
			this.pictureBoxIcon.Image = global::ArdeshirV.Forms.Properties.Resources.IconInfo;
			this.pictureBoxIcon.Location = new System.Drawing.Point(3, 3);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(42, 48);
			this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBoxIcon.TabIndex = 2;
			this.pictureBoxIcon.TabStop = false;
			// 
			// buttonThree
			// 
			this.buttonThree.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonThree.Location = new System.Drawing.Point(161, 3);
			this.buttonThree.Name = "buttonThree";
			this.buttonThree.Size = new System.Drawing.Size(75, 23);
			this.buttonThree.TabIndex = 3;
			this.buttonThree.Text = "Three";
			this.buttonThree.UseVisualStyleBackColor = true;
			// 
			// labelMessage
			// 
			this.labelMessage.BackColor = System.Drawing.Color.Transparent;
			this.labelMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelMessage.Location = new System.Drawing.Point(51, 0);
			this.labelMessage.Name = "labelMessage";
			this.labelMessage.Size = new System.Drawing.Size(187, 55);
			this.labelMessage.TabIndex = 0;
			this.labelMessage.Text = "Message";
			this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Controls.Add(this.buttonThree, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonTwo, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonOne, 0, 0);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 72);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(241, 29);
			this.tableLayoutPanel1.TabIndex = 4;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.pictureBoxIcon, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.labelMessage, 1, 0);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 12);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(241, 55);
			this.tableLayoutPanel2.TabIndex = 5;
			// 
			// FormMessage
			// 
			this.AcceptButton = this.buttonOne;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonTwo;
			this.ClientSize = new System.Drawing.Size(265, 106);
			this.ControlBox = false;
			this.Controls.Add(this.tableLayoutPanel2);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormMessage";
			this.Text = "FormMessage";
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxIcon)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		
		#endregion InitializeComponent
	}
}
