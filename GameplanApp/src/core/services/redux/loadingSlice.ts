import { createSlice } from "@reduxjs/toolkit";

type State = {
    isLoading: boolean;
}

const initialState: State = {
    isLoading: true
};

const loadingSlice = createSlice({
    name: "loading",
    initialState,
    reducers: {
        enableLoading: (state) => {
            state.isLoading = true;
        },
        disableLoading: (state) => {
            state.isLoading = false;
        },
    },
});

export const { enableLoading, disableLoading } = loadingSlice.actions;
export default loadingSlice.reducer;
