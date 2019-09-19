#region Header

// Form About
// Form About.cs : Provides Form About Box
// Copyright© 2002-2019 ardeshirv@protonmail.com, Licensed under GPLv3+

using System;
using System.IO;
using System.Drawing;
using ArdeshirV.Utilities;
using System.Reflection;
using System.Windows.Forms;

#endregion
//-----------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
    /// <summary>
    /// About Form in Vector Project.
    /// </summary>
    public class FormAbout : ArdeshirV.Forms.SpecialForm
    {
        #region Variables

        private Label m_lblVersion;
        private LinkLabel m_lblCopyright;
        private Label m_lblApplicationName;
        private RichTextBox m_txtDescription;
        private string m_strLink = string.Empty;
        private LinkLabel m_lnkTechnicalSupport;
        private string m_strEmail = string.Empty;
        private static bool s_blnIsExists = false;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnSysteminfo;
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.PictureBox m_picApplicationIcon;
        private readonly string m_strSystemInfo = Environment.SystemDirectory + "\\msinfo32.exe";

        #endregion
        //---------------------------------------------------------------------
        #region Constructor

        protected FormAbout(Form frmOwner, string strLinkSite, string strEmail, Image imgAppImage)
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            AssemblyAttributeAccessors l_aaaInformation =
                new AssemblyAttributeAccessors(
                    Assembly.GetAssembly(frmOwner.GetType()));

            m_strEmail = strEmail;
            Icon = frmOwner.Icon;
            m_strLink = strLinkSite;
            m_picApplicationIcon.Image = imgAppImage;
            //this.labelProductName.Text = AssemblyProduct;
            //m_lnkLink.Text = "Click here to view technical support site.";

            //if (strEmail == string.Empty || strEmail == null)
            ///    m_lnkMalieTo.Visible = false;
            //else
            //    m_lnkMalieTo.Text = strEmail;
            if (m_strLink == string.Empty || strLinkSite == null)
                m_lnkTechnicalSupport.Visible = false;
            else
                m_lnkTechnicalSupport.Text = m_strLink;

            m_lblCopyright.Text = l_aaaInformation.AssemblyCopyright;
            m_lblApplicationName.Text = l_aaaInformation.AssemblyTitle;
            m_txtDescription.Text = l_aaaInformation.AssemblyDescription;
            Text = String.Format("About {0}", l_aaaInformation.AssemblyTitle);
            //labelCompanyName.Text = AssemblyAttributeAccessors.AssemblyCompany;
            m_lblVersion.Text = String.Format("Version {0}",
                l_aaaInformation.AssemblyVersion);
            m_btnSysteminfo.Enabled = File.Exists(m_strSystemInfo);

            int intEmailIndex = m_lblCopyright.Text.
                ToLower().IndexOf(strEmail.ToLower());
            int intWebsiteIndex = m_lblCopyright.Text.
                ToLower().IndexOf(strLinkSite.ToLower());

            if(intEmailIndex >= 0)
            {
                int intPos = intEmailIndex;
                m_lblCopyright.LinkArea = new LinkArea(intPos, strEmail.Length);
            }
            else if(intWebsiteIndex >= 0)
            {
                int intPos = intWebsiteIndex;
                m_lblCopyright.LinkArea = new LinkArea(intPos, strLinkSite.Length);
            }

            if (frmOwner == null)
                ShowDialog();
            else
                ShowDialog(frmOwner);
        }

        #endregion
        //---------------------------------------------------------------------
        #region Utility functions

        public static FormAbout Show(Form frmOwner, string strLinkSite, string strEMail)
        {
            return new FormAbout(frmOwner, strLinkSite, strEMail, frmOwner.Icon.ToBitmap());
        }
        //---------------------------------------------------------------------
        public static FormAbout Show(Form frmOwner, string strLinkSite, string strEMail, Image imgAppImage)
        {
            return new FormAbout(frmOwner, strLinkSite, strEMail, imgAppImage);
        }
        //---------------------------------------------------------------------
        private static void ShowSystemInfoDialog()
        {
            string l_strSystemInfo = Environment.SystemDirectory + "\\msinfo32.exe";

            if (File.Exists(l_strSystemInfo))
                System.Diagnostics.Process.Start(l_strSystemInfo);
            else
                throw new Exception(string.Format("File {0} missing!", l_strSystemInfo));
        }

        #endregion
        //---------------------------------------------------------------------
        #region Event Handlers

        private void m_lnkMalieTo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //m_lnkMalieTo.LinkVisited = true;
            (sender as LinkLabel).LinkVisited = true;
            System.Windows.Forms.Clipboard.SetText(m_strEmail);
            System.Diagnostics.Process.Start("mailto:" + m_strEmail);
        }
        //---------------------------------------------------------------------
        private void m_lnkTechnicalSupport_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //m_lnkTechnicalSupport.LinkVisited = true;
            (sender as LinkLabel).LinkVisited = true;
            System.Diagnostics.Process.Start(m_strLink);
        }
        //---------------------------------------------------------------------
        private void btnOk_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        //---------------------------------------------------------------------
        private void btnSysteminfo_Click(object sender, System.EventArgs e)
        {
            ShowSystemInfoDialog();
        }
        //---------------------------------------------------------------------
        private void frmAbout_Load(object sender, System.EventArgs e)
        {
            if (s_blnIsExists)
                Close();
            else
                s_blnIsExists = true;
        }
        //---------------------------------------------------------------------
        private void FormAbout_FormClosed(object sender, FormClosedEventArgs e)
        {
            s_blnIsExists = false;
        }
        //---------------------------------------------------------------------
        private void M_lblCopyright_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (m_lblCopyright.Text.ToLower().Contains(m_strEmail.ToLower()))
                m_lnkMalieTo_LinkClicked(sender, e);
            else if (m_lblCopyright.Text.ToLower().Contains(m_strLink.ToLower()))
                m_lnkMalieTo_LinkClicked(sender, e);
        }

        #endregion
        //---------------------------------------------------------------------
        #region overrided functions

        protected override void OnClosed(EventArgs e)
        {
            s_blnIsExists = false;
            base.OnClosed(e);
        }
        //---------------------------------------------------------------------
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
                if (components != null)
                    components.Dispose();

            base.Dispose(disposing);
        }

        #endregion
        //---------------------------------------------------------------------
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.m_picApplicationIcon = new System.Windows.Forms.PictureBox();
        	this.m_btnOk = new System.Windows.Forms.Button();
        	this.m_btnSysteminfo = new System.Windows.Forms.Button();
        	this.m_lblApplicationName = new System.Windows.Forms.Label();
        	this.m_lnkTechnicalSupport = new System.Windows.Forms.LinkLabel();
        	this.m_txtDescription = new System.Windows.Forms.RichTextBox();
        	this.m_lblVersion = new System.Windows.Forms.Label();
        	this.m_lblCopyright = new System.Windows.Forms.LinkLabel();
        	((System.ComponentModel.ISupportInitialize)(this.m_picApplicationIcon)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// m_picApplicationIcon
        	// 
        	this.m_picApplicationIcon.BackColor = System.Drawing.Color.White;
        	this.m_picApplicationIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.m_picApplicationIcon.InitialImage = null;
        	this.m_picApplicationIcon.Location = new System.Drawing.Point(12, 12);
        	this.m_picApplicationIcon.Name = "m_picApplicationIcon";
        	this.m_picApplicationIcon.Size = new System.Drawing.Size(125, 125);
        	this.m_picApplicationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        	this.m_picApplicationIcon.TabIndex = 6;
        	this.m_picApplicationIcon.TabStop = false;
        	// 
        	// m_btnOk
        	// 
        	this.m_btnOk.BackColor = System.Drawing.Color.Transparent;
        	this.m_btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.m_btnOk.Location = new System.Drawing.Point(502, 12);
        	this.m_btnOk.Name = "m_btnOk";
        	this.m_btnOk.Size = new System.Drawing.Size(80, 25);
        	this.m_btnOk.TabIndex = 8;
        	this.m_btnOk.Text = "&OK";
        	this.m_btnOk.UseVisualStyleBackColor = false;
        	this.m_btnOk.Click += new System.EventHandler(this.btnOk_Click);
        	// 
        	// m_btnSysteminfo
        	// 
        	this.m_btnSysteminfo.BackColor = System.Drawing.Color.Transparent;
        	this.m_btnSysteminfo.Location = new System.Drawing.Point(502, 43);
        	this.m_btnSysteminfo.Name = "m_btnSysteminfo";
        	this.m_btnSysteminfo.Size = new System.Drawing.Size(80, 25);
        	this.m_btnSysteminfo.TabIndex = 7;
        	this.m_btnSysteminfo.Text = "&System Info";
        	this.m_btnSysteminfo.UseVisualStyleBackColor = false;
        	this.m_btnSysteminfo.Click += new System.EventHandler(this.btnSysteminfo_Click);
        	// 
        	// m_lblApplicationName
        	// 
        	this.m_lblApplicationName.BackColor = System.Drawing.Color.Transparent;
        	this.m_lblApplicationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.m_lblApplicationName.Location = new System.Drawing.Point(143, 12);
        	this.m_lblApplicationName.Name = "m_lblApplicationName";
        	this.m_lblApplicationName.Size = new System.Drawing.Size(245, 56);
        	this.m_lblApplicationName.TabIndex = 4;
        	this.m_lblApplicationName.Text = "App Name";
        	this.m_lblApplicationName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// m_lnkTechnicalSupport
        	// 
        	this.m_lnkTechnicalSupport.BackColor = System.Drawing.Color.Transparent;
        	this.m_lnkTechnicalSupport.Location = new System.Drawing.Point(12, 158);
        	this.m_lnkTechnicalSupport.Name = "m_lnkTechnicalSupport";
        	this.m_lnkTechnicalSupport.Size = new System.Drawing.Size(570, 23);
        	this.m_lnkTechnicalSupport.TabIndex = 5;
        	this.m_lnkTechnicalSupport.TabStop = true;
        	this.m_lnkTechnicalSupport.Text = "Technical Support";
        	this.m_lnkTechnicalSupport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.m_lnkTechnicalSupport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTechnicalSupport_LinkClicked);
        	// 
        	// m_txtDescription
        	// 
        	this.m_txtDescription.BackColor = System.Drawing.SystemColors.Control;
        	this.m_txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.m_txtDescription.Location = new System.Drawing.Point(143, 74);
        	this.m_txtDescription.Name = "m_txtDescription";
        	this.m_txtDescription.ReadOnly = true;
        	this.m_txtDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
        	this.m_txtDescription.Size = new System.Drawing.Size(439, 63);
        	this.m_txtDescription.TabIndex = 0;
        	this.m_txtDescription.Text = "Description";
        	// 
        	// m_lblVersion
        	// 
        	this.m_lblVersion.BackColor = System.Drawing.Color.Transparent;
        	this.m_lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.m_lblVersion.Location = new System.Drawing.Point(389, 12);
        	this.m_lblVersion.Name = "m_lblVersion";
        	this.m_lblVersion.Size = new System.Drawing.Size(106, 56);
        	this.m_lblVersion.TabIndex = 2;
        	this.m_lblVersion.Text = "Version";
        	this.m_lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// m_lblCopyright
        	// 
        	this.m_lblCopyright.BackColor = System.Drawing.Color.Transparent;
        	this.m_lblCopyright.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
        	this.m_lblCopyright.Location = new System.Drawing.Point(12, 140);
        	this.m_lblCopyright.Name = "m_lblCopyright";
        	this.m_lblCopyright.Size = new System.Drawing.Size(570, 22);
        	this.m_lblCopyright.TabIndex = 9;
        	this.m_lblCopyright.Text = "Copyright goes here.";
        	this.m_lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.m_lblCopyright.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.M_lblCopyright_LinkClicked);
        	// 
        	// FormAbout
        	// 
        	this.ClientSize = new System.Drawing.Size(596, 335);
        	this.ControlBox = false;
        	this.Controls.Add(this.m_lnkTechnicalSupport);
        	this.Controls.Add(this.m_lblCopyright);
        	this.Controls.Add(this.m_lblVersion);
        	this.Controls.Add(this.m_btnSysteminfo);
        	this.Controls.Add(this.m_btnOk);
        	this.Controls.Add(this.m_txtDescription);
        	this.Controls.Add(this.m_lblApplicationName);
        	this.Controls.Add(this.m_picApplicationIcon);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "FormAbout";
        	this.ShowInTaskbar = false;
        	this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAbout_FormClosed);
        	this.Load += new System.EventHandler(this.frmAbout_Load);
        	((System.ComponentModel.ISupportInitialize)(this.m_picApplicationIcon)).EndInit();
        	this.ResumeLayout(false);

        }
        #endregion
    }
}
//-----------------------------------------------------------------------------
