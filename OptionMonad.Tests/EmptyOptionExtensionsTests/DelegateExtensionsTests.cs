using NUnit.Framework;
using OptionMonad.EmptyOption;
using OptionMonad.EmptyOptionExtensions;
using System;
using System.Linq.Expressions;

namespace OptionMonad.Tests.EmptyOptionExtensionsTests
{
    [Category("Option Extensions")]
    [Category("Empty Option")]
    public class DelegateExtensionsTests
    {
        [Test]
        public void SafeInvokeSomeTest()
        {
            // Arrange
            Action<string> @delegate = val => Expression.Empty();

            // Act
            var result = @delegate.SafeInvoke<string, int>("Test");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result, Is.InstanceOf<EmptyOption<int>>());
                Assert.That(result.IsSome(), Is.True);
            });
        }

        [Test]
        public void SafeInvokeNoneTest()
        {
            // Arrange
            Action<string> @delegate = val => throw new Exception();

            // Act
            var result = @delegate.SafeInvoke<string, int>("Test");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsNone(), Is.True);
                Assert.That((result as NoneEmptyOption<int>).Error, Is.EqualTo(default(int)));
            });
        }

    }
}
