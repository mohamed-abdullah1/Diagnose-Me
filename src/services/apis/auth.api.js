import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const authApi = createApi({
    reducerPath: "api",
    baseQuery: fetchBaseQuery({
        baseUrl: "https://cb10-45-100-152-23.ngrok-free.app/auth/v1",
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
        register: builder.mutation({
            query: (body) => ({
                url: "/register",
                method: "POST",
                body,
            }),
            invalidatesTags: ["Auth"],
        }),
        verify: builder.mutation({
            query: (body) => ({
                url: "/pin/verify",
                method: "POST",
                body,
            }),
            invalidatesTags: ["Auth"],
        }),
        confirm: builder.mutation({
            query: (body) => ({
                url: "/email/confirm",
                method: "POST",
                body,
            }),
            invalidatesTags: ["Auth"],
        }),
        resendConfirm: builder.mutation({
            query: (body) => ({
                url: "/email/confirmation/resend",
                method: "POST",
                body,
            }),
            invalidatesTags: ["Auth"],
        }),
    }),
});

export const {
    useLoginMutation,
    useGetInfoQuery,
    useRegisterMutation,
    useVerifyMutation,
    useConfirmMutation,
    useResendConfirmMutation,
} = authApi;
