import { useEffect, useState } from "react";
import { Season } from "../Season";
import { useQuery } from "@tanstack/react-query";
import { getSeasons } from "../services/seasonService";

const useFetchSeasons = () => {
    const [seasons, setSeasons] = useState<Season[]>([]);

    const { data: newSeasons, isLoading, isError } = useQuery({
        queryKey: ["seasons"],
        queryFn: async ({ signal }) => getSeasons(signal),
    })

    useEffect(() => {
        if (newSeasons) {
            setSeasons(newSeasons);
        }
    }, [newSeasons]);

    return { seasons, isLoading, isError }
}

export default useFetchSeasons;