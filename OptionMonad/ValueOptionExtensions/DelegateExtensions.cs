using System;

namespace OptionMonad.ValueOptionExtensions
{
    public static class DelegateExtensions
    {
        public static Option<TReturn, TError> SafeInvoke<TValue, TReturn, TError>(this Func<TValue, TReturn> @delegate, TValue value)
        {
            try
            {
                return @delegate(value).Some<TReturn, TError>();
            }
            catch
            {
                return Option<TReturn, TError>.None();
            }
        }
    }
}
