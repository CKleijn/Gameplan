import { objToQueryParamsString } from "@/core/utils/helpers";
import { CreateEditSeasonDTO } from "../SeasonDTO";
import createRequest from "@/core/utils/httpClient";
import { PagedListQuery } from "@/core/components/utils/Types";

export const getSeasons = async (query: PagedListQuery, signal: AbortSignal) => await createRequest({ endpoint: `seasons?${objToQueryParamsString(query)}`, method: 'GET', signal });
export const createSeason = async (season: CreateEditSeasonDTO) => await createRequest({ endpoint: 'season', method: 'POST', body: season });
export const editSeason = async (season: CreateEditSeasonDTO) => await createRequest({ endpoint: `season/${season.id}`, method: 'PUT', body: season });
export const deleteSeason = async (seasonId: string) => await createRequest({ endpoint: `season/${seasonId}`, method: 'DELETE' });