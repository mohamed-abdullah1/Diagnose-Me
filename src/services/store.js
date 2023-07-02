import { configureStore } from "@reduxjs/toolkit";
import { authApi } from "./apis/auth.api";
import authReducer from "./slices/auth.slice";
import registrationReducer from "./slices/registration.slice";
import chatReducer from "./slices/chat.slice";
import { questionApi } from "./apis/questions.api";
import { chatApi } from "./apis/chat.api";
import { combineReducers } from "@reduxjs/toolkit";
import { setupListeners } from "@reduxjs/toolkit/query";
import { persistStore } from "redux-persist";
import {
  persistReducer,
  FLUSH,
  REHYDRATE,
  PAUSE,
  PERSIST,
  PURGE,
  REGISTER,
} from "redux-persist";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { blogsApi } from "./apis/blogs.api";
import { appointmentApi } from "./apis/appointment.api";
import { medicalServicesApi } from "./apis/medicalService";

const persistConfig = {
  key: "root",
  storage: AsyncStorage,
  // Additional configuration options, if needed
};

const rootReducer = combineReducers({
  auth: authReducer,
  registration: registrationReducer,
  chat: chatReducer,
  [authApi.reducerPath]: authApi.reducer,
  [chatApi.reducerPath]: chatApi.reducer,
  [questionApi.reducerPath]: questionApi.reducer, // other reducers...
  [blogsApi.reducerPath]: blogsApi.reducer, // other reducers...
  [appointmentApi.reducerPath]: appointmentApi.reducer, // other reducers...
  [medicalServicesApi.reducerPath]: medicalServicesApi.reducer, // other reducers...
});
const persistedReducer = persistReducer(persistConfig, rootReducer);

const store = configureStore({
  reducer: persistedReducer,
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({
      serializableCheck: {
        ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER],
        warnAfter: 128,
      },
      immutableCheck: { warnAfter: 128 },
    }).concat(
      authApi.middleware,
      chatApi.middleware,
      questionApi.middleware,
      blogsApi.middleware,
      appointmentApi.middleware,
      medicalServicesApi.middleware
    ),
});
setupListeners(store.dispatch);

export const persister = persistStore(store);
export default store;
