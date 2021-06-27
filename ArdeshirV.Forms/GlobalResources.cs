#region Header

// Copyright© 2002-2021 ArdeshirV@protonmail.com, Licensed under GPLv3+
using System;
using System.Drawing;
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
			
			public static Image LGPLLicenseLogo {
				get {
					return res.Resources.LGPLv3;
				}
			}
			
			public static Image GPLLicenseLogo {
				get {
					return res.Resources.GPLv3;
				}
			}
			
			public static string MITLicense {
				get {
					return qres.License;
				}
			}
			
			public static string QrCodeMITLicense {
				get {
					return qres.License;
				}
			}
			
			public static string GPLLicense {
				get {
					return res.Resources.GPL_LICENSE;
				}
			}
			
			public static string LGPLLicense {
				get {
					return res.Resources.LGPL_LICENSE;
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
					return res.Resources.bitcoin;
				}
			}
			
			public static Bitmap _0x {
				get {
					return res.Resources._0x;
				}
			}
			
			public static Bitmap Aelf {
				get {
					return res.Resources.aelf;
				}
			}
			
			public static Bitmap Ripple {
				get {
					return res.Resources.xrp;
				}
			}
			
			public static Bitmap NEM {
				get {
					return res.Resources.nem;
				}
			}
			
			public static Bitmap Aeon {
				get {
					return res.Resources.aeon;
				}
			}
			
			public static Bitmap Aeternity {
				get {
					return res.Resources.aeternity;
				}
			}
			
			public static Bitmap Aion {
				get {
					return res.Resources.aion;
				}
			}
			
			public static Bitmap Algorand {
				get {
					return res.Resources.algorand;
				}
			}
			
			public static Bitmap Appcoins {
				get {
					return res.Resources.appcoins;
				}
			}
			
			public static Bitmap Aragon {
				get {
					return res.Resources.aragon;
				}
			}
			
			public static Bitmap Augur {
				get {
					return res.Resources.augur;
				}
			}
			
			public static Bitmap BandProtocol {
				get {
					return res.Resources.band_protocol;
				}
			}
			
			public static Bitmap BasicAttentionToken {
				get {
					return res.Resources.basic_attention_token;
				}
			}
			
			public static Bitmap Binance {
				get {
					return res.Resources.binance_coin;
				}
			}
			
			public static Bitmap Bitcloud {
				get {
					return res.Resources.bitcloud;
				}
			}
			
			public static Bitmap BitcoinCash {
				get {
					return res.Resources.bitcoin_cash;
				}
			}
			
			public static Bitmap BitcoinDiamond {
				get {
					return res.Resources.bitcoin_diamond;
				}
			}
			
			public static Bitmap BitcoinGold {
				get {
					return res.Resources.bitcoin_gold;
				}
			}
			
			public static Bitmap BitcoinPlus {
				get {
					return res.Resources.bitcoin_plus;
				}
			}
			
			public static Bitmap BitcoinPrivate {
				get {
					return res.Resources.bitcoin_private;
				}
			}
			
			public static Bitmap BitcoinSV {
				get {
					return res.Resources.bitcoin_sv;
				}
			}
			
			public static Bitmap Bitcore {
				get {
					return res.Resources.bitcore;
				}
			}
			
			public static Bitmap BitforexToken {
				get {
					return res.Resources.bitforex_token;
				}
			}
			
			public static Bitmap Blockstamp {
				get {
					return res.Resources.blockstamp;
				}
			}
			
			public static Bitmap Cardano {
				get {
					return res.Resources.cardano;
				}
			}
			
			public static Bitmap Celo {
				get {
					return res.Resources.celo;
				}
			}
			
			public static Bitmap Celsius {
				get {
					return res.Resources.celsius;
				}
			}
			
			public static Bitmap Chainlink {
				get {
					return res.Resources.chainlink;
				}
			}
			
			public static Bitmap Chainx {
				get {
					return res.Resources.chainx;
				}
			}
			
			public static Bitmap Civic {
				get {
					return res.Resources.civic;
				}
			}
			
			public static Bitmap Cosmos {
				get {
					return res.Resources.cosmos;
				}
			}
			
			public static Bitmap CryptoCom {
				get {
					return res.Resources.crypto_com;
				}
			}
			
			public static Bitmap CurveDaoToken {
				get {
					return res.Resources.curve_dao_token;
				}
			}
			
			public static Bitmap Dash {
				get {
					return res.Resources.dash;
				}
			}
			
			public static Bitmap Decentraland {
				get {
					return res.Resources.decentraland;
				}
			}
			
			public static Bitmap Decred {
				get {
					return res.Resources.decred;
				}
			}
			
			public static Bitmap Dogecoin {
				get {
					return res.Resources.dogecoin;
				}
			}
			
			public static Bitmap EnergyWebToken {
				get {
					return res.Resources.energy_web_token;
				}
			}
			
			public static Bitmap EnjinCoin {
				get {
					return res.Resources.enjin_coin;
				}
			}
			
			public static Bitmap Eos {
				get {
					return res.Resources.eos;
				}
			}
			
			public static Bitmap EtherZero {
				get {
					return res.Resources.ether_zero;
				}
			}
			
			public static Bitmap Ethereum {
				get {
					return res.Resources.ethereum;
				}
			}
			
			public static Bitmap EthereumClassic {
				get {
					return res.Resources.ethereum_classic;
				}
			}
			
			public static Bitmap Filecoin {
				get {
					return res.Resources.filecoin;
				}
			}
			
			public static Bitmap FtxToken {
				get {
					return res.Resources.ftx_token;
				}
			}
			
			public static Bitmap Gas {
				get {
					return res.Resources.gas;
				}
			}
			
			public static Bitmap GeminiDollar {
				get {
					return res.Resources.gemini_dollar;
				}
			}
			
			public static Bitmap Gifto {
				get {
					return res.Resources.gifto;
				}
			}
			
			public static Bitmap Grin {
				get {
					return res.Resources.grin;
				}
			}
			
			public static Bitmap Harmony {
				get {
					return res.Resources.harmony;
				}
			}
			
			public static Bitmap Holo {
				get {
					return res.Resources.holo;
				}
			}
			
			public static Bitmap Icon {
				get {
					return res.Resources.icon;
				}
			}
			
			public static Bitmap IOSToken {
				get {
					return res.Resources.iostoken;
				}
			}
			
			public static Bitmap IOTA {
				get {
					return res.Resources.iota;
				}
			}
			
			public static Bitmap Iotex {
				get {
					return res.Resources.iotex;
				}
			}
			
			public static Bitmap Komodo {
				get {
					return res.Resources.komodo;
				}
			}
			
			public static Bitmap Likecoin {
				get {
					return res.Resources.likecoin;
				}
			}
			
			public static Bitmap Lisk {
				get {
					return res.Resources.lisk;
				}
			}
			
			public static Bitmap Litecoin {
				get {
					return res.Resources.litecoin;
				}
			}
			
			public static Bitmap LoomNetwork {
				get {
					return res.Resources.loom_network;
				}
			}
			
			public static Bitmap Loopring {
				get {
					return res.Resources.loopring;
				}
			}
			
			public static Bitmap Maker {
				get {
					return res.Resources.maker;
				}
			}
			
			public static Bitmap Metal {
				get {
					return res.Resources.metal;
				}
			}
			
			public static Bitmap Monero {
				get {
					return res.Resources.monero;
				}
			}
			
			public static Bitmap Nano {
				get {
					return res.Resources.nano;
				}
			}
			
			public static Bitmap Nem {
				get {
					return res.Resources.nem;
				}
			}
			
			public static Bitmap Neo {
				get {
					return res.Resources.neo;
				}
			}
			
			public static Bitmap Nxt {
				get {
					return res.Resources.nxt;
				}
			}
			
			public static Bitmap Ontology {
				get {
					return res.Resources.ontology;
				}
			}
			
			public static Bitmap Orchid {
				get {
					return res.Resources.orchid;
				}
			}
			
			public static Bitmap PaxGold {
				get {
					return res.Resources.pax_gold;
				}
			}
			
			public static Bitmap PaxosStandard {
				get {
					return res.Resources.paxos_standard;
				}
			}
			
			public static Bitmap Pivx {
				get {
					return res.Resources.pivx;
				}
			}
			
			public static Bitmap Polkadot {
				get {
					return res.Resources.polkadot_new;
				}
			}
			
			public static Bitmap Qash {
				get {
					return res.Resources.qash;
				}
			}
			
			public static Bitmap Qtum {
				get {
					return res.Resources.qtum;
				}
			}
			
			public static Bitmap Ravencoin {
				get {
					return res.Resources.ravencoin;
				}
			}
			
			public static Bitmap Salt {
				get {
					return res.Resources.salt;
				}
			}
			
			public static Bitmap Siacoin {
				get {
					return res.Resources.siacoin;
				}
			}
			
			public static Bitmap Status {
				get {
					return res.Resources.status;
				}
			}
			
			public static Bitmap Steem {
				get {
					return res.Resources.steem;
				}
			}
			
			public static Bitmap SteemDollars {
				get {
					return res.Resources.steem_dollars;
				}
			}
			
			public static Bitmap Stellar {
				get {
					return res.Resources.stellar;
				}
			}
			
			public static Bitmap Storj {
				get {
					return res.Resources.storj;
				}
			}
			
			public static Bitmap Stratis {
				get {
					return res.Resources.stratis;
				}
			}
			
			public static Bitmap Sushiswap {
				get {
					return res.Resources.sushiswap;
				}
			}
			
			public static Bitmap Swipe {
				get {
					return res.Resources.swipe;
				}
			}
			
			public static Bitmap Swissborg {
				get {
					return res.Resources.swissborg;
				}
			}
			
			public static Bitmap USDTether {
				get {
					return res.Resources.tether;
				}
			}

			public static Bitmap XAUT {
				get {
					return res.Resources.tether_gold;
				}
			}
			
			public static Bitmap TetherGold {
				get {
					return res.Resources.tether_gold;
				}
			}

			public static Bitmap Tezos {
				get {
					return res.Resources.tezos;
				}
			}

			public static Bitmap Tokenpay {
				get {
					return res.Resources.tokenpay;
				}
			}

			public static Bitmap Tron {
				get {
					return res.Resources.tron;
				}
			}

			public static Bitmap TrueUSD {
				get {
					return res.Resources.trueusd;
				}
			}

			public static Bitmap Uniswap {
				get {
					return res.Resources.uniswap;
				}
			}

			public static Bitmap USDCoin {
				get {
					return res.Resources.usd_coin;
				}
			}

			public static Bitmap Vechain {
				get {
					return res.Resources.vechain;
				}
			}

			public static Bitmap Verge {
				get {
					return res.Resources.verge;
				}
			}

			public static Bitmap Vericoin {
				get {
					return res.Resources.vericoin;
				}
			}

			public static Bitmap Vertcoin {
				get {
					return res.Resources.vertcoin;
				}
			}

			public static Bitmap Vibe {
				get {
					return res.Resources.vibe;
				}
			}

			public static Bitmap Waves {
				get {
					return res.Resources.waves;
				}
			}

			public static Bitmap WePower {
				get {
					return res.Resources.wepower;
				}
			}

			public static Bitmap Wing {
				get {
					return res.Resources.wing;
				}
			}

			public static Bitmap XRP {
				get {
					return res.Resources.xrp;
				}
			}

			public static Bitmap YearnFinance {
				get {
					return res.Resources.yearn_finance;
				}
			}

			public static Bitmap ZCash {
				get {
					return res.Resources.zcash;
				}
			}

			public static Bitmap ZClassic {
				get {
					return res.Resources.zclassic;
				}
			}

			public static Bitmap Zel {
				get {
					return res.Resources.zel;
				}
			}

			public static Bitmap Zilliqa {
				get {
					return res.Resources.zilliqa;
				}
			}
		}
	}
}

