import { PagedListQuery } from "@/core/components/utils/Types";
import { isCreator } from "@/core/utils/helpers";
import SeasonCreateFormButton from "@/modules/Match/components/MatchFormDialog";
import MatchList from "@/modules/Match/components/MatchList";
import MatchToolbar from "@/modules/Match/components/MatchToolbar";
import useFetchSeasonById from "@/modules/Season/hooks/useFetchSeasonById";
import { useState } from "react";
import { useTranslation } from "react-i18next";
import { useParams } from "react-router-dom";

type Props = {};

const MatchesPage: React.FC<Props> = () => {
	const { seasonId } = useParams<{ seasonId: string }>();
	const { season } = useFetchSeasonById(seasonId!);
	const { t } = useTranslation();
	const [query, setQuery] = useState<PagedListQuery>({
		searchTerm: null,
		sortColumn: null,
		sortOrder: null,
		page: 1,
		pageSize: 5,
	});

	if (!seasonId || !season) return null;

	return (
		<>
			<div className="flex flex-row items-center justify-between mt-14 sm:mt-0">
				<h1 className="font-bold text-4xl my-5">{t("matches")}</h1>
				{isCreator(season.creator) && (
					<SeasonCreateFormButton seasonId={seasonId} />
				)}
			</div>
			<div className="flex flex-col sm:flex-row">
				<div className="max-w-full sm:w-8/12 mb-5">
					<MatchToolbar seasonId={seasonId} query={query} setQuery={setQuery} />
					<MatchList
						seasonId={seasonId}
						creator={season.creator}
						query={query}
						setQuery={setQuery}
					/>
				</div>
				<div className="max-w-full sm:w-4/12">Charts/Participants</div>
			</div>
		</>
	);
};

export default MatchesPage;
