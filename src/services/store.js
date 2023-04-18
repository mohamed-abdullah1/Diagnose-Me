import { configureStore } from "@reduxjs/toolkit";
import { authApi } from "./apis/auth.api";
import authReducer from "./slices/auth.slice";
import registrationReducer from "./slices/registration.slice";

const store = configureStore({
    reducer: {
        auth: authReducer,
        registration: registrationReducer,
        [authApi.reducerPath]: authApi.reducer,
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(authApi.middleware),
});

export default store;
