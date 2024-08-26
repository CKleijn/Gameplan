import { Button } from "@/core/components/ui/button";
import { getAuth, GoogleAuthProvider, signInWithPopup } from "firebase/auth";
import { useTranslation } from "react-i18next";
import { getUserByUID, registerUser } from "../services/userService";
import { QueryClient, useMutation } from "@tanstack/react-query";
import { User } from "../User";

type Props = {};

const UserSignIn: React.FC<Props> = () => {
	const { t } = useTranslation();
	const queryClient = new QueryClient();

	const { mutateAsync: signInGoogleMutation } = useMutation({
		mutationFn: async () => {
			const userCredential = await signInWithPopup(
				getAuth(),
				new GoogleAuthProvider()
			);

			if (!userCredential) {
				throw new Error("Sign in failed");
			}

			return userCredential.user;
		},
		onSuccess: async (firebaseUser) => {
			const backendUser = await getUserByUID(firebaseUser.uid);

			if (backendUser?.status == 400) {
				await registerUserMutation({
					uid: firebaseUser.uid,
					photoURL: firebaseUser.photoURL,
					displayName: firebaseUser.displayName,
					email: firebaseUser.email,
					phoneNumber: firebaseUser.phoneNumber,
					provider: "firebase",
					createdAt: firebaseUser.metadata.creationTime,
				});
			}

			queryClient.invalidateQueries();
		},
	});

	const { mutateAsync: registerUserMutation } = useMutation({
		mutationFn: async (user: User) => await registerUser(user),
	});

	return (
		<Button variant="ghost" onClick={() => signInGoogleMutation()}>
			{t("signIn")}
		</Button>
	);
};

export default UserSignIn;
