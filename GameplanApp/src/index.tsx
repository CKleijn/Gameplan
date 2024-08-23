import ReactDOM from "react-dom/client";
import "@/core/stylesheets/main.css";
import { RouterProvider } from "react-router-dom";
import { QueryClientProvider, QueryClient } from "@tanstack/react-query";
import "@/core/services/i18n/i18n";
import { Provider } from "react-redux";
import router from "./router";
import store from "@/core/services/redux/store";
import AuthListener from "./core/components/AuthListener";
import { initializeApp } from "firebase/app";
import firebaseConfig from "@/core/services/firebase/firebase-config";

initializeApp(firebaseConfig);
const queryClient = new QueryClient();

ReactDOM.createRoot(document.getElementById("root")!).render(
	<Provider store={store}>
		<AuthListener />
		<QueryClientProvider client={queryClient}>
			<RouterProvider router={router} />
		</QueryClientProvider>
	</Provider>
);
