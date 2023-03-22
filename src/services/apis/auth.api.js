import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const authApi = createApi({
    reducerPath: "api",
    baseQuery: fetchBaseQuery({
        baseUrl: "https://51a1-45-98-30-32.eu.ngrok.io/auth/v1",
        headers: {
            "Content-Type": "application/json",
        },
    }),
    tagTypes: ["Auth"],
    endpoints: (builder) => ({
        login: builder.mutation({
            query: (body) => ({
                url: "/login",
                method: "POST",
                body,
            }),
            invalidatesTags: ["Auth"],
        }),
        getInfo: builder.query({
            query: (token) => ({
                url: "/me",
                method: "GET",
                headers: {
                    Authorization: token,
                },
            }),
            providesTags: ["Auth"],
        }),
    }),
});

export const { useLoginMutation, useGetInfoQuery } = authApi;
