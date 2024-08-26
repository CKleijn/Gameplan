import { Button } from "@/core/components/ui/button";
import { Avatar, AvatarImage } from "@/core/components/ui/avatar";
import {
	DropdownMenu,
	DropdownMenuContent,
	DropdownMenuGroup,
	DropdownMenuItem,
	DropdownMenuLabel,
	DropdownMenuSeparator,
	DropdownMenuTrigger,
} from "@/core/components/ui/dropdown-menu";
import UserSettingsDialog from "@/modules/User/components/UserSettingsDialog";
import UserProfileDialog from "@/modules/User/components/UserProfileDialog";
import { useTranslation } from "react-i18next";
import { useSelector } from "react-redux";
import { RootState } from "@/core/services/redux/store";
import UserSignOut from "./UserSignOut";
import UserSignIn from "./UserSignIn";

type Props = {};

const UserDropdown: React.FC<Props> = () => {
	const { t } = useTranslation();
	const user = useSelector((state: RootState) => state.userSlice.user);

	return (
		<>
			{!!user ? (
				<DropdownMenu>
					<DropdownMenuTrigger asChild>
						<Button variant="ghost">
							<Avatar className="w-7 h-7">
								<AvatarImage src={user.photoURL!} sizes="sm" />
							</Avatar>
							<span className="ml-2 text-sm font-medium">
								{user.displayName}
							</span>
						</Button>
					</DropdownMenuTrigger>
					<DropdownMenuContent className="w-40">
						<DropdownMenuLabel>{t("myAccount")}</DropdownMenuLabel>
						<DropdownMenuSeparator />
						<DropdownMenuGroup>
							<DropdownMenuItem>
								<UserProfileDialog />
							</DropdownMenuItem>
							<DropdownMenuItem>
								<UserSettingsDialog />
							</DropdownMenuItem>
						</DropdownMenuGroup>
						<DropdownMenuSeparator />
						<UserSignOut />
					</DropdownMenuContent>
				</DropdownMenu>
			) : (
				<UserSignIn />
			)}
		</>
	);
};

export default UserDropdown;
