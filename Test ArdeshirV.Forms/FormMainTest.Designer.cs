using System.Windows.Forms;

namespace ArdeshirV.TestForms
{
    partial class FormMainTest
    {        
        #region Dispose

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        /*protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }*/
        
        #endregion
        //-------------------------------------------------------------------------------------
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainTest));
        	this.buttonNewForm = new Button();
        	this.buttonErrorHandlerForm = new Button();
        	this.buttonFormAbout = new Button();
        	this.buttonShrinkWidth = new Button();
        	this.buttonShrinkHeight = new Button();
        	this.buttonExit = new Button();
        	this.buttonSplashForm = new Button();
        	this.m_lblMessage = new Label();
        	this.ButtonFormMessage = new Button();
        	this.ButtonInput = new Button();
        	this.SuspendLayout();
        	// 
        	// buttonNewForm
        	// 
        	this.buttonNewForm.Anchor = AnchorStyles.None;
        	this.buttonNewForm.Location = new System.Drawing.Point(70, 268);
        	this.buttonNewForm.Name = "buttonNewForm";
        	this.buttonNewForm.Size = new System.Drawing.Size(111, 23);
        	this.buttonNewForm.TabIndex = 2;
        	this.buttonNewForm.Text = "New SpecialForm ...";
        	this.buttonNewForm.UseVisualStyleBackColor = true;
        	this.buttonNewForm.Click += new System.EventHandler(this.buttonNewForm_Click);
        	// 
        	// buttonErrorHandlerForm
        	// 
        	this.buttonErrorHandlerForm.Anchor = AnchorStyles.None;
        	this.buttonErrorHandlerForm.Location = new System.Drawing.Point(70, 239);
        	this.buttonErrorHandlerForm.Name = "buttonErrorHandlerForm";
        	this.buttonErrorHandlerForm.Size = new System.Drawing.Size(111, 23);
        	this.buttonErrorHandlerForm.TabIndex = 1;
        	this.buttonErrorHandlerForm.Text = "Form Error Handler ...";
        	this.buttonErrorHandlerForm.UseVisualStyleBackColor = true;
        	this.buttonErrorHandlerForm.Click += new System.EventHandler(this.buttonErrorHandlerForm_Click);
        	// 
        	// buttonFormAbout
        	// 
        	this.buttonFormAbout.Anchor = AnchorStyles.None;
        	this.buttonFormAbout.Location = new System.Drawing.Point(70, 210);
        	this.buttonFormAbout.Name = "buttonFormAbout";
        	this.buttonFormAbout.Size = new System.Drawing.Size(111, 23);
        	this.buttonFormAbout.TabIndex = 0;
        	this.buttonFormAbout.Text = "Form &About ...";
        	this.buttonFormAbout.UseVisualStyleBackColor = true;
        	this.buttonFormAbout.Click += new System.EventHandler(this.buttonFormAbout_Click);
        	// 
        	// buttonShrinkWidth
        	// 
        	this.buttonShrinkWidth.Anchor = AnchorStyles.None;
        	this.buttonShrinkWidth.Location = new System.Drawing.Point(70, 65);
        	this.buttonShrinkWidth.Name = "buttonShrinkWidth";
        	this.buttonShrinkWidth.Size = new System.Drawing.Size(111, 23);
        	this.buttonShrinkWidth.TabIndex = 3;
        	this.buttonShrinkWidth.Text = "Shrink &Horizontaly";
        	this.buttonShrinkWidth.UseVisualStyleBackColor = true;
        	this.buttonShrinkWidth.Click += new System.EventHandler(this.buttonShrinkWidth_Click);
        	// 
        	// buttonShrinkHeight
        	// 
        	this.buttonShrinkHeight.Anchor = AnchorStyles.None;
        	this.buttonShrinkHeight.Location = new System.Drawing.Point(70, 94);
        	this.buttonShrinkHeight.Name = "buttonShrinkHeight";
        	this.buttonShrinkHeight.Size = new System.Drawing.Size(111, 23);
        	this.buttonShrinkHeight.TabIndex = 4;
        	this.buttonShrinkHeight.Text = "Shrink &Verticaly";
        	this.buttonShrinkHeight.UseVisualStyleBackColor = true;
        	this.buttonShrinkHeight.Click += new System.EventHandler(this.buttonShrinkHeight_Click);
        	// 
        	// buttonExit
        	// 
        	this.buttonExit.Anchor = AnchorStyles.None;
        	this.buttonExit.Location = new System.Drawing.Point(70, 297);
        	this.buttonExit.Name = "buttonExit";
        	this.buttonExit.Size = new System.Drawing.Size(111, 23);
        	this.buttonExit.TabIndex = 6;
        	this.buttonExit.Text = "E&xit";
        	this.buttonExit.UseVisualStyleBackColor = true;
        	this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
        	// 
        	// buttonSplashForm
        	// 
        	this.buttonSplashForm.Anchor = AnchorStyles.None;
        	this.buttonSplashForm.Location = new System.Drawing.Point(70, 123);
        	this.buttonSplashForm.Name = "buttonSplashForm";
        	this.buttonSplashForm.Size = new System.Drawing.Size(111, 23);
        	this.buttonSplashForm.TabIndex = 5;
        	this.buttonSplashForm.Text = "&Splash Form ...";
        	this.buttonSplashForm.UseVisualStyleBackColor = true;
        	this.buttonSplashForm.Click += new System.EventHandler(this.buttonSplashForm_Click);
        	// 
        	// m_lblMessage
        	// 
        	this.m_lblMessage.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
			| AnchorStyles.Right)));
        	this.m_lblMessage.BackColor = System.Drawing.SystemColors.ActiveCaption;
        	this.m_lblMessage.FlatStyle = FlatStyle.System;
        	this.m_lblMessage.Location = new System.Drawing.Point(12, 9);
        	this.m_lblMessage.Name = "m_lblMessage";
        	this.m_lblMessage.Size = new System.Drawing.Size(224, 14);
        	this.m_lblMessage.TabIndex = 7;
        	this.m_lblMessage.Text = "XXX";
        	this.m_lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// ButtonFormMessage
        	// 
        	this.ButtonFormMessage.Anchor = AnchorStyles.None;
        	this.ButtonFormMessage.Location = new System.Drawing.Point(70, 152);
        	this.ButtonFormMessage.Name = "ButtonFormMessage";
        	this.ButtonFormMessage.Size = new System.Drawing.Size(111, 23);
        	this.ButtonFormMessage.TabIndex = 8;
        	this.ButtonFormMessage.Text = "Form &Message...";
        	this.ButtonFormMessage.UseVisualStyleBackColor = true;
        	this.ButtonFormMessage.Click += new System.EventHandler(this.ButtonFormMessageClick);
        	// 
        	// ButtonInput
        	// 
        	this.ButtonInput.Anchor = AnchorStyles.None;
        	this.ButtonInput.Location = new System.Drawing.Point(70, 181);
        	this.ButtonInput.Name = "ButtonInput";
        	this.ButtonInput.Size = new System.Drawing.Size(111, 23);
        	this.ButtonInput.TabIndex = 9;
        	this.ButtonInput.Text = "Form &Input...";
        	this.ButtonInput.UseVisualStyleBackColor = true;
        	this.ButtonInput.Click += new System.EventHandler(this.ButtonInputClick);
        	// 
        	// FormMainTest
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = AutoScaleMode.Font;
        	this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        	this.ClientSize = new System.Drawing.Size(248, 370);
        	this.Controls.Add(this.ButtonInput);
        	this.Controls.Add(this.ButtonFormMessage);
        	this.Controls.Add(this.m_lblMessage);
        	this.Controls.Add(this.buttonSplashForm);
        	this.Controls.Add(this.buttonExit);
        	this.Controls.Add(this.buttonShrinkHeight);
        	this.Controls.Add(this.buttonShrinkWidth);
        	this.Controls.Add(this.buttonFormAbout);
        	this.Controls.Add(this.buttonErrorHandlerForm);
        	this.Controls.Add(this.buttonNewForm);
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MinimumSize = new System.Drawing.Size(160, 337);
        	this.Name = "FormMainTest";
        	this.Text = "Test ArdeshirV.Forms";
        	this.Resize += new System.EventHandler(this.TestArdeshirV_Forms_Resize);
        	this.ResumeLayout(false);

        }

        #endregion
        //-------------------------------------------------------------------------------------
        #region Variables

        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

        private Button buttonNewForm;
        private Button buttonErrorHandlerForm;
        private Button buttonFormAbout;
        private Button buttonShrinkWidth;
        private Button buttonShrinkHeight;
        private Button buttonExit;
        private Button buttonSplashForm;
        private Label m_lblMessage;
        private Button ButtonFormMessage;
        private Button ButtonInput;
        
        #endregion
    }
}
