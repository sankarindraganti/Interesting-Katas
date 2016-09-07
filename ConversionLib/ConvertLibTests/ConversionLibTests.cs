using System;
using ConversionLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ConvertLibTests
{
    [TestClass]
    public class ConversionLibTests
    {
        [TestMethod]
        [TestCategory("IntToRomanTests")]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidInputConversionTest()
        {
            var converter = new Converter();
            converter.ConvertFromIntToRoman(0);
        }

        [TestMethod]
        [TestCategory("IntToRomanTests")]
        [ExpectedException(typeof(ArgumentException))]
        public void IntToRomanBoundaryTest()
        {
            var converter = new Converter();
            converter.ConvertFromIntToRoman(5000);
        }


        [TestMethod]
        [TestCategory("IntToRomanTests")]
        public void InttoRomanBasicTest()
        {
            var moqConverter = new Mock<IConverter>();
            moqConverter.Setup(x => x.ConvertFromIntToRoman(It.IsAny<int>())).Returns("CXXIII");
           
            var converter = new Converter();
            var str = converter.ConvertFromIntToRoman(4999);
            Assert.AreEqual(str, "MMMMCMXCIX");
        }

        [TestMethod]
        [TestCategory("RomanToIntTests")]
        public void RomanToIntBasicTest()
        {
            var converter = new Converter();
            var value = converter.ConvertFromRomanToInt("MMMMCMXCIX");
            Assert.AreEqual(4999,value);
        }

        [TestMethod]
        [TestCategory("RomanToIntTests")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RomanToIntNullInputTest()
        {
            var moq = new Mock<IConverter>();
            moq.Setup(x => x.ConvertFromRomanToInt(It.Is<string>(input => string.IsNullOrEmpty(input))))
                .Throws(new ArgumentNullException($"Input string cannot be null"));

            moq.Object.ConvertFromRomanToInt(null);


            //Assert.AreEqual($"Input string cannot be null", value.ToString());
        }


    }
}
