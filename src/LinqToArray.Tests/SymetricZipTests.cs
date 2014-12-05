using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Linq;

namespace LinqToArray
{
    [TestClass]
    public class SymetricZipTests
    {
        [TestMethod]
        public void ThrowsArgumentExceptionIfArraysNotSameLength()
        {
            var array1 = Enumerable.Range(1, 3).ToArray();
            var array2 = Enumerable.Range(1, 4).ToArray();

            Action zippingAsymetricArrays = () => array1.SymetricZip(array2, (a, b) => a + b).Sum();

            zippingAsymetricArrays.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void ReverseMatchesZipReverse()
        {
            var array1 = Enumerable.Range(1, 4).ToArray();
            var array2 = Enumerable.Range(1, 4).ToArray();

            var actual = array1.SymetricZip(array2, (a, b) => a + b).Reverse();
            var expected = array1.Zip(array2, (a, b) => a + b).Reverse();

            actual.Should().Equal(expected);
        }

        [TestMethod]
        public void SkipMatchesZipSkip()
        {
            var array1 = Enumerable.Range(1, 4).ToArray();
            var array2 = Enumerable.Range(1, 4).ToArray();

            var actual = array1.SymetricZip(array2, (a, b) => a + b).Skip(1);
            var expected = array1.Zip(array2, (a, b) => a + b).Skip(1);

            actual.Should().Equal(expected);
        }
    }
}
