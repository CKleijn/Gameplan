import { setUser, clearUser } from "@/modules/User/redux/userSlice";
import { getAuth, onAuthStateChanged, User as FirebaseUser } from "firebase/auth";
import { useDispatch } from "react-redux";
import { AppDispatch } from "../services/redux/store";
import { useEffect } from "react";
import { disableLoading, enableLoading } from "../services/redux/loadingSlice";

export const useUserStateListener = () => {
    const dispatch = useDispatch<AppDispatch>();

    useEffect(() => {
        const unsubscribe = onAuthStateChanged(getAuth(), async (user: FirebaseUser | null) => {
            dispatch(enableLoading());

            !!user ?
                dispatch(setUser({
                    uid: user.uid,
                    photoURL: user.photoURL,
                    displayName: user.displayName,
                    email: user.email,
                    phoneNumber: user.phoneNumber,
                    provider: "firebase",
                    createdAt: user.metadata.creationTime,
                })) :
                dispatch(clearUser());

            dispatch(disableLoading());
        });

        return () => {
            unsubscribe();
            dispatch(disableLoading());
        }
    }, []);
};