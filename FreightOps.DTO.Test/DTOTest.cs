using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FreightOps.DTO.Validator;
using FluentValidation.TestHelper;

namespace FreightOps.DTO.Test
{
    [TestClass]
    public class DTOTest
    {
        private MyDTOValidator validator;
        public DTOTest()
        {
            validator = new MyDTOValidator();
        }

        [TestCategory("DTO"), TestMethod]
        public void Should_have_error_when_MyString_is_null()
        {
            validator.ShouldHaveValidationErrorFor(x => x.Name, null as string);
        }

        [TestCategory("DTO"), TestMethod]
        public void Should_not_have_error_when_MyString_is_provided()
        {
            validator.ShouldNotHaveValidationErrorFor(x => x.Name, "null as string");
        }
    }
}
