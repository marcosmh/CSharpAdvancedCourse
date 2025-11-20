using System;
using System.Collections.Generic;

namespace AdvancedFunctionalProgramming
{
	public class MaybeMonad<T>
	{

        private readonly T _value;

        private readonly bool _hashValue;

        private MaybeMonad(T value, bool hashValue)
        {
            _value = value;
            _hashValue = hashValue;
        }

        public static MaybeMonad<T> Some(T value) => new MaybeMonad<T>(value, true);

        public static MaybeMonad<T> None() => new MaybeMonad<T>(default(T), false);

        public T GetValue()
            => _hashValue ? _value : default(T);

        public override string ToString()
            => _hashValue ? $"Some: {_value} " : "None";

        public MaybeMonad<TResult> Bind<TResult>(Func<T, MaybeMonad<TResult>> binder)
        {
            if(!_hashValue)
            {
                return MaybeMonad<TResult>.None();
            }

            return binder(_value);
        }



    }
}

