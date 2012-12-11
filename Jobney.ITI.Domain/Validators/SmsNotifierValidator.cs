using FluentValidation;
using Jobney.ITI.Interfaces;

namespace Jobney.ITI.Domain.Validators
{
    public class SmsNotifierValidator : AbstractValidator<ICallbackNotifier>
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
                .Matches("^[0-9]+$") // Hardly enough coverage.. I know..
                .WithMessage("Notification Address is not a valid phone number");
        }
    }
}
