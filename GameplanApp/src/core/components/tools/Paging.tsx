import { Dispatch, SetStateAction, useEffect } from "react";
import { PagedListQuery, Paging as PagingType } from "../utils/Types";
import useDebounce from "@/core/hooks/useDebounce";
import { useQueryClient } from "@tanstack/react-query";
import {
	PaginationContent,
	PaginationItem,
	PaginationPrevious,
	PaginationEllipsis,
	PaginationLink,
	PaginationNext,
	Pagination,
} from "../ui/pagination";

type Props = {
	queryKey: string;
	paging: PagingType;
	query: PagedListQuery;
	setQuery: Dispatch<SetStateAction<PagedListQuery>>;
};

const Paging: React.FC<Props> = ({ queryKey, paging, query, setQuery }) => {
	const queryClient = useQueryClient();
	const page = useDebounce(query.page);

	useEffect(() => {
		queryClient.refetchQueries({ queryKey: [queryKey] });
	}, [page]);

	useEffect(() => {
		if (paging.page * paging.pageSize > paging.totalCount - paging.pageSize) {
			setQuery((prev) => ({ ...prev, page: 1 }));
		}
	}, [query.searchTerm]);

	return (
		<>
			{!(paging.page == 1 && !paging.hasNextPage) && (
				<Pagination className="w-full mt-3">
					<PaginationContent className="cursor-pointer">
						{paging.hasPreviousPage && (
							<PaginationItem
								onClick={() =>
									setQuery((prev) => ({ ...prev, page: page - 1 }))
								}
							>
								<PaginationPrevious />
							</PaginationItem>
						)}
						{paging.hasPreviousPage && paging.page > 2 && (
							<PaginationItem>
								<PaginationEllipsis />
							</PaginationItem>
						)}
						{paging.hasPreviousPage && (
							<PaginationItem
								onClick={() =>
									setQuery((prev) => ({ ...prev, page: page - 1 }))
								}
							>
								<PaginationLink>{paging.page - 1}</PaginationLink>
							</PaginationItem>
						)}
						<PaginationItem className="rounded-md bg-blue-600">
							<PaginationLink>{paging.page}</PaginationLink>
						</PaginationItem>
						{paging.hasNextPage && (
							<PaginationItem
								onClick={() =>
									setQuery((prev) => ({ ...prev, page: page + 1 }))
								}
							>
								<PaginationLink>{paging.page + 1}</PaginationLink>
							</PaginationItem>
						)}
						{paging.hasNextPage &&
							paging.page != paging.totalCount / paging.pageSize - 1 && (
								<PaginationItem>
									<PaginationEllipsis />
								</PaginationItem>
							)}
						{paging.hasNextPage && (
							<PaginationItem
								onClick={() =>
									setQuery((prev) => ({ ...prev, page: page + 1 }))
								}
							>
								<PaginationNext />
							</PaginationItem>
						)}
					</PaginationContent>
				</Pagination>
			)}
		</>
	);
};

export default Paging;
