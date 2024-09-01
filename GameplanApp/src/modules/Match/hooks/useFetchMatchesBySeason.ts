import { useEffect, useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { Match } from "../Match";
import { getMatchesBySeasonId } from "../services/matchService";
import { PagedListQuery, Paging } from "@/core/components/utils/Types";

const useFetchMatchesBySeason = (seasonId: string, query: PagedListQuery) => {
    const [matches, setMatches] = useState<Match[]>([]);
    const [paging, setPaging] = useState<Paging>({
        page: 1,
        pageSize: 5,
        totalCount: 0,
        hasNextPage: false,
        hasPreviousPage: false
    });

    const { data: newMatches, isLoading, isError } = useQuery({
        queryKey: [`season/${seasonId}/matches`],
        queryFn: async ({ signal }) => getMatchesBySeasonId(seasonId, query, signal),
        retry: false,
    })

    useEffect(() => {
        if (newMatches) {
            setMatches(newMatches.items);
            setPaging({
                page: newMatches.page,
                pageSize: newMatches.pageSize,
                totalCount: newMatches.totalCount,
                hasNextPage: newMatches.hasNextPage,
                hasPreviousPage: newMatches.hasPreviousPage
            });
        }
    }, [newMatches]);

    return { matches, paging, isLoading, isError }
}

export default useFetchMatchesBySeason;