using System.ComponentModel.DataAnnotations;

namespace GameplanAPI.Common.Enums
{
    public enum MatchStatus
    {
        [Display(Name = "Upcoming")]
        Upcoming = 0,
        [Display(Name = "Finished")]
        Finished = 1,
        [Display(Name = "Postponed")]
        Postponed = 2
    }
}
