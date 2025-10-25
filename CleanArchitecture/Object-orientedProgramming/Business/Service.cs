﻿using System;
namespace Object_orientedProgramming.Business
{
	public class Service : ISalable
	{
		private decimal _amount;
		private decimal _tax;


		public Service(decimal amount, decimal tax)
		{
			_amount = amount;
			_tax = tax;
		}

		public decimal GetPrice()
			=> _amount + _tax;
    }
}

