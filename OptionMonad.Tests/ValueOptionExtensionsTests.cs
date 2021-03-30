using NUnit.Framework;
using OptionMonad.ValueOptionExtensions;
using System.Collections.Generic;

namespace OptionMonad.Tests
{
    [Category("OptionExtensions")]
    public class ValueOptionExtensionsTests
    {
        [Test]
        [TestCaseSource(nameof(IsSomeTestCases))]
        public void IsSomeTest(Option<string, int> option, bool expected)
        {
            // Arrange
            // Act
            var actual = option.IsSome();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCaseSource(nameof(IsNoneTestCases))]
        public void IsNoneTest(Option<string, int> option, bool expected)
        {
            // Arrange
            // Act
            var actual = option.IsNone();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        public static IEnumerable<TestCaseData> IsSomeTestCases()
        {
            yield return new TestCaseData("helloThere".Some<string, int>(), true);
            yield return new TestCaseData(42.None<string, int>(), false);
        }

        public static IEnumerable<TestCaseData> IsNoneTestCases()
        {
            yield return new TestCaseData("helloThere".Some<string, int>(), false);
            yield return new TestCaseData(42.None<string, int>(), true);
        }
    }
}
