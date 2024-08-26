import useFetchSeasons from "../hooks/useFetchSeasons";
import Spinner from "@/core/components/utils/Spinner";
import SeasonCard from "./SeasonCard";

type Props = {};

const SeasonList: React.FC<Props> = () => {
	const { seasons, isLoading } = useFetchSeasons();

	if (isLoading) return <Spinner />;

	return (
		<div className="grid grid-flow-row grid-cols-1 gap-5 mt-5 md:grid-cols-3">
			{seasons.map((season) => (
				<SeasonCard key={season.id} season={season} />
			))}
		</div>
	);
};

export default SeasonList;
