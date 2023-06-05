using System;
namespace MuzikMarket_Ell.Concrete
{
	public class Fatura 
	{ 
		#region properties
		
			public int faturaId { get ;set;}
			public string faturaNo { get ;set;}
			public decimal toplamTutar { get ;set;}
			public int musteriId { get ;set;}
            public string musteriAd { get; set; }
			public bool faturaDurum { get ;set;}
		#endregion 
	}
} 
