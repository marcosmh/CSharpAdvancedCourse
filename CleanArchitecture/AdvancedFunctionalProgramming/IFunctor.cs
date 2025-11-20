using System;

namespace AdvancedFunctionalProgramming
{
    public interface IFunctor<T>
    {
        IFunctor<TResult> Map<TResult>(Func<T, TResult> fn);

        T GetValue();
        
    }
}