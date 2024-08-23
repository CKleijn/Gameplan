import SeasonCreateFormButton from "@/modules/Match/components/MatchFormDialog";
import MatchList from "@/modules/Match/components/MatchList";
import { useTranslation } from "react-i18next";
import { useParams } from "react-router-dom";

type Props = {};

const MatchesPage: React.FC<Props> = () => {
	const { seasonId } = useParams<{ seasonId: string }>();
	const { t } = useTranslation();

	if (!seasonId) return null;

	return (
		<>
			<div className="flex flex-row items-center justify-between">
				<h1 className="font-bold text-4xl my-5">{t("matches")}</h1>
				<SeasonCreateFormButton seasonId={seasonId} />
			</div>
			<div className="flex flex-col">
				<div className="w-8/12">
					<MatchList seasonId={seasonId} />
				</div>
				{/* <div className="w-4/12">Charts</div> */}
			</div>
		</>
	);
};

export default MatchesPage;
