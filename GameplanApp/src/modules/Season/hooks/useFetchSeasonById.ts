import { useEffect, useState } from "react";
import { Season } from "../Season";
import { useQuery } from "@tanstack/react-query";
import { getSeasonById } from "../services/seasonService";

const useFetchSeasonById = (seasonId: string) => {
    const [season, setSeason] = useState<Season>({
        id: "",
        club: "",
        calendarYear: "",
        upcomingMatches: [],
        creator: "",
        updatedAt: "",
        createdAt: "",
    });

    const { data: newSeason, isLoading, isError } = useQuery({
        queryKey: [`season/${seasonId}`],
        queryFn: async ({ signal }) => getSeasonById(seasonId, signal),
        retry: false,
    })

    useEffect(() => {
        if (newSeason) {
            setSeason(newSeason);
        }
    }, [newSeason]);

    return { season, isLoading, isError }
}

export default useFetchSeasonById;