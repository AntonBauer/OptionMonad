using NUnit.Framework;
using OptionMonad.ValueOption;
using OptionMonad.ValueOptionExtensions;
using System;

namespace OptionMonad.Tests.ValueOptionExtensionsTests
{
    [Category("Option Extensions")]
    [Category("Value Option")]
    public class DelegateExtensionsTests
    {
        [Test]
        public void SafeInvokeSomeTest()
        {
            // Arrange
            Func<string, int> @delegate = val => val.Length;

            // Act
            var result = @delegate.SafeInvoke<string, int, int>("Test");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsSome(), Is.True);
                Assert.That((result as SomeOption<int, int>).Value, Is.EqualTo(4));
            });
        }

        [Test]
        public void SafeInvokeNoneTest()
        {
            // Arrange
            Func<string, int> @delegate = val => throw new Exception();

            // Act
            var result = @delegate.SafeInvoke<string, int, int>("Test");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
                Assert.That(result.IsNone(), Is.True);
                Assert.That((result as NoneOption<int, int>).Error, Is.EqualTo(default(int)));
            });
        }
    }
}
