import useFetchMatchesBySeason from "../hooks/useFetchMatchesBySeason";
import Spinner from "@/core/components/utils/Spinner";
import MatchCard from "./MatchCard";
import Paging from "@/core/components/tools/Paging";
import { PagedListQuery } from "@/core/components/utils/Types";
import { Dispatch, SetStateAction } from "react";

type Props = {
	seasonId: string;
	query: PagedListQuery;
	setQuery: Dispatch<SetStateAction<PagedListQuery>>;
};

const MatchList: React.FC<Props> = ({ seasonId, query, setQuery }) => {
	const { matches, paging, isLoading } = useFetchMatchesBySeason(
		seasonId,
		query
	);

	if (isLoading) return <Spinner />;

	return (
		<>
			<div className="space-y-5 mt-5">
				{matches.map((match) => (
					<MatchCard key={match.id} match={match} />
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
