using System;
using System.Threading.Tasks;


namespace AdvancedFunctionalProgramming
{
	public static class Memorization
	{

		public static Func<double, double> Pow(double pow)
		{
			var cache = new Dictionary<double, double>();

			return (number) =>
			{
				if (cache.ContainsKey(number))
				{
                    Console.WriteLine($"Ya Existe {number} ");
                    return cache[number];
				}

				Console.WriteLine($"No Existe {number} ");
				double total = Math.Pow(number, pow);
				cache[number] = total;
				return total;
			};
		}

		public static Func<int, Task<string>> GetUrl(string url)
		{
			var cache = new Dictionary<int, string>();

			return async (id) =>
			{
				if(cache.ContainsKey(id))
				{
                    Console.WriteLine($"YA EXISTE EL {id}");
                    return cache[id];
                }

                Console.WriteLine($"NO EXISTE EL {id}");
				using (var client = new HttpClient())
				{
					var requestURL = url + "/" + id;
					var response = await client.GetAsync(requestURL);
					var responseBody = await response.Content.ReadAsStringAsync();

					cache[id] = responseBody;
					return responseBody;
				}
            };

            

        }


	}
}

