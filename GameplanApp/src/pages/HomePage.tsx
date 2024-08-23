import { Button } from "@/core/components/ui/button";
import { useTranslation } from "react-i18next";
import { Link } from "react-router-dom";

type Props = {};

const HomePage: React.FC<Props> = () => {
	const { t } = useTranslation();

	return (
		<div className="flex flex-col fixed-height">
			<div className="max-w-screen-sm text-center m-auto space-y-8">
				<h1 className="max-w-screen-sm text-5xl md:text-6xl font-bold uppercase block">
					{t("gameplanTitle")}{" "}
					<span className="text-blue-600">{t("season")}</span>!
				</h1>
				<p className="font-light">{t("gameplanDescription")}</p>
				<div className="space-x-3">
					<Button variant={"default"} className="w-36">
						<Link to={"seasons"}>{t("getStarted")}</Link>
					</Button>
					<Button variant={"secondary"} className="w-36">
						<a className="px-3.5 py-2" href="mailto:info@gameplan.com">
							{t("requestFeature")}
						</a>
					</Button>
				</div>
			</div>
		</div>
	);
};

export default HomePage;
