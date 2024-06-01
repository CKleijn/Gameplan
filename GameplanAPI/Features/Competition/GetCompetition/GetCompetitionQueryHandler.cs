using GameplanAPI.Common.Errors;
using GameplanAPI.Common.Interfaces;
using GameplanAPI.Common.Models;
using GameplanAPI.Features.Competition._Interfaces;

namespace GameplanAPI.Features.Competition.GetCompetition
{
    public sealed class GetCompetitionQueryHandler(ICompetitionRepository competitionRepository)
        : IQueryHandler<GetCompetitionQuery, Competition>
    {
        public async Task<Result<Competition>> Handle(
            GetCompetitionQuery request, 
            CancellationToken cancellationToken)
        {
            var competition = await competitionRepository.Get(request.Id, cancellationToken);
            
            if (competition == null)
            {
                return Result<Competition>.Failure(Errors<Competition>.NotFound(request.Id));
            }

            return Result<Competition>.Success(competition);
        }
    }
}
