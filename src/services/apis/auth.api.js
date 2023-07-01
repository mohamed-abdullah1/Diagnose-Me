import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import apiEndPoint from "../apiEndPoint";
export const authApi = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({
    baseUrl: `${apiEndPoint}/auth/v1`,
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
    forgetPassword: builder.mutation({
      query: (body) => ({
        url: "/password/forget",
        method: "POST",
        body,
      }),
      invalidatesTags: ["Auth"],
    }),
    passwordReset: builder.mutation({
      query: (body) => ({
        url: "/password/reset",
        method: "POST",
        body,
      }),
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
  useForgetPasswordMutation,
  usePasswordResetMutation,
} = authApi;
