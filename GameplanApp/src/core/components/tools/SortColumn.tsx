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
	items: string[];
	placeholder: string;
	setQuery: Dispatch<SetStateAction<PagedListQuery>>;
};

const SortColumn: React.FC<Props> = ({ items, placeholder, setQuery }) => {
	const { t } = useTranslation();

	return (
		<Select
			onValueChange={(value) =>
				setQuery((prev) => ({ ...prev, sortColumn: value }))
			}
		>
			<SelectTrigger className="w-full">
				<SelectValue placeholder={placeholder} />
			</SelectTrigger>
			<SelectContent>
				{items.map((item) => (
					<SelectItem key={item} value={item}>
						{t(item)}
					</SelectItem>
				))}
			</SelectContent>
		</Select>
	);
};

export default SortColumn;
