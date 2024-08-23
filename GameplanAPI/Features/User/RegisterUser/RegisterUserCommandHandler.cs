using FluentValidation;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.User._Interfaces;

namespace GameplanAPI.Features.User.RegisterUser
{
    public sealed class RegisterUserCommandHandler(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork,
        IValidator<RegisterUserCommand> validator,
        IUserMapper mapper) 
        : ICommandHandler<RegisterUserCommand>
    {
        public async Task<Result> Handle(
            RegisterUserCommand request, 
            CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
            {
                return Result.Failure(validationResult.Errors);
            }

            var user = mapper.RegisterUserCommandToUser(request);

            userRepository.Add(user);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
