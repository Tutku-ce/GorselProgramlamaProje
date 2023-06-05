using System;
namespace MuzikMarket_Ell.Concrete
{
	public class UrunStok 
	{ 
		#region properties
		
			public int urunStokId { get ;set;}
			public int urunId { get ;set;}
            public string urunAd { get; set; }
			public int stokAdet { get ;set;}
			public bool urunStokDurum { get ;set;}
		#endregion 
	}
} 
