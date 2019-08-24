#region Header

// Form Error Handler
// Form Error Handler.cs : Provides Forn Error Handler
// Copyright© 2002-2019 ardeshirv@protonmail.com, Licensed under GPLv3+

using System;
using System.Drawing;
using System.Windows.Forms;

#endregion
//-----------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
    /// <summary>
    /// About Form in Vector Project.
    /// </summary>
    public class FormErrorHandler : ArdeshirV.Forms.SpecialForm
	{
        #region Variables

        private Exception exp;
        private int intMax = 400;
        private int intMin = 145;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnMore;
		private System.Windows.Forms.LinkLabel m_lnkLink;
		private System.Windows.Forms.TextBox m_txtMessage;

        private Label m_lblMessage;
        private string m_strLink = "";
		private bool m_blnIsShrinked = false;
        private Label m_lblStackTrack;
        private Button buttonInnerExp;
        private static bool s_blnIsExists = false;

        #endregion
        //---------------------------------------------------------------------
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="frmParent">Parent form</param>
        /// <param name="strLinkContents">Link value</param>
        /// <param name="strTechnicalSupportMail">Technical support mail address</param>
        protected FormErrorHandler(Exception expException, Form frmOwner, string strLinkSite)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;

            Opacity = 1.0;
            Height = intMin;
            exp = expException;
            m_strLink = strLinkSite;

            if (m_strLink == string.Empty || m_strLink == null)
                m_lnkLink.Visible = false;
            else
                m_lnkLink.Text = m_strLink;

            m_lblMessage.Text = expException.Message;
            m_txtMessage.Text = expException.StackTrace;
            buttonInnerExp.Enabled = (exp.InnerException != null);

            if (frmOwner == null)
                ShowDialog();
            else
                ShowDialog(frmOwner);
		}

		#endregion
        //---------------------------------------------------------------------
        #region Utility functions

        /// <summary>
        /// Show about-box form.
        /// </summary>
        /// <param name="expException">Exception</param>
        public static FormErrorHandler Show(Exception expException, Form frmOwner, string strLinkSite)
        {
            return new FormErrorHandler(expException, frmOwner, strLinkSite);
        }

        #endregion
        //---------------------------------------------------------------------
		#region Event Handlers

		/// <summary>
		/// Occurs whenever OK Button became Click.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOk_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		/// <summary>
		/// Linke to web site.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void lnkLink_LinkClicked(object sender,LinkLabelLinkClickedEventArgs e)
		{
			m_lnkLink.LinkVisited = true;
			System.Diagnostics.Process.Start(m_strLink);
		}

		/// <summary>
		/// Occurs whenever Dialog has been loaded.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmAbout_Load(object sender, System.EventArgs e)
		{
			if(s_blnIsExists)
				Close();
			else
				s_blnIsExists = true;
		}

		/// <summary>
		/// Occured whenever btnMore button has been clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnMore_Click(object sender, System.EventArgs e)
		{
            m_btnMore.Enabled = false;
			m_blnIsShrinked = !m_blnIsShrinked;

			if(Height <= 200)
            {
                ShrinkHeightByTime(intMax);
				m_btnMore.Text = "&Less <<";
			}
			else
            {
                ShrinkHeightByTime(intMin);
				m_btnMore.Text = "&More >>";
			}

            m_btnMore.Enabled = true;
		}

		/// <summary>
		/// Occured whnever btnSend button has been clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSend_Click(object sender, System.EventArgs e)
        {
            #region Hidden
            /*
			string l_strMessage;
            System.Net.Mail.MailMessage l_milMessage = new System.Net.Mail.MailMessage();

			l_strMessage =
				"User name: "  + Environment.UserName + "\n" +
				"Current date & time: " + System.DateTime.Now.ToString() + "\n" +
				"-------------------------------Contents------------------------\n" +
				m_txtMessage.Text + "\n" +
				"---------------------------------------------------------------\n";
			l_milMessage.To.Add(m_strTechnicalSupportMail);
			l_milMessage.From = new System.Net.Mail.MailAddress("nobody@somewhere.net");
			l_milMessage.Subject = "[SSTRobot]Automatic Sended from " + m_txtErrorMessage.Text;
			l_milMessage.Body = l_strMessage;
            l_milMessage.BodyEncoding = System.Text.Encoding.Unicode;

			try
			{
                System.Net.Mail.SmtpClient l_stpClient = new System.Net.Mail.SmtpClient();

                l_stpClient.Send(l_milMessage);
			}
			catch(Exception exp)
			{
				MessageBox.Show(this, exp.Message, "Error!", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			((Button)sender).Enabled = false;*/
            #endregion
        }

        private void FormErrorHandler_FormClosed(object sender, FormClosedEventArgs e)
        {
            s_blnIsExists = false;
        }

        private void ButtonInnerExp_Click(object sender, EventArgs e)
        {
            //if(exp.InnerException != null)
                FormErrorHandler.Show(exp.InnerException, ParentForm, m_strLink);
        }

		#endregion
		//---------------------------------------------------------------------
		#region overrided functions

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/*protected override void Dispose(bool disposing)
		{
			if(disposing)
				if(components != null)
					components.Dispose();

			base.Dispose(disposing);
		}*/

		#endregion
		//---------------------------------------------------------------------
		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_lnkLink = new System.Windows.Forms.LinkLabel();
            this.m_btnMore = new System.Windows.Forms.Button();
            this.m_txtMessage = new System.Windows.Forms.TextBox();
            this.m_lblMessage = new System.Windows.Forms.Label();
            this.m_lblStackTrack = new System.Windows.Forms.Label();
            this.buttonInnerExp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnOk.BackColor = System.Drawing.Color.Transparent;
            this.m_btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnOk.Location = new System.Drawing.Point(490, 12);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(82, 23);
            this.m_btnOk.TabIndex = 5;
            this.m_btnOk.Text = "&OK";
            this.m_btnOk.UseVisualStyleBackColor = false;
            this.m_btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // m_lnkLink
            // 
            this.m_lnkLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkLink.BackColor = System.Drawing.Color.Transparent;
            this.m_lnkLink.Location = new System.Drawing.Point(12, 81);
            this.m_lnkLink.Name = "m_lnkLink";
            this.m_lnkLink.Size = new System.Drawing.Size(472, 19);
            this.m_lnkLink.TabIndex = 1;
            this.m_lnkLink.TabStop = true;
            this.m_lnkLink.Text = "Technical Support";
            this.m_lnkLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkLink.UseCompatibleTextRendering = true;
            this.m_lnkLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLink_LinkClicked);
            // 
            // m_btnMore
            // 
            this.m_btnMore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnMore.BackColor = System.Drawing.Color.Transparent;
            this.m_btnMore.Location = new System.Drawing.Point(490, 70);
            this.m_btnMore.Name = "m_btnMore";
            this.m_btnMore.Size = new System.Drawing.Size(82, 23);
            this.m_btnMore.TabIndex = 4;
            this.m_btnMore.Text = "&More >>";
            this.m_btnMore.UseVisualStyleBackColor = false;
            this.m_btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // m_txtMessage
            // 
            this.m_txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtMessage.BackColor = System.Drawing.Color.Black;
            this.m_txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtMessage.ForeColor = System.Drawing.Color.Gold;
            this.m_txtMessage.Location = new System.Drawing.Point(12, 123);
            this.m_txtMessage.Multiline = true;
            this.m_txtMessage.Name = "m_txtMessage";
            this.m_txtMessage.ReadOnly = true;
            this.m_txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_txtMessage.Size = new System.Drawing.Size(560, 227);
            this.m_txtMessage.TabIndex = 3;
            this.m_txtMessage.Text = "Message";
            this.m_txtMessage.WordWrap = false;
            // 
            // m_lblMessage
            // 
            this.m_lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblMessage.BackColor = System.Drawing.Color.Transparent;
            this.m_lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(46)))), ((int)(((byte)(36)))));
            this.m_lblMessage.Location = new System.Drawing.Point(12, 9);
            this.m_lblMessage.Name = "m_lblMessage";
            this.m_lblMessage.Size = new System.Drawing.Size(472, 69);
            this.m_lblMessage.TabIndex = 0;
            this.m_lblMessage.Text = "Message";
            this.m_lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lblStackTrack
            // 
            this.m_lblStackTrack.BackColor = System.Drawing.Color.Transparent;
            this.m_lblStackTrack.Location = new System.Drawing.Point(12, 107);
            this.m_lblStackTrack.Name = "m_lblStackTrack";
            this.m_lblStackTrack.Size = new System.Drawing.Size(560, 13);
            this.m_lblStackTrack.TabIndex = 6;
            this.m_lblStackTrack.Text = "&Stack Track:";
            // 
            // buttonInnerExp
            // 
            this.buttonInnerExp.Location = new System.Drawing.Point(490, 41);
            this.buttonInnerExp.Name = "buttonInnerExp";
            this.buttonInnerExp.Size = new System.Drawing.Size(82, 23);
            this.buttonInnerExp.TabIndex = 7;
            this.buttonInnerExp.Text = "&Inner Error...";
            this.buttonInnerExp.UseVisualStyleBackColor = true;
            this.buttonInnerExp.Click += new System.EventHandler(this.ButtonInnerExp_Click);
            // 
            // FormErrorHandler
            // 
            this.ClientSize = new System.Drawing.Size(584, 107);
            this.Controls.Add(this.buttonInnerExp);
            this.Controls.Add(this.m_lblStackTrack);
            this.Controls.Add(this.m_txtMessage);
            this.Controls.Add(this.m_lblMessage);
            this.Controls.Add(this.m_lnkLink);
            this.Controls.Add(this.m_btnMore);
            this.Controls.Add(this.m_btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormErrorHandler";
            this.Opacity = 0D;
            this.ShowInTaskbar = false;
            this.Text = "Error";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormErrorHandler_FormClosed);
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        #endregion
    }
}


