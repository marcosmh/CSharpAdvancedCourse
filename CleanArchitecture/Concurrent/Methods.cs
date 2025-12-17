using System;

namespace Concurrent
{
	public static class Methods
	{

		public static async Task Wait(int seconds)
		{
			Console.WriteLine("Comienza la espera");

			await Task.Delay(seconds);

			Console.WriteLine("Termina la espera");
		}

		public static async Task<double> AddAsync(double number1, double number2)
		{
			await Task.Delay(1000);

			return number1 + number2;
		}
	}
}

