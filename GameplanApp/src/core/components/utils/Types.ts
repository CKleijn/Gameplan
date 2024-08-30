export type PagedListQuery = {
    searchTerm?: string | null;
    sortColumn?: string | null;
    sortOrder?: string | null;
    page: number;
    pageSize: number;
}

export type Paging = {
    page: number,
    pageSize: number,
    totalCount: number,
    hasNextPage: boolean,
    hasPreviousPage: boolean
}