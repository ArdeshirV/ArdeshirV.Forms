#region Header

// Form About
// Form About.cs : Provides Form About Box
// Copyright© 2002-2019 ArdeshirV@protonmail.com, Licensed under GPLv3+

using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using ArdeshirV.Utilities;
using System.Windows.Forms;

#endregion
//-----------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
    /// <summary>
    /// About Form
    /// </summary>
    public class FormAbout : FormBase
    {
        #region Variables

        private Button m_btnOk;
        private Label m_lblVersion;
        private Button m_btnSysteminfo;
        private LinkLabel m_lblCopyright;
        private Label m_lblApplicationName;
        private RichTextBox m_txtDescription;
        private string m_strLink = string.Empty;
        private LinkLabel m_lnkTechnicalSupport;
        private PictureBox m_picApplicationIcon;
        private string m_strEmail = string.Empty;
        private static bool s_blnIsExists = false;
        private System.ComponentModel.IContainer components = null;
        private readonly string m_strSystemInfo = Environment.SystemDirectory + "\\msinfo32.exe";
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageCopyright;
        private System.Windows.Forms.TabPage tabPageDonation;
        private System.Windows.Forms.TabPage tabPageLicense;
        private System.Windows.Forms.PictureBox pictureBoxLicense;
        private System.Windows.Forms.RichTextBox richTextBoxLicense;
        private System.Windows.Forms.ComboBox comboBoxCopyrights;
        private System.Windows.Forms.ComboBox comboBoxLicenses;
        private System.Windows.Forms.ComboBox comboBoxDonations;
        private System.Windows.Forms.PictureBox pictureBoxDonation;
        private System.Windows.Forms.RichTextBox richTextBoxDonation;

        #endregion
        //---------------------------------------------------------------------
        #region Constructor

        protected FormAbout(Form frmOwner, string strLinkSite,
            string strEmail, Image imgAppImage) : base()
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
            //    m_lnkMalieTo.Visible = false;
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
                ToLower().IndexOf(strEmail.ToLower(), StringComparison.Ordinal);
            int intWebsiteIndex = m_lblCopyright.Text.
                ToLower().IndexOf(strLinkSite.ToLower(), StringComparison.Ordinal);

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
            
            comboBoxLicenses.SelectedIndex = comboBoxLicenses.Items.Count > 0? 0: -1;
            comboBoxDonations.SelectedIndex = comboBoxDonations.Items.Count > 0? 0: -1;
            comboBoxCopyrights.SelectedIndex = comboBoxCopyrights.Items.Count > 0? 0: -1;

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
        private void UpdateTabControlBackColor(bool boolFormIsActive)
        {
			tabPageLicense.BackColor =
			tabPageDonation.BackColor =
			tabPageCopyright.BackColor =
			boolFormIsActive ?
			BackgoundInactiveStartGradientColor:
			BackgoundStartGradientColor;
        }
        //---------------------------------------------------------------------
        private static void ShowSystemInfoDialog()
        {
            string l_strSystemInfo = Environment.SystemDirectory + "\\msinfo32.exe";

            if (File.Exists(l_strSystemInfo))
                System.Diagnostics.Process.Start(l_strSystemInfo);
            else
                throw new FileNotFoundException(string.Format("File {0} missing!", l_strSystemInfo));
        }

        #endregion
        //---------------------------------------------------------------------
        #region Event Handlers

		void FormAboutDeactivate(object sender, EventArgs e)
		{
			UpdateTabControlBackColor(IsActivated);
		}
		//---------------------------------------------------------------------
		void FormAboutActivated(object sender, EventArgs e)
		{
			UpdateTabControlBackColor(IsActivated);	
		}
        //---------------------------------------------------------------------
		void ComboBoxCopyrightsSelectedIndexChanged(object sender, EventArgs e)
		{
		}
        //---------------------------------------------------------------------
		void ComboBoxDonationsSelectedIndexChanged(object sender, EventArgs e)
		{
		}
        //---------------------------------------------------------------------
		void ComboBoxLicensesSelectedIndexChanged(object sender, EventArgs e)
		{
		}
        //---------------------------------------------------------------------
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
                m_lnkTechnicalSupport_LinkClicked(sender, e);
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
        protected override void OnShown(EventArgs e)
        {
			UpdateTabControlBackColor(false);
        	base.OnShown(e);
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
        	this.tabControl = new System.Windows.Forms.TabControl();
        	this.tabPageCopyright = new System.Windows.Forms.TabPage();
        	this.comboBoxCopyrights = new System.Windows.Forms.ComboBox();
        	this.tabPageDonation = new System.Windows.Forms.TabPage();
        	this.comboBoxDonations = new System.Windows.Forms.ComboBox();
        	this.pictureBoxDonation = new System.Windows.Forms.PictureBox();
        	this.richTextBoxDonation = new System.Windows.Forms.RichTextBox();
        	this.tabPageLicense = new System.Windows.Forms.TabPage();
        	this.comboBoxLicenses = new System.Windows.Forms.ComboBox();
        	this.pictureBoxLicense = new System.Windows.Forms.PictureBox();
        	this.richTextBoxLicense = new System.Windows.Forms.RichTextBox();
        	((System.ComponentModel.ISupportInitialize)(this.m_picApplicationIcon)).BeginInit();
        	this.tabControl.SuspendLayout();
        	this.tabPageCopyright.SuspendLayout();
        	this.tabPageDonation.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBoxDonation)).BeginInit();
        	this.tabPageLicense.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBoxLicense)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// m_picApplicationIcon
        	// 
        	this.m_picApplicationIcon.BackColor = System.Drawing.Color.White;
        	this.m_picApplicationIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.m_picApplicationIcon.InitialImage = null;
        	this.m_picApplicationIcon.Location = new System.Drawing.Point(6, 6);
        	this.m_picApplicationIcon.Name = "m_picApplicationIcon";
        	this.m_picApplicationIcon.Size = new System.Drawing.Size(125, 125);
        	this.m_picApplicationIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        	this.m_picApplicationIcon.TabIndex = 6;
        	this.m_picApplicationIcon.TabStop = false;
        	// 
        	// m_btnOk
        	// 
        	this.m_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.m_btnOk.BackColor = System.Drawing.Color.Transparent;
        	this.m_btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.m_btnOk.Location = new System.Drawing.Point(502, 253);
        	this.m_btnOk.Name = "m_btnOk";
        	this.m_btnOk.Size = new System.Drawing.Size(80, 25);
        	this.m_btnOk.TabIndex = 8;
        	this.m_btnOk.Text = "&OK";
        	this.m_btnOk.UseVisualStyleBackColor = false;
        	this.m_btnOk.Click += new System.EventHandler(this.btnOk_Click);
        	// 
        	// m_btnSysteminfo
        	// 
        	this.m_btnSysteminfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.m_btnSysteminfo.BackColor = System.Drawing.Color.Transparent;
        	this.m_btnSysteminfo.Location = new System.Drawing.Point(416, 253);
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
        	this.m_lblApplicationName.Location = new System.Drawing.Point(12, 9);
        	this.m_lblApplicationName.Name = "m_lblApplicationName";
        	this.m_lblApplicationName.Size = new System.Drawing.Size(395, 56);
        	this.m_lblApplicationName.TabIndex = 4;
        	this.m_lblApplicationName.Text = "App Name";
        	this.m_lblApplicationName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        	// 
        	// m_lnkTechnicalSupport
        	// 
        	this.m_lnkTechnicalSupport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.m_lnkTechnicalSupport.BackColor = System.Drawing.Color.Transparent;
        	this.m_lnkTechnicalSupport.Location = new System.Drawing.Point(12, 257);
        	this.m_lnkTechnicalSupport.Name = "m_lnkTechnicalSupport";
        	this.m_lnkTechnicalSupport.Size = new System.Drawing.Size(398, 23);
        	this.m_lnkTechnicalSupport.TabIndex = 5;
        	this.m_lnkTechnicalSupport.TabStop = true;
        	this.m_lnkTechnicalSupport.Text = "Technical Support";
        	this.m_lnkTechnicalSupport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.m_lnkTechnicalSupport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTechnicalSupport_LinkClicked);
        	// 
        	// m_txtDescription
        	// 
        	this.m_txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.m_txtDescription.BackColor = System.Drawing.SystemColors.Control;
        	this.m_txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.m_txtDescription.Location = new System.Drawing.Point(137, 33);
        	this.m_txtDescription.Name = "m_txtDescription";
        	this.m_txtDescription.ReadOnly = true;
        	this.m_txtDescription.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
        	this.m_txtDescription.Size = new System.Drawing.Size(419, 98);
        	this.m_txtDescription.TabIndex = 0;
        	this.m_txtDescription.Text = "Description";
        	// 
        	// m_lblVersion
        	// 
        	this.m_lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.m_lblVersion.BackColor = System.Drawing.Color.Transparent;
        	this.m_lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.m_lblVersion.Location = new System.Drawing.Point(411, 10);
        	this.m_lblVersion.Name = "m_lblVersion";
        	this.m_lblVersion.Size = new System.Drawing.Size(173, 56);
        	this.m_lblVersion.TabIndex = 2;
        	this.m_lblVersion.Text = "Version";
        	this.m_lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// m_lblCopyright
        	// 
        	this.m_lblCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.m_lblCopyright.BackColor = System.Drawing.Color.Transparent;
        	this.m_lblCopyright.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
        	this.m_lblCopyright.Location = new System.Drawing.Point(12, 235);
        	this.m_lblCopyright.Name = "m_lblCopyright";
        	this.m_lblCopyright.Size = new System.Drawing.Size(570, 22);
        	this.m_lblCopyright.TabIndex = 9;
        	this.m_lblCopyright.Text = "Copyright goes here.";
        	this.m_lblCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.m_lblCopyright.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.M_lblCopyright_LinkClicked);
        	// 
        	// tabControl
        	// 
        	this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.tabControl.Controls.Add(this.tabPageCopyright);
        	this.tabControl.Controls.Add(this.tabPageDonation);
        	this.tabControl.Controls.Add(this.tabPageLicense);
        	this.tabControl.Location = new System.Drawing.Point(12, 68);
        	this.tabControl.Name = "tabControl";
        	this.tabControl.SelectedIndex = 0;
        	this.tabControl.Size = new System.Drawing.Size(570, 163);
        	this.tabControl.TabIndex = 10;
        	// 
        	// tabPageCopyright
        	// 
        	this.tabPageCopyright.BackColor = System.Drawing.Color.Transparent;
        	this.tabPageCopyright.Controls.Add(this.comboBoxCopyrights);
        	this.tabPageCopyright.Controls.Add(this.m_picApplicationIcon);
        	this.tabPageCopyright.Controls.Add(this.m_txtDescription);
        	this.tabPageCopyright.Location = new System.Drawing.Point(4, 22);
        	this.tabPageCopyright.Name = "tabPageCopyright";
        	this.tabPageCopyright.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPageCopyright.Size = new System.Drawing.Size(562, 137);
        	this.tabPageCopyright.TabIndex = 0;
        	this.tabPageCopyright.Text = "Copyright";
        	// 
        	// comboBoxCopyrights
        	// 
        	this.comboBoxCopyrights.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.comboBoxCopyrights.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.comboBoxCopyrights.FormattingEnabled = true;
        	this.comboBoxCopyrights.Location = new System.Drawing.Point(137, 6);
        	this.comboBoxCopyrights.Name = "comboBoxCopyrights";
        	this.comboBoxCopyrights.Size = new System.Drawing.Size(419, 21);
        	this.comboBoxCopyrights.TabIndex = 10;
        	this.comboBoxCopyrights.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCopyrightsSelectedIndexChanged);
        	// 
        	// tabPageDonation
        	// 
        	this.tabPageDonation.BackColor = System.Drawing.Color.Transparent;
        	this.tabPageDonation.Controls.Add(this.comboBoxDonations);
        	this.tabPageDonation.Controls.Add(this.pictureBoxDonation);
        	this.tabPageDonation.Controls.Add(this.richTextBoxDonation);
        	this.tabPageDonation.Location = new System.Drawing.Point(4, 22);
        	this.tabPageDonation.Name = "tabPageDonation";
        	this.tabPageDonation.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPageDonation.Size = new System.Drawing.Size(562, 137);
        	this.tabPageDonation.TabIndex = 1;
        	this.tabPageDonation.Text = "Donation";
        	// 
        	// comboBoxDonations
        	// 
        	this.comboBoxDonations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.comboBoxDonations.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.comboBoxDonations.FormattingEnabled = true;
        	this.comboBoxDonations.Items.AddRange(new object[] {
			"Bitcoin"});
        	this.comboBoxDonations.Location = new System.Drawing.Point(137, 6);
        	this.comboBoxDonations.Name = "comboBoxDonations";
        	this.comboBoxDonations.Size = new System.Drawing.Size(419, 21);
        	this.comboBoxDonations.TabIndex = 13;
        	this.comboBoxDonations.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDonationsSelectedIndexChanged);
        	// 
        	// pictureBoxDonation
        	// 
        	this.pictureBoxDonation.BackColor = System.Drawing.Color.White;
        	this.pictureBoxDonation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.pictureBoxDonation.InitialImage = null;
        	this.pictureBoxDonation.Location = new System.Drawing.Point(6, 6);
        	this.pictureBoxDonation.Name = "pictureBoxDonation";
        	this.pictureBoxDonation.Size = new System.Drawing.Size(125, 125);
        	this.pictureBoxDonation.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        	this.pictureBoxDonation.TabIndex = 12;
        	this.pictureBoxDonation.TabStop = false;
        	// 
        	// richTextBoxDonation
        	// 
        	this.richTextBoxDonation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.richTextBoxDonation.BackColor = System.Drawing.SystemColors.Control;
        	this.richTextBoxDonation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.richTextBoxDonation.Location = new System.Drawing.Point(137, 33);
        	this.richTextBoxDonation.Name = "richTextBoxDonation";
        	this.richTextBoxDonation.ReadOnly = true;
        	this.richTextBoxDonation.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
        	this.richTextBoxDonation.Size = new System.Drawing.Size(419, 98);
        	this.richTextBoxDonation.TabIndex = 11;
        	this.richTextBoxDonation.Text = "1CtvnCrobtE3X1AgDCfr1EaJpYKVaoFXHZ";
        	// 
        	// tabPageLicense
        	// 
        	this.tabPageLicense.BackColor = System.Drawing.Color.Transparent;
        	this.tabPageLicense.Controls.Add(this.comboBoxLicenses);
        	this.tabPageLicense.Controls.Add(this.pictureBoxLicense);
        	this.tabPageLicense.Controls.Add(this.richTextBoxLicense);
        	this.tabPageLicense.Location = new System.Drawing.Point(4, 22);
        	this.tabPageLicense.Name = "tabPageLicense";
        	this.tabPageLicense.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPageLicense.Size = new System.Drawing.Size(562, 137);
        	this.tabPageLicense.TabIndex = 2;
        	this.tabPageLicense.Text = "License";
        	// 
        	// comboBoxLicenses
        	// 
        	this.comboBoxLicenses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.comboBoxLicenses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.comboBoxLicenses.FormattingEnabled = true;
        	this.comboBoxLicenses.Location = new System.Drawing.Point(137, 6);
        	this.comboBoxLicenses.Name = "comboBoxLicenses";
        	this.comboBoxLicenses.Size = new System.Drawing.Size(419, 21);
        	this.comboBoxLicenses.TabIndex = 9;
        	this.comboBoxLicenses.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLicensesSelectedIndexChanged);
        	// 
        	// pictureBoxLicense
        	// 
        	this.pictureBoxLicense.BackColor = System.Drawing.Color.White;
        	this.pictureBoxLicense.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        	this.pictureBoxLicense.InitialImage = null;
        	this.pictureBoxLicense.Location = new System.Drawing.Point(6, 6);
        	this.pictureBoxLicense.Name = "pictureBoxLicense";
        	this.pictureBoxLicense.Size = new System.Drawing.Size(125, 125);
        	this.pictureBoxLicense.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        	this.pictureBoxLicense.TabIndex = 8;
        	this.pictureBoxLicense.TabStop = false;
        	// 
        	// richTextBoxLicense
        	// 
        	this.richTextBoxLicense.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
        	this.richTextBoxLicense.BackColor = System.Drawing.SystemColors.Control;
        	this.richTextBoxLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.richTextBoxLicense.Location = new System.Drawing.Point(137, 33);
        	this.richTextBoxLicense.Name = "richTextBoxLicense";
        	this.richTextBoxLicense.ReadOnly = true;
        	this.richTextBoxLicense.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
        	this.richTextBoxLicense.Size = new System.Drawing.Size(419, 98);
        	this.richTextBoxLicense.TabIndex = 7;
        	this.richTextBoxLicense.Text = "Description";
        	// 
        	// FormAbout
        	// 
        	this.ClientSize = new System.Drawing.Size(596, 290);
        	this.ControlBox = false;
        	this.Controls.Add(this.tabControl);
        	this.Controls.Add(this.m_lnkTechnicalSupport);
        	this.Controls.Add(this.m_lblCopyright);
        	this.Controls.Add(this.m_lblVersion);
        	this.Controls.Add(this.m_btnSysteminfo);
        	this.Controls.Add(this.m_btnOk);
        	this.Controls.Add(this.m_lblApplicationName);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "FormAbout";
        	this.ShowInTaskbar = false;
        	this.Activated += new System.EventHandler(this.FormAboutActivated);
        	this.Deactivate += new System.EventHandler(this.FormAboutDeactivate);
        	this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormAbout_FormClosed);
        	this.Load += new System.EventHandler(this.frmAbout_Load);
        	((System.ComponentModel.ISupportInitialize)(this.m_picApplicationIcon)).EndInit();
        	this.tabControl.ResumeLayout(false);
        	this.tabPageCopyright.ResumeLayout(false);
        	this.tabPageDonation.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.pictureBoxDonation)).EndInit();
        	this.tabPageLicense.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.pictureBoxLicense)).EndInit();
        	this.ResumeLayout(false);

        }
        
        #endregion
    }
}
//-----------------------------------------------------------------------------
