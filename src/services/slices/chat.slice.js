import { createSlice } from "@reduxjs/toolkit";

//doctor
const initialState = {
    userId: "42dd2f62-0e78-4a50-ade3-46daf7d23dbd",
    token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjQyZGQyZjYyLTBlNzgtNGE1MC1hZGUzLTQ2ZGFmN2QyM2RiZCIsImlhdCI6MTY4MjIxMjg2MiwiZXhwIjoxNjg0ODA0ODYyfQ.xZUInWhNeBe_Xunm4b7bJFJWOl1G3WAK7KMqxFuYJ28",
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
