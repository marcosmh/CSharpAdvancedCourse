using System;

namespace Object_orientedProgramming.Business
{
	public class ExpiringBeer : Beer
	{
		public DateTime Expiration { get; set; }

		public ExpiringBeer(string name, decimal price, decimal alcohol,
			DateTime expiration, int quantity)
			: base(name, price, alcohol, quantity)
		{
			Expiration = expiration;
			var p = Price;
		}

        public override string GetInfo()
        {
			return "Cerveza con caducidad : " + Name + ", " +
				"Precio: $ " + Price + ", Alcohol: " + Alcohol +
				" Caducidad: " + Expiration.Date.ToString();
        }
    }
}

