using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Competition._Interfaces;

namespace GameplanAPI.Features.Competition.GetAllCompetitions
{
    public sealed class GetAllCompetitionsQueryHandler(ICompetitionRepository competitionRepository) 
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
