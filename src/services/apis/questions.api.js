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
  tagTypes: ["Question", "Blogs"],
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
    agreement: builder.mutation({
      query: ({ token, questionId, value }) => ({
        url: `/questions/question-id/${questionId}/agreement/${value}`,
        method: "POST",
        headers: {
          Authorization: token,
        },
      }),
      invalidatesTags: ["Question"],
    }),
    answer: builder.mutation({
      query: ({ token, questionId, ...body }) => ({
        url: `questions/question-id/${questionId}/answer`,
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
        url: `/questions/page-number/${pageNumber}?q=${searchQuery}&tag=${specialty}`,
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
    getAnswers: builder.query({
      query: ({ token, questionId, page }) => ({
        url: `/questions/question-id/${questionId}/answers/page-number/${page}`,
        method: "GET",
        headers: {
          Authorization: token,
        },
      }),
      providesTags: ["Question"],
    }),
    getTrendQuestions: builder.query({
      query: ({ token }) => ({
        url: `questions/important`,
        method: "GET",
        headers: {
          Authorization: token,
        },
      }),
      providesTags: ["Question"],
    }),
  }),
});

export const {
  useAskMutation,
  useGetQuestionsQuery,
  useGetSingleQuestionQuery,
  useGetAnswersQuery,
  useGetTrendQuestionsQuery,
  useAgreementMutation,
  useAnswerMutation,
} = questionApi;
