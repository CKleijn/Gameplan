import { useEffect, useState } from "react";
import { useQuery } from "@tanstack/react-query";
import { Match } from "../Match";
import { getMatchesBySeasonId } from "../services/matchService";

type Props = {
    seasonId: string;
}

const useFetchMatchesBySeason = ({ seasonId }: Props) => {
    const [matches, setMatches] = useState<Match[]>([]);

    const { data: newMatches, isLoading, isError } = useQuery({
        queryKey: [`season/${seasonId}/matches`],
        queryFn: async ({ signal }) => getMatchesBySeasonId(seasonId, signal)
    })

    useEffect(() => {
        if (newMatches) {
            setMatches(newMatches);
        }
    }, [newMatches]);

    return { matches, isLoading, isError }
}

export default useFetchMatchesBySeason;