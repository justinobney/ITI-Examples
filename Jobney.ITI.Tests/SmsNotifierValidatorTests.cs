using FluentValidation.TestHelper;
using Jobney.ITI.Domain;
using Jobney.ITI.Domain.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobney.ITI.Tests
{
    [TestClass]
    public class SmsNotifierValidatorTests
    {
        protected SmsNotifier Target;
        protected SmsNotifierValidator Validator;

        [TestInitialize]
        public void Init()
        {
            Target = new SmsNotifier();
            Validator = new SmsNotifierValidator();
        }

        [TestClass]
        public class TheMessageTests : SmsNotifierValidatorTests
        {
            [TestMethod]
            public void FailsByDefailt()
            {
                //assert       
                Validator.ShouldHaveValidationErrorFor(x => x.Message, Target);
            }

            [TestMethod]
            public void FailsWhenNull()
            {
                //arrange
                Target.NotificationAddress = null;

                //assert       
                Validator.ShouldHaveValidationErrorFor(x => x.Message, Target);
            }

            [TestMethod]
            public void FailsWhenEmptyString()
            {
                //arrange
                Target.NotificationAddress = null;

                //assert       
                Validator.ShouldHaveValidationErrorFor(x => x.Message, Target);
            }

            [TestMethod]
            public void PasesWhenHasMessage()
            {
                //arrange
                Target.Message = "Hi. I would like to contact you by email.";

                //assert       
                Validator.ShouldNotHaveValidationErrorFor(x => x.Message, Target);
            }
        }

        [TestClass]
        public class TheNotificationAddressTests : SmsNotifierValidatorTests
        {
            [TestMethod]
            public void FailsByDefailt()
            {
                //assert       
                Validator.ShouldHaveValidationErrorFor(x => x.NotificationAddress, Target);
            }

            [TestMethod]
            public void FailsWhenNull()
            {
                //arrange
                Target.NotificationAddress = null;

                //assert       
                Validator.ShouldHaveValidationErrorFor(x => x.NotificationAddress, Target);
            }

            [TestMethod]
            public void PasesWhenValidPhone()
            {
                //arrange
                Target.NotificationAddress = "2251234560";

                //assert       
                Validator.ShouldNotHaveValidationErrorFor(x => x.NotificationAddress, Target);
            }
        }

    }
}
