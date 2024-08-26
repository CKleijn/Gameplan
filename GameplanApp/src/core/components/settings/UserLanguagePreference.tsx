import {
	Select,
	SelectTrigger,
	SelectValue,
	SelectContent,
	SelectItem,
} from "@/core/components/ui/select";
import i18n from "../../services/i18n/i18n";
import { useTranslation } from "react-i18next";
import { Label } from "../ui/label";

type Props = {};

const UserLanguagePreference: React.FC<Props> = () => {
	const { t } = useTranslation();

	const changeLanguage = (lng: string) => {
		i18n.changeLanguage(lng);
		localStorage.setItem("lng", lng);
	};

	return (
		<>
			<Label>{t("language")}</Label>
			<Select onValueChange={changeLanguage} defaultValue={i18n.language}>
				<SelectTrigger className="w-full">
					<SelectValue placeholder="Language" />
				</SelectTrigger>
				<SelectContent>
					<SelectItem value="en">{t("english")}</SelectItem>
					<SelectItem value="nl">{t("dutch")}</SelectItem>
				</SelectContent>
			</Select>
		</>
	);
};

export default UserLanguagePreference;
