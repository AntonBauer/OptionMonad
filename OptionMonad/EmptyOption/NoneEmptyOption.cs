namespace OptionMonad.EmptyOption
{
    public class NoneEmptyOption<TError> : EmptyOption<TError>
    {
        public TError? Error { get; private set; }

        private NoneEmptyOption(TError? error) => Error = error;

        public static NoneEmptyOption<TError> Create(TError? error) => new(error);
    }
}
