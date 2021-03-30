namespace OptionMonad.EmptyOption
{
    public abstract class EmptyOption<TError>
    {
        public static EmptyOption< TError> Some() => SomeEmptyOption<TError>.Create();

        public static EmptyOption<TError> None(TError? error = default) => NoneEmptyOption<TError>.Create(error);
    }
}
