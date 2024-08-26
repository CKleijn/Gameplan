import { createBrowserRouter } from "react-router-dom";
import NotFoundPage from "./pages/NotFoundPage";
import MatchesPage from "./pages/MatchesPage";
import SeasonsPage from "./pages/SeasonsPage";
import AppWrapper from "./core/components/AppWrapper";
import HomePage from "./pages/HomePage";
import NotAuthorizedPage from "./pages/NotAuthorizedPage";
import ProtectedRoute from "./core/components/utils/ProtectedRoute";

const router = createBrowserRouter([
	{
		path: "/",
		element: <AppWrapper />,
		errorElement: <NotFoundPage />,
		children: [
			{ path: "/", element: <HomePage /> },
			{
				path: "/seasons",
				element: (
					<ProtectedRoute>
						<SeasonsPage />
					</ProtectedRoute>
				),
			},
			{
				path: "/season/:seasonId/matches",
				element: (
					<ProtectedRoute>
						<MatchesPage />
					</ProtectedRoute>
				),
			},
			{ path: "/not-authorized", element: <NotAuthorizedPage /> },
			{ path: "*", element: <NotFoundPage /> },
		],
	},
]);

export default router;
