namespace OptionMonad
{
    public class NoneOption<TValue, TError> : Option<TValue, TError>
    {
        public TError? Error { get; private set; }

        private NoneOption(TError? error) => Error = error;

        public static NoneOption<TValue, TError> Create(TError? error) => new NoneOption<TValue, TError>(error);
    }
}
