import { PagedListQuery } from "@/core/components/utils/Types";
import SeasonCreateFormButton from "@/modules/Season/components/SeasonFormDialog";
import SeasonList from "@/modules/Season/components/SeasonList";
import SeasonToolbar from "@/modules/Season/components/SeasonToolbar";
import { useState } from "react";
import { useTranslation } from "react-i18next";

type Props = {};

const SeasonsPage: React.FC<Props> = () => {
	const { t } = useTranslation();
	const [query, setQuery] = useState<PagedListQuery>({
		searchTerm: null,
		sortColumn: null,
		sortOrder: null,
		page: 1,
		pageSize: 3,
	});

	return (
		<>
			<div className="flex flex-row items-center justify-between">
				<h1 className="font-bold text-4xl my-5">{t("seasons")}</h1>
				<SeasonCreateFormButton />
			</div>
			<SeasonToolbar query={query} setQuery={setQuery} />
			<SeasonList query={query} setQuery={setQuery} />
		</>
	);
};

export default SeasonsPage;
