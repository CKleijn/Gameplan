import { Match } from "../Match/Match";

export type Season = {
    id: string;
    club: string;
    calendarYear: string;
    upcomingMatches: Match[];
    creator: string;
    updatedAt?: string;
    createdAt: string;
};