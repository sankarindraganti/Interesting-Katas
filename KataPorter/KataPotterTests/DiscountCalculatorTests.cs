using System;
using System.Collections;
using System.Collections.Generic;
using KataPorter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace KataPotterTests
{
    [TestClass]
    public class DiscountCalculatorTests
    {
        [TestMethod]
        [TestCategory("DiscountCalculator")]
        public void NoOfConfiguredDiscountsTest()
        {
            var discountCalculator = new DiscountCalculator();
            Assert.AreEqual(5, discountCalculator.DiscountMap.Count);
        }

        [TestMethod]
        [TestCategory("DiscountCalculator")]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetBestPriceForZeroBooks()
        {
            var discountCalculator = new DiscountCalculator();
            discountCalculator.GetBestPrice(null);
            Assert.AreEqual(0, discountCalculator.GetBestPrice(null));
        }

        [TestMethod]
        [TestCategory("DiscountCalculator")]
        public void BasicDiscountTests()
        {
            var discountCalculator = new DiscountCalculator();
            
            Assert.AreEqual(8, discountCalculator.GetBestPrice(new int[] { 0 }));
            Assert.AreEqual(8, discountCalculator.GetBestPrice(new int[] { 1 }));
            Assert.AreEqual(8, discountCalculator.GetBestPrice(new int[] { 2 }));
            Assert.AreEqual(8, discountCalculator.GetBestPrice(new int[] { 3 }));
            Assert.AreEqual(8, discountCalculator.GetBestPrice(new int[] { 4 }));

            Assert.AreEqual(8 * 2, discountCalculator.GetBestPrice(new int[] {0,0}));
            Assert.AreEqual(8 * 3, discountCalculator.GetBestPrice(new int[] { 1, 1, 1 }));
        }

        [TestMethod]
        [TestCategory("DiscountCalculator")]
        public void SimpleDiscountsTests()
        {
            var discountCalculator = new DiscountCalculator();

            Assert.AreEqual(8 * 2 * 0.95, discountCalculator.GetBestPrice(new int[] { 0, 1 }));
            Assert.AreEqual(8 * 3 * 0.9, discountCalculator.GetBestPrice(new int[] { 0, 2, 4 }));
            Assert.AreEqual(8 * 4 * 0.8, discountCalculator.GetBestPrice(new int[] { 0, 1, 2, 4 }));
            Assert.AreEqual(8 * 5 * 0.75, discountCalculator.GetBestPrice(new int[] { 0, 1, 2, 3, 4 }));            
        }

        [TestMethod]
        [TestCategory("DiscountCalculator")]
        public void MultipleDiscountsTests()
        {
            var discountCalculator = new DiscountCalculator();

            Assert.AreEqual(8 + (8 * 2 * 0.95), discountCalculator.GetBestPrice(new int[] { 0, 0, 1 }));
            Assert.AreEqual(2 * (8 * 2 * 0.95), discountCalculator.GetBestPrice(new int[] { 0, 0, 1, 1 }));
            Assert.AreEqual((8 * 4 * 0.8) + (8 * 2 * 0.95), discountCalculator.GetBestPrice(new int[] { 0, 0, 1, 2, 2, 3 }));
            Assert.AreEqual(8 + (8 * 5 * 0.75), discountCalculator.GetBestPrice(new int[] { 0, 1, 1, 2, 3, 4 }));
        }

        [TestMethod]
        [TestCategory("DiscountCalculator")]
        public void DiscountsTestsEdgeCases()
        {
            var discountCalculator = new DiscountCalculator();

            Assert.AreEqual(2 * (8 * 4 * 0.8), discountCalculator.GetBestPrice(new int[] { 0, 0, 1, 1, 2, 2, 3, 4 }));
            Assert.AreEqual(3 * (8 * 5 * 0.75) + 2 * (8 * 4 * 0.8), discountCalculator.GetBestPrice(new int[] { 0, 0, 0, 0, 0,
                                                                                                                1, 1, 1, 1, 1,
                                                                                                                2, 2, 2, 2,
                                                                                                                3, 3, 3, 3, 3,
                                                                                                                4, 4, 4, 4 }));
            Assert.AreEqual(78.8, discountCalculator.GetBestPrice(new int[] { 0, 0, 0, 1, 1, 2, 2, 2, 2, 3, 3, 4 }));
            Assert.AreEqual(100.00000000000001, discountCalculator.GetBestPrice(new int[] { 0, 1, 1, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4 }));
        }

    }
}

