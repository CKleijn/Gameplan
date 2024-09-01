import useFetchSeasons from "../hooks/useFetchSeasons";
import SeasonCard from "./SeasonCard";
import { Dispatch, SetStateAction } from "react";
import { PagedListQuery } from "@/core/components/utils/Types";
import Paging from "@/core/components/tools/Paging";

type Props = {
	query: PagedListQuery;
	setQuery: Dispatch<SetStateAction<PagedListQuery>>;
};

const SeasonList: React.FC<Props> = ({ query, setQuery }) => {
	const { seasons, paging } = useFetchSeasons(query);

	return (
		<>
			<div className="grid grid-flow-row grid-cols-1 gap-5 mt-5 md:grid-cols-3">
				{seasons.map((season) => (
					<SeasonCard key={season.id} season={season} />
				))}
			</div>
			<Paging
				queryKey="seasons"
				paging={paging}
				query={query}
				setQuery={setQuery}
			/>
		</>
	);
};

export default SeasonList;
