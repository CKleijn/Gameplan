import userSlice from "@/modules/User/redux/userSlice";
import { configureStore } from "@reduxjs/toolkit";
import loadingSlice from "./loadingSlice";

const store = configureStore({
    reducer: {
        userSlice,
        loadingSlice
    }
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
export default store;