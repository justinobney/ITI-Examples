using FluentValidation;
using Jobney.ITI.Interfaces;

namespace Jobney.ITI.Domain.Validators
{
    public class EmailNotifierValidator : AbstractValidator<ICallbackNotifier>
    {
        public EmailNotifierValidator()
        {
            RuleFor(x => x.Message)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.NotificationAddress)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .EmailAddress();
        }
    }
}
