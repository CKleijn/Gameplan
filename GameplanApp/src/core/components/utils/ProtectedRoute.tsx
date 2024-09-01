import { useSelector } from "react-redux";
import { Navigate } from "react-router-dom";
import { RootState } from "../../services/redux/store";
import Spinner from "./Spinner";

type Props = {
	children: React.ReactNode;
};

const ProtectedRoute: React.FC<Props> = ({ children }) => {
	const user = useSelector((state: RootState) => state.userSlice.user);
	const isLoading = useSelector(
		(state: RootState) => state.loadingSlice.isLoading
	);

	if (isLoading) return <Spinner />;

	if (user) {
		return <>{children}</>;
	}

	return <Navigate to="/not-authorized" replace={true} />;
};

export default ProtectedRoute;
