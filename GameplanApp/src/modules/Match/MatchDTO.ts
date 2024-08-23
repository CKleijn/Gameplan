export type CreateEditMatchDTO = {
    id?: string;
    homeClub: string;
    awayClub: string;
    dateTime: string;
    competitionType: string;
    matchStatus?: string;
    seasonId?: string;
};

export type MatchResultDTO = {
    id: string;
    homeScore: number;
    awayScore: number;
    matchStatus: string;
};

export enum CompetitionType {
    NationalCompetition = "National Competition",
    NationalCup = "National Cup",
    NationalSupercup = "National Supercup",
    ChampionsLeague = "Champions League",
    EuropaLeague = "Europa League",
    ConferenceLeague = "Conference League",
    Other = "Other"
}

export enum MatchStatus {
    Upcoming = "Upcoming",
    Finished = "Finished",
    Postponed = "Postponed"
}