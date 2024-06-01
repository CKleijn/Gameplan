using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Competition._Interfaces;

namespace GameplanAPI.Features.Competition.DeleteCompetition
{
    public sealed class DeleteCompetitionCommandHandler(
        ICompetitionRepository competitionRepository, 
        IUnitOfWork unitOfWork) 
        : ICommandHandler<DeleteCompetitionCommand>
    {
        public async Task<Result> Handle(
            DeleteCompetitionCommand request, 
            CancellationToken cancellationToken)
        {
            var competition = await competitionRepository.Get(request.Id, cancellationToken);

            if (competition == null)
            {
                return Result.Failure(Errors<Competition>.NotFound(request.Id));
            }

            competitionRepository.Delete(competition);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
