import { useEffect, useState } from "react";
import { Season } from "../Season";
import { useQuery } from "@tanstack/react-query";
import { getSeasons } from "../services/seasonService";
import { PagedListQuery, Paging } from "@/core/components/utils/Types";

const useFetchSeasons = (query: PagedListQuery) => {
    const [seasons, setSeasons] = useState<Season[]>([]);
    const [paging, setPaging] = useState<Paging>({
        page: 1,
        pageSize: 5,
        totalCount: 0,
        hasNextPage: false,
        hasPreviousPage: false
    });

    const { data: newSeasons, isLoading, isError } = useQuery({
        queryKey: ["seasons"],
        queryFn: async ({ signal }) => getSeasons(query, signal),
    })

    useEffect(() => {
        if (newSeasons) {
            setSeasons(newSeasons.items);
            setPaging({
                page: newSeasons.page,
                pageSize: newSeasons.pageSize,
                totalCount: newSeasons.totalCount,
                hasNextPage: newSeasons.hasNextPage,
                hasPreviousPage: newSeasons.hasPreviousPage
            });
        }
    }, [newSeasons]);

    return { seasons, paging, isLoading, isError }
}

export default useFetchSeasons;