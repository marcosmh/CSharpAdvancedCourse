using System;

namespace AdvancedFunctionalProgramming
{
    public class Identity<T> : IFunctor<T>
    {

        private readonly T _value;

        public Identity(T value)
            => _value = value;

        public IFunctor<TResult> Map<TResult>(Func<T, TResult> fn)
            => new Identity<TResult>(fn(_value));

        public T GetValue() => _value;
    }
}