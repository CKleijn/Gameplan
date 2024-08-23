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
import { UserIcon } from "lucide-react";
import { Avatar, AvatarImage } from "@/core/components/ui/avatar";
import { RootState } from "@/core/services/redux/store";
import { useSelector } from "react-redux";
import { Input } from "@/core/components/ui/input";
import { Label } from "@/core/components/ui/label";
import { dateFormatter } from "@/core/utils/helpers";

type Props = {};

const UserProfileDialog: React.FC<Props> = () => {
	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);
	const { t } = useTranslation();
	const { user } = useSelector((state: RootState) => state.userSlice);

	return (
		<>
			{!!user && (
				<Dialog
					open={isDialogOpen}
					onOpenChange={(open) => setIsDialogOpen(open)}
				>
					<DialogTrigger asChild>
						<div
							className="contents hover:cursor-pointer"
							onClick={(e) => e.stopPropagation()}
						>
							<UserIcon className="mr-2 h-4 w-4" />
							{t("profile")}
						</div>
					</DialogTrigger>
					<DialogContent
						className="max-w-sm"
						onClick={(e) => e.stopPropagation()}
					>
						<DialogHeader>
							<DialogTitle>{t("profile")}</DialogTitle>
							<DialogDescription>{t("profileDescription")}</DialogDescription>
						</DialogHeader>
						<div className="flex flex-col items-center">
							<Avatar className="w-20 h-20">
								<AvatarImage src={user.photoURL!} sizes="sm" />
							</Avatar>
							<span className="font-medium">{user.displayName}</span>
							<div className="w-full mt-3 space-y-3">
								<div className="space-y-1">
									<Label>{t("email")}</Label>
									<Input disabled value={user.email!} />
								</div>
								<div className="space-y-1">
									<Label>{t("phoneNumber")}</Label>
									<Input disabled value={user.phoneNumber! || "-"} />
								</div>
								<div className="space-y-1">
									<Label>{t("createdAt")}</Label>
									<Input
										disabled
										value={dateFormatter(user.createdAt!) || "-"}
									/>
								</div>
							</div>
						</div>
					</DialogContent>
				</Dialog>
			)}
		</>
	);
};

export default UserProfileDialog;
