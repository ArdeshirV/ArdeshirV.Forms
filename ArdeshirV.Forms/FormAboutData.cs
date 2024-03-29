﻿#region Header

// Form About
// FormAboutData.cs : Provides data holder for form about
// Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under LGPLv3+

using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using ArdeshirV.Tools;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using ArdeshirV.Forms.Properties;
using ArdeshirV.Tools.QrCode;
using qr=ArdeshirV.Tools.QrCode;

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
    	/// <param name="product_name">Component's name</param>
    	/// <param name="version">Component's version</param>
    	/// <param name="company">Component's company name</param>
    	/// <param name="copyrights">Copyright text</param>
    	/// <param name="description">Component's description</param>
    	/// <param name="logo">Component's logo</param>
    	public Copyright(string product_name, string version, string company,
    	                 string copyrights, string description, Image logo)
    	{
    		_name = product_name;
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
    		_name = info.AssemblyProduct;
    		_logo = logo;
    		_version = info.AssemblyVersion;
    		_company = info.AssemblyCompany;
    		_copyright = info.AssemblyCopyright;
    		_description = info.AssemblyDescription;
    	}
    }
    //-------------------------------------------------------------------------------
    /// <summary>
    /// Contains a credit name/logo-description pair.
    /// </summary>
    public sealed class Credit
    {
    	private readonly string _name;
    	private readonly Image  _avator;
    	private readonly string _description;
    	//---------------------------------------------------------------------
    	public string Name { get { return _name; } }
    	public Image Avator { get { return _avator; } }
    	public string Description { get { return _description; } }
    	//---------------------------------------------------------------------
    	private Credit() {}
    	//---------------------------------------------------------------------
    	/// <summary>
    	/// Creates a credit entry with name, logo and description.
    	/// </summary>
    	/// <param name="name">Specify the person who has this credit.</param>
    	/// <param name="description">Description about this credit</param>
    	/// <param name="avator">Personal credit avator</param>
    	public Credit(string name, string description, Image avator)
    	{
    		_name = name;
    		_avator = avator;
    		_description = description;
    	}
    }
    //-----------------------------------------------------------------------------------
    /// <summary>
    /// Contains an array of credits
    /// </summary>
    public sealed class Credits
    {
    	private readonly string _name;
    	private readonly Credit[] _creditArr;
    	//-------------------------------------------------------------------------------
    	public string Name { get { return _name; } }
    	public Credit[] Items { get { return _creditArr; } }
    	public Credit this[int index] { get { return _creditArr[index]; } }
    	//-------------------------------------------------------------------------------
    	private Credits() {}
    	//-------------------------------------------------------------------------------
    	/// <summary>
    	/// Creates a credit array entry with names, avators and descritons.
    	/// </summary>
    	/// <param name="name">Component Name that refer to current credit.</param>
    	/// <param name="creditArr">Contains credit name, avator and descriton
    	/// about the current component that specified in name.</param>
    	public Credits(string name, Credit[] creditArr)
    	{
    		_name = name;
    		_creditArr = creditArr;
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
    /// Contains a donation currency-type/address-list pair.
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
		//-------------------------------------------------------------------------------
		public static Donation NewDonationByDefaultCurrencyLogos(
			string DefaultCurrencyName, string CurrencyAddress) {
			if(GlobalResouces.CurrencyLogos.Contains(DefaultCurrencyName))
				return new Donation(DefaultCurrencyName, CurrencyAddress,
				                    GlobalResouces.CurrencyLogos.
				                    GetItemByName(DefaultCurrencyName));
			else
				throw new ApplicationException(string.Format(
					"The \"{0}\" not found in GlobalResouces.CurrencyLogos",
					DefaultCurrencyName));
		}
    }
    //-----------------------------------------------------------------------------------
	public sealed class FormAboutData
	{
		private readonly string _URL;
		private readonly string _email;
		private readonly IWin32Window _formOwner;
		private readonly Dictionary<string, License> _licenses;
		private readonly Dictionary<string, Credit[]> _credits;
		private readonly Dictionary<string, Copyright> _copyrights;
		private readonly Dictionary<string, Donation[]> _donations;
		//-------------------------------------------------------------------------------
		public string URL { get { return _URL; } }
		public string Email { get { return _email; } }
		public IWin32Window Owner { get { return _formOwner; } }
		public Dictionary<string, Credit[]> Credits { get { return _credits; } }
		public Dictionary<string, License> Licenses { get { return _licenses; } }
		public Dictionary<string, Copyright> Copyrights { get { return _copyrights; } }
		public Dictionary<string, Donation[]> Donations { get { return _donations; } }
		//-------------------------------------------------------------------------------
		public string AppName
		{
			get {
				string result = string.Empty;
				
				if(Owner != null)
					result = new AssemblyAttributeAccessors(Owner).AssemblyTitle;
				
				return result;
			}
		}
		//-------------------------------------------------------------------------------
		private FormAboutData() {}
		//-------------------------------------------------------------------------------
		public FormAboutData(IWin32Window owner, Copyright[] copyrights,
		                     Credits[] credits, License[] licenses,
		                     Donations[] donations, string URL, string email)
		{
			_URL = URL;
			_email = email;
			_formOwner = owner;
			_credits = new Dictionary<string, Credit[]>();
			_licenses = new Dictionary<string, License>();
			_donations = new Dictionary<string, Donation[]>();
			_copyrights = new Dictionary<string, Copyright>();

			if(donations != null)
				foreach(Donations d in donations)
					_donations.Add(d.Name, d.Items);
			
			if(credits != null)
				foreach(Credits c in credits)
					_credits.Add(c.Name, c.Items);
			
			if(licenses != null)
				foreach(License l in licenses)
					_licenses.Add(l.Name, l);
			
			if(copyrights != null)
				foreach(Copyright c in copyrights)
					_copyrights.Add(c.Name, c);
			
			AddDefaults();
		}
		//-------------------------------------------------------------------------------
		private void AddDefaults()
		{
			AssemblyAttributeAccessors aaa = new AssemblyAttributeAccessors(this);
			_donations.Add(aaa.AssemblyProduct, DefaultDonationList.Items);
			
			_copyrights.Add(aaa.AssemblyProduct, new Copyright(this, Resources.ArdeshirV_Forms_Logo));
			_licenses.Add(aaa.AssemblyProduct, new License("LGPLv3+", Resources.LGPL_LICENSE, Resources.LGPLv3));
			_credits.Add(aaa.AssemblyProduct, new Credit[] { DefaultCreditList.GetItem("ArdeshirV.Forms") });
			
			aaa = new AssemblyAttributeAccessors(qr.QrCode.Ecc.High);
			_copyrights.Add(aaa.AssemblyProduct, new Copyright(qr.QrCode.Ecc.High, qr.Res.Logo));
			_licenses.Add(aaa.AssemblyProduct, new License("MIT", qr.Res.License, qr.Res.LicenseLogo));
			_credits.Add(aaa.AssemblyProduct, new Credit[] {
			             	DefaultCreditList.GetItem("ArdeshirV.Tools.QrCode"),
			             	DefaultCreditList.GetItem("Manuel Bleichenbacher"),
			             	DefaultCreditList.GetItem("Nayuki Project")
			});
		}
	}
	//-----------------------------------------------------------------------------------
	/// <summary>
	/// Provides default donation addresses.
	/// </summary>
	public static class DefaultDonationList
	{
		private static readonly Donation[] _donations;
		private static readonly Dictionary<string, Donation> _list;
		//-------------------------------------------------------------------------------
		static DefaultDonationList()
		{
			//***************************************************************************
			// Warning: Nobody is not allowed to change or modify my donation addresses here
			// but you are allowed to add your own donation addresses somewhere else
 			// that refer to your own components. That place is out of this file.
			// for more information and find that sample code about
			// how to adding your own addresses easily above mine;
			// You can find the best sample code in "TestForms/FormMainTest.cs" file.	
			// Search for "todo: You are allowed to change..." in your "Task List"
			// in the "FormMainTest.cs" file of "TestForms" project
			_donations = new Donation[] {
				/*CreateDonationByDefaultLogos("Bitcoin", "1GtjrxH6t8om8KwHAHKpcG5SAwVSsm4PEi"),
				CreateDonationByDefaultLogos("Ethereum", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Tron", "TCB6uBci8mw1P4e2xikSGbyHcFjNCFphXr"),
				CreateDonationByDefaultLogos("Paxos Standard", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Tether", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("PAX Gold", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Tether Gold", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("TrueUSD", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Binance", "bnb15qwa7kl46ledh5zqqynmy2tqw92mhzuwmap6sf"),
				CreateDonationByDefaultLogos("Nano", "nano_3feuiaogay8zbsfye5ob1xp7obwb4syfpmc4pcb7ctckhh5z8671q4uzm9tc"),
				CreateDonationByDefaultLogos("Stellar", "GCMALSIYBJT74K5SKJFHMLBJRWFCO6EPIKQ4DO6C7ER4QAYIMTQSOOWI"),
				CreateDonationByDefaultLogos("Ripple", "raBw695Qnkt5RNTxTcyGFPzC5yFFHYztfR"),
				CreateDonationByDefaultLogos("Cardano", "DdzFFzCqrhsoSn5qvqRTovUkr1XHWy9LvbvDHVYFoFFyxAJkf1bT4X4ySpm8DwFqDo3EWAn934W9WfipbSNiXTcRzEqLP1y5KyAfMByJ"),
				CreateDonationByDefaultLogos("Neo", "AXqbLBWhcrFrjumvrm8nW9iYaUFoKML17b"),
				CreateDonationByDefaultLogos("NEM", "NDXCTS2ITWO4J33YPL7AMHSGOIFRJSTBWSDZ4C3P"),
				CreateDonationByDefaultLogos("Qtum", "QddGvqLg5yTi2J2DvixZVFgA1rpm5RAq2x"),
				CreateDonationByDefaultLogos("Litecoin", "LdfYVr2Lgyuwp9K5Dk4aUsUbUQ2Rr5TA1n"),
				CreateDonationByDefaultLogos("Bitcoin Cash", "bitcoincash:qzqsse2w6vqkqylfvkuqdvmgpl34zyq2cvwneunpyl"),
				CreateDonationByDefaultLogos("Dash", "XhsE3ntLYdKMbT4JptTvURqyu9RKuypDCf"),
				CreateDonationByDefaultLogos("Verge", "DRviBtskt1M6BBTpAoNvF3qLrpKTN3mb7P"),
				CreateDonationByDefaultLogos("Zcash", "t1ZnspKa3XFijtUAG6yKHsM3y6Bdb7C8HKA"),
				CreateDonationByDefaultLogos("Monero", "42dJ7dWZjHyV4bzL4uVcS6cYnNfSvtXQyJaZ83yj4xALMiZoEMuja5SdcMHZS3Ai1eDCF9D5RDzgrHoyngckf38yC2MM42y")*/
				// New Age:	
				CreateDonationByDefaultLogos("Bitcoin", "1GtjrxH6t8om8KwHAHKpcG5SAwVSsm4PEi"),
				CreateDonationByDefaultLogos("Ethereum", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("0x", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Aelf", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				//CreateDonationByDefaultLogos("Aeon", ""),
				//CreateDonationByDefaultLogos("Aeternity", ""),
				//CreateDonationByDefaultLogos("Aion", ""),
				CreateDonationByDefaultLogos("Algorand", "R56QE572WNYFZHGDVEZJJISC3FUKTL3R6BOH5PI2CAOZA6EKN3VXEAYPUE"),
				CreateDonationByDefaultLogos("AppCoins", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Aragon", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Augur", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Band Protocol", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Basic Attention Token", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Binance", "bnb15qwa7kl46ledh5zqqynmy2tqw92mhzuwmap6sf"),
				//CreateDonationByDefaultLogos("Bitcloud", ""),
				CreateDonationByDefaultLogos("Bitcoin Cash", "bitcoincash:qzqsse2w6vqkqylfvkuqdvmgpl34zyq2cvwneunpyl"),
				//CreateDonationByDefaultLogos("Bitcoin Diamond", "",
				CreateDonationByDefaultLogos("Bitcoin Gold", "GfZCbP7Ke63ZC15XuJ25Hk85RD3wrNNUhx"),
				//CreateDonationByDefaultLogos("Bitcoin Plus", ""),
				//CreateDonationByDefaultLogos("Bitcoin Private", ""),
				CreateDonationByDefaultLogos("Bitcoin SV", "1Q5x8RN4U9NfX8vCzzEiQjzEwF96nqK9a6"),
				//CreateDonationByDefaultLogos("BitCore", ""),
				CreateDonationByDefaultLogos("Bitforex Token", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				//CreateDonationByDefaultLogos("BlockStamp", ""),
				CreateDonationByDefaultLogos("Cardano", "addr1qya3zys7rq43wgqza56gp7c4u8nz65r2nevx0fgufr9v67mjas64zaqf3e06txnwxlmswc5kuu5zg4vhmqqy5kp7x7lqlktd4p"),
				//CreateDonationByDefaultLogos("Celo", ""),
				CreateDonationByDefaultLogos("Celsius", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Chainlink", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				//CreateDonationByDefaultLogos("ChainX", ""),
				CreateDonationByDefaultLogos("Civic", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Cosmos", "cosmos19vsvjmat4e9rajf3ul8pj7hvfdf2qwyd8m858g"),
				CreateDonationByDefaultLogos("Crypto.com", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Curve DAO Token", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Dash", "XhsE3ntLYdKMbT4JptTvURqyu9RKuypDCf"),
				CreateDonationByDefaultLogos("Decentraland", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Decred", "DsXEuRKJGKJuyzTJdwjP4Q7uvu9pbWmtUjR"),
				CreateDonationByDefaultLogos("Dogecoin", "DBTNGiTWbU4bY3b9JG65Ukaf7YmVP6L92S"),
				//CreateDonationByDefaultLogos("Energy Web Token", ""),
				CreateDonationByDefaultLogos("Enjin Coin", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				//CreateDonationByDefaultLogos("EOS", ""),
				//CreateDonationByDefaultLogos("Ether Zero", ""),
				CreateDonationByDefaultLogos("Ethereum Classic", "0xcA5616Eed1526C7556EB82E9a256EA8853758De9"),
				//CreateDonationByDefaultLogos("Filecoin", ""),
				CreateDonationByDefaultLogos("FTX Token", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Gas", "AXqbLBWhcrFrjumvrm8nW9iYaUFoKML17b"),
				CreateDonationByDefaultLogos("Gemini Dollar", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Gifto", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				//CreateDonationByDefaultLogos("Grin", ""),
				CreateDonationByDefaultLogos("Harmony", "one1tzj94a0txlzatfar3lu7ze9nt2pmsmhx2ktx79"),
				CreateDonationByDefaultLogos("Holo", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				//CreateDonationByDefaultLogos("Icon", ""),
				//CreateDonationByDefaultLogos("IOS Token", ""),
				//CreateDonationByDefaultLogos("IOTA", ""),
				//CreateDonationByDefaultLogos("IoTeX", ""),
				CreateDonationByDefaultLogos("Komodo", "RJ6AdFxX3cSU8j6uMJ3i2DssZSmPvRcZ78"),
				//CreateDonationByDefaultLogos("LikeCoin", ""),
				CreateDonationByDefaultLogos("Lisk", "6098732446475015356L"),
				CreateDonationByDefaultLogos("Litecoin", "LdfYVr2Lgyuwp9K5Dk4aUsUbUQ2Rr5TA1n"),
				CreateDonationByDefaultLogos("Loom Network", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Loopring", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Maker", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Metal", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Monero", "42dJ7dWZjHyV4bzL4uVcS6cYnNfSvtXQyJaZ83yj4xALMiZoEMuja5SdcMHZS3Ai1eDCF9D5RDzgrHoyngckf38yC2MM42y"),
				CreateDonationByDefaultLogos("Nano", "nano_3feuiaogay8zbsfye5ob1xp7obwb4syfpmc4pcb7ctckhh5z8671q4uzm9tc"),
				CreateDonationByDefaultLogos("NEM", "NDXCTS2ITWO4J33YPL7AMHSGOIFRJSTBWSDZ4C3P"),
				CreateDonationByDefaultLogos("Neo", "AXqbLBWhcrFrjumvrm8nW9iYaUFoKML17b"),
				//CreateDonationByDefaultLogos("NXT", ""),
				CreateDonationByDefaultLogos("Ontology", "AFtEqcxj87TLpV1wpPm5uuD2ZZWe5zdESJ"),
				CreateDonationByDefaultLogos("Orchid", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("PAX Gold", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Paxos Standard", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				//CreateDonationByDefaultLogos("PIVX", ""),
				CreateDonationByDefaultLogos("Polkadot", "1BpdZXFUNeqUbpmfVrL9D2qMYtyBV2pbw9dtAqrYxAbMim5"),
				CreateDonationByDefaultLogos("Qash", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Qtum", "QddGvqLg5yTi2J2DvixZVFgA1rpm5RAq2x"),
				CreateDonationByDefaultLogos("Ravencoin", "RWHvuEKEmVHt63a4XhZJwKPS5mivxsfiBQ"),
				CreateDonationByDefaultLogos("Salt", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				//CreateDonationByDefaultLogos("Siacoin", ""),
				CreateDonationByDefaultLogos("Status", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				//CreateDonationByDefaultLogos("Steem", ""),
				//CreateDonationByDefaultLogos("Steem Dollars", ""),
				CreateDonationByDefaultLogos("Stellar", "GCMALSIYBJT74K5SKJFHMLBJRWFCO6EPIKQ4DO6C7ER4QAYIMTQSOOWI"),
				CreateDonationByDefaultLogos("Storj", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				//CreateDonationByDefaultLogos("Stratis", ""),
				CreateDonationByDefaultLogos("Sushi", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Swipe", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("SwissBorg", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Tether", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Tether Gold", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Tezos", "tz1Q4VFYnPDFPrNpVjjvtEffQCHktWo1MZqp"),
				//CreateDonationByDefaultLogos("TokenPay", ""),
				CreateDonationByDefaultLogos("Tron", "TCB6uBci8mw1P4e2xikSGbyHcFjNCFphXr"),
				CreateDonationByDefaultLogos("TrueUSD", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Uniswap", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("USD Coin", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("VeChain", "0x632813f28848927ba22f66017617adb1e89db690"),
				CreateDonationByDefaultLogos("Verge", "DRviBtskt1M6BBTpAoNvF3qLrpKTN3mb7P"),
				//CreateDonationByDefaultLogos("VeriCoin", ""),
				CreateDonationByDefaultLogos("Vertcoin", "VxBmHndYCaY9zp9jHFmurgFG7CfQhTXAnm"),
				CreateDonationByDefaultLogos("VIBE", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Waves", "3P9pDZTKqdotRFK1A24dkC31P6ZxkqGF75z"),
				CreateDonationByDefaultLogos("WePower", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Wing", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Ripple", "raBw695Qnkt5RNTxTcyGFPzC5yFFHYztfR"),
				CreateDonationByDefaultLogos("yearn.finance", "0x6E6465394D14975956cd1BD37ab4E35F2C60300E"),
				CreateDonationByDefaultLogos("Zcash", "t1ZnspKa3XFijtUAG6yKHsM3y6Bdb7C8HKA"),
				//CreateDonationByDefaultLogos("Zclassic", ""),
				//CreateDonationByDefaultLogos("Flux", ""),
				CreateDonationByDefaultLogos("Zilliqa", "zil1xw9d6v2gncew6vqkuqkl59mrvdjtf6qac7vqfh")
			};
			_list = new Dictionary<string, Donation>();
			foreach(Donation d in _donations)
				_list.Add(d.Name, d);
			//************************************************************************
		}
		//-------------------------------------------------------------------------------
		/// <summary>
		/// Provides a new donation instance with one of predefined currency image logos
		/// that are exists as predefined values in GlobalResouces.CurrencyLogos
		/// You can check the full list of predefined currency logos in
		/// the GlobalResouces.CurrencyLogos.NamesList
		/// </summary>
		/// <param name="CurrencyName">The currency name that should be exists in
		/// GlobalResouces.CurrencyLogos.NamesList as default currency logos</param>
		/// <param name="CurrencyAddress"></param>
		/// <returns></returns>
		public static Donation CreateDonationByDefaultLogos(
			string CurrencyName, string CurrencyAddress)
		{
			if(GlobalResouces.CurrencyLogos.Contains(CurrencyName)) {
				Image imageLogo = GlobalResouces.CurrencyLogos.GetItemByName(CurrencyName);
				return new Donation(CurrencyName, CurrencyAddress, imageLogo);
			} else
				throw new Exception(string.Format(
					"Error in DefaultDonationList.CreateDonationByDefaultLogos\nThe cu" +
					"rrency name: \"{0}\" is not exists in predefined CurrencyLogos list.",
					CurrencyName));
		}
		//-------------------------------------------------------------------------------
		public static Donation[] Items {
			get {
				return _donations;
			}
		}
		//-------------------------------------------------------------------------------
		public static Donation GetItem(string Name) {
			return _list[Name];
		}
		//-------------------------------------------------------------------------------
		public static bool IsExists(string Name) {
			return _list.ContainsKey(Name);
		}
	}
	//-----------------------------------------------------------------------------------
	/// <summary>
	/// Provides default credit information that are used
	/// in this project and relative projects.
	/// </summary>
	public static class DefaultCreditList
	{
		private static readonly Credit[] _credits;
		private static readonly Dictionary<string, Credit> _list;
		//-------------------------------------------------------------------------------
		static DefaultCreditList()
		{
			//***************************************************************************
			// Warning: Nobody is not allowed to change or modify credits that
			// are mentioned here but you are allowed to add your own credit
			// somewhere else that refer to your own components.
			// That place is out of this file.
			// Now search for "todo: You are allowed to change..." in your "Task List"
			// in FormMainTest.cs for more information and find that sample code about
			// how to adding your own credit information easily above mine.
			// You can find the best sample code in TestForms/FormMainTest.cs file.
			const string strCreditArdeshirVQrCode=
@"ArdeshirV downgrade the https://github.com/manuelbl/QrCodeGenerator project to C# 2.0 to use it with ArdeshirV.Forms Project.
QrCode: https://ardeshirv.github.io/ArdeshirV.Tools.QrCode
Github: https://github.com/ArdeshirV/ArdeshirV.Tools.QrCode
Email: ArdeshirV@protonmail.com";

			const string strCreditArdeshirV  =
@"ArdeshirV is founder and developer of 'ArdeshirV.Forms' project.
ArdeshirV.Forms: https://ardeshirv.github.io/ArdeshirV.Forms
Github: https://github.com/ArdeshirV/ArdeshirV.Forms
Email: ArdeshirV@protonmail.com";

			const string strCreditNayuki =
@"The original QrCode project is created in Nayuki project with Java by Nayuki.
Project Nayuki: https://www.nayuki.io/page/qr-code-generator-library
Github: https://github.com/nayuki/QR-Code-generator
Email: me@nayuki.io";

			const string strCreditBleichenbacher =
@"Manuel Bleichenbacher converted original Nayuki project about QrCodeGenerator from Java to C#.
QrCodeGenerator: https://github.com/manuelbl/QrCodeGenerator";

			_credits = new Credit[] {
			    new Credit("ArdeshirV.Tools.QrCode", strCreditArdeshirVQrCode, Resources.ArdeshirV),
				new Credit("ArdeshirV.Forms", strCreditArdeshirV, Resources.ArdeshirV),
				new Credit("Nayuki Project", strCreditNayuki, Res.NayukiAvator),
				new Credit("Manuel Bleichenbacher", strCreditBleichenbacher, Res.ManuelBleichenbacherAvator)
			};
			
			_list = new Dictionary<string, Credit>();
			foreach(Credit c in _credits)
				_list.Add(c.Name, c);
			//***************************************************************************
		}
		//-------------------------------------------------------------------------------
		/// <summary>
		/// Gets all items.
		/// </summary>
		public static Credit[] Items {
			get {
				return _credits;
			}
		}
		//-------------------------------------------------------------------------------
		/// <summary>
		/// Gets an item that is specified by a name.
		/// </summary>
		/// <param name="strCreditName">Credit name.</param>
		/// <returns>Credit with specified name.</returns>
		public static Credit GetItem(string strCreditName) {
			return _list[strCreditName];
		}
		//-------------------------------------------------------------------------------
		/// <summary>
		/// Check the item with specified name is exists or not.
		/// </summary>
		/// <param name="strCreditName">Credit name</param>
		/// <returns>true if credit with specified name is exists</returns>
		public static bool IsExists(string strCreditName) {
			return _list.ContainsKey(strCreditName);
		}
	}
}
//---------------------------------------------------------------------------------------
