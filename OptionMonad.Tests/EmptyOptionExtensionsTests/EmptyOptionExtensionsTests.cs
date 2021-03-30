using NUnit.Framework;
using OptionMonad.EmptyOption;
using OptionMonad.EmptyOptionExtensions;
using System.Collections.Generic;

namespace OptionMonad.Tests.EmptyOptionExtensionsTests
{
    [Category("Option Extensions")]
    [Category("Empty Option")]
    public class EmptyOptionExtensionsTests
    {
        [Test]
        [TestCaseSource(nameof(IsSomeTestCases))]
        public void IsSomeTest(EmptyOption<int> option, bool expected)
        {
            // Arrange
            // Act
            var actual = option.IsSome();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        [TestCaseSource(nameof(IsNoneTestCases))]
        public void IsNoneTest(EmptyOption<int> option, bool expected)
        {
            // Arrange
            // Act
            var actual = option.IsNone();

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        public static IEnumerable<TestCaseData> IsSomeTestCases()
        {
            yield return new TestCaseData(EmptyOption<int>.Some(), true);
            yield return new TestCaseData(EmptyOption<int>.None(), false);
        }

        public static IEnumerable<TestCaseData> IsNoneTestCases()
        {
            yield return new TestCaseData(EmptyOption<int>.Some(), false);
            yield return new TestCaseData(EmptyOption<int>.None(), true);
        }
    }
}
