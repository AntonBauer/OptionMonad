using NUnit.Framework;
using OptionMonad.ValueOptionExtensions;
using System;

namespace OptionMonad.Tests.ExtensionsTests
{
    [Category("OptionExtensions")]
    public class BindingExtensionsTests
    {
        [Test]
        public void BindToSomeTest()
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
    }
}
