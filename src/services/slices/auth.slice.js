import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    user: null,
    token: null,
    error: null,
};

const authSlice = createSlice({
    name: "auth",
    initialState,
    reducers: {
        login(state, action) {
            state.token = action.payload.token;
            state.error = null;
        },
        setUserInfo(state, action) {
            state.user = action.payload;
        },
        setPersonalPic(state, action) {
            state.user.profilePictureUrl = action.payload;
        },
        logout(state) {
            state.user = null;
            state.token = null;
        },
    },
});

export const selectUser = (state) => state.auth.user;
export const selectToken = (state) => state.auth.token;

export const { login, setUserInfo, logout, setPersonalPic } = authSlice.actions;
export default authSlice.reducer;
