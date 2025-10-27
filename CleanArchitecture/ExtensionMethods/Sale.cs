using System;

namespace ExtensionMethods
{
	public class Sale
	{
        public decimal Amount { get; set; }

		public Sale(decimal amount)
			=> Amount = amount;
	}


}

