using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.User._Interfaces;

namespace GameplanAPI.Features.User.GetUserByUID
{
    public sealed class GetUserByUIDQueryHandler(
        IUserRepository userRepository)
        : IQueryHandler<GetUserByUIDQuery, User>
    {
        public async Task<Result<User>> Handle(
            GetUserByUIDQuery request,
            CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByUID(request.UID, cancellationToken);

            if (user == null)
            {
                return Result<User>.Failure(Errors<User>.NotFound(request.UID));
            }

            return Result<User>.Success(user);
        }
    }
}
