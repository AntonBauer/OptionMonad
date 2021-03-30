using System.Linq.Expressions;

namespace OptionMonad.EmptyOption
{
    public class SomeEmptyOption<TError> : EmptyOption<TError>
    {
        private SomeEmptyOption() => Expression.Empty();

        public static SomeEmptyOption<TError> Create() => new SomeEmptyOption<TError>();
    }
}
