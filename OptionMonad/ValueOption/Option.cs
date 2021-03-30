namespace OptionMonad
{
    public abstract class Option<TValue, TError>
    {
        public static Option<TValue, TError> Some(TValue value) => SomeOption<TValue, TError>.Create(value);

        public static Option<TValue, TError> None(TError? error = default) => NoneOption<TValue, TError>.Create(error);
    }
}
