#region Header

// Form About
// Form About.cs : Provides Form About Box
// Copyright© 2002-2019 ArdeshirV@protonmail.com, Licensed under LGPLv3+

using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using ArdeshirV.Utilities;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

#endregion
//-----------------------------------------------------------------------------------
namespace ArdeshirV.Forms
{	
    /// <summary>
    /// About Form
    /// </summary>
    public class FormAbout : FormBase
    {
        #region Variables

        private FormAboutData data;
        private Button m_btnOk;
        private Button m_btnSysteminfo;
        private Label m_lblApplicationName;
        //private string m_strLink = string.Empty;
        private LinkLabel linkLabelEmail;
        private PictureBox pictureBoxAppIcon;
        //private string m_strEmail = string.Empty;
        private static bool s_blnIsExists = false;
        private TabControl tabControl;
        private TabPage tabPageCopyright;
        private TabPage tabPageDonation;
        private TabPage tabPageLicense;
        private PictureBox pictureBoxLicense;
        private RichTextBox richTextBoxLicense;
        private ComboBox comboBoxCopyrights;
        private ComboBox comboBoxLicenses;
        //private PictureBox comboBoxDonationCurrenciesion;
        private RichTextBox richTextBoxDonation;
        private Button buttonCopyrightCopy;
        private Button buttonDonationCopy;
        private Button buttonLicenseCopy;
        private LinkLabel linkLabelCopyright;
        private RichTextBox richTextBoxCopyrightDescription;
        private ToolTip toolTip;
        private PictureBox pictureBoxDonation;
        private RichTextBox textBoxVersion;
        private LinkLabel linkLabelURL;
        private ComboBox comboBoxDonation;
        private ComboBox comboBoxDonationCurrencies;
        private System.ComponentModel.IContainer components;
        private readonly string m_strSystemInfo = Environment.SystemDirectory + "\\msinfo32.exe";

        #endregion
        //---------------------------------------------------------------------
        #region Constructor

        protected FormAbout(FormAboutData data) : base()
        {
            comboBoxDonationCurrencies = new ComboBox();
            InitializeComponent();
            InitFormAbout(data);
            if(data.Owner is Form)
            	ShowDialog(data.Owner as Form);
            else
            	ShowDialog();
        }

        #endregion
        //---------------------------------------------------------------------
        #region Utility functions

