using OptionMonad.EmptyOption;
using OptionMonad.EmptyOptionExtensions;
using OptionMonad.ValueOption;
using System;

namespace OptionMonad.ValueOptionExtensions
{
    public static class BindingExtensions
    {
        public static Option<TNextValue, TError> Bind<TValue, TNextValue, TError>(this Option<TValue, TError> option, Func<TValue, Option<TNextValue, TError>> next) =>
            option switch
            {
                SomeOption<TValue, TError> some => next(some.Value),
                NoneOption<TValue, TError> none => Option<TNextValue, TError>.None(none.Error),
                _ => Option<TNextValue, TError>.None(),
            };

        public static Option<TNextValue, TError> Bind<TValue, TNextValue, TError>(this Option<TValue, TError> option, Func<TValue, TNextValue> next) =>
            option switch
            {
                SomeOption<TValue, TError> some => next.SafeInvoke<TValue, TNextValue, TError>(some.Value),
                NoneOption<TValue, TError> none => Option<TNextValue, TError>.None(none.Error),
                _ => Option<TNextValue, TError>.None(),
            };

        public static EmptyOption<TError> Bind<TValue, TError>(this Option<TValue, TError> option, Action<TValue> next) =>
            option switch
            {
                SomeOption<TValue, TError> some => next.SafeInvoke<TValue, TError>(some.Value),
                NoneOption<TValue, TError> none => EmptyOption<TError>.None(none.Error),
                _ => EmptyOption<TError>.None()
            };
    }
}
