import { Dispatch, SetStateAction, useEffect } from "react";
import { useQueryClient } from "@tanstack/react-query";
import useDebounce from "@/core/hooks/useDebounce";
import Search from "@/core/components/tools/Search";
import { PagedListQuery } from "@/core/components/utils/Types";
import SortColumn from "@/core/components/tools/SortColumn";
import SortingOrder from "@/core/components/tools/SortingOrder";

type Props = {
	seasonId: string;
	query: PagedListQuery;
	setQuery: Dispatch<SetStateAction<PagedListQuery>>;
};

const MatchToolbar: React.FC<Props> = ({ seasonId, query, setQuery }) => {
	const queryClient = useQueryClient();

	// Sort hoeft niet
	const searchTerm = useDebounce(query.searchTerm);
	const sortColumn = useDebounce(query.sortColumn);
	const sortOrder = useDebounce(query.sortOrder);

	useEffect(() => {
		queryClient.refetchQueries({ queryKey: [`season/${seasonId}/matches`] });
	}, [searchTerm, sortColumn, sortOrder]);

	return (
		<div className="flex flex-col sm:flex-row gap-3 sm:gap-5">
			<Search placeholder="Search matches" setQuery={setQuery} />
			<SortColumn
				items={["competitionType", "matchStatus", "dateTime"]}
				placeholder="Sort matches"
				setQuery={setQuery}
			/>
			<SortingOrder setQuery={setQuery} />
		</div>
	);
};

export default MatchToolbar;
