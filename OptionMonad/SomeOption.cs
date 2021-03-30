namespace OptionMonad
{
    public class SomeOption<TValue, TError> : Option<TValue, TError>
    {
        public TValue Value { get; private set; }

        private SomeOption(TValue value) => Value = value;

        public static SomeOption<TValue, TError> Create(TValue value) => new SomeOption<TValue, TError>(value);
    }
}
