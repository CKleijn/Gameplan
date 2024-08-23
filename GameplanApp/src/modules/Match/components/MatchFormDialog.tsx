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
import { CompetitionType, CreateEditMatchDTO } from "../MatchDTO";
import { createMatch, editMatch } from "../services/matchService";
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
	match?: CreateEditMatchDTO;
	triggerUI?: string;
};

const schema = z.object({
	id: z.string().optional(),
	homeClub: z.string({ message: t("homeClubRequired") }),
	awayClub: z.string({ message: t("awayClubRequired") }),
	dateTime: z.string({ message: t("dateTimeRequired") }),
	competitionType: z.string({ message: t("competitionRequired") }),
	seasonId: z.string().optional(),
});

type Fields = z.infer<typeof schema>;

const MatchFormDialog: React.FC<Props> = ({ seasonId, match, triggerUI }) => {
	const queryClient = useQueryClient();
	const { toast } = useToast();
	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);
	const { t } = useTranslation();

	useEffect(() => {
		if (isDialogOpen) {
			form.reset(
				match && {
					id: match.id,
					homeClub: match.homeClub,
					awayClub: match.awayClub,
					dateTime: match.dateTime,
					competitionType: getEnumKeyByValue(
						CompetitionType,
						match.competitionType
					),
				}
			);
		}
	}, [isDialogOpen, match]);

	const form = useForm<Fields>({
		resolver: zodResolver(schema),
		defaultValues: match
			? {
					id: match.id,
					homeClub: match.homeClub,
					awayClub: match.awayClub,
					dateTime: new Date(match.dateTime).toISOString(),
					competitionType: getEnumKeyByValue(
						CompetitionType,
						match.competitionType
					),
			  }
			: {
					id: undefined,
					homeClub: undefined,
					awayClub: undefined,
					competitionType: undefined,
					seasonId: seasonId,
			  },
		mode: "onChange",
	});

	const { mutateAsync: createMatchMutation } = useMutation({
		mutationFn: createMatch,
		onSuccess: () => {
			queryClient.invalidateQueries({
				queryKey: [`season/${seasonId}/matches`],
			});
		},
	});

	const { mutateAsync: editMatchMutation } = useMutation({
		mutationFn: editMatch,
		onSuccess: () => {
			queryClient.invalidateQueries({
				queryKey: [`season/${seasonId}/matches`],
			});
		},
	});

	const onSubmit: SubmitHandler<Fields> = async (data) => {
		if (!!match) {
			if (match.matchStatus !== "Finished") {
				await editMatchMutation(data);
				toast({
					title: `${t("match")} ${data.homeClub} - ${data.awayClub} ${t(
						"edited"
					)}!`,
					description: new Date().toLocaleString(),
				});
			} else {
				toast({
					title: `${t("match")} #${data.id} ${t("cantUpdateAlreadyFinished")}!`,
					description: new Date().toLocaleString(),
				});
			}
		} else {
			await createMatchMutation(data);
			toast({
				title: `${t("match")} ${data.homeClub} - ${data.awayClub} ${t(
					"created"
				)}!`,
				description: new Date().toLocaleString(),
			});
		}

		setIsDialogOpen(false);
	};

	return (
		<Dialog open={isDialogOpen} onOpenChange={(open) => setIsDialogOpen(open)}>
			<DialogTrigger asChild>
				{!!triggerUI && triggerUI == "dropdown-item" ? (
					<div
						className="contents hover:cursor-pointer"
						onClick={(e) => e.stopPropagation()}
					>
						{!!match ? t("edit") : t("create")}
					</div>
				) : (
					<Button variant={"outline"} onClick={(e) => e.stopPropagation()}>
						{!!match ? t("edit") : t("create")}
					</Button>
				)}
			</DialogTrigger>
			<DialogContent
				className="sm:max-w-lg"
				onClick={(e) => e.stopPropagation()}
			>
				<DialogHeader>
					<DialogTitle>{!!match ? t("edit") : t("create")}</DialogTitle>
					<DialogDescription>{t("saveAfterFinished")}</DialogDescription>
				</DialogHeader>
				<Form {...form}>
					<form onSubmit={form.handleSubmit(onSubmit)} className="space-y-8">
						<FormField
							control={form.control}
							name="homeClub"
							render={({ field }) => (
								<FormItem>
									<FormLabel>{t("homeClub")}</FormLabel>
									<FormControl>
										<Input placeholder={t("homeClubPlaceholder")} {...field} />
									</FormControl>
									<FormMessage />
								</FormItem>
							)}
						/>
						<FormField
							control={form.control}
							name="awayClub"
							render={({ field }) => (
								<FormItem>
									<FormLabel>{t("awayClub")}</FormLabel>
									<FormControl>
										<Input placeholder={t("awayClubPlaceholder")} {...field} />
									</FormControl>
									<FormMessage />
								</FormItem>
							)}
						/>
						<FormField
							control={form.control}
							name="dateTime"
							render={({ field }) => (
								<FormItem>
									<FormLabel>{t("dateTime")}</FormLabel>
									<FormControl>
										<Input
											type="datetime-local"
											placeholder={t("dateTimePlaceholder")}
											{...field}
										/>
									</FormControl>
									<FormMessage />
								</FormItem>
							)}
						/>
						<FormField
							control={form.control}
							name="competitionType"
							render={({ field }) => (
								<FormItem>
									<FormLabel>{t("competition")}</FormLabel>
									<Select
										onValueChange={field.onChange}
										defaultValue={field.value}
									>
										<FormControl>
											<SelectTrigger>
												<SelectValue
													placeholder={t("competitionPlaceholder")}
												/>
											</SelectTrigger>
										</FormControl>
										<SelectContent>
											{Object.entries(CompetitionType).map(([key, value]) => (
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

export default MatchFormDialog;
