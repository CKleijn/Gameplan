import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { User } from "../User";

type State = {
    user: User | null;
}

const initialState: State = {
    user: null
};

const userSlice = createSlice({
    name: "user",
    initialState,
    reducers: {
        setUser: (state, action: PayloadAction<User | null>) => {
            state.user = action.payload;
        },
        clearUser: (state) => {
            if (state.user) {
                state.user = null;
            }
        }
    },
});

export const { setUser, clearUser } = userSlice.actions;
export default userSlice.reducer;
