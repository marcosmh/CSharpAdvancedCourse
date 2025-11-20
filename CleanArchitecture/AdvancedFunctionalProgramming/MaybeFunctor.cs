using System;

namespace AdvancedFunctionalProgramming
{
	public class MaybeFunctor<T> : IFunctor<T>
	{
		private readonly T _value;

		private readonly bool _hashValue;

		private MaybeFunctor(T value, bool hashValue)
		{
			_value = value;
			_hashValue = hashValue;
		}

		public static MaybeFunctor<T> Some(T value) => new MaybeFunctor<T>(value, true);

        public static MaybeFunctor<T> None() => new MaybeFunctor<T>(default(T), false);

		public IFunctor<TResult> Map<TResult>(Func<T, TResult> fn)
		{
			if(!_hashValue)
			{
				return MaybeFunctor<TResult>.None();
			}

			return MaybeFunctor<TResult>.Some(fn(_value));
		}

		public T GetValue()
			=> _hashValue ? _value : default(T);

    }
}

