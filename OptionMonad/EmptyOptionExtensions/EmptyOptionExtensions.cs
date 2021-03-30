using OptionMonad.EmptyOption;

namespace OptionMonad.EmptyOptionExtensions
{
    public static class EmptyOptionExtensions
    {
        public static bool IsSome<TError>(this EmptyOption<TError> option) => option is SomeEmptyOption<TError>;

        public static bool IsNone<TError>(this EmptyOption<TError> option) => option is NoneEmptyOption<TError>;
    }
}
