namespace Test_ArdeshirV.Forms
{
    partial class FormMainTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        //private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMainTest));
            this.buttonNewForm = new System.Windows.Forms.Button();
            this.buttonErrorHandlerForm = new System.Windows.Forms.Button();
            this.buttonFormAbout = new System.Windows.Forms.Button();
            this.buttonShrinkWidth = new System.Windows.Forms.Button();
            this.buttonShrinkHeight = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonSplashForm = new System.Windows.Forms.Button();
            this.m_lblMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonNewForm
            // 
            this.buttonNewForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonNewForm.Location = new System.Drawing.Point(32, 192);
            this.buttonNewForm.Name = "buttonNewForm";
            this.buttonNewForm.Size = new System.Drawing.Size(111, 23);
            this.buttonNewForm.TabIndex = 2;
            this.buttonNewForm.Text = "New SpecialForm ...";
            this.buttonNewForm.UseVisualStyleBackColor = true;
            this.buttonNewForm.Click += new System.EventHandler(this.buttonNewForm_Click);
            // 
            // buttonErrorHandlerForm
            // 
            this.buttonErrorHandlerForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonErrorHandlerForm.Location = new System.Drawing.Point(32, 163);
            this.buttonErrorHandlerForm.Name = "buttonErrorHandlerForm";
            this.buttonErrorHandlerForm.Size = new System.Drawing.Size(111, 23);
            this.buttonErrorHandlerForm.TabIndex = 1;
            this.buttonErrorHandlerForm.Text = "Form Error Handler ...";
            this.buttonErrorHandlerForm.UseVisualStyleBackColor = true;
            this.buttonErrorHandlerForm.Click += new System.EventHandler(this.buttonErrorHandlerForm_Click);
            // 
            // buttonFormAbout
            // 
            this.buttonFormAbout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonFormAbout.Location = new System.Drawing.Point(32, 134);
            this.buttonFormAbout.Name = "buttonFormAbout";
            this.buttonFormAbout.Size = new System.Drawing.Size(111, 23);
            this.buttonFormAbout.TabIndex = 0;
            this.buttonFormAbout.Text = "Form &About ...";
            this.buttonFormAbout.UseVisualStyleBackColor = true;
            this.buttonFormAbout.Click += new System.EventHandler(this.buttonFormAbout_Click);
            // 
            // buttonShrinkWidth
            // 
            this.buttonShrinkWidth.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonShrinkWidth.Location = new System.Drawing.Point(32, 47);
            this.buttonShrinkWidth.Name = "buttonShrinkWidth";
            this.buttonShrinkWidth.Size = new System.Drawing.Size(111, 23);
            this.buttonShrinkWidth.TabIndex = 3;
            this.buttonShrinkWidth.Text = "Shrink Width";
            this.buttonShrinkWidth.UseVisualStyleBackColor = true;
            this.buttonShrinkWidth.Click += new System.EventHandler(this.buttonShrinkWidth_Click);
            // 
            // buttonShrinkHeight
            // 
            this.buttonShrinkHeight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonShrinkHeight.Location = new System.Drawing.Point(32, 76);
            this.buttonShrinkHeight.Name = "buttonShrinkHeight";
            this.buttonShrinkHeight.Size = new System.Drawing.Size(111, 23);
            this.buttonShrinkHeight.TabIndex = 4;
            this.buttonShrinkHeight.Text = "Shrink Height";
            this.buttonShrinkHeight.UseVisualStyleBackColor = true;
            this.buttonShrinkHeight.Click += new System.EventHandler(this.buttonShrinkHeight_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonExit.Location = new System.Drawing.Point(32, 221);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(111, 23);
            this.buttonExit.TabIndex = 6;
            this.buttonExit.Text = "E&xit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonSplashForm
            // 
            this.buttonSplashForm.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSplashForm.Location = new System.Drawing.Point(32, 105);
            this.buttonSplashForm.Name = "buttonSplashForm";
            this.buttonSplashForm.Size = new System.Drawing.Size(111, 23);
            this.buttonSplashForm.TabIndex = 5;
            this.buttonSplashForm.Text = "&Splash Form ...";
            this.buttonSplashForm.UseVisualStyleBackColor = true;
            this.buttonSplashForm.Click += new System.EventHandler(this.buttonSplashForm_Click);
            // 
            // m_lblMessage
            // 
            this.m_lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblMessage.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_lblMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_lblMessage.Location = new System.Drawing.Point(12, 9);
            this.m_lblMessage.Name = "m_lblMessage";
            this.m_lblMessage.Size = new System.Drawing.Size(151, 14);
            this.m_lblMessage.TabIndex = 7;
            this.m_lblMessage.Text = "XXX";
            this.m_lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMainTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(175, 275);
            this.Controls.Add(this.m_lblMessage);
            this.Controls.Add(this.buttonSplashForm);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonShrinkHeight);
            this.Controls.Add(this.buttonShrinkWidth);
            this.Controls.Add(this.buttonFormAbout);
            this.Controls.Add(this.buttonErrorHandlerForm);
            this.Controls.Add(this.buttonNewForm);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(160, 275);
            this.Name = "FormMainTest";
            this.Text = "Test ArdeshirV.Forms";
            this.Resize += new System.EventHandler(this.TestArdeshirV_Forms_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNewForm;
        private System.Windows.Forms.Button buttonErrorHandlerForm;
        private System.Windows.Forms.Button buttonFormAbout;
        private System.Windows.Forms.Button buttonShrinkWidth;
        private System.Windows.Forms.Button buttonShrinkHeight;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Button buttonSplashForm;
        private System.Windows.Forms.Label m_lblMessage;
    }
}

