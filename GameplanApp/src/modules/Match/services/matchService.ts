import createRequest from "@/core/utils/httpClient";
import { CreateEditMatchDTO, MatchResultDTO } from "../MatchDTO";
import { PagedListQuery } from "@/core/components/utils/Types";
import { objToQueryParamsString } from "@/core/utils/helpers";

export const getMatchesBySeasonId = async (seasonId: string, query: PagedListQuery, signal: AbortSignal) => await createRequest({ endpoint: `matches/season/${seasonId}?${objToQueryParamsString(query)}`, method: 'GET', signal });
export const getMatchById = async (matchId: string, signal: AbortSignal) => await createRequest({ endpoint: `match/${matchId}`, method: 'GET', signal });
export const createMatch = async (match: CreateEditMatchDTO) => await createRequest({ endpoint: 'match', method: 'POST', body: match });
export const editMatch = async (match: CreateEditMatchDTO) => await createRequest({ endpoint: `match/${match.id}`, method: 'PUT', body: match });
export const updateMatchResult = async (matchResult: MatchResultDTO) => await createRequest({ endpoint: `match/${matchResult.id}/result`, method: 'PUT', body: matchResult });
export const deleteMatch = async (matchId: string) => await createRequest({ endpoint: `match/${matchId}`, method: 'DELETE' });