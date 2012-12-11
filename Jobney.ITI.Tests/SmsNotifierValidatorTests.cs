using FluentValidation.TestHelper;
using Jobney.ITI.Domain;
using Jobney.ITI.Domain.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobney.ITI.Tests
{
    [TestClass]
    public class SmsNotifierValidatorTests
    {
        private SmsNotifier target;
        private SmsNotifierValidator validator;

        [TestInitialize]
        public void Init()
        {
            target = new SmsNotifier();
            validator = new SmsNotifierValidator();
        }

        [TestClass]
        public class TheMessageTests : SmsNotifierValidatorTests
        {
            [TestMethod]
            public void FailsByDefailt()
            {
                //assert       
                validator.ShouldHaveValidationErrorFor(x => x.Message, target);
            }

            [TestMethod]
            public void FailsWhenNull()
            {
                //arrange
                target.NotificationAddress = null;

                //assert       
                validator.ShouldHaveValidationErrorFor(x => x.Message, target);
            }

            [TestMethod]
            public void FailsWhenEmptyString()
            {
                //arrange
                target.NotificationAddress = null;

                //assert       
                validator.ShouldHaveValidationErrorFor(x => x.Message, target);
            }

            [TestMethod]
            public void PasesWhenHasMessage()
            {
                //arrange
                target.Message = "Hi. I would like to contact you by email.";

                //assert       
                validator.ShouldNotHaveValidationErrorFor(x => x.Message, target);
            }
        }

        [TestClass]
        public class TheNotificationAddressTests : SmsNotifierValidatorTests
        {
            [TestMethod]
            public void FailsByDefailt()
            {
                //assert       
                validator.ShouldHaveValidationErrorFor(x => x.NotificationAddress, target);
            }

            [TestMethod]
            public void FailsWhenNull()
            {
                //arrange
                target.NotificationAddress = null;

                //assert       
                validator.ShouldHaveValidationErrorFor(x => x.NotificationAddress, target);
            }

            [TestMethod]
            public void PasesWhenValidPhone()
            {
                //arrange
                target.NotificationAddress = "2251234560";

                //assert       
                validator.ShouldNotHaveValidationErrorFor(x => x.NotificationAddress, target);
            }
        }
    }
}