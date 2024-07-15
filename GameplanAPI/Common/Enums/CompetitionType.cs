using System.ComponentModel.DataAnnotations;

namespace GameplanAPI.Common.Enums
{
    public enum CompetitionType
    {
        [Display(Name = "National Competition")]
        NationalCompetition = 0,
        [Display(Name = "National Cup")]
        NationalCup = 1,
        [Display(Name = "National Supercup")]
        NationalSupercup = 2,
        [Display(Name = "Champions League")]
        ChampionsLeague = 3,
        [Display(Name = "Europa League")]
        EuropaLeague = 4,
        [Display(Name = "Conference League")]
        ConferenceLeague = 5,
        [Display(Name = "Other")]
        Other = 6
    }
}
