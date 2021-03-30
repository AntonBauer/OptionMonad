namespace OptionMonad.ValueOption
{
    public class SomeOption<TValue, TError> : Option<TValue, TError>
    {
        public TValue Value { get; private set; }

        private SomeOption(TValue value) => Value = value;

        public static SomeOption<TValue, TError> Create(TValue value) => new(value);
    }
}
