import { Dispatch, SetStateAction } from "react";
import { PagedListQuery } from "../utils/Types";
import {
	Select,
	SelectContent,
	SelectItem,
	SelectTrigger,
	SelectValue,
} from "../ui/select";
import { useTranslation } from "react-i18next";

type Props = {
	setQuery: Dispatch<SetStateAction<PagedListQuery>>;
};

const SortingOrder: React.FC<Props> = ({ setQuery }) => {
	const { t } = useTranslation();

	return (
		<Select
			onValueChange={(value) =>
				setQuery((prev) => ({ ...prev, sortOrder: value }))
			}
		>
			<SelectTrigger className="w-full">
				<SelectValue placeholder="Sorting order" />
			</SelectTrigger>
			<SelectContent defaultValue="asc">
				<SelectItem value="asc">{t("asc")}</SelectItem>
				<SelectItem value="desc">{t("desc")}</SelectItem>
			</SelectContent>
		</Select>
	);
};

export default SortingOrder;
