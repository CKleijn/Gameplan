import { useTranslation } from "react-i18next";

type Props = {};

const Footer: React.FC<Props> = () => {
	const { t } = useTranslation();

	return (
		<footer className="relative bottom-0 min-w-full p-4 mt-4">
			<div className="container mx-auto text-center">
				<p className="">
					&copy; <span className="font-semibold text-blue-600">2024</span>{" "}
					Gameplan - {t("allRightsReserved")}
				</p>
			</div>
		</footer>
	);
};

export default Footer;
