using NUnit.Framework;
using OptionMonad.ValueOptionExtensions;

namespace OptionMonad.Tests
{
    [Category("OptionExtensions")]
    public class GeneralExtensionsTests
    {
        [Test]
        public void SomeTest()
        {
            // Arrange
            var value = "Hello there";

            // Act
            var option = value.Some<string, int>();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(option, Is.Not.Null);
                Assert.That(option, Is.InstanceOf<SomeOption<string, int>>());
                Assert.That((option as SomeOption<string, int>).Value, Is.EqualTo(value));
            });
        }

        [Test]
        public void NoneTest()
        {
            // Arrange
            var error = "Hello there";

            // Act
            var option = error.None<int, string>();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(option, Is.Not.Null);
                Assert.That(option, Is.InstanceOf<NoneOption<int, string>>());
                Assert.That((option as NoneOption<int, string>).Error, Is.EqualTo(error));
            });
        }
    }
}