import SeasonCreateFormButton from "@/modules/Season/components/SeasonFormDialog";
import SeasonList from "@/modules/Season/components/SeasonList";
import { useTranslation } from "react-i18next";

type Props = {};

const SeasonsPage: React.FC<Props> = () => {
	const { t } = useTranslation();

	return (
		<>
			<div className="flex flex-row items-center justify-between">
				<h1 className="font-bold text-4xl my-5">{t("seasons")}</h1>
				<SeasonCreateFormButton />
			</div>
			<SeasonList />
		</>
	);
};

export default SeasonsPage;
