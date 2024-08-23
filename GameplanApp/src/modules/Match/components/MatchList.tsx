import useFetchMatchesBySeason from "../hooks/useFetchMatchesBySeason";
import Spinner from "@/core/components/Spinner";
import MatchCard from "./MatchCard";

type Props = {
	seasonId: string;
};

const MatchList: React.FC<Props> = ({ seasonId }) => {
	const { matches, isLoading } = useFetchMatchesBySeason({ seasonId });

	if (isLoading) return <Spinner />;

	return (
		<div className="space-y-5">
			{matches.map((match) => (
				<MatchCard key={match.id} match={match} />
			))}
		</div>
	);
};

export default MatchList;
