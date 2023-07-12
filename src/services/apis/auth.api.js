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
    verifyDoctor: builder.mutation({
      query: ({ token }) => ({
        url: "/doctor/identity/verify",
        method: "POST",
        body: {
          base64License:
            "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",
        }, //TODO: CHANGE THE BODY WITH THE BASE64 COMMING FROM BACKEND
        headers: {
          Authorization: token,
        },
      }),
      invalidatesTags: ["Auth"],
    }),
    uploadProfilePic: builder.mutation({
      query: ({ token, ...body }) => ({
        url: "profile/picture/upload",
        method: "POST",
        body,
        headers: {
          Authorization: token,
        },
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
  useForgetPasswordMutation,
  usePasswordResetMutation,
  useVerifyDoctorMutation,
  useUploadProfilePicMutation,
} = authApi;
