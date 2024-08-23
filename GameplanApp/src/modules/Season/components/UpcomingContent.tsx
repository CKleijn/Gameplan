import { dateFormatter } from "@/core/utils/helpers";
import { Match } from "@/modules/Match/Match";
import { AlarmClock } from "lucide-react";
import { useTranslation } from "react-i18next";

type Props = {
	upcomingMatches: Match[];
};

const UpcomingContext: React.FC<Props> = ({ upcomingMatches }) => {
	const { t } = useTranslation();

	return (
		<>
			<div className="flex items-center space-x-4 rounded-md border p-4">
				<AlarmClock />
				<div className="flex-1 space-y-1">
					<p className="text-sm font-medium leading-none">
						{t("upcomingMatches")}
					</p>
					<p className="text-sm text-muted-foreground">
						{t("registerPresence")}
					</p>
				</div>
			</div>
			<div>
				{upcomingMatches?.map((match) => (
					<div
						key={match.id}
						className="my-4 ml-1 grid grid-cols-[25px_1fr] items-start pb-1 last:mb-0 last:pb-0"
					>
						<span className="flex h-2 w-2 translate-y-1 rounded-full bg-blue-600" />
						<div className="space-y-1">
							<p className="text-sm font-medium leading-none">
								{match.homeClub} - {match.awayClub}
							</p>
							<p className="text-sm text-muted-foreground">
								{dateFormatter(match.dateTime)}
							</p>
						</div>
					</div>
				))}
			</div>
		</>
	);
};

export default UpcomingContext;
