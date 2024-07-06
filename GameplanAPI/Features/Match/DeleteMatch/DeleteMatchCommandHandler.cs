using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Match._Interfaces;
using GameplanAPI.Features.Match.GetMatch;
using MediatR;

namespace GameplanAPI.Features.Match.DeleteMatch
{
    public sealed class DeleteMatchCommandHandler(
        IMatchRepository matchRepository,
        ISender sender,
        IUnitOfWork unitOfWork)
        : ICommandHandler<DeleteMatchCommand>
    {
        public async Task<Result> Handle(
            DeleteMatchCommand request, 
            CancellationToken cancellationToken)
        {
            var matchQuery = new GetMatchQuery(request.Id);

            var matchQueryResult = await sender.Send(matchQuery, cancellationToken);

            if (matchQueryResult.IsFailure)
            {
                return Result.Failure(matchQueryResult.Error);
            }

            matchRepository.Delete(matchQueryResult.Value!);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
