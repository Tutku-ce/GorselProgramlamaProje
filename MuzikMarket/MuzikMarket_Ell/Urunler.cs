using System;
namespace MuzikMarket_Ell.Concrete
{
	public class Urunler 
	{ 
		#region properties
		
			public int urunId { get ;set;}
			public string urunAd { get ;set;}
			public string urunKodu { get ;set;}
			public string urunAciklama { get ;set;}
			public decimal urunFiyati { get ;set;}
			public int kategoriId { get ;set;}
            public string kategoriAd { get; set; }
			public bool urunDurum { get ;set;}
		#endregion 
	}
} 
