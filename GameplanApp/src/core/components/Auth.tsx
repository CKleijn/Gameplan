import {
	getAuth,
	GoogleAuthProvider,
	signInWithPopup,
	signOut,
} from "firebase/auth";
import { Button } from "./ui/button";
import { Avatar, AvatarImage } from "./ui/avatar";
import {
	DropdownMenu,
	DropdownMenuContent,
	DropdownMenuGroup,
	DropdownMenuItem,
	DropdownMenuLabel,
	DropdownMenuSeparator,
	DropdownMenuTrigger,
} from "./ui/dropdown-menu";
import { LogOut } from "lucide-react";
import { useTranslation } from "react-i18next";
import { useSelector } from "react-redux";
import { RootState } from "../services/redux/store";
import UserSettingsDialog from "../../modules/User/components/UserSettingsDialog";
import UserProfileDialog from "@/modules/User/components/UserProfileDialog";

type Props = {};

const Auth: React.FC<Props> = () => {
	const auth = getAuth();
	const { t } = useTranslation();
	const { user } = useSelector((state: RootState) => state.userSlice);

	const signInGoogle = async () =>
		await signInWithPopup(auth, new GoogleAuthProvider());
	const signOutGoogle = async () => await signOut(auth);

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
						<DropdownMenuItem onClick={signOutGoogle}>
							<LogOut className="mr-2 h-4 w-4" />
							{t("signOut")}
						</DropdownMenuItem>
					</DropdownMenuContent>
				</DropdownMenu>
			) : (
				<Button variant="ghost" onClick={signInGoogle}>
					{t("signIn")}
				</Button>
			)}
		</>
	);
};

export default Auth;
