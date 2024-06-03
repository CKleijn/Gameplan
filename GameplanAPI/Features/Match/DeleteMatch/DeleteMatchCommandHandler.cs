using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Match._Interfaces;

namespace GameplanAPI.Features.Match.DeleteMatch
{
    public sealed class DeleteMatchCommandHandler(
        IMatchRepository matchRepository,
        IUnitOfWork unitOfWork)
        : ICommandHandler<DeleteMatchCommand>
    {
        public async Task<Result> Handle(
            DeleteMatchCommand request, 
            CancellationToken cancellationToken)
        {
            var match = await matchRepository.Get(request.Id, cancellationToken);

            if (match == null)
            {
                return Result.Failure(Errors<Match>.NotFound(request.Id));
            }

            matchRepository.Delete(match);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
