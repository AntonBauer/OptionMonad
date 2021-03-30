using NUnit.Framework;
using OptionMonad.ValueOptionExtensions;
using System;

namespace OptionMonad.Tests.ExtensionsTests
{
    [Category("OptionExtensions")]
    public class BindingExtensionsTests
    {
        [Test]
        public void BindSomeToPlainTest()
        {
            // Arrange
            var option = "Hello there".Some<string, int>();
            Func<string, int> @delegate = val => val.Length;

            // Act
            var actual = option.Bind(@delegate);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual, Is.InstanceOf<Option<int, int>>());
                Assert.That(actual.IsSome(), Is.True);
                Assert.That((actual as SomeOption<int, int>).Value, Is.EqualTo(11));
            });
        }

        [Test]
        public void BindNoneToPlainTest()
        {
            // Arrange
            var error = 42;
            var option = error.None<string, int>();
            Func<string, int> @delegate = val => val.Length;

            // Act
            var actual = option.Bind(@delegate);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual, Is.InstanceOf<Option<int, int>>());
                Assert.That(actual.IsNone(), Is.True);
                Assert.That((actual as NoneOption<int, int>).Error, Is.EqualTo(error));
            });
        }

        [Test]
        public void BindSomeToSomeOptionTest()
        {
            // Arrange
            var option = "Hello there".Some<string, int>();
            Func<string, Option<int, int>> @delegate = val => val.Length.Some<int, int>();

            // Act
            var actual = option.Bind(@delegate);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual, Is.InstanceOf<Option<int, int>>());
                Assert.That(actual.IsSome(), Is.True);
                Assert.That((actual as SomeOption<int, int>).Value, Is.EqualTo(11));
            });
        }

        [Test]
        public void BindSomeToNoneOptionTest()
        {
            // Arrange
            var option = "Hello there".Some<string, int>();
            Func<string, Option<int, int>> @delegate = val => 42.None<int, int>();

            // Act
            var actual = option.Bind(@delegate);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual, Is.InstanceOf<Option<int, int>>());
                Assert.That(actual.IsNone(), Is.True);
                Assert.That((actual as NoneOption<int, int>).Error, Is.EqualTo(42));
            });
        }

        [Test]
        public void BindNoneToSomeOptionTest()
        {
            // Arrange
            var error = 42;
            var option = error.None<string, int>();
            Func<string, Option<int, int>> @delegate = val => val.Length.Some<int, int>();

            // Act
            var actual = option.Bind(@delegate);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual, Is.InstanceOf<Option<int, int>>());
                Assert.That(actual.IsNone(), Is.True);
                Assert.That((actual as NoneOption<int, int>).Error, Is.EqualTo(error));
            });
        }

        [Test]
        public void BindNoneToNoneOptionTest()
        {
            // Arrange
            var error = 42;
            var internalError = 24;
            var option = error.None<string, int>();
            Func<string, Option<int, int>> @delegate = val => internalError.None<int, int>();

            // Act
            var actual = option.Bind(@delegate);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.Not.Null);
                Assert.That(actual, Is.InstanceOf<Option<int, int>>());
                Assert.That(actual.IsNone(), Is.True);
                Assert.That((actual as NoneOption<int, int>).Error, Is.EqualTo(error));
            });
        }
    }
}
