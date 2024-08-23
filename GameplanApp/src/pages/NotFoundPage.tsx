import { Button } from "@/core/components/ui/button";
import { useTranslation } from "react-i18next";
import { useNavigate } from "react-router-dom";

const NotFoundPage: React.FC = () => {
	const navigate = useNavigate();
	const { t } = useTranslation();

	return (
		<div className="flex fixed-height">
			<div className="m-auto text-center">
				<span className="text-5xl font-bold uppercase block m-3">
					{t("notFound")}
				</span>
				<div className="space-x-2">
					<Button variant={"ghost"} onClick={() => navigate("/")}>
						{t("home")}
					</Button>
					<Button variant={"ghost"} onClick={() => navigate(-1)}>
						{t("back")}
					</Button>
				</div>
			</div>
		</div>
	);
};

export default NotFoundPage;
