import useFetchMatchesBySeason from "../hooks/useFetchMatchesBySeason";
import MatchCard from "./MatchCard";
import Paging from "@/core/components/tools/Paging";
import { PagedListQuery } from "@/core/components/utils/Types";
import { Dispatch, SetStateAction } from "react";

type Props = {
	seasonId: string;
	creator: string;
	query: PagedListQuery;
	setQuery: Dispatch<SetStateAction<PagedListQuery>>;
};

const MatchList: React.FC<Props> = ({ seasonId, creator, query, setQuery }) => {
	const { matches, paging } = useFetchMatchesBySeason(seasonId, query);

	return (
		<>
			<div className="space-y-5 mt-5">
				{matches.map((match) => (
					<MatchCard key={match.id} creator={creator} match={match} />
				))}
			</div>
			<Paging
				queryKey={`season/${seasonId}/matches`}
				paging={paging}
				query={query}
				setQuery={setQuery}
			/>
		</>
	);
};

export default MatchList;
