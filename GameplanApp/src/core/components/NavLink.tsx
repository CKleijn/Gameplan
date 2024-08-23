import { MouseEventHandler } from "react";
import { NavigationMenuLink } from "./ui/navigation-menu";
import { t } from "i18next";

type Props = {
	title: string;
	onClick?: MouseEventHandler<HTMLAnchorElement> | undefined;
};

const NavLink: React.FC<Props> = ({ title, onClick }) => {
	return (
		<NavigationMenuLink onClick={onClick}>
			<div className="block cursor-pointer select-none space-y-1 rounded-md p-3 leading-none no-underline outline-none transition-colors hover:bg-accent hover:text-accent-foreground focus:bg-accent focus:text-accent-foreground">
				<div className="text-sm font-medium leading-none">{t(title)}</div>
			</div>
		</NavigationMenuLink>
	);
};

export default NavLink;
