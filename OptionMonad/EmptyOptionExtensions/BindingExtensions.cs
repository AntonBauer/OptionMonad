using OptionMonad.EmptyOption;
using System;

namespace OptionMonad.EmptyOptionExtensions
{
    public static class BindingExtensions
    {
        public static EmptyOption<TError> Bind<TError>(this EmptyOption<TError> option, Action @delegate) =>
            option switch
            {
                SomeEmptyOption<TError> => @delegate.SafeInvoke<TError>(),
                _ => option,
            };
    }
}
