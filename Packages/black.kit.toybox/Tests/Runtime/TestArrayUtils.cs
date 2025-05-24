using System.Linq;
using NUnit.Framework;
using UnityEngine;

namespace black.kit.toybox.Tests
{
    /// <summary>Test class for <see cref="ArrayUtils"/>.</summary>
    [TestFixture]
    public sealed class TestArrayUtils
    {
        /// <summary>
        /// Test for the <see cref="ArrayUtils.At{T}(T[], int)"/> method.
        /// </summary>
        [TestCase(new[] { 1, 2, 3 }, 0, ExpectedResult = 1)]
        [TestCase(new[] { 1, 2, 3 }, 1, ExpectedResult = 2)]
        [TestCase(new[] { 1, 2, 3 }, 2, ExpectedResult = 3)]
        [TestCase(new[] { 1, 2, 3 }, 3, ExpectedResult = 1)]
        [TestCase(new[] { 1, 2, 3 }, -1, ExpectedResult = 3)]
        [TestCase(new[] { 1, 2, 3 }, -2, ExpectedResult = 2)]
        [TestCase(new[] { 1, 2, 3 }, -3, ExpectedResult = 1)]
        [TestCase(new[] { 1, 2, 3 }, -4, ExpectedResult = 3)]
        [TestCase(new[] { 1, 2, 3 }, -5, ExpectedResult = 2)]
        [TestCase(new[] { 1, 2, 3 }, -6, ExpectedResult = 1)]
        [TestCase(new int[0], 0, ExpectedResult = 0)]
        [TestCase(new int[0], -1, ExpectedResult = 0)]
        [TestCase(null, 0, ExpectedResult = 0)]
        public int At(int[] array, int index) => array.At(index);

        /// <summary>
        /// Test for the <see cref="ArrayUtils.AtIndex{T}(T[], int)"/> method.
        /// </summary>
        [TestCase(new[] { 1, 2, 3 }, 0, ExpectedResult = 0)]
        [TestCase(new[] { 1, 2, 3 }, 1, ExpectedResult = 1)]
        [TestCase(new[] { 1, 2, 3 }, 2, ExpectedResult = 2)]
        [TestCase(new[] { 1, 2, 3 }, 3, ExpectedResult = 0)]
        [TestCase(new[] { 1, 2, 3 }, -1, ExpectedResult = 2)]
        [TestCase(new[] { 1, 2, 3 }, -2, ExpectedResult = 1)]
        [TestCase(new[] { 1, 2, 3 }, -3, ExpectedResult = 0)]
        [TestCase(new[] { 1, 2, 3 }, -4, ExpectedResult = 2)]
        [TestCase(new[] { 1, 2, 3 }, -5, ExpectedResult = 1)]
        [TestCase(new[] { 1, 2, 3 }, -6, ExpectedResult = 0)]
        [TestCase(new int[0], 0, ExpectedResult = -1)]
        [TestCase(new int[0], -1, ExpectedResult = -1)]
        [TestCase(null, 0, ExpectedResult = -1)]
        public int AtIndex(int[] array, int index) => array.AtIndex(index);

        /// <summary>
        /// Test for the <see cref="ArrayUtils.Contains{T}(T[], T)"/> method.
        /// </summary>
        [TestCase(new[] { 1, 2, 3 }, 2, ExpectedResult = true)]
        [TestCase(new[] { 1, 2, 3 }, 4, ExpectedResult = false)]
        [TestCase(null, 2, ExpectedResult = false)]
        [TestCase(null, 4, ExpectedResult = false)]
        public bool Contains(int[] array, int value) => array.Contains(value);

        /// <summary>
        /// Test for the <see cref="ArrayUtils.Fill{T}(T[], T)"/> method.
        /// </summary>
        [Test]
        public void Fill()
        {
            int[] array = { 1, 2, 3 };
            Assert.DoesNotThrow(() => array.Fill(0));
            Assert.IsTrue(array.All(obj => obj == 0));
        }

        /// <summary>
        /// Test for the <see cref="ArrayUtils.IsFill{T}(T[])"/> method.
        /// </summary>
        [TestCase(new[] { 0, 0, 0 }, ExpectedResult = true)]
        [TestCase(new[] { 0, 0, 1 }, ExpectedResult = false)]
        [TestCase(new[] { 1, 1, 1 }, ExpectedResult = true)]
        [TestCase(new int[0], ExpectedResult = false)]
        public bool IsFill(int[] array) => array.IsFill();

        /// <summary>
        /// Test for the <see cref="ArrayUtils.IsFill{T}(T[], T)"/> method.
        /// </summary>
        [TestCase(new[] { 0, 0, 0 }, 0, ExpectedResult = true)]
        [TestCase(new[] { 0, 0, 1 }, 0, ExpectedResult = false)]
        [TestCase(new[] { 0, 0, 1 }, 1, ExpectedResult = false)]
        [TestCase(new[] { 1, 1, 1 }, 1, ExpectedResult = true)]
        [TestCase(new int[0], 0, ExpectedResult = false)]
        [TestCase(new int[0], 1, ExpectedResult = false)]
        public bool IsFill(int[] array, int value) => array.IsFill(value);

        /// Test for the <see cref="ArrayUtils.SetActive(GameObject[], bool)"/>
        /// method.
        /// </summary>
        [Test]
        public void SetActive()
        {
            GameObject[] array = { new(), null, new() };
            var exists = array.Where(obj => obj);
            Assert.DoesNotThrow(() => array.SetActive(true));
            Assert.IsTrue(exists.All(obj => obj.activeSelf));
            Assert.DoesNotThrow(() => array.SetActive(false));
            Assert.IsFalse(exists.Any(obj => obj.activeSelf));
        }

        /// <summary>
        /// Test for the <see cref="ArrayUtils.SetActive(GameObject[], bool)"/>
        /// method.
        /// </summary>
        [Test]
        public void SetActive_Null()
        {
            GameObject[] array = null;
            Assert.DoesNotThrow(() => array.SetActive(true));
            Assert.DoesNotThrow(() => array.SetActive(false));
        }
    }
}
