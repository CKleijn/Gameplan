import { Dispatch, SetStateAction, useEffect } from "react";
import { useQueryClient } from "@tanstack/react-query";
import useDebounce from "@/core/hooks/useDebounce";
import Search from "@/core/components/tools/Search";
import { PagedListQuery } from "@/core/components/utils/Types";
import SortColumn from "@/core/components/tools/SortColumn";
import SortingOrder from "@/core/components/tools/SortingOrder";

type Props = {
	query: PagedListQuery;
	setQuery: Dispatch<SetStateAction<PagedListQuery>>;
};

const SeasonToolbar: React.FC<Props> = ({ query, setQuery }) => {
	const queryClient = useQueryClient();

	// Sort hoeft niet
	const searchTerm = useDebounce(query.searchTerm);
	const sortColumn = useDebounce(query.sortColumn);
	const sortOrder = useDebounce(query.sortOrder);

	useEffect(() => {
		queryClient.refetchQueries({ queryKey: ["seasons"] });
	}, [searchTerm, sortColumn, sortOrder]);

	return (
		<div className="flex gap-5">
			<Search placeholder="Search seasons" setQuery={setQuery} />
			<SortColumn
				items={["club", "calendarYear"]}
				placeholder="Sort seasons"
				setQuery={setQuery}
			/>
			<SortingOrder setQuery={setQuery} />
		</div>
	);
};

export default SeasonToolbar;
