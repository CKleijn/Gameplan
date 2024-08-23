import {
	Card,
	CardContent,
	CardFooter,
	CardHeader,
	CardTitle,
} from "@/core/components/ui/card";
import { Season } from "../Season";
import UpcomingContext from "./UpcomingContent";
import SeasonEditFormDialogButton from "./SeasonFormDialog";
import { useNavigate } from "react-router-dom";
import SeasonDeleteAlertDialog from "@/core/components/DeleteAlertDialog";
import { deleteSeason } from "../services/seasonService";
import { Badge } from "@/core/components/ui/badge";

type Props = {
	season: Season;
};

const SeasonCard: React.FC<Props> = ({ season }) => {
	const navigate = useNavigate();

	return (
		<Card
			className="cursor-pointer hover:outline"
			onClick={() => navigate(`/season/${season.id}/matches`)}
		>
			<CardHeader>
				<CardTitle className="flex gap-x-2">
					{season.club} <Badge className="mt-0.5">{season.calendarYear}</Badge>
				</CardTitle>
			</CardHeader>
			<CardContent>
				<UpcomingContext upcomingMatches={season.upcomingMatches} />
			</CardContent>
			<CardFooter className="block space-y-2">
				<SeasonEditFormDialogButton season={season} classNames="w-full" />
				<SeasonDeleteAlertDialog
					id={season.id}
					type="season"
					classNames="w-full"
					queryKey="seasons"
					mutation={deleteSeason}
				/>
			</CardFooter>
		</Card>
	);
};

export default SeasonCard;
