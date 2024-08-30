using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.User._Interfaces;

namespace GameplanAPI.Features.User.GetUserByUID
{
    public sealed class GetUserByUIDQueryHandler(
        IUserMapper mapper,
        IUserRepository userRepository)
        : IQueryHandler<GetUserByUIDQuery, UserResponse>
    {
        public async Task<Result<UserResponse>> Handle(
            GetUserByUIDQuery request,
            CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByUID(request.UID, cancellationToken);

            if (user == null)
            {
                return Result<UserResponse>.Failure(Errors<User>.NotFound(request.UID));
            }

            return Result<UserResponse>.Success(mapper.UserToUserResponse(user));
        }
    }
}
