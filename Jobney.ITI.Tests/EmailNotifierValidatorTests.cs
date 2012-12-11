using FluentValidation.TestHelper;
using Jobney.ITI.Domain;
using Jobney.ITI.Domain.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Jobney.ITI.Tests
{
    [TestClass]
    public class EmailNotifierValidatorTests
    {
        protected EmailNotifier Target;
        protected EmailNotifierValidator Validator;
        
        [TestInitialize]
        public void Init()
        {
            Target = new EmailNotifier();
            Validator = new EmailNotifierValidator();
        }

        [TestClass]
        public class TheMessageTests : EmailNotifierValidatorTests
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
        public class TheNotificationAddressTests : EmailNotifierValidatorTests
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
            public void PasesWhenValidEmail()
            {
                //arrange
                Target.NotificationAddress = "youremail@gmail.com";

                //assert       
                Validator.ShouldNotHaveValidationErrorFor(x => x.NotificationAddress, Target);
            }
        }
        
    }
}
