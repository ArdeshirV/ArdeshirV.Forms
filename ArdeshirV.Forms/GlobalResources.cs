#region Header

// Copyright© 2002-2021 ArdeshirV@protonmail.com, Licensed under GPLv3+
using System;
using System.Drawing;
using res = ArdeshirV.Forms.Properties;
using qres = ArdeshirV.Utilities.QrCode.Res;

#endregion
//---------------------------------------------------------------------------------------

namespace ArdeshirV.Forms
{
	/// <summary>
	/// Resources is a static class that provides access to predifiend global resources,
	/// such as currency logos and author's photo that used in ArdeshirV.Forms.
	/// </summary>
	public static class GlobalResouces
	{
		/// <summary>
		/// Licenses is a static class that provides global licenses resources,
		/// such as MIT license content and logo and also LGPL license content and logo.
		/// </summary>
		public static class Licenses {
			public static Image MITLicenseLogo {
				get {
					return qres.LicenseLogo;
				}
			}
			
			public static Image LGPLLicenseLogo {
				get {
					return res.Resources.LGPLv3;
				}
			}
			
			public static string MITLicense {
				get {
					return qres.License;
				}
			}
			
			public static string LGPLLicense {
				get {
					return res.Resources.LICENSE;
				}
			}
		}
		
		/// <summary>
		/// ComponentLogos is a static class that provides global component photos.
		/// </summary>
		public static class ComponentsLogos {
			public static Image QrCodeLogo {
				get {
					return qres.Logo;
				}
			}
			
			public static Image ArdeshirVFormsLogo {
				get {
					return res.Resources.ArdeshirV_Forms_Logo;
				}
			}
		}
		
		/// <summary>
		/// AuthorPhotos is a static class that provides component author's photos.
		/// </summary>
		public static class AuthorsPhotos {
			/// <summary>
			/// ArdeshirV's photo; ArdeshirV is founder of ArdeshirV.Forms project.
			/// </summary>
			public static Image ArdeshirV {
				get {
					return res.Resources.ArdeshirV;
				}
			}
			
			/// <summary>
			/// Nayuki avator; Nayuki is founder of QrCode project.
			/// </summary>
			public static Image Nayuki {
				get {
					return qres.NayukiAvator;
				}
			}
			
			/// <summary>
			/// ManuelBleichenbacher avator; ManuelBleichenbacher converted original QrCode from java to C#.
			/// </summary>
			public static Image ManuelBleichenbacher {
				get {
					return qres.ManuelBleichenbacherAvator;
				}
			}
		}
			
		/// <summary>
		/// CurrencyLogos is a static class that provides global currency logos,
		/// such as Bitcoin logo, Ethereum logo, Nano logo, USDTether logo and etc.
		/// </summary>
		public static class CurrencyLogos {
			public static Bitmap Bitcoin {
				get {
					return res.Resources.Bitcoin;
				}
			}
			
			public static Bitmap Ethereum {
				get {
					return res.Resources.Ethereum;
				}
			}
			
			public static Bitmap Tron {
				get {
					return res.Resources.Tron;
				}
			}
			
			public static Bitmap TrueUSD {
				get {
					return res.Resources.TrueUSD;
				}
			}
			
			public static Bitmap USDTether {
				get {
					return res.Resources.USDTether;
				}
			}
			
			public static Bitmap Binance {
				get {
					return res.Resources.Binance;
				}
			}
			
			public static Bitmap Nano {
				get {
					return res.Resources.Nano;
				}
			}
			
			public static Bitmap Stellar {
				get {
					return res.Resources.Stellar;
				}
			}
			
			public static Bitmap Ripple {
				get {
					return res.Resources.Ripple;
				}
			}
			
			public static Bitmap Cardano {
				get {
					return res.Resources.Cardano;
				}
			}
			
			public static Bitmap Neo {
				get {
					return res.Resources.Neo;
				}
			}
			
			public static Bitmap NEM {
				get {
					return res.Resources.NEM;
				}
			}
			
			public static Bitmap Qtum {
				get {
					return res.Resources.Qtum;
				}
			}
			
			public static Bitmap Litecoin {
				get {
					return res.Resources.Litecoin;
				}
			}
			
			public static Bitmap BitcoinCash {
				get {
					return res.Resources.BitcoinCash;
				}
			}
			
			public static Bitmap Dash {
				get {
					return res.Resources.Dash;
				}
			}
			
			public static Bitmap Verge {
				get {
					return res.Resources.Verge;
				}
			}
			
			public static Bitmap ZCash {
				get {
					return res.Resources.ZCash;
				}
			}
			
			public static Bitmap Monero {
				get {
					return res.Resources.Monero;
				}
			}
		}
	}
}

