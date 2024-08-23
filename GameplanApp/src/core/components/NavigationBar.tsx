import {
	NavigationMenu,
	NavigationMenuItem,
	NavigationMenuLink,
	NavigationMenuList,
} from "@/core/components/ui/navigation-menu";
import { Link, useNavigate } from "react-router-dom";
import Auth from "./Auth";
import NavLink from "./NavLink";
import { ModeToggle } from "./ModeToggle";

type Props = {};

const NavigationBar: React.FC<Props> = () => {
	const navigate = useNavigate();

	return (
		<NavigationMenu className="fixed min-w-full">
			<div className="container mx-auto">
				<img
					onClick={() => navigate("/")}
					className="float-left h-14 mt-3 hover:cursor-pointer"
					src={
						localStorage.getItem("theme") == "dark"
							? "logo_light.png"
							: "logo_dark.png"
					}
					alt="Gameplan logo"
				/>
				<NavigationMenuList className="pt-4 space-x-4 float-right">
					<NavigationMenuItem>
						<Link to={"seasons"}>
							<NavLink title="seasons" />
						</Link>
					</NavigationMenuItem>
					<NavigationMenuItem>
						<NavigationMenuLink>
							<ModeToggle />
						</NavigationMenuLink>
					</NavigationMenuItem>
					<NavigationMenuItem>
						<NavigationMenuLink>
							<Auth />
						</NavigationMenuLink>
					</NavigationMenuItem>
				</NavigationMenuList>
			</div>
		</NavigationMenu>
	);
};

export default NavigationBar;
