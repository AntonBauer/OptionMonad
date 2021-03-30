using OptionMonad.ValueOption;

namespace OptionMonad.ValueOptionExtensions
{
    public static class ValueOptionExtensions
    {
        public static bool IsSome<TValue, TError>(this Option<TValue, TError> option) => option is SomeOption<TValue, TError>;

        public static bool IsNone<TValue, TError>(this Option<TValue, TError> option) => option is NoneOption<TValue, TError>;
    }
}
