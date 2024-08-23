import { z } from "zod";
import { SubmitHandler, useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import {
	Form,
	FormField,
	FormItem,
	FormLabel,
	FormControl,
	FormMessage,
} from "@/core/components/ui/form";
import { Input } from "@/core/components/ui/input";
import { Button } from "@/core/components/ui/button";
import { useEffect, useState } from "react";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useToast } from "@/core/components/ui/use-toast";
import { MatchStatus, MatchResultDTO } from "../MatchDTO";
import { updateMatchResult } from "../services/matchService";
import {
	Select,
	SelectContent,
	SelectItem,
	SelectTrigger,
	SelectValue,
} from "@/core/components/ui/select";
import { getEnumKeyByValue } from "@/core/utils/helpers";
import {
	Dialog,
	DialogContent,
	DialogDescription,
	DialogHeader,
	DialogTitle,
	DialogTrigger,
} from "@/core/components/ui/dialog";
import { useTranslation } from "react-i18next";
import { t } from "i18next";

type Props = {
	seasonId: string;
	match: MatchResultDTO;
};

const schema = z.object({
	id: z.string({ message: t("idRequired") }),
	homeScore: z.coerce
		.number()
		.nonnegative()
		.refine((val) => !isNaN(Number(val)), {
			message: t("homeScoreNumber"),
		})
		.transform((val) => Number(val)),
	awayScore: z.coerce
		.number()
		.nonnegative()
		.refine((val) => !isNaN(Number(val)), {
			message: t("awayScoreNumber"),
		})
		.transform((val) => Number(val)),
	matchStatus: z.string({ message: t("statusRequired") }),
});

type Fields = z.infer<typeof schema>;

const MatchResultFormDialog: React.FC<Props> = ({ seasonId, match }) => {
	const queryClient = useQueryClient();
	const { toast } = useToast();
	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);
	const { t } = useTranslation();

	useEffect(() => {
		if (isDialogOpen) {
			form.reset({
				id: match.id,
				homeScore: match.homeScore,
				awayScore: match.awayScore,
				matchStatus: getEnumKeyByValue(MatchStatus, match.matchStatus),
			});
		}
	}, [isDialogOpen, match]);

	const form = useForm<Fields>({
		resolver: zodResolver(schema),
		defaultValues: {
			id: match.id,
			homeScore: match.homeScore,
			awayScore: match.awayScore,
			matchStatus: getEnumKeyByValue(MatchStatus, match.matchStatus),
		},
		mode: "onChange",
	});

	const { mutateAsync: updateMatchResultMutation } = useMutation({
		mutationFn: updateMatchResult,
		onSuccess: () => {
			queryClient.invalidateQueries({
				queryKey: [`season/${seasonId}/matches`],
			});
		},
	});

	const onSubmit: SubmitHandler<Fields> = async (data) => {
		if (match.matchStatus !== "Finished") {
			await updateMatchResultMutation(data);
			toast({
				title: `${t("match")} #${data.id} ${t("updated")}!`,
				description: new Date().toLocaleString(),
			});
		} else {
			toast({
				title: `${t("match")} #${data.id} ${t("cantUpdateAlreadyFinished")}!`,
				description: new Date().toLocaleString(),
			});
		}

		setIsDialogOpen(false);
	};

	return (
		<Dialog open={isDialogOpen} onOpenChange={(open) => setIsDialogOpen(open)}>
			<DialogTrigger asChild>
				<div
					className="contents hover:cursor-pointer"
					onClick={(e) => e.stopPropagation()}
				>
					{t("update")}
				</div>
			</DialogTrigger>
			<DialogContent
				className="sm:max-w-lg"
				onClick={(e) => e.stopPropagation()}
			>
				<DialogHeader>
					<DialogTitle>{t("update")}</DialogTitle>
					<DialogDescription>{t("saveAfterFinished")}</DialogDescription>
				</DialogHeader>
				<Form {...form}>
					<form onSubmit={form.handleSubmit(onSubmit)} className="space-y-8">
						<FormField
							control={form.control}
							name="homeScore"
							render={({ field }) => (
								<FormItem>
									<FormLabel>{t("homeScore")}</FormLabel>
									<FormControl>
										<Input
											type="number"
											min={0}
											placeholder={t("homeScorePlaceholder")}
											{...field}
										/>
									</FormControl>
									<FormMessage />
								</FormItem>
							)}
						/>
						<FormField
							control={form.control}
							name="awayScore"
							render={({ field }) => (
								<FormItem>
									<FormLabel>{t("awayScore")}</FormLabel>
									<FormControl>
										<Input
											type="number"
											min={0}
											placeholder={t("awayScorePlaceholder")}
											{...field}
										/>
									</FormControl>
									<FormMessage />
								</FormItem>
							)}
						/>
						<FormField
							control={form.control}
							name="matchStatus"
							render={({ field }) => (
								<FormItem>
									<FormLabel>{t("status")}</FormLabel>
									<Select
										onValueChange={field.onChange}
										defaultValue={field.value}
									>
										<FormControl>
											<SelectTrigger>
												<SelectValue placeholder={t("statusPlaceholder")} />
											</SelectTrigger>
										</FormControl>
										<SelectContent>
											{Object.entries(MatchStatus).map(([key, value]) => (
												<SelectItem key={key} value={key}>
													{t(value)}
												</SelectItem>
											))}
										</SelectContent>
									</Select>
									<FormMessage />
								</FormItem>
							)}
						/>
						<div className="flex justify-between">
							<Button
								type="button"
								variant="outline"
								onClick={() => setIsDialogOpen(false)}
							>
								{t("cancel")}
							</Button>
							<Button type="submit" disabled={!form.formState.isValid}>
								{t("save")}
							</Button>
						</div>
					</form>
				</Form>
			</DialogContent>
		</Dialog>
	);
};

export default MatchResultFormDialog;
