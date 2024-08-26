import { Button } from "@/core/components/ui/button";
import {
	DropdownMenu,
	DropdownMenuContent,
	DropdownMenuGroup,
	DropdownMenuItem,
	DropdownMenuLabel,
	DropdownMenuSeparator,
	DropdownMenuTrigger,
} from "@/core/components/ui/dropdown-menu";
import { t } from "i18next";
import { EllipsisVertical } from "lucide-react";
import MatchEditFormDialogButton from "./MatchFormDialog";
import { Match } from "../Match";
import MatchResultFormDialogButton from "./MatchResultFormDialog";
import MatchDeleteAlertDialog from "@/core/components/dialogs/DeleteAlertDialog";
import { deleteMatch } from "../services/matchService";

type Props = {
	match: Match;
};

const MatchActionsDropdown: React.FC<Props> = ({ match }) => {
	return (
		<DropdownMenu>
			<DropdownMenuTrigger asChild>
				<Button variant="ghost">
					<EllipsisVertical />
				</Button>
			</DropdownMenuTrigger>
			<DropdownMenuContent className="w-40">
				<DropdownMenuLabel>{t("actions")}</DropdownMenuLabel>
				<DropdownMenuSeparator />
				<DropdownMenuGroup>
					{match.matchStatus !== "Finished" && (
						<>
							<DropdownMenuItem>
								<MatchEditFormDialogButton
									seasonId={match.seasonId}
									match={match}
									triggerUI="dropdown-item"
								/>
							</DropdownMenuItem>
							<DropdownMenuItem>
								<MatchResultFormDialogButton
									seasonId={match.seasonId}
									match={match}
								/>
							</DropdownMenuItem>
						</>
					)}
					<DropdownMenuItem>
						<MatchDeleteAlertDialog
							id={match.id}
							type="match"
							triggerUI="dropdown-item"
							queryKey={`season/${match.seasonId}/matches`}
							mutation={deleteMatch}
						/>
					</DropdownMenuItem>
				</DropdownMenuGroup>
			</DropdownMenuContent>
		</DropdownMenu>
	);
};

export default MatchActionsDropdown;