        private void InitFormAbout(FormAboutData d) 
        {
            // TODO: Create a messageBox that present AssemblyInfo for a standard component
            this.data = d;
            StartPosition = FormStartPosition.CenterParent;
            if(d.Owner is Form) {
            	Form MyOwner = d.Owner as Form;
            	Icon = MyOwner.Icon;
            }
            linkLabelURL.Text = d.URL;
            linkLabelEmail.Text = d.Email;
            this.m_lblApplicationName.Text = d.AppName;
            //Extractor.ExctractEmails(Text);
            //Extractor.ExctractURLs(Extractor);
            pictureBoxAppIcon.Image = d.Copyrights[""].Logo;
            
            /*
            m_strLink = strLinkSite;
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

            textBoxVersion.Text = String.Format("Version {0}", l_aaaInformation.AssemblyVersion);
            linkLabelCopyright.Text = l_aaaInformation.AssemblyCopyright;
            m_lblApplicationName.Text = l_aaaInformation.AssemblyTitle;
            richTextBoxCopyrightDescription.Text = l_aaaInformation.AssemblyDescription;
            Text = String.Format("About {0}", l_aaaInformation.AssemblyTitle);
            //labelCompanyName.Text = AssemblyAttributeAccessors.AssemblyCompany;
            m_btnSysteminfo.Enabled = File.Exists(m_strSystemInfo);

            int intEmailIndex = linkLabelCopyright.Text.
                ToLower().IndexOf(strEmail.ToLower(), StringComparison.Ordinal);
            int intWebsiteIndex = linkLabelCopyright.Text.
                ToLower().IndexOf(strLinkSite.ToLower(), StringComparison.Ordinal);

            if(intEmailIndex >= 0)
            {
                int intPos = intEmailIndex;
                linkLabelCopyright.LinkArea = new LinkArea(intPos, strEmail.Length);
            }
            else if(intWebsiteIndex >= 0)
            {
                int intPos = intWebsiteIndex;
                linkLabelCopyright.LinkArea = new LinkArea(intPos, strLinkSite.Length);
            }
            
            comboBoxLicenses.SelectedIndex = comboBoxLicenses.Items.Count > 0? 0: -1;
            comboBoxDonations.SelectedIndex = comboBoxDonations.Items.Count > 0? 0: -1;
            comboBoxCopyrights.SelectedIndex = comboBoxCopyrights.Items.Count > 0? 0: -1;
            */
        }
        //---------------------------------------------------------------------
        public static FormAbout Show(Form frmOwner, string strLinkSite, string strEMail)
        {
            //return new FormAbout(frmOwner, strLinkSite, strEMail, frmOwner.Icon.ToBitmap());
            return null;
        }
        //---------------------------------------------------------------------
        public static FormAbout Show(Form frmOwner, string strLinkSite, string strEMail, Image imgAppImage)
        {
            //return new FormAbout(frmOwner, strLinkSite, strEMail, imgAppImage);
            return null;
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
		void ButtonCopyClick(object sender, EventArgs e)
		{
			Clipboard.SetText(linkLabelCopyright.Text);
		}
		//-------------------------------------------------------------------------------
		void ButtonDonationCopyClick(object sender, EventArgs e)
		{
			Clipboard.SetText(richTextBoxDonation.Text);
		}
		//-------------------------------------------------------------------------------
		void ButtonLicenseCopyClick(object sender, EventArgs e)
		{
			Clipboard.SetText(richTextBoxLicense.Text);
		}
        //---------------------------------------------------------------------
        private static void ShowSystemInfoDialog()
        {
            string l_strSystemInfo = Environment.SystemDirectory + "\\msinfo32.exe";

            if (File.Exists(l_strSystemInfo))
                System.Diagnostics.Process.Start(l_strSystemInfo);
            else
                throw new FileNotFoundException(string.Format(
            		"File {0} missing!", l_strSystemInfo));
        }

        #endregion
        //---------------------------------------------------------------------
        #region Event Handlers

		void FormAboutDeactivate(object sender, EventArgs e)
		{
			UpdateTabControlBackColor(IsActivated);
		}
		//-------------------------------------------------------------------------------
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
        private void m_lnkMalieTo_LinkClicked(object sender,
                                              LinkLabelLinkClickedEventArgs e)
        {
            //m_lnkMalieTo.LinkVisited = true;
            (sender as LinkLabel).LinkVisited = true;
            // Clipboard.SetText(data.Email);
            System.Diagnostics.Process.Start("mailto:" + data.Email);
        }
        //---------------------------------------------------------------------
        private void m_lnkTechnicalSupport_LinkClicked(object sender,
        	LinkLabelLinkClickedEventArgs e)
        {
            //m_lnkTechnicalSupport.LinkVisited = true;
            (sender as LinkLabel).LinkVisited = true;
            System.Diagnostics.Process.Start(data.URL);
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
        private void M_lblCopyright_LinkClicked(object sender,
        	LinkLabelLinkClickedEventArgs e)
        {
            if (linkLabelCopyright.Text.ToLower().
        	    Contains(data.Email.ToLower()))
                	m_lnkMalieTo_LinkClicked(sender, e);
            else if (linkLabelCopyright.Text.ToLower().
        	    Contains(data.URL.ToLower()))
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
        	this.components = new System.ComponentModel.Container();
        	this.pictureBoxAppIcon = new PictureBox();
        	this.m_btnOk = new Button();
        	this.m_btnSysteminfo = new Button();
        	this.m_lblApplicationName = new Label();
        	this.linkLabelEmail = new LinkLabel();
        	this.tabControl = new TabControl();
        	this.tabPageCopyright = new TabPage();
        	this.textBoxVersion = new RichTextBox();
        	this.linkLabelCopyright = new LinkLabel();
        	this.buttonCopyrightCopy = new Button();
        	this.comboBoxCopyrights = new ComboBox();
        	this.richTextBoxCopyrightDescription = new RichTextBox();
        	this.tabPageDonation = new TabPage();
        	this.comboBoxDonation = new ComboBox();
        	this.buttonDonationCopy = new Button();
        	this.comboBoxDonationCurrencies = new ComboBox();
        	this.pictureBoxDonation = new PictureBox();
        	this.richTextBoxDonation = new RichTextBox();
        	this.tabPageLicense = new TabPage();
        	this.buttonLicenseCopy = new Button();
        	this.comboBoxLicenses = new ComboBox();
        	this.pictureBoxLicense = new PictureBox();
        	this.richTextBoxLicense = new RichTextBox();
        	this.toolTip = new ToolTip(this.components);
        	this.linkLabelURL = new LinkLabel();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBoxAppIcon)).BeginInit();
        	this.tabControl.SuspendLayout();
        	this.tabPageCopyright.SuspendLayout();
        	this.tabPageDonation.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBoxDonation)).BeginInit();
        	this.tabPageLicense.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBoxLicense)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// pictureBoxAppIcon
        	// 
        	this.pictureBoxAppIcon.BackColor = System.Drawing.Color.White;
        	this.pictureBoxAppIcon.BorderStyle = BorderStyle.Fixed3D;
        	this.pictureBoxAppIcon.InitialImage = null;
        	this.pictureBoxAppIcon.Location = new System.Drawing.Point(6, 6);
        	this.pictureBoxAppIcon.Name = "pictureBoxAppIcon";
        	this.pictureBoxAppIcon.Size = new System.Drawing.Size(128, 128);
        	this.pictureBoxAppIcon.SizeMode = PictureBoxSizeMode.StretchImage;
        	this.pictureBoxAppIcon.TabIndex = 6;
        	this.pictureBoxAppIcon.TabStop = false;
        	// 
        	// m_btnOk
        	// 
        	this.m_btnOk.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
        	this.m_btnOk.BackColor = System.Drawing.Color.Transparent;
        	this.m_btnOk.DialogResult = DialogResult.OK;
        	this.m_btnOk.Location = new System.Drawing.Point(542, 225);
        	this.m_btnOk.Name = "m_btnOk";
        	this.m_btnOk.Size = new System.Drawing.Size(80, 25);
        	this.m_btnOk.TabIndex = 6;
        	this.m_btnOk.Text = "&OK";
        	this.m_btnOk.UseVisualStyleBackColor = false;
        	this.m_btnOk.Click += new System.EventHandler(this.btnOk_Click);
        	// 
        	// m_btnSysteminfo
        	// 
        	this.m_btnSysteminfo.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
        	this.m_btnSysteminfo.BackColor = System.Drawing.Color.Transparent;
        	this.m_btnSysteminfo.Location = new System.Drawing.Point(456, 225);
        	this.m_btnSysteminfo.Name = "m_btnSysteminfo";
        	this.m_btnSysteminfo.Size = new System.Drawing.Size(80, 25);
        	this.m_btnSysteminfo.TabIndex = 5;
        	this.m_btnSysteminfo.Text = "&System Info";
        	this.toolTip.SetToolTip(this.m_btnSysteminfo, "Shows information about current system");
        	this.m_btnSysteminfo.UseVisualStyleBackColor = false;
        	this.m_btnSysteminfo.Click += new System.EventHandler(this.btnSysteminfo_Click);
        	// 
        	// m_lblApplicationName
        	// 
        	this.m_lblApplicationName.BackColor = System.Drawing.Color.Transparent;
        	this.m_lblApplicationName.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.m_lblApplicationName.Location = new System.Drawing.Point(12, 0);
        	this.m_lblApplicationName.Name = "m_lblApplicationName";
        	this.m_lblApplicationName.Size = new System.Drawing.Size(610, 50);
        	this.m_lblApplicationName.TabIndex = 0;
        	this.m_lblApplicationName.Text = "App Name";
        	this.m_lblApplicationName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        	// 
        	// linkLabelEmail
        	// 
        	this.linkLabelEmail.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) 
			| AnchorStyles.Right)));
        	this.linkLabelEmail.BackColor = System.Drawing.Color.Transparent;
        	this.linkLabelEmail.Location = new System.Drawing.Point(12, 221);
        	this.linkLabelEmail.Name = "linkLabelEmail";
        	this.linkLabelEmail.Size = new System.Drawing.Size(436, 18);
        	this.linkLabelEmail.TabIndex = 4;
        	this.linkLabelEmail.TabStop = true;
        	this.linkLabelEmail.Text = "Email goes here";
        	this.linkLabelEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.linkLabelEmail.LinkClicked += new LinkLabelLinkClickedEventHandler(this.m_lnkTechnicalSupport_LinkClicked);
        	// 
        	// tabControl
        	// 
        	this.tabControl.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
			| AnchorStyles.Right)));
        	this.tabControl.Controls.Add(this.tabPageCopyright);
        	this.tabControl.Controls.Add(this.tabPageDonation);
        	this.tabControl.Controls.Add(this.tabPageLicense);
        	this.tabControl.Location = new System.Drawing.Point(12, 52);
        	this.tabControl.Name = "tabControl";
        	this.tabControl.SelectedIndex = 0;
        	this.tabControl.Size = new System.Drawing.Size(610, 166);
        	this.tabControl.TabIndex = 2;
        	// 
        	// tabPageCopyright
        	// 
        	this.tabPageCopyright.BackColor = System.Drawing.Color.Transparent;
        	this.tabPageCopyright.Controls.Add(this.textBoxVersion);
        	this.tabPageCopyright.Controls.Add(this.linkLabelCopyright);
        	this.tabPageCopyright.Controls.Add(this.buttonCopyrightCopy);
        	this.tabPageCopyright.Controls.Add(this.comboBoxCopyrights);
        	this.tabPageCopyright.Controls.Add(this.pictureBoxAppIcon);
        	this.tabPageCopyright.Controls.Add(this.richTextBoxCopyrightDescription);
        	this.tabPageCopyright.Location = new System.Drawing.Point(4, 22);
        	this.tabPageCopyright.Name = "tabPageCopyright";
        	this.tabPageCopyright.Padding = new Padding(3);
        	this.tabPageCopyright.Size = new System.Drawing.Size(602, 140);
        	this.tabPageCopyright.TabIndex = 0;
        	this.tabPageCopyright.Text = "Copyright";
        	// 
        	// textBoxVersion
        	// 
        	this.textBoxVersion.Location = new System.Drawing.Point(140, 56);
        	this.textBoxVersion.Name = "textBoxVersion";
        	this.textBoxVersion.ReadOnly = true;
        	this.textBoxVersion.Size = new System.Drawing.Size(456, 20);
        	this.textBoxVersion.TabIndex = 8;
        	this.textBoxVersion.Text = "";
        	// 
        	// linkLabelCopyright
        	// 
        	this.linkLabelCopyright.BackColor = System.Drawing.SystemColors.Control;
        	this.linkLabelCopyright.BorderStyle = BorderStyle.Fixed3D;
        	this.linkLabelCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.linkLabelCopyright.LinkArea = new LinkArea(21, 24);
        	this.linkLabelCopyright.Location = new System.Drawing.Point(140, 32);
        	this.linkLabelCopyright.Name = "linkLabelCopyright";
        	this.linkLabelCopyright.Size = new System.Drawing.Size(456, 21);
        	this.linkLabelCopyright.TabIndex = 7;
        	this.linkLabelCopyright.TabStop = true;
        	this.linkLabelCopyright.Text = "Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under GPLv3+";
        	this.linkLabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.linkLabelCopyright.UseCompatibleTextRendering = true;
        	// 
        	// buttonCopyrightCopy
        	// 
        	this.buttonCopyrightCopy.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
        	this.buttonCopyrightCopy.BackColor = System.Drawing.Color.Transparent;
        	this.buttonCopyrightCopy.Location = new System.Drawing.Point(526, 6);
        	this.buttonCopyrightCopy.Name = "buttonCopyrightCopy";
        	this.buttonCopyrightCopy.Size = new System.Drawing.Size(70, 21);
        	this.buttonCopyrightCopy.TabIndex = 1;
        	this.buttonCopyrightCopy.Text = "&Copy";
        	this.toolTip.SetToolTip(this.buttonCopyrightCopy, "Copy selected copyright to clipboard");
        	this.buttonCopyrightCopy.UseVisualStyleBackColor = false;
        	this.buttonCopyrightCopy.Click += new System.EventHandler(this.ButtonCopyClick);
        	// 
        	// comboBoxCopyrights
        	// 
        	this.comboBoxCopyrights.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
			| AnchorStyles.Right)));
        	this.comboBoxCopyrights.DropDownStyle = ComboBoxStyle.DropDownList;
        	this.comboBoxCopyrights.FormattingEnabled = true;
        	this.comboBoxCopyrights.Items.AddRange(new object[] {
			"Component\'s Name"});
        	this.comboBoxCopyrights.Location = new System.Drawing.Point(140, 6);
        	this.comboBoxCopyrights.Name = "comboBoxCopyrights";
        	this.comboBoxCopyrights.Size = new System.Drawing.Size(380, 21);
        	this.comboBoxCopyrights.TabIndex = 0;
        	this.comboBoxCopyrights.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCopyrightsSelectedIndexChanged);
        	// 
        	// richTextBoxCopyrightDescription
        	// 
        	this.richTextBoxCopyrightDescription.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
			| AnchorStyles.Left) 
			| AnchorStyles.Right)));
        	this.richTextBoxCopyrightDescription.BackColor = System.Drawing.SystemColors.Control;
        	this.richTextBoxCopyrightDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.richTextBoxCopyrightDescription.Location = new System.Drawing.Point(140, 82);
        	this.richTextBoxCopyrightDescription.Name = "richTextBoxCopyrightDescription";
        	this.richTextBoxCopyrightDescription.ReadOnly = true;
        	this.richTextBoxCopyrightDescription.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
        	this.richTextBoxCopyrightDescription.Size = new System.Drawing.Size(456, 52);
        	this.richTextBoxCopyrightDescription.TabIndex = 2;
        	this.richTextBoxCopyrightDescription.Text = "Description";
        	// 
        	// tabPageDonation
        	// 
        	this.tabPageDonation.BackColor = System.Drawing.Color.Transparent;
        	this.tabPageDonation.Controls.Add(this.comboBoxDonation);
        	this.tabPageDonation.Controls.Add(this.buttonDonationCopy);
        	this.tabPageDonation.Controls.Add(this.comboBoxDonationCurrencies);
        	this.tabPageDonation.Controls.Add(this.pictureBoxDonation);
        	this.tabPageDonation.Controls.Add(this.richTextBoxDonation);
        	this.tabPageDonation.Location = new System.Drawing.Point(4, 22);
        	this.tabPageDonation.Name = "tabPageDonation";
        	this.tabPageDonation.Padding = new Padding(3);
        	this.tabPageDonation.Size = new System.Drawing.Size(602, 140);
        	this.tabPageDonation.TabIndex = 1;
        	this.tabPageDonation.Text = "Donation";
        	// 
        	// comboBoxDonation
        	// 
        	this.comboBoxDonation.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
			| AnchorStyles.Right)));
        	this.comboBoxDonation.DropDownStyle = ComboBoxStyle.DropDownList;
        	this.comboBoxDonation.FormattingEnabled = true;
        	this.comboBoxDonation.Items.AddRange(new object[] {
			"Bitcoin"});
        	this.comboBoxDonation.Location = new System.Drawing.Point(140, 6);
        	this.comboBoxDonation.Name = "comboBoxDonation";
        	this.comboBoxDonation.Size = new System.Drawing.Size(456, 21);
        	this.comboBoxDonation.TabIndex = 13;
        	// 
        	// buttonDonationCopy
        	// 
        	this.buttonDonationCopy.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
        	this.buttonDonationCopy.BackColor = System.Drawing.Color.Transparent;
        	this.buttonDonationCopy.Location = new System.Drawing.Point(526, 33);
        	this.buttonDonationCopy.Name = "buttonDonationCopy";
        	this.buttonDonationCopy.Size = new System.Drawing.Size(70, 21);
        	this.buttonDonationCopy.TabIndex = 1;
        	this.buttonDonationCopy.Text = "&Copy";
        	this.toolTip.SetToolTip(this.buttonDonationCopy, "Copy selected donation address to clipboard");
        	this.buttonDonationCopy.UseVisualStyleBackColor = false;
        	this.buttonDonationCopy.Click += new System.EventHandler(this.ButtonDonationCopyClick);
        	// 
        	// comboBoxDonationCurrencies
        	// 
        	this.comboBoxDonationCurrencies.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
			| AnchorStyles.Right)));
        	this.comboBoxDonationCurrencies.DropDownStyle = ComboBoxStyle.DropDownList;
        	this.comboBoxDonationCurrencies.FormattingEnabled = true;
        	this.comboBoxDonationCurrencies.Items.AddRange(new object[] {
			"Bitcoin"});
        	this.comboBoxDonationCurrencies.Location = new System.Drawing.Point(140, 33);
        	this.comboBoxDonationCurrencies.Name = "comboBoxDonationCurrencies";
        	this.comboBoxDonationCurrencies.Size = new System.Drawing.Size(380, 21);
        	this.comboBoxDonationCurrencies.TabIndex = 0;
        	this.comboBoxDonationCurrencies.SelectedIndexChanged += new System.EventHandler(this.ComboBoxDonationsSelectedIndexChanged);
        	// 
        	// pictureBoxDonation
        	// 
        	this.pictureBoxDonation.BackColor = System.Drawing.Color.White;
        	this.pictureBoxDonation.BorderStyle = BorderStyle.Fixed3D;
        	this.pictureBoxDonation.InitialImage = null;
        	this.pictureBoxDonation.Location = new System.Drawing.Point(6, 6);
        	this.pictureBoxDonation.Name = "pictureBoxDonation";
        	this.pictureBoxDonation.Size = new System.Drawing.Size(128, 128);
        	this.pictureBoxDonation.SizeMode = PictureBoxSizeMode.StretchImage;
        	this.pictureBoxDonation.TabIndex = 12;
        	this.pictureBoxDonation.TabStop = false;
        	// 
        	// richTextBoxDonation
        	// 
        	this.richTextBoxDonation.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
			| AnchorStyles.Left) 
			| AnchorStyles.Right)));
        	this.richTextBoxDonation.BackColor = System.Drawing.SystemColors.Control;
        	this.richTextBoxDonation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.richTextBoxDonation.Location = new System.Drawing.Point(140, 60);
        	this.richTextBoxDonation.Name = "richTextBoxDonation";
        	this.richTextBoxDonation.ReadOnly = true;
        	this.richTextBoxDonation.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
        	this.richTextBoxDonation.Size = new System.Drawing.Size(456, 74);
        	this.richTextBoxDonation.TabIndex = 2;
        	this.richTextBoxDonation.Text = "1MjwviitdNC7ndvjXL3dG7mE9Pir3ZBSBP";
        	// 
        	// tabPageLicense
        	// 
        	this.tabPageLicense.BackColor = System.Drawing.Color.Transparent;
        	this.tabPageLicense.Controls.Add(this.buttonLicenseCopy);
        	this.tabPageLicense.Controls.Add(this.comboBoxLicenses);
        	this.tabPageLicense.Controls.Add(this.pictureBoxLicense);
        	this.tabPageLicense.Controls.Add(this.richTextBoxLicense);
        	this.tabPageLicense.Location = new System.Drawing.Point(4, 22);
        	this.tabPageLicense.Name = "tabPageLicense";
        	this.tabPageLicense.Padding = new Padding(3);
        	this.tabPageLicense.Size = new System.Drawing.Size(602, 140);
        	this.tabPageLicense.TabIndex = 2;
        	this.tabPageLicense.Text = "License";
        	// 
        	// buttonLicenseCopy
        	// 
        	this.buttonLicenseCopy.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Right)));
        	this.buttonLicenseCopy.BackColor = System.Drawing.Color.Transparent;
        	this.buttonLicenseCopy.Location = new System.Drawing.Point(526, 6);
        	this.buttonLicenseCopy.Name = "buttonLicenseCopy";
        	this.buttonLicenseCopy.Size = new System.Drawing.Size(70, 21);
        	this.buttonLicenseCopy.TabIndex = 1;
        	this.buttonLicenseCopy.Text = "&Copy";
        	this.toolTip.SetToolTip(this.buttonLicenseCopy, "Copy selectet license to clipboard");
        	this.buttonLicenseCopy.UseVisualStyleBackColor = false;
        	this.buttonLicenseCopy.Click += new System.EventHandler(this.ButtonLicenseCopyClick);
        	// 
        	// comboBoxLicenses
        	// 
        	this.comboBoxLicenses.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
			| AnchorStyles.Right)));
        	this.comboBoxLicenses.DropDownStyle = ComboBoxStyle.DropDownList;
        	this.comboBoxLicenses.FormattingEnabled = true;
        	this.comboBoxLicenses.Location = new System.Drawing.Point(140, 6);
        	this.comboBoxLicenses.Name = "comboBoxLicenses";
        	this.comboBoxLicenses.Size = new System.Drawing.Size(380, 21);
        	this.comboBoxLicenses.TabIndex = 0;
        	this.comboBoxLicenses.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLicensesSelectedIndexChanged);
        	// 
        	// pictureBoxLicense
        	// 
        	this.pictureBoxLicense.BackColor = System.Drawing.Color.White;
        	this.pictureBoxLicense.BorderStyle = BorderStyle.Fixed3D;
        	this.pictureBoxLicense.InitialImage = null;
        	this.pictureBoxLicense.Location = new System.Drawing.Point(6, 6);
        	this.pictureBoxLicense.Name = "pictureBoxLicense";
        	this.pictureBoxLicense.Size = new System.Drawing.Size(128, 128);
        	this.pictureBoxLicense.SizeMode = PictureBoxSizeMode.StretchImage;
        	this.pictureBoxLicense.TabIndex = 8;
        	this.pictureBoxLicense.TabStop = false;
        	// 
        	// richTextBoxLicense
        	// 
        	this.richTextBoxLicense.Anchor = ((AnchorStyles)((((AnchorStyles.Top | AnchorStyles.Bottom) 
			| AnchorStyles.Left) 
			| AnchorStyles.Right)));
        	this.richTextBoxLicense.BackColor = System.Drawing.SystemColors.Control;
        	this.richTextBoxLicense.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.richTextBoxLicense.Location = new System.Drawing.Point(140, 33);
        	this.richTextBoxLicense.Name = "richTextBoxLicense";
        	this.richTextBoxLicense.ReadOnly = true;
        	this.richTextBoxLicense.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
        	this.richTextBoxLicense.Size = new System.Drawing.Size(456, 101);
        	this.richTextBoxLicense.TabIndex = 2;
        	this.richTextBoxLicense.Text = "License Details";
        	// 
        	// linkLabelURL
        	// 
        	this.linkLabelURL.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) 
			| AnchorStyles.Right)));
        	this.linkLabelURL.BackColor = System.Drawing.Color.Transparent;
        	this.linkLabelURL.Location = new System.Drawing.Point(12, 239);
        	this.linkLabelURL.Name = "linkLabelURL";
        	this.linkLabelURL.Size = new System.Drawing.Size(438, 19);
        	this.linkLabelURL.TabIndex = 7;
        	this.linkLabelURL.TabStop = true;
        	this.linkLabelURL.Text = "Technical Support URL goes here";
        	this.linkLabelURL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	// 
        	// FormAbout
        	// 
        	this.ClientSize = new System.Drawing.Size(634, 262);
        	this.ControlBox = false;
        	this.Controls.Add(this.linkLabelURL);
        	this.Controls.Add(this.m_lblApplicationName);
        	this.Controls.Add(this.tabControl);
        	this.Controls.Add(this.linkLabelEmail);
        	this.Controls.Add(this.m_btnSysteminfo);
        	this.Controls.Add(this.m_btnOk);
        	this.FormBorderStyle = FormBorderStyle.FixedDialog;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "FormAbout";
        	this.ShowInTaskbar = false;
        	this.Text = "About";
        	this.Activated += new System.EventHandler(this.FormAboutActivated);
        	this.Deactivate += new System.EventHandler(this.FormAboutDeactivate);
        	this.FormClosed += new FormClosedEventHandler(this.FormAbout_FormClosed);
        	this.Load += new System.EventHandler(this.frmAbout_Load);
        	((System.ComponentModel.ISupportInitialize)(this.pictureBoxAppIcon)).EndInit();
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
//-----------------------------------------------------------------------------------
