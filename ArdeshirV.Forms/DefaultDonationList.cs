#region Header

// Copyright© 2002-2020 ArdeshirV@protonmail.com, Licensed under LGPLv3+
using System;
using System.Collections.Generic;
using ArdeshirV.Forms.Properties;

#endregion
//---------------------------------------------------------------------------------------
namespace ArdeshirV.Forms
{
	/// <summary>
	/// DefaultDonationList provides default donation addresses
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
			// Now search for "todo: You are allowed to change..." in your "Task List"
			// for more information and find that sample code about
			// how to adding your own addresses easily.
			_donations = new Donation[] {
				new Donation("Bitcoin", "1MjwviitdNC7ndvjXL3dG7mE9Pir3ZBSBP", Resources.Bitcoin),
				new Donation("Ethereum", "0x1DBED0B76d1070a47613EdEE58D9eD8afD6A206D", Resources.Ethereum),
				new Donation("Nano", "nano_1t7fg3drandk1crg363cn66px1adzsz3reeece8puuecbti4ysnyszbikry5", Resources.Nano),
				new Donation("TrueUSD", "0x1DBED0B76d1070a47613EdEE58D9eD8afD6A206D", Resources.TrueUSD),
				new Donation("Litecoin", "LWzeZqbn38AzYJTJg6yyDAbKi7i8EEUbqw", Resources.Litecoin),
				new Donation("BitcoinCash", "bitcoincash:qp6m9sm9d6tflamxhr4wkggcd2lt5vmavy6xyk7sg4", Resources.BitcoinCash),
				new Donation("Cardano", "DdzFFzCqrhstvvrf4EGLkhSkSFpf9obzTPqex9wzSqd1BfoaXkoT1nXLpvHvbSQGSzk66PaNKVzcV6uhmR8emospbv3UgXi2wNjbqSfN", Resources.Cardano),
				new Donation("Stellar", "GAO6L574LOYTJDY7RJM5UD6K26ALY7Z3WCOSPM2GFAOY75JLOZUPKEON", Resources.Stellar),
				new Donation("Ripple", "rndM8KNWq4FgcWpKjwwFtzkAnDpW2akpeS", Resources.Ripple),
				new Donation("Neo", "AGxAc3yEA4GKaku5jhYct6RwjzGfjxwDx6", Resources.Neo),
				new Donation("Tron", "TShbF9NibNPuyAHGbjSeXB4hzej11MMeWE", Resources.Tron),
				new Donation("NEM", "ND6X577XWNXYFHS4FU4SIY2ND4XUCOGAW7ZRMA4T", Resources.NEM),
				new Donation("Qtum", "QSwAps21X8PKyaHade9K9cMm5bwSScroVf", Resources.Qtum),
				new Donation("USDTether", "0x1DBED0B76d1070a47613EdEE58D9eD8afD6A206D", Resources.USDTether),
				new Donation("Binance", "bnb102m7dhuffkujjp40djj2ekctsya6m9uggss3c8", Resources.Binance),
				new Donation("Dash", "XjJbXDgq8XBLEpEPNpYHkVF6yJjURQaAu8", Resources.Dash),
				new Donation("Verge", "DMbadYFQxZA5bg4PoypVNXeQs4YnMo9yYT", Resources.Verge),
				new Donation("ZCash", "t1cVThXN3ccm8WAGALoTVz172YQHVf1bvGY", Resources.ZCash)
			};
			_list = new Dictionary<string, Donation>();
			foreach(Donation d in _donations)
				_list.Add(d.Name, d);
			//************************************************************************
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
}
//---------------------------------------------------------------------------------------
