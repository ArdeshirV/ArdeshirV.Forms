#region Header

// Form Error Handler.cs : Provides Forn Error Handler
// Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under LGPLv3+

using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

#endregion
//---------------------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
    /// <summary>
    /// About Form in Vector Project.
    /// </summary>
    public class FormErrorHandler : FormBase
	{
        #region Variables

        private Exception exp;
        private Button m_btnOk;
        private ToolTip toolTip;
        private Button m_btnMore;
        private Button buttonCopy;
		private LinkLabel m_lnkLink;
        private string m_strLink = "";
        private Label m_lblStackTrack;
        private Button buttonInnerExp;
        private TextBox textBoxMessage;
        private const int intMax = 450;
        private const int intMin = 188;
		private TextBox textBoxStackTrack;
        private readonly string strFileLine;
		private bool m_blnIsShrinked = false;
        private static bool s_blnIsExists = false;
        private System.ComponentModel.IContainer components;

        #endregion
        //-------------------------------------------------------------------------------
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="expException">Exception</param>
        /// <param name="frmOwner">Form parent</param>
        /// <param name="strLinkSite">Link value</param>
        protected FormErrorHandler(Exception expException,
                                   Form frmOwner, string strLinkSite) : base(frmOwner)
        {
            InitializeComponent();
            Opacity = 1.0;
            Height = intMin;
            exp = expException;
            m_strLink = strLinkSite;
            textBoxMessage.SelectedText = "";
			DialogResult = DialogResult.Cancel;
            //textBoxMessage.Text = expException.Message;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            Text = string.Format("{0} - Error", frmOwner.Text);
            string strTrack = textBoxStackTrack.Text = expException.StackTrace;
            
            const string strLine = ":line";
            if(strTrack.Contains(strLine))
            {
            	int intSlashIndex = strTrack.LastIndexOf("\\",
            		StringComparison.InvariantCulture);
            	
            	if(intSlashIndex > 0)
            		strFileLine = strTrack.Substring(intSlashIndex + 1);
			}
            
            string strMsgTitle = string.Empty;
            
            if(!string.IsNullOrEmpty(strFileLine))
            	strMsgTitle = string.Concat(
					strFileLine, Environment.NewLine, Environment.NewLine);
            
            textBoxMessage.Text = strMsgTitle + expException.Message;            
            buttonInnerExp.Enabled = (exp.InnerException != null);

			if (string.IsNullOrEmpty(m_strLink))
				m_lnkLink.Visible = false;
			else {
	        	if(frmOwner != null)
	        		m_lnkLink.Text = m_strLink;
	        			//string.Format("Visit {0} on the web", frmOwner.Text);
	        	else
	            	m_lnkLink.Text = m_strLink;
			}

            ShowDialog(frmOwner);
		}

		#endregion
        //-------------------------------------------------------------------------------
        #region Utility functions

        /// <summary>
        /// Shows error handler form
        /// </summary>
        public static FormErrorHandler Show(Exception exp,
                                            Form frmOwner, string strLinkSite)
        {
            return new FormErrorHandler(exp, frmOwner, strLinkSite);
        }
        
        /// <summary>
        /// Shows error handler form
        /// </summary>
        public static FormErrorHandler Show(Exception exp, Form frmOwner)
        {
            return new FormErrorHandler(exp, frmOwner, string.Empty);
        }

        #endregion
        //-------------------------------------------------------------------------------
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
		//-------------------------------------------------------------------------------
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
        //---------------------------------------------------------------------
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
		//-------------------------------------------------------------------------------
		/// <summary>
		/// Occured whenever btnMore button has been clicked.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnMore_Click(object sender, System.EventArgs e)
		{
            m_btnMore.Enabled = false;
			m_blnIsShrinked = !m_blnIsShrinked;

			if(Height <= intMin) {
                ShrinkHeightByTime(intMax);
				m_btnMore.Text = "&Less <<";
			} else {
                ShrinkHeightByTime(intMin);
				m_btnMore.Text = "&More >>";
			}

            m_btnMore.Enabled = true;
		}
		//-------------------------------------------------------------------------------
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
		//-------------------------------------------------------------------------------
        private void FormErrorHandler_FormClosed(object sender, FormClosedEventArgs e)
        {
            s_blnIsExists = false;
        }
        //---------------------------------------------------------------------
        private void ButtonInnerExp_Click(object sender, EventArgs e)
        {
            //if(exp.InnerException != null)
                FormErrorHandler.Show(exp.InnerException, ParentForm, m_strLink);
        }
        //---------------------------------------------------------------------
		void buttonCopy_Click(object sender, EventArgs e)
		{
			Clipboard.SetText(textBoxMessage.Text);
		}

		#endregion
		//-------------------------------------------------------------------------------
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
		//-------------------------------------------------------------------------------
		#region Windows Form Designer generated code

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.m_btnOk = new Button();
			this.m_lnkLink = new LinkLabel();
			this.m_btnMore = new Button();
			this.textBoxStackTrack = new TextBox();
			this.m_lblStackTrack = new Label();
			this.buttonInnerExp = new Button();
			this.textBoxMessage = new TextBox();
			this.buttonCopy = new Button();
			this.toolTip = new ToolTip(this.components);
			this.SuspendLayout();
			// 
			// m_btnOk
			// 
			this.m_btnOk.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.m_btnOk.BackColor = System.Drawing.Color.Transparent;
			this.m_btnOk.DialogResult = DialogResult.Cancel;
			this.m_btnOk.Location = new System.Drawing.Point(490, 12);
			this.m_btnOk.Name = "m_btnOk";
			this.m_btnOk.Size = new System.Drawing.Size(82, 23);
			this.m_btnOk.TabIndex = 1;
			this.m_btnOk.Text = "&OK";
			this.m_btnOk.UseVisualStyleBackColor = false;
			this.m_btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// m_lnkLink
			// 
			this.m_lnkLink.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
			| AnchorStyles.Right)));
			this.m_lnkLink.BackColor = System.Drawing.Color.Transparent;
			this.m_lnkLink.Location = new System.Drawing.Point(12, 125);
			this.m_lnkLink.Name = "m_lnkLink";
			this.m_lnkLink.Size = new System.Drawing.Size(472, 19);
			this.m_lnkLink.TabIndex = 4;
			this.m_lnkLink.TabStop = true;
			this.m_lnkLink.Text = "Technical Support";
			this.m_lnkLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.toolTip.SetToolTip(this.m_lnkLink, "Link/email to technical support");
			this.m_lnkLink.UseCompatibleTextRendering = true;
			this.m_lnkLink.LinkClicked += new LinkLabelLinkClickedEventHandler(this.lnkLink_LinkClicked);
			// 
			// m_btnMore
			// 
			this.m_btnMore.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
			this.m_btnMore.BackColor = System.Drawing.Color.Transparent;
			this.m_btnMore.Location = new System.Drawing.Point(490, 99);
			this.m_btnMore.Name = "m_btnMore";
			this.m_btnMore.Size = new System.Drawing.Size(82, 23);
			this.m_btnMore.TabIndex = 3;
			this.m_btnMore.Text = "&More >>";
			this.m_btnMore.UseVisualStyleBackColor = false;
			this.m_btnMore.Click += new System.EventHandler(this.btnMore_Click);
			// 
			// textBoxStackTrack
			// 
			this.textBoxStackTrack.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
			| AnchorStyles.Right)));
			this.textBoxStackTrack.BackColor = System.Drawing.Color.Black;
			this.textBoxStackTrack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxStackTrack.ForeColor = System.Drawing.Color.Gold;
			this.textBoxStackTrack.Location = new System.Drawing.Point(12, 177);
			this.textBoxStackTrack.Multiline = true;
			this.textBoxStackTrack.Name = "textBoxStackTrack";
			this.textBoxStackTrack.ReadOnly = true;
			this.textBoxStackTrack.ScrollBars = ScrollBars.Both;
			this.textBoxStackTrack.Size = new System.Drawing.Size(560, 224);
			this.textBoxStackTrack.TabIndex = 6;
			this.textBoxStackTrack.TabStop = false;
			this.textBoxStackTrack.Text = "Message";
			this.textBoxStackTrack.WordWrap = false;
			// 
			// m_lblStackTrack
			// 
			this.m_lblStackTrack.BackColor = System.Drawing.Color.Transparent;
			this.m_lblStackTrack.Location = new System.Drawing.Point(12, 161);
			this.m_lblStackTrack.Name = "m_lblStackTrack";
			this.m_lblStackTrack.Size = new System.Drawing.Size(560, 13);
			this.m_lblStackTrack.TabIndex = 5;
			this.m_lblStackTrack.Text = "&Stack Track:";
			// 
			// buttonInnerExp
			// 
			this.buttonInnerExp.Location = new System.Drawing.Point(490, 70);
			this.buttonInnerExp.Name = "buttonInnerExp";
			this.buttonInnerExp.Size = new System.Drawing.Size(82, 23);
			this.buttonInnerExp.TabIndex = 2;
			this.buttonInnerExp.Text = "&Inner Error...";
			this.toolTip.SetToolTip(this.buttonInnerExp, "Shows the exception that is the cause of the current exception");
			this.buttonInnerExp.UseVisualStyleBackColor = true;
			this.buttonInnerExp.Click += new System.EventHandler(this.ButtonInnerExp_Click);
			// 
			// textBoxMessage
			// 
			this.textBoxMessage.BackColor = System.Drawing.Color.Black;
			this.textBoxMessage.BorderStyle = BorderStyle.None;
			this.textBoxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxMessage.ForeColor = System.Drawing.Color.Red;
			this.textBoxMessage.Location = new System.Drawing.Point(12, 12);
			this.textBoxMessage.Multiline = true;
			this.textBoxMessage.Name = "textBoxMessage";
			this.textBoxMessage.ReadOnly = true;
			this.textBoxMessage.ScrollBars = ScrollBars.Vertical;
			this.textBoxMessage.Size = new System.Drawing.Size(472, 110);
			this.textBoxMessage.TabIndex = 0;
			this.textBoxMessage.TabStop = false;
			this.textBoxMessage.Text = "m_lblMessage";
			// 
			// buttonCopy
			// 
			this.buttonCopy.Location = new System.Drawing.Point(490, 41);
			this.buttonCopy.Name = "buttonCopy";
			this.buttonCopy.Size = new System.Drawing.Size(82, 23);
			this.buttonCopy.TabIndex = 7;
			this.buttonCopy.Text = "&Copy";
			this.toolTip.SetToolTip(this.buttonCopy, "Copy error message to clipboard");
			this.buttonCopy.UseVisualStyleBackColor = true;
			this.buttonCopy.Click += new System.EventHandler(this.buttonCopy_Click);
			// 
			// FormErrorHandler
			// 
			this.ClientSize = new System.Drawing.Size(584, 149);
			this.Controls.Add(this.buttonCopy);
			this.Controls.Add(this.textBoxMessage);
			this.Controls.Add(this.buttonInnerExp);
			this.Controls.Add(this.m_lblStackTrack);
			this.Controls.Add(this.textBoxStackTrack);
			this.Controls.Add(this.m_lnkLink);
			this.Controls.Add(this.m_btnMore);
			this.Controls.Add(this.m_btnOk);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormErrorHandler";
			this.Opacity = 0D;
			this.ShowInTaskbar = false;
			this.Text = "Error";
			this.FormClosed += new FormClosedEventHandler(this.FormErrorHandler_FormClosed);
			this.Load += new System.EventHandler(this.frmAbout_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		
        #endregion
    }
}
//---------------------------------------------------------------------------------------
