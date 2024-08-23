using FluentValidation;

namespace GameplanAPI.Features.User.RegisterUser
{
    public sealed class RegisterUserCommandValidator
        : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(user => user.UID)
                .NotEmpty()
                .WithMessage("UID is required!");

            RuleFor(user => user.DisplayName)
                .NotEmpty()
                .WithMessage("Display name is required!");

            RuleFor(user => user.Email)
                .NotEmpty()
                .WithMessage("Email is required!");

            RuleFor(user => user.Provider)
                .NotEmpty()
                .WithMessage("Provider is required!");
        }
    }
}
