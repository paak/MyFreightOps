using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FreightOps.Common.Test
{
    [TestClass]
    public class ISO6346ValidationTest
    {
        private ISO6346Validation validator;
        public ISO6346ValidationTest()
        {
            validator = new ISO6346Validation();
        }

        [TestMethod]
        public void Should_valid_ISO6346Validation()
        {
            Assert.IsTrue(validator.Validate("CSQU3054383"), "Valid ISO6346 Container number");
        }

        [TestMethod]
        public void Should_invalid_ISO6346Validation()
        {
            Assert.IsFalse(validator.Validate("CSQU3054384"), "Valid ISO6346 Container number");
        }

        [TestMethod]
        public void Should_invalid2_ISO6346Validation()
        {
            Assert.IsFalse(validator.Validate("CSQU305438A"), "Valid ISO6346 Container number");
        }
    }
}
