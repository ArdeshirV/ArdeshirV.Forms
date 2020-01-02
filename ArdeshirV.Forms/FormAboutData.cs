#region Header

// Form About
// FormAboutData.cs : Provides data holder for form about
// Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under LGPLv3+

using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using ArdeshirV.Utilities;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using ArdeshirV.Forms.Properties;
using ArdeshirV.Utilities.QrCode;
using qr=ArdeshirV.Utilities.QrCode;

#endregion
//-----------------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
    /// <summary>
    /// License class contains data about application/component's license
    /// </summary>
    public sealed class License
    {
    	private readonly string _name;
    	private readonly string _text;
    	private readonly Image  _logo;
    	//---------------------------------------------------------------------
    	/// <summary>
    	/// Component's name
    	/// </summary>
    	public string Name { get{ return _name; } }
    	//---------------------------------------------------------------------
    	/// <summary>
    	/// License text 
    	/// </summary>
    	public string Text { get{ return _text; } }
    	//---------------------------------------------------------------------
    	/// <summary>
    	/// License logo
    	/// </summary>
    	public Image  Logo { get{ return _logo; } }
    	//---------------------------------------------------------------------
    	private License() {}
    	//---------------------------------------------------------------------
    	/// <summary>
    	/// Creates License class that contains the component's license information
    	/// </summary>
    	/// <param name="name">License name such as GPL, MIT, Apache...</param>
    	/// <param name="text">License contents and details</param>
    	/// <param name="logo">License logo</param>
    	public License(string name, string text, Image logo)
    	{
    		_name = name;
    		_text = text;
    		_logo = logo;
    	}
    }
    //-------------------------------------------------------------------------------    
    /// <summary>
    /// Copyright class contains data about application/component's copyright 
    /// </summary>
    public sealed class Copyright
    {
    	private readonly Image  _logo;
    	private readonly string _name;
    	private readonly string _version;
    	private readonly string _company;
    	private readonly string _copyright;
    	private readonly string _description;
    	//---------------------------------------------------------------------
    	/// <summary>
    	/// Component's name
    	/// </summary>
    	public string Name { get{ return _name; } }
    	//---------------------------------------------------------------------
    	/// <summary>
    	/// Component's version
    	/// </summary>
    	public string Version { get{ return _version; } }
    	//---------------------------------------------------------------------
    	/// <summary>
    	/// Copyright text
    	/// </summary>
    	public string Copyrights { get{ return _copyright; } }
    	//---------------------------------------------------------------------
    	/// <summary>
    	/// Company name
    	/// </summary>
    	public string Company { get{ return _company; } }
    	//---------------------------------------------------------------------
    	/// <summary>
    	/// Component's description
    	/// </summary>
    	public string Description { get{ return _description; } }
    	//---------------------------------------------------------------------
    	/// <summary>
    	/// Component's logo
    	/// </summary>
    	public Image  Logo { get{ return _logo; } }
    	//---------------------------------------------------------------------
    	private Copyright() {}
    	//---------------------------------------------------------------------
    	/// <summary>
    	/// Creates copyright class that contains the component's copyright information.
    	/// </summary>
    	/// <param name="name">Component's name</param>
    	/// <param name="version">Component's version</param>
    	/// <param name="company">Component's company name</param>
    	/// <param name="copyrights">Copyright text</param>
    	/// <param name="description">Component's description</param>
    	/// <param name="logo">Component's logo</param>
    	public Copyright(string name, string version, string company,
    	                 string copyrights, string description, Image logo)
    	{
    		_name = name;
    		_logo = logo;
    		_company = company;
    		_version = version;
    		_copyright = copyrights;
    		_description = description;
    	}
    	//---------------------------------------------------------------------
    	/// <summary>
    	/// Creates copyright class that contains the component's copyright information.
    	/// This constructor retrive copyright assembly information
    	/// from specified control by reflection.
    	/// </summary>
    	/// <param name="component">Retrive copyright information from this component</param>
    	/// <param name="logo">Component's logo</param>
    	public Copyright(object component, Image logo)
    	{
            AssemblyAttributeAccessors info = new AssemblyAttributeAccessors(
    			Assembly.GetAssembly(component.GetType()));
    		_name = info.AssemblyTitle;
    		_logo = logo;
    		_version = info.AssemblyVersion;
    		_company = info.AssemblyCompany;
    		_copyright = info.AssemblyCopyright;
    		_description = info.AssemblyDescription;
    	}
    }
    //-------------------------------------------------------------------------------
    /// <summary>
    /// Contains a donation currency-type/address pair.
    /// </summary>
    public sealed class Donation
    {
    	private readonly string _name;
    	private readonly Image  _logo;
    	private readonly string _address;
    	//---------------------------------------------------------------------
    	public string Name { get { return _name; } }
    	public Image Logo { get { return _logo; } }
    	public string Address { get { return _address; } }
    	//---------------------------------------------------------------------
    	private Donation() {}
    	//---------------------------------------------------------------------
    	/// <summary>
    	/// Creates a donation entry with currency-type/address pair.
    	/// </summary>
    	/// <param name="name">Currency type such as PayPal, Bitcoin, ...</param>
    	/// <param name="address">Currency address</param>
    	/// <param name="logo">Currency global logo</param>
    	public Donation(string name, string address, Image logo)
    	{
    		_name = name;
    		_logo = logo;
    		_address = address;
    	}
    }
    //-----------------------------------------------------------------------------------
    /// <summary>
    /// Contains a donation currency-type/address pair.
    /// </summary>
    public sealed class Donations
    {
    	private readonly string _name;
    	private readonly Donation[] _donations;
    	//-------------------------------------------------------------------------------
    	public string Name { get { return _name; } }
    	public Donation[] Items { get { return _donations; } }
    	public Donation this[int index] { get { return _donations[index]; } }
    	//-------------------------------------------------------------------------------
    	private Donations() {}
    	//-------------------------------------------------------------------------------
    	/// <summary>
    	/// Creates a donation entry with currency-type/address pair.
    	/// </summary>
    	/// <param name="name">Component Name that refer to donation addresses</param>
    	/// <param name="donations">Currency Name(s), Address(es), Logo(s)</param>
    	public Donations(string name, Donation[] donations)
    	{
    		_name = name;
    		_donations = donations;
    	}
    }
    //-----------------------------------------------------------------------------------
	public sealed class FormAboutData
	{
		private readonly string _URL;
		private readonly string _email;
		private readonly Component _formOwner;
		private readonly Dictionary<string, License> _licenses;
		private readonly Dictionary<string, Copyright> _copyrights;
		private readonly Dictionary<string, Donation[]> _donations;
		//-------------------------------------------------------------------------------
		public string URL { get { return _URL; } }
		public string Email { get { return _email; } }
		public Component Owner { get { return _formOwner; } }
		public Dictionary<string, License> Licenses { get { return _licenses; } }
		public Dictionary<string, Copyright> Copyrights { get { return _copyrights; } }
		public Dictionary<string, Donation[]> Donations { get { return _donations; } }
		//-------------------------------------------------------------------------------
		public string AppName
		{
			get
			{
				string result = string.Empty;
				
				if(Owner != null)
					result = new AssemblyAttributeAccessors(Owner).AssemblyProduct;
				
				return result;
			}
		}
		//-------------------------------------------------------------------------------
		private FormAboutData() {}
		//-------------------------------------------------------------------------------
		public FormAboutData(Component owner, Copyright[] copyrights,
		                     License[] licenses, Donations[] donations,
		                     string URL, string email)
		{
			_URL = URL;
			_email = email;
			_formOwner = owner;
			_licenses = new Dictionary<string, License>();
			_donations = new Dictionary<string, Donation[]>();
			_copyrights = new Dictionary<string, Copyright>();

			foreach(Donations d in donations)
				_donations.Add(d.Name, d.Items);
			
			foreach(License l in licenses)
				_licenses.Add(l.Name, l);
			
			foreach(Copyright c in copyrights)
				_copyrights.Add(c.Name, c);
			
			AddDefaults();
		}
		//-------------------------------------------------------------------------------
		private void AddDefaults()
		{
			AssemblyAttributeAccessors aaa = new AssemblyAttributeAccessors(this);
			_donations.Add(aaa.AssemblyTitle, DefaultDonationList.Items);
			_copyrights.Add(aaa.AssemblyTitle, new Copyright(this, Resources.ArdeshirV_Forms_Logo));
			_licenses.Add(aaa.AssemblyTitle, new License("LGPLv3+", Resources.LICENSE, Resources.LGPLv3));
			
			aaa = new AssemblyAttributeAccessors(qr.QrCode.Ecc.High);
			_copyrights.Add(aaa.AssemblyTitle, new Copyright(qr.QrCode.Ecc.High, qr.Res.Logo));
			_licenses.Add(aaa.AssemblyTitle, new License("MIT", qr.Res.License, qr.Res.LicenseLogo));
		}
	}
}
//---------------------------------------------------------------------------------------