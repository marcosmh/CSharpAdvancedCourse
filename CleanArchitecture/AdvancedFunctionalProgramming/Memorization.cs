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


		public static Func<TInput, TOutput> Mem<TInput, TOutput>(Func<TInput, TOutput> fn)
		{
			var cache = new Dictionary<TInput, TOutput>();

			return (key) =>
			{
				if(cache.ContainsKey(key))
				{
                    Console.WriteLine($"YA EXISTE EL {key}");
					return cache[key];
                }

                Console.WriteLine($"NO EXISTE EL {key}");
				TOutput value = fn(key);
				cache[key] = value;
				return value;

            };
		}

        public static Func<TInput, Task<TOutput>> MemAsync<TInput, TOutput>(Func<TInput, Task<TOutput>> fn)
        {
            var cache = new Dictionary<TInput, TOutput>();

            return async(key) =>
            {
                if (cache.ContainsKey(key))
                {
                    Console.WriteLine($"YA EXISTE EL {key}");
                    return cache[key];
                }

                Console.WriteLine($"NO EXISTE EL {key}");
                TOutput value = await fn(key);
                cache[key] = value;
                return value;

            };
        }


    }
}

