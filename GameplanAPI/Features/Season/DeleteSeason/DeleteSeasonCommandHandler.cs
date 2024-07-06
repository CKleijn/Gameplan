using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Season._Interfaces;
using GameplanAPI.Features.Season.GetSeason;
using MediatR;

namespace GameplanAPI.Features.Season.DeleteSeason
{
    public sealed class DeleteSeasonCommandHandler(
        ISeasonRepository seasonRepository, 
        ISender sender,
        IUnitOfWork unitOfWork)
        : ICommandHandler<DeleteSeasonCommand>
    {
        public async Task<Result> Handle(
            DeleteSeasonCommand request, 
            CancellationToken cancellationToken)
        {
            var seasonQuery = new GetSeasonQuery(request.Id);

            var seasonQueryResult = await sender.Send(seasonQuery, cancellationToken);

            if (seasonQueryResult.IsFailure)
            {
                return Result.Failure(seasonQueryResult.Error);
            }

            seasonRepository.Delete(seasonQueryResult.Value!);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
