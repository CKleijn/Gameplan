import { createBrowserRouter } from "react-router-dom";
import NotFoundPage from "./pages/NotFoundPage";
import MatchesPage from "./pages/MatchesPage";
import SeasonsPage from "./pages/SeasonsPage";
import AppWrapper from "./core/components/AppWrapper";
import HomePage from "./pages/HomePage";

const router = createBrowserRouter([
	{
		path: "/",
		element: <AppWrapper />,
		errorElement: <NotFoundPage />,
		children: [
			{ path: "/", element: <HomePage /> },
			{ path: "/seasons", element: <SeasonsPage /> },
			{ path: "/season/:seasonId/matches", element: <MatchesPage /> },
			{ path: "*", element: <NotFoundPage /> },
		],
	},
]);

export default router;
