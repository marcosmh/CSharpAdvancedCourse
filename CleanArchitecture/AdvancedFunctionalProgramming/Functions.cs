using System;
using System.Collections.Generic;


namespace AdvancedFunctionalProgramming
{
	public static class Functions
	{

		public static string PipeString(string input, params Func<string, string>[] functions)
		{
			string result = input;

			foreach( var fn in functions)
            {
                result = fn(result);
            }
            return result;
        }

        public static T Pipe<T>(T input, params Func<T, T>[] functions)
        {
            T result = input;

            foreach (var fn in functions)
            {
                result = fn(result);
            }
            return result;
        }

        public static TResult P<TInput, TResult>(this TInput input, Func<TInput, TResult> fn)
        {
            return fn(input);
        }   

    }
}

