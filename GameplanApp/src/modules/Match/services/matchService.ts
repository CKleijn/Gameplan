import createRequest from "@/core/utils/httpClient";
import { CreateEditMatchDTO, UpdateMatchResultDTO } from "../MatchDTO";

export const getMatchesBySeasonId = async (seasonId: string, signal: AbortSignal) => await createRequest({ endpoint: `matches/season/${seasonId}`, method: 'GET', signal });
export const getMatchById = async (matchId: string, signal: AbortSignal) => await createRequest({ endpoint: `match/${matchId}`, method: 'GET', signal });
export const createMatch = async (match: CreateEditMatchDTO) => await createRequest({ endpoint: 'match', method: 'POST', body: match });
export const editMatch = async (match: CreateEditMatchDTO) => await createRequest({ endpoint: `match/${match.id}`, method: 'PUT', body: match });
export const updateMatchResult = async (matchResult: UpdateMatchResultDTO) => await createRequest({ endpoint: `match/${matchResult.id}/result`, method: 'PUT', body: matchResult });
export const deleteMatch = async (matchId: string) => await createRequest({ endpoint: `match/${matchId}`, method: 'DELETE' });