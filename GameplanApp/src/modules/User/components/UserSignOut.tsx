import { DropdownMenuItem } from "@/core/components/ui/dropdown-menu";
import { QueryClient, useMutation } from "@tanstack/react-query";
import { getAuth, signOut } from "firebase/auth";
import { LogOut } from "lucide-react";
import { useTranslation } from "react-i18next";

type Props = {};

const UserSignOut: React.FC<Props> = () => {
	const { t } = useTranslation();
	const queryClient = new QueryClient();

	const { mutateAsync: signOutGoogleMutation } = useMutation({
		mutationFn: async () => await signOut(getAuth()),
		onSuccess: () => {
			queryClient.resetQueries();
		},
	});

	return (
		<DropdownMenuItem onClick={() => signOutGoogleMutation()}>
			<LogOut className="mr-2 h-4 w-4" />
			{t("signOut")}
		</DropdownMenuItem>
	);
};

export default UserSignOut;
