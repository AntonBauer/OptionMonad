using OptionMonad.EmptyOption;
using System;

namespace OptionMonad.EmptyOptionExtensions
{
    public static class DelegateExtensions
    {
        public static EmptyOption<TError> SafeInvoke<TValue, TError>(this Action<TValue> @delegate, TValue value)
        {
            try
            {
                @delegate(value);
                return EmptyOption<TError>.Some();
            }
            catch
            {
                return EmptyOption<TError>.None();
            }
        }

        public static EmptyOption<TError> SafeInvoke<TError>(this Action @delegate)
        {
            try
            {
                @delegate();
                return EmptyOption<TError>.Some();
            }
            catch
            {
                return EmptyOption<TError>.None();
            }
        }
    }
}
