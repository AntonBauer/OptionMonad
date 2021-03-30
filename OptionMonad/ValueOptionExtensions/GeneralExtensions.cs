namespace OptionMonad.ValueOptionExtensions
{
    public static class GeneralExtensions
    {
        public static Option<TValue, TError> Some<TValue, TError>(this TValue value) => Option<TValue, TError>.Some(value);

        public static Option<TValue, TError> None<TValue, TError>(this TError error) => Option<TValue, TError>.None(error);
    }
}
