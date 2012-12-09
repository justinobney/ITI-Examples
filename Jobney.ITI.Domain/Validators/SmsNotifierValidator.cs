using FluentValidation;

namespace Jobney.ITI.Domain.Validators
{
    public class SmsNotifierValidator : AbstractValidator<SmsNotifier>
    {
        public SmsNotifierValidator()
        {
            RuleFor(x => x.Message)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.NotificationAddress)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .NotEmpty()
                .Matches("^[0-9]+$");
        }
    }
}
