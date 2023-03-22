import { configureStore } from "@reduxjs/toolkit";
import { authApi } from "./apis/auth.api";
import authReducer from "./slices/auth.slice";

const store = configureStore({
    reducer: {
        auth: authReducer,
        [authApi.reducerPath]: authApi.reducer,
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(authApi.middleware),
});

export default store;
