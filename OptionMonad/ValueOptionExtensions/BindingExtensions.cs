using OptionMonad.EmptyOption;
using OptionMonad.EmptyOptionExtensions;
using OptionMonad.ValueOption;
using System;
using System.Threading.Tasks;

namespace OptionMonad.ValueOptionExtensions
{
    public static class BindingExtensions
    {
        public static Option<TNextValue, TError> Bind<TValue, TNextValue, TError>(this Option<TValue, TError> option, Func<TValue, Option<TNextValue, TError>> next) =>
            option switch
            {
                SomeOption<TValue, TError> some => next(some.Value),
                NoneOption<TValue, TError> none when none.Error is not null => none.Error.None<TNextValue, TError>(),
                _ => Option<TNextValue, TError>.None(),
            };

        public static Option<TNextValue, TError> Bind<TValue, TNextValue, TError>(this Option<TValue, TError> option, Func<TValue, TNextValue> next) =>
            option switch
            {
                SomeOption<TValue, TError> some => next.SafeInvoke<TValue, TNextValue, TError>(some.Value),
                NoneOption<TValue, TError> none when none.Error is not null => none.Error.None<TNextValue, TError>(),
                _ => Option<TNextValue, TError>.None()
            };

        public static EmptyOption<TError> Bind<TValue, TError>(this Option<TValue, TError> option, Action<TValue> next) =>
            option switch
            {
                SomeOption<TValue, TError> some => next.SafeInvoke<TValue, TError>(some.Value),
                NoneOption<TValue, TError> none => EmptyOption<TError>.None(none.Error),
                _ => EmptyOption<TError>.None()
            };

        public static Task<Option<TNextValue, TError>> Bind<TValue, TNextValue, TError>(this Option<TValue, TError> option, Func<TValue, Task<Option<TNextValue, TError>>> next) =>
            option switch
            {
                SomeOption<TValue, TError> some => next(some.Value),
                NoneOption<TValue, TError> none when none.Error is not null => Task.FromResult(none.Error.None<TNextValue, TError>()),
                _ => Task.FromResult(Option<TNextValue, TError>.None())
            };

        public static Task<Option<TNextValue, TError>> Bind<TValue, TNextValue, TError>(this Task<Option<TValue, TError>> optionTask, Func<TValue, Task<Option<TNextValue, TError>>> next) =>
            optionTask.ContinueWith
            (
                prev => prev.Result.Bind(next),
                continuationOptions: TaskContinuationOptions.OnlyOnRanToCompletion
            ).Unwrap();

        public static Task<Option<TNextValue, TError>> Bind<TValue, TNextValue, TError>(this Task<Option<TValue, TError>> optionTask, Func<TValue, Option<TNextValue, TError>> next) =>
            optionTask.ContinueWith
            (
                prev => prev.Result.Bind(next),
                continuationOptions: TaskContinuationOptions.OnlyOnRanToCompletion
            );
    }
}
