import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import endPoint from "../apiEndPoint";
export const questionApi = createApi({
  reducerPath: "question",
  baseQuery: fetchBaseQuery({
    baseUrl: `${endPoint}/medical-blog/v1`,
    headers: {
      "Content-Type": "application/json",
    },
  }),
  tagTypes: ["Question"],
  endpoints: (builder) => ({
    ask: builder.mutation({
      query: ({ body, token }) => ({
        url: "/questions/ask",
        method: "POST",
        body,
        headers: {
          Authorization: token,
        },
      }),
      invalidatesTags: ["Question"],
    }),
    getQuestions: builder.query({
      query: ({ token, pageNumber, searchQuery, specialty }) => ({
        url: `/questions/page-number/${pageNumber}`,
        // url: `/questions/page-number/${pageNumber}?q=${searchQuery}&tag=${specialty}`, //TODO: un comment this
        method: "GET",
        headers: {
          Authorization: token,
        },
      }),
      providesTags: ["Question"],
      pagination: true,
    }),
    getSingleQuestion: builder.query({
      query: ({ token, questionId }) => ({
        url: `/questions/question-id/${questionId}`,
        method: "GET",
        headers: {
          Authorization: token,
        },
      }),
      providesTags: ["Question"],
    }),
    //     register: builder.mutation({
    //       query: (body) => ({
    //         url: "/register",
    //         method: "POST",
    //         body,
    //       }),
    //       invalidatesTags: ["Auth"],
    //     }),
    //     verify: builder.mutation({
    //       query: (body) => ({
    //         url: "/pin/verify",
    //         method: "POST",
    //         body,
    //       }),
    //       invalidatesTags: ["Auth"],
    //     }),
    //     confirm: builder.mutation({
    //       query: (body) => ({
    //         url: "/email/confirm",
    //         method: "POST",
    //         body,
    //       }),
    //       invalidatesTags: ["Auth"],
    //     }),
    //     resendConfirm: builder.mutation({
    //       query: (body) => ({
    //         url: "/email/confirmation/resend",
    //         method: "POST",
    //         body,
    //       }),
    //       invalidatesTags: ["Auth"],
    //     }),
    //     forgetPassword: builder.mutation({
    //       query: (body) => ({
    //         url: "/password/forget",
    //         method: "POST",
    //         body,
    //       }),
    //       invalidatesTags: ["Auth"],
    //     }),
    //     passwordReset: builder.mutation({
    //       query: (body) => ({
    //         url: "/password/reset",
    //         method: "POST",
    //         body,
    //       }),
    //     }),
  }),
});

export const {
  useAskMutation,
  useGetQuestionsQuery,
  useGetSingleQuestionQuery,
} = questionApi;
