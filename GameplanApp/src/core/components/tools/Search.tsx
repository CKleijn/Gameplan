import { Dispatch, SetStateAction } from "react";
import { Input } from "../ui/input";
import { PagedListQuery } from "../utils/Types";

type Props = {
	placeholder: string;
	setQuery: Dispatch<SetStateAction<PagedListQuery>>;
};

const Search: React.FC<Props> = ({ placeholder, setQuery }) => {
	return (
		<Input
			type="text"
			placeholder={placeholder}
			onChange={(e) =>
				setQuery((prev) => ({ ...prev, searchTerm: e.target.value }))
			}
		/>
	);
};

export default Search;
