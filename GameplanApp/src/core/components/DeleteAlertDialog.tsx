import {
	MutationFunction,
	useMutation,
	useQueryClient,
} from "@tanstack/react-query";
import {
	AlertDialog,
	AlertDialogTrigger,
	AlertDialogContent,
	AlertDialogTitle,
	AlertDialogDescription,
	AlertDialogCancel,
	AlertDialogAction,
	AlertDialogHeader,
	AlertDialogFooter,
} from "./ui/alert-dialog";
import { Button } from "./ui/button";
import { useToast } from "./ui/use-toast";
import { useTranslation } from "react-i18next";

type Props = {
	id: string;
	type: string;
	classNames?: string;
	triggerUI?: string;
	queryKey: string;
	mutation: MutationFunction<any, any>;
};

const DeleteAlertDialog: React.FC<Props> = ({
	id,
	type,
	classNames,
	triggerUI,
	queryKey,
	mutation,
}) => {
	const queryClient = useQueryClient();
	const { toast } = useToast();
	const { t } = useTranslation();

	const { mutateAsync: deleteMutation } = useMutation({
		mutationFn: mutation,
		onSuccess: () => {
			toast({
				title: `${t(type)} ${t("deleted")}!`,
				description: new Date().toLocaleString(),
			});
			queryClient.invalidateQueries({ queryKey: [queryKey] });
		},
	});

	return (
		<AlertDialog>
			<AlertDialogTrigger asChild>
				{!!triggerUI && triggerUI == "dropdown-item" ? (
					<div
						className={`contents hover:cursor-pointer ${classNames}`}
						onClick={(e) => e.stopPropagation()}
					>
						{t("delete")}
					</div>
				) : (
					<Button
						className={classNames}
						variant={"destructive"}
						onClick={(e) => e.stopPropagation()}
					>
						{t("delete")}
					</Button>
				)}
			</AlertDialogTrigger>
			<AlertDialogContent onClick={(e) => e.stopPropagation()}>
				<AlertDialogHeader>
					<AlertDialogTitle>{t("areYouSure")}</AlertDialogTitle>
					<AlertDialogDescription>
						{t("actionCannotUndone")}
					</AlertDialogDescription>
				</AlertDialogHeader>
				<AlertDialogFooter>
					<AlertDialogCancel>{t("cancel")}</AlertDialogCancel>
					<AlertDialogAction onClick={async () => await deleteMutation(id)}>
						{t("delete")}
					</AlertDialogAction>
				</AlertDialogFooter>
			</AlertDialogContent>
		</AlertDialog>
	);
};

export default DeleteAlertDialog;
