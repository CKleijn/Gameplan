import {
	NavigationMenu,
	NavigationMenuItem,
	NavigationMenuLink,
	NavigationMenuList,
} from "@/core/components/ui/navigation-menu";
import { Link, useNavigate } from "react-router-dom";
import { ModeToggle } from "../settings/ModeToggle";
import { useTranslation } from "react-i18next";
import UserDropdown from "@/modules/User/components/UserDropdown";
import { useSelector } from "react-redux";
import { RootState } from "../../services/redux/store";

type Props = {};

const NavigationBar: React.FC<Props> = () => {
	const user = useSelector((state: RootState) => state.userSlice.user);
	const navigate = useNavigate();
	const { t } = useTranslation();

	return (
		<NavigationMenu className="fixed min-w-full bg-blue-600">
			<div className="container mx-auto">
				<img
					onClick={() => navigate("/")}
					className="float-left h-14 mt-3 hover:cursor-pointer"
					src={"logo_light.png"}
					alt="Gameplan logo"
				/>
				<NavigationMenuList className="pt-4 space-x-4 float-right">
					{!!user && (
						<NavigationMenuItem>
							<Link to={"seasons"}>
								<NavigationMenuLink>
									<div className="block cursor-pointer select-none space-y-1 rounded-md p-3 leading-none no-underline outline-none transition-colors hover:bg-accent hover:text-accent-foreground focus:bg-accent focus:text-accent-foreground">
										<div className="text-sm font-medium leading-none">
											{t("seasons")}
										</div>
									</div>
								</NavigationMenuLink>
							</Link>
						</NavigationMenuItem>
					)}
					<NavigationMenuItem>
						<NavigationMenuLink>
							<ModeToggle />
						</NavigationMenuLink>
					</NavigationMenuItem>
					<NavigationMenuItem>
						<NavigationMenuLink>
							<UserDropdown />
						</NavigationMenuLink>
					</NavigationMenuItem>
				</NavigationMenuList>
			</div>
		</NavigationMenu>
	);
};

export default NavigationBar;
