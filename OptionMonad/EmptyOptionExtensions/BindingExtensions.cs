using OptionMonad.EmptyOption;
using OptionMonad.ValueOptionExtensions;
using System;

namespace OptionMonad.EmptyOptionExtensions
{
    public static class BindingExtensions
    {
        public static EmptyOption<TError> Bind<TError>(this EmptyOption<TError> option, Action @delegate) =>
            option switch
            {
                SomeEmptyOption<TError> => @delegate.SafeInvoke<TError>(),
                _ => option,
            };

        public static Option<TValue, TError> Bind<TValue, TError>(this EmptyOption<TError> option, Func<TValue> @delegate) =>
            option switch
            {
                SomeEmptyOption<TError> => @delegate.SafeInvoke<TValue, TError>(),
                _ => Option<TValue, TError>.None()
            };
        public static Option<TValue, TError> Bind<TValue, TError>(this EmptyOption<TError> option, Func<Option<TValue, TError>> @delegate) =>
            option switch
            {
                SomeEmptyOption<TError> => @delegate(),
                _ => Option<TValue, TError>.None()
            };
    }
}
