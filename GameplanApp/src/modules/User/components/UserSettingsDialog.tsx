import { useState } from "react";
import {
	Dialog,
	DialogContent,
	DialogDescription,
	DialogHeader,
	DialogTitle,
	DialogTrigger,
} from "@/core/components/ui/dialog";
import { useTranslation } from "react-i18next";
import { Settings } from "lucide-react";
import UserLanguagePreference from "@/core/components/settings/UserLanguagePreference";

type Props = {};

const UserSettingsDialog: React.FC<Props> = () => {
	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);
	const { t } = useTranslation();

	return (
		<Dialog open={isDialogOpen} onOpenChange={(open) => setIsDialogOpen(open)}>
			<DialogTrigger asChild>
				<div
					className="contents hover:cursor-pointer"
					onClick={(e) => e.stopPropagation()}
				>
					<Settings className="mr-2 h-4 w-4" />
					{t("settings")}
				</div>
			</DialogTrigger>
			<DialogContent className="max-w-sm" onClick={(e) => e.stopPropagation()}>
				<DialogHeader>
					<DialogTitle>{t("settings")}</DialogTitle>
					<DialogDescription>{t("settingsDescription")}</DialogDescription>
				</DialogHeader>
				<UserLanguagePreference />
			</DialogContent>
		</Dialog>
	);
};

export default UserSettingsDialog;
