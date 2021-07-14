#region Header

// Copyright© 2002-2021 ArdeshirV@protonmail.com, Licensed under GPLv3+
using System;
using System.Drawing;
using System.Collections.Generic;
using res = ArdeshirV.Forms.Properties;
using qres = ArdeshirV.Tools.QrCode.Res;

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
			//---------------------------------------------------------------------------
			public static Image LGPLLicenseLogo {
				get {
					return res.Resources.LGPLv3;
				}
			}
			//---------------------------------------------------------------------------
			public static Image GPLLicenseLogo {
				get {
					return res.Resources.GPLv3;
				}
			}
			//---------------------------------------------------------------------------
			public static string MITLicense {
				get {
					return qres.License;
				}
			}
			//---------------------------------------------------------------------------
			public static string QrCodeMITLicense {
				get {
					return qres.License;
				}
			}
			//---------------------------------------------------------------------------
			public static string GPLLicense {
				get {
					return res.Resources.GPL_LICENSE;
				}
			}
			//---------------------------------------------------------------------------
			public static string LGPLLicense {
				get {
					return res.Resources.LGPL_LICENSE;
				}
			}
		}
		//-------------------------------------------------------------------------------
		/// <summary>
		/// ComponentLogos is a static class that provides global component photos.
		/// </summary>
		public static class ComponentsLogos {
			public static Image QrCodeLogo {
				get {
					return qres.Logo;
				}
			}
			//---------------------------------------------------------------------------
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
			//---------------------------------------------------------------------------
			/// <summary>
			/// Nayuki avator; Nayuki is founder of QrCode project.
			/// </summary>
			public static Image Nayuki {
				get {
					return qres.NayukiAvator;
				}
			}
			//---------------------------------------------------------------------------
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
			private static readonly Dictionary<string, Bitmap> logos =
				new Dictionary<string, Bitmap>();
			//---------------------------------------------------------------------------			
			public static Bitmap GetItemByName(string logoName) {
				Bitmap bitmapTarget;
				if(logos.TryGetValue(logoName, out bitmapTarget))
					return bitmapTarget;
				else {
					throw new Exception(string.Format(
						"Error in CurrencyLogos.GetItemByName\nThe currency name: " + 
						"\"{0}\" is not exists in predefined CurrencyLogos list.",
						logoName));
				}
			}
			//--------------------------------------------------------------------------
			/// <summary>
			/// Checks if the stringCurrencyName is
			/// exists in the predefined currency logos.
			/// </summary>
			/// <param name="stringCurrencyName">Predefined currency name</param>
			/// <returns>The image(logo) of the predefined currency
			/// that refer to stringCurrencyName</returns>
			public static bool Contains(string stringCurrencyName) {
				return logos.ContainsKey(stringCurrencyName);
			}
			//---------------------------------------------------------------------------			
			/// <summary>
			/// Returns an IEnumerable to the list of all predefined currency logos.
			/// </summary>
			public static System.Collections.IEnumerable NamesList {
				get {
					return logos.Keys;
				}
			}
			//---------------------------------------------------------------------------			
			static CurrencyLogos() {				
				logos.Add("Bitcoin", res.Resources.bitcoin);
				logos.Add("Ethereum", res.Resources.ethereum);
				logos.Add("0x", res.Resources._0x);
				logos.Add("Aelf", res.Resources.aelf);
				logos.Add("Aeon", res.Resources.aeon);
				logos.Add("Aeternity", res.Resources.aeternity);
				logos.Add("Aion", res.Resources.aion);
				logos.Add("Algorand", res.Resources.algorand);
				logos.Add("AppCoins", res.Resources.appcoins);
				logos.Add("Aragon", res.Resources.aragon);
				logos.Add("Augur", res.Resources.augur);
				logos.Add("Band Protocol", res.Resources.band_protocol);
				logos.Add("Basic Attention Token", res.Resources.basic_attention_token);
				logos.Add("Binance", res.Resources.binance_coin);
				logos.Add("Bitcloud", res.Resources.bitcloud);
				logos.Add("Bitcoin Cash", res.Resources.bitcoin_cash);
				logos.Add("Bitcoin Diamond", res.Resources.bitcoin_diamond);
				logos.Add("Bitcoin Gold", res.Resources.bitcoin_gold);
				logos.Add("Bitcoin Plus", res.Resources.bitcoin_plus);
				logos.Add("Bitcoin Private", res.Resources.bitcoin_private);
				logos.Add("Bitcoin SV", res.Resources.bitcoin_sv);
				logos.Add("BitCore", res.Resources.bitcore);
				logos.Add("Bitforex Token", res.Resources.bitforex_token);
				logos.Add("BlockStamp", res.Resources.blockstamp);
				logos.Add("Cardano", res.Resources.cardano);
				logos.Add("Celo", res.Resources.celo);
				logos.Add("Celsius", res.Resources.celsius);
				logos.Add("Chainlink", res.Resources.chainlink);
				logos.Add("ChainX", res.Resources.chainx);
				logos.Add("Civic", res.Resources.civic);
				logos.Add("Cosmos", res.Resources.cosmos);
				logos.Add("Crypto.com", res.Resources.crypto_com);
				logos.Add("Curve DAO Token", res.Resources.curve_dao_token);
				logos.Add("Dash", res.Resources.dash);
				logos.Add("Decentraland", res.Resources.decentraland);
				logos.Add("Decred", res.Resources.decred);
				logos.Add("Dogecoin", res.Resources.dogecoin);
				logos.Add("Energy Web Token", res.Resources.energy_web_token);
				logos.Add("Enjin Coin", res.Resources.enjin_coin);
				logos.Add("EOS", res.Resources.eos);
				logos.Add("Ether Zero", res.Resources.ether_zero);
				logos.Add("Ethereum Classic", res.Resources.ethereum_classic);
				logos.Add("Filecoin", res.Resources.filecoin);
				logos.Add("FTX Token", res.Resources.ftx_token);
				logos.Add("Gas", res.Resources.gas);
				logos.Add("Gemini Dollar", res.Resources.gemini_dollar);
				logos.Add("Gifto", res.Resources.gifto);
				logos.Add("Grin", res.Resources.grin);
				logos.Add("Harmony", res.Resources.harmony);
				logos.Add("Holo", res.Resources.holo);
				logos.Add("Icon", res.Resources.icon);
				logos.Add("IOS Token", res.Resources.iostoken);
				logos.Add("IOTA", res.Resources.iota);
				logos.Add("IoTeX", res.Resources.iotex);
				logos.Add("Komodo", res.Resources.komodo);
				logos.Add("LikeCoin", res.Resources.likecoin);
				logos.Add("Lisk", res.Resources.lisk);
				logos.Add("Litecoin", res.Resources.litecoin);
				logos.Add("Loom Network", res.Resources.loom_network);
				logos.Add("Loopring", res.Resources.loopring);
				logos.Add("Maker", res.Resources.maker);
				logos.Add("Metal", res.Resources.metal);
				logos.Add("Monero", res.Resources.monero);
				logos.Add("Nano", res.Resources.nano);
				logos.Add("NEM", res.Resources.nem);
				logos.Add("Neo", res.Resources.neo);
				logos.Add("NXT", res.Resources.nxt);
				logos.Add("Ontology", res.Resources.ontology);
				logos.Add("Orchid", res.Resources.orchid);
				logos.Add("PAX Gold", res.Resources.pax_gold);
				logos.Add("Paxos Standard", res.Resources.paxos_standard);
				logos.Add("PIVX", res.Resources.pivx);
				logos.Add("Polkadot", res.Resources.polkadot_new);
				logos.Add("Qash", res.Resources.qash);
				logos.Add("Qtum", res.Resources.qtum);
				logos.Add("Ravencoin", res.Resources.ravencoin);
				logos.Add("Salt", res.Resources.salt);
				logos.Add("Siacoin", res.Resources.siacoin);
				logos.Add("Status", res.Resources.status);
				logos.Add("Steem", res.Resources.steem);
				logos.Add("Steem Dollars", res.Resources.steem_dollars);
				logos.Add("Stellar", res.Resources.stellar);
				logos.Add("Storj", res.Resources.storj);
				logos.Add("Stratis", res.Resources.stratis);
				logos.Add("Sushi", res.Resources.sushiswap);
				logos.Add("Swipe", res.Resources.swipe);
				logos.Add("SwissBorg", res.Resources.swissborg);
				logos.Add("Tether", res.Resources.tether);
				logos.Add("Tether Gold", res.Resources.tether_gold);
				logos.Add("Tezos", res.Resources.tezos);
				logos.Add("TokenPay", res.Resources.tokenpay);
				logos.Add("Tron", res.Resources.tron);
				logos.Add("TrueUSD", res.Resources.trueusd);
				logos.Add("Uniswap", res.Resources.uniswap);
				logos.Add("USD Coin", res.Resources.usd_coin);
				logos.Add("VeChain", res.Resources.vechain);
				logos.Add("Verge", res.Resources.verge);
				logos.Add("VeriCoin", res.Resources.vericoin);
				logos.Add("Vertcoin", res.Resources.vertcoin);
				logos.Add("VIBE", res.Resources.vibe);
				logos.Add("Waves", res.Resources.waves);
				logos.Add("WePower", res.Resources.wepower);
				logos.Add("Wing", res.Resources.wing);
				logos.Add("Ripple", res.Resources.xrp);
				logos.Add("yearn.finance", res.Resources.yearn_finance);
				logos.Add("Zcash", res.Resources.zcash);
				logos.Add("Zclassic", res.Resources.zclassic);
				logos.Add("Flux", res.Resources.zel);
				logos.Add("Zilliqa", res.Resources.zilliqa);
			}
		}
	}
}

