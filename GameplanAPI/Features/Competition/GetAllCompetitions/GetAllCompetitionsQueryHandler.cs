using GameplanAPI.Features.Competition._Interfaces;
using GameplanAPI.Shared.Abstractions.Handling;
using GameplanAPI.Shared.Abstractions.Messaging;

namespace GameplanAPI.Features.Competition.GetAllCompetitions
{
    public class GetAllCompetitionsQueryHandler(ICompetitionRepository competitionRepository) 
        : IQueryHandler<GetAllCompetitionsQuery, IEnumerable<Competition>>
    {
        public async Task<Result<IEnumerable<Competition>>> Handle(
            GetAllCompetitionsQuery request, 
            CancellationToken cancellationToken)
        {
            var competitions = await competitionRepository.GetAll(cancellationToken);

            return Result<IEnumerable<Competition>>.Success(competitions);
        }
    }
}
