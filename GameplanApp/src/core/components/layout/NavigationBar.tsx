import {
	NavigationMenu,
	NavigationMenuItem,
	NavigationMenuLink,
	NavigationMenuList,
} from "@/core/components/ui/navigation-menu";
import { Link, useLocation, useNavigate } from "react-router-dom";
import { ModeToggle } from "../settings/ModeToggle";
import { useTranslation } from "react-i18next";
import UserDropdown from "@/modules/User/components/UserDropdown";
import { useSelector } from "react-redux";
import { RootState } from "../../services/redux/store";

type Props = {};

const NavigationBar: React.FC<Props> = () => {
	const user = useSelector((state: RootState) => state.userSlice.user);
	const isLoading = useSelector(
		(state: RootState) => state.loadingSlice.isLoading
	);
	const navigate = useNavigate();
	const currentPage = useLocation().pathname;
	const { t } = useTranslation();

	return (
		<NavigationMenu className="fixed min-w-full bg-blue-600">
			<div className="container mx-auto">
				<img
					onClick={() => navigate("/")}
					className="float-left h-20 relative hover:cursor-pointer"
					src={"icons/logo.png"}
					alt="Gameplan logo"
				/>
				{!isLoading && (
					<NavigationMenuList className="pt-5 space-x-4 float-right">
						<NavigationMenuItem
							className={
								currentPage === "/"
									? "select-none rounded-md bg-accent-foreground text-accent"
									: undefined
							}
						>
							<Link to={"/"}>
								<NavigationMenuLink>
									<div className="block cursor-pointer select-none space-y-1 rounded-md p-3 leading-none no-underline outline-none transition-colors hover:bg-accent hover:text-accent-foreground focus:bg-accent focus:text-accent-foreground">
										<div className="text-sm font-medium leading-none">
											{t("home")}
										</div>
									</div>
								</NavigationMenuLink>
							</Link>
						</NavigationMenuItem>
						{!!user && (
							<NavigationMenuItem
								className={
									currentPage === "/seasons"
										? "select-none rounded-md bg-accent-foreground text-accent"
										: undefined
								}
							>
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
				)}
			</div>
		</NavigationMenu>
	);
};

export default NavigationBar;
