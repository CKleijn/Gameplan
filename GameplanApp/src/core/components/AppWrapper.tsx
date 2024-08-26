import { ThemeProvider } from "./settings/ThemeProvider";
import { Toaster } from "./ui/toaster";
import { Outlet } from "react-router-dom";
import Footer from "./layout/Footer";
import { useUserStateListener } from "../hooks/useUserStateListener";
import NavigationBar from "./layout/NavigationBar";

type Props = {};

const AppWrapper: React.FC<Props> = () => {
	useUserStateListener();

	return (
		<ThemeProvider defaultTheme="dark">
			<NavigationBar />
			<div className="container mx-auto pt-16">
				<Outlet />
			</div>
			<Footer />
			<Toaster />
		</ThemeProvider>
	);
};

export default AppWrapper;
