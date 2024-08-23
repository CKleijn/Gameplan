import { Card, CardContent, CardHeader } from "@/core/components/ui/card";
import { Match } from "../Match";
import { Badge } from "@/core/components/ui/badge";
import MatchActionsDropdown from "./MatchActionsDropdown";
import { useTranslation } from "react-i18next";
import { dateFormatter } from "@/core/utils/helpers";

type Props = {
	match: Match;
};

const MatchCard: React.FC<Props> = ({ match }) => {
	const { t } = useTranslation();

	return (
		<Card>
			<CardHeader className="float-right p-2">
				<MatchActionsDropdown match={match} />
			</CardHeader>
			<CardContent className="p-4">
				<div className="flex flex-row text-center">
					<div className="w-4/12 m-auto">
						<div className="font-bold text-4xl">
							{match.homeClub.trim().slice(0, 3).toUpperCase()}
						</div>
						{match.homeClub}
					</div>
					<div className="w-4/12 m-auto">
						<Badge>
							{t(match.matchStatus)} - {t(match.competitionType)}
						</Badge>
						<div className="flex">
							<div className="w-5/12 m-auto">
								<div className="font-bold text-6xl">{match.homeScore}</div>
							</div>
							<div className="w-2/12 m-auto">
								<div className="font-bold text-4xl">-</div>
							</div>
							<div className="w-5/12 m-auto">
								<div className="font-bold text-6xl">{match.awayScore}</div>
							</div>
						</div>
						<small>{dateFormatter(match.dateTime)}</small>
					</div>
					<div className="w-4/12 m-auto">
						<div className="font-bold text-4xl">
							{match.awayClub.trim().slice(0, 3).toUpperCase()}
						</div>
						{match.awayClub}
					</div>
				</div>
			</CardContent>
		</Card>
	);
};

export default MatchCard;
