import { ThemeProvider } from "./ThemeProvider";
import { Toaster } from "./ui/toaster";
import NavigationBar from "./NavigationBar";
import { Outlet } from "react-router-dom";
import Footer from "./Footer";

type Props = {};

const AppWrapper: React.FC<Props> = () => {
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
