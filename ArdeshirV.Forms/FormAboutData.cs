#region Header

// Form About
// FormAboutData.cs : Provides data holder for form about
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
//-----------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
    /// <summary>
    /// License class contains data about application/component's license.
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
    	/// Creates License class that contains the component's license information.
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
    
    /// <summary>
    /// Copyright class contains data about application/component's copyright 
    /// </summary>
    public sealed class Copyright
    {
    	private readonly Image  _logo;
    	private readonly string _name;
    	private readonly string _version;
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
    	/// <param name="copyrights">Copyright text</param>
    	/// <param name="description">Component's description</param>
    	/// <param name="logo">Component's logo</param>
    	public Copyright(string name, string version,
    	                 string copyrights, string description, Image logo)
    	{
    		_name = name;
    		_logo = logo;
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
    	public Copyright(Component component, Image logo)
    	{
            AssemblyAttributeAccessors info = new AssemblyAttributeAccessors(
    			Assembly.GetAssembly(component.GetType()));
    		_name = info.AssemblyTitle;
    		_logo = logo;
    		_version = info.AssemblyVersion;
    		_copyright = info.AssemblyCopyright;
    		_description = info.AssemblyDescription;
    	}
    }
    //-------------------------------------------------------------------------
    /// <summary>
    /// Contains a donation currency-type/address pair.
    /// </summary>
    public sealed class Donation
    {
    	private readonly string _name;
    	private readonly string _address;
    	//---------------------------------------------------------------------
    	public string Name { get { return _name; } }
    	public string Address { get { return _address; } }
    	//---------------------------------------------------------------------
    	private Donation() {}
    	//---------------------------------------------------------------------
    	/// <summary>
    	/// Creates a donation entry with currency-type/address pair.
    	/// </summary>
    	/// <param name="name">Currency type such as PayPal, Bitcoin, ...</param>
    	/// <param name="address">Currency address</param>
    	private Donation(string name, string address) 
    	{
    		_name = name;
    		_address = address;
    	}
    }
    //-------------------------------------------------------------------------
	public sealed class FormAboutData
	{
		private readonly string _URL;
		private readonly string _email;
		private readonly Form _formOwner;
		private readonly Dictionary<string, string> _donations;
		private readonly Dictionary<string, License> _licenses;
		private readonly Dictionary<string, Copyright> _copyrights;
		//---------------------------------------------------------------------
		public string URL { get { return _URL; } }
		public string Email { get { return _email; } }
		public Form Owner { get { return _formOwner; } }
		public Dictionary<string, string> Donations { get { return _donations; } }
		public Dictionary<string, License> Licenses { get { return _licenses; } }
		public Dictionary<string, Copyright> Copyrights { get { return _copyrights; } }
		//---------------------------------------------------------------------
		public string AppName
		{
			get
			{
				string result = string.Empty;
				
				if(Owner != null)
					result = new AssemblyAttributeAccessors(
						Assembly.GetAssembly(
							Owner.GetType())).AssemblyProduct;
				
				return result;
			}
		}
		//---------------------------------------------------------------------
		private FormAboutData() {}
		//---------------------------------------------------------------------
		public FormAboutData(Form owner, Copyright[] copyrights,
		                     License[] licenses, Donation[] donations,
		                     string URL, string email)
		{
			_formOwner = owner;
			_URL = URL;
			_email = email;
			_donations = new Dictionary<string, string>();
			_licenses = new Dictionary<string, License>();
			_copyrights = new Dictionary<string, Copyright>();
			
			foreach(Donation d in donations)
				_donations.Add(d.Name, d.Address);
			
			foreach(Copyright c in copyrights)
				_copyrights.Add(c.Name, c);
			
			foreach(License l in licenses)
				_licenses.Add(l.Name, l);
		}
	}
}
//-----------------------------------------------------------------------------