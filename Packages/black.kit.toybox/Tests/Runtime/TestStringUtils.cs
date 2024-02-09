using NUnit.Framework;

namespace black.kit.toybox.Tests
{
    /// <summary>Test class for <see cref="StringUtils"/>.</summary>
    [TestFixture]
    public sealed class TestStringUtils
    {
        /// <summary>
        /// Test for
        /// <see cref="StringUtils.AreAllCharsContained(string, string)"/>.
        /// </summary>
        [TestCase("bcd", "abcde", ExpectedResult = true)]
        [TestCase("bcd", "bcd", ExpectedResult = true)]
        [TestCase("abc", "bcd", ExpectedResult = false)]
        [TestCase("abc", "def", ExpectedResult = false)]
        [TestCase(null, "abc", ExpectedResult = true)]
        [TestCase("abc", null, ExpectedResult = false)]
        [TestCase(null, null, ExpectedResult = true)]
        [TestCase("", "abc", ExpectedResult = true)]
        [TestCase("abc", "", ExpectedResult = false)]
        [TestCase("", "", ExpectedResult = true)]
        public bool AreAllCharsContained(string str, string charset) =>
            str.AreAllCharsContained(charset);
    }
}
