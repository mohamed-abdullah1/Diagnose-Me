import { createSlice } from "@reduxjs/toolkit";

const initialState = {
    userId: "59c3809e-570a-48ff-8842-99a596b3a4e1",
    token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjQyZGQyZjYyLTBlNzgtNGE1MC1hZGUzLTQ2ZGFmN2QyM2RiZCIsImlhdCI6MTY4MjE0OTk0NiwiZXhwIjoxNjg0NzQxOTQ2fQ.RkHpjslmkVdT21tx_ZjuctzteKzA7Xfu5rVSWc7zZq4",
    numOfChats: 0,
};

const chatSlice = createSlice({
    name: "chat",
    initialState,
    reducers: {
        setUser(state, action) {
            state.userId = action.payload.userId;
            state.token = action.payload.token;
        },
        setNumOfChats(state, action) {
            state.numOfChats = action.payload;
        },
    },
});
export const selectChat = (state) => state.chat;
export const { setUser, setNumOfChats } = chatSlice.actions;
export default chatSlice.reducer;
