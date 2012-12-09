using FluentValidation;

namespace Jobney.ITI.Domain.Validators
{
    public class EmailNotifierValidator : AbstractValidator<EmailNotifier>
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
