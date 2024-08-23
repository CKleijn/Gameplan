import { Button } from "@/core/components/ui/button";
import {
	Dialog,
	DialogTrigger,
	DialogContent,
	DialogTitle,
	DialogDescription,
	DialogHeader,
} from "@/core/components/ui/dialog";
import { useEffect, useState } from "react";
import { useTranslation } from "react-i18next";
import { CreateEditSeasonDTO } from "../SeasonDTO";
import { z } from "zod";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { useToast } from "@/core/components/ui/use-toast";
import { SubmitHandler, useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import { createSeason, editSeason } from "../services/seasonService";
import {
	Form,
	FormControl,
	FormField,
	FormItem,
	FormLabel,
	FormMessage,
} from "@/core/components/ui/form";
import { Input } from "@/core/components/ui/input";
import { t } from "i18next";

type Props = {
	season?: CreateEditSeasonDTO;
	classNames?: string;
};

const schema = z.object({
	id: z.string().optional(),
	club: z.string({ message: t("clubRequired") }),
	calendarYear: z.string({ message: t("calendarYearRequired") }),
});

type Fields = z.infer<typeof schema>;

const SeasonFormDialog: React.FC<Props> = ({ season, classNames }) => {
	const [isDialogOpen, setIsDialogOpen] = useState<boolean>(false);
	const queryClient = useQueryClient();
	const { toast } = useToast();
	const { t } = useTranslation();

	useEffect(() => {
		if (isDialogOpen) {
			form.reset(
				season && {
					id: season.id,
					club: season.club,
					calendarYear: season.calendarYear,
				}
			);
		}
	}, [isDialogOpen, season]);

	const form = useForm<Fields>({
		resolver: zodResolver(schema),
		defaultValues: !!season
			? {
					id: season.id,
					club: season.club,
					calendarYear: season.calendarYear,
			  }
			: {
					id: undefined,
					club: undefined,
					calendarYear: undefined,
			  },
		mode: "onChange",
	});

	const { mutateAsync: createSeasonMutation } = useMutation({
		mutationFn: createSeason,
		onSuccess: () => {
			queryClient.invalidateQueries({ queryKey: ["seasons"] });
		},
	});

	const { mutateAsync: editSeasonMutation } = useMutation({
		mutationFn: editSeason,
		onSuccess: () => {
			queryClient.invalidateQueries({ queryKey: ["seasons"] });
		},
	});

	const onSubmit: SubmitHandler<Fields> = async (data) => {
		!!season
			? await editSeasonMutation(data)
			: await createSeasonMutation(data);

		toast({
			title: `${t("season")} ${data.club} (${data.calendarYear}) ${
				!!season ? t("edited") : t("created")
			}!`,
			description: new Date().toLocaleString(),
		});

		setIsDialogOpen(false);
	};

	return (
		<Dialog open={isDialogOpen} onOpenChange={(open) => setIsDialogOpen(open)}>
			<DialogTrigger asChild>
				<Button
					variant={"outline"}
					className={classNames}
					onClick={(e) => e.stopPropagation()}
				>
					{!!season ? t("edit") : t("create")}
				</Button>
			</DialogTrigger>
			<DialogContent
				className="sm:max-w-lg"
				onClick={(e) => e.stopPropagation()}
			>
				<DialogHeader>
					<DialogTitle>{!!season ? t("edit") : t("create")}</DialogTitle>
					<DialogDescription>{t("saveAfterFinished")}</DialogDescription>
				</DialogHeader>
				<Form {...form}>
					<form onSubmit={form.handleSubmit(onSubmit)} className="space-y-8">
						<FormField
							control={form.control}
							name="club"
							render={({ field }) => (
								<FormItem>
									<FormLabel>{t("club")}</FormLabel>
									<FormControl>
										<Input placeholder={t("clubPlaceholder")} {...field} />
									</FormControl>
									<FormMessage />
								</FormItem>
							)}
						/>
						<FormField
							control={form.control}
							name="calendarYear"
							render={({ field }) => (
								<FormItem>
									<FormLabel>{t("calendarYear")}</FormLabel>
									<FormControl>
										<Input
											placeholder={t("calendarYearPlaceholder")}
											{...field}
										/>
									</FormControl>
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

export default SeasonFormDialog;
