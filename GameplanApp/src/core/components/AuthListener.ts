import { setUser, clearUser } from "@/modules/User/redux/userSlice";
import { getAuth, onAuthStateChanged, User as FirebaseUser } from "firebase/auth";
import { useDispatch } from "react-redux";
import { AppDispatch } from "../services/redux/store";
import { User } from "@/modules/User/User";
import { useEffect } from "react";

type Props = {};

const AuthListener: React.FC<Props> = () => {
    const dispatch = useDispatch<AppDispatch>();

    useEffect(() => {
        const unsubscribe = onAuthStateChanged(getAuth(), async (user: FirebaseUser | null) => {
            if (user) {
                // https://gist.github.com/shadowcodex/dcfe7d11b2e8cb0ca51d
                const simpleUser: User = {
                    uid: user.uid,
                    photoURL: user.photoURL,
                    displayName: user.displayName,
                    email: user.email,
                    phoneNumber: user.phoneNumber,
                    createdAt: user.metadata.creationTime,
                };
                dispatch(setUser(simpleUser));
            } else {
                dispatch(clearUser());
            }
        });

        return () => unsubscribe();
    }, []);

    return null;
};

export default AuthListener;
