using System;
namespace MuzikMarket_Ell.Concrete
{
	public class Satislar 
	{ 
		#region properties
		
			public int satisId { get ;set;}
			public int urunId { get ;set;}
            public string urunAd { get; set; }
			public int urunAdet { get ;set;}
			public decimal birimFiyat { get ;set;}
			public decimal toplamFiyat { get ;set;}
			public int faturaId { get ;set;}
			public bool satisDurum { get ;set;}
		#endregion 
	}
} 
