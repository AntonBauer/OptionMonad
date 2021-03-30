using NUnit.Framework;

namespace OptionMonad.Tests
{
    [Category("OptionsCreation")]
    public class OptionTests
    {
        [Test]
        public void CreateSomeTest()
        {
            // Arrange
            const string value = "Hello there";

            // Act
            var some = Option<string, string>.Some(value);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(some, Is.Not.Null);
                Assert.That(some, Is.InstanceOf<SomeOption<string, string>>());
                Assert.That((some as SomeOption<string, string>).Value, Is.EqualTo(value));
            });
        }

        [Test]
        public void CreateNoneTest()
        {
            // Arrange
            const string error = "Some error message";
           
            // Act
            var some = Option<string, string>.None(error);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(some, Is.Not.Null);
                Assert.That(some, Is.InstanceOf<NoneOption<string, string>>());
                Assert.That((some as NoneOption<string, string>).Error, Is.EqualTo(error));
            });
        }
    }
}