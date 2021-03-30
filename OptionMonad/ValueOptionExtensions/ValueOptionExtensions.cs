using System;

namespace OptionMonad.ValueOptionExtensions
{
    public static class ValueOptionExtensions
    {
        public static bool IsSome<TValue, TError>(this Option<TValue, TError> option) => option is SomeOption<TValue, TError>;

        public static bool IsNone<TValue, TError>(this Option<TValue, TError> option) => option is NoneOption<TValue, TError>;

        public static Option<TNextValue, TError> Bind<TValue, TNextValue, TError>(this Option<TValue, TError> option, Func<TValue, Option<TNextValue, TError>> next) =>
            option switch
            {
                SomeOption<TValue, TError> some => next(some.Value),
                NoneOption<TValue, TError> none => Option<TNextValue, TError>.None(none.Error),
                _ => Option<TNextValue, TError>.None(),
            };
    }
}
