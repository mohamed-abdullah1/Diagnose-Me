import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { chat_url } from "../apiEndPoint";

export const chatApi = createApi({
  reducerPath: "chatApi",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://chat-appointment-service-api.onrender.com/api",
    headers: {
      "Content-Type": "application/json",
    },
  }),
  tagTypes: ["Chat"],
  endpoints: (builder) => ({
    createAccessChat: builder.mutation({
      query: ({ token, userId }) => {
        console.log("👉 BODY 🔡🔡🔡🔡🔡🔡🔡🔡:- ", userId, token);
        return {
          url: `/chat/${userId}`,
          method: "POST",
          headers: {
            Authorization: token,
          },
        };
      },
      transformResponse: (response) => {
        console.log("👉 RESPONSE CHAT CREATEORACCESS:- ", response);
        return response;
      },
      invalidatesTags: ["Chat"],
    }),
    getChats: builder.query({
      query: (token) => {
        console.log("👉 BODY CHAT:-🚓💖 ", token);

        return {
          url: "/chat",
          method: "GET",
          headers: {
            Authorization: token,
          },
        };
      },
      transformResponse: (response) =>
        response
          .filter((c) => c.latestMessage)
          .map((chat) => {
            const {
              _id: msgId,
              content: msgContent,
              createdAt,
              chat: chatId,
            } = chat.latestMessage;
            return {
              chatUsers: chat.users,
              msgId,
              msgContent,
              createdAt,
              chatId,
            };
          }),
      providesTags: ["Chat"],
    }),
    sendMessage: builder.mutation({
      query: ({ token, ...body }) => ({
        url: "/message",
        method: "POST",
        body,
        headers: {
          Authorization: token,
        },
      }),

      invalidatesTags: ["Chat"],
    }),
    getAllMessages: builder.query({
      query: ({ token, chatId }) => ({
        url: `/message/${chatId}`,
        method: "GET",
        headers: {
          Authorization: token,
        },
      }),
      transformResponse: (response) => {
        const msgs = response.map(({ _id, content, sender }) => ({
          id: _id,
          content,
          sender,
        }));
        return msgs;
      },
      providesTags: ["Chat"],
    }),
  }),
});

export const {
  useCreateAccessChatMutation,
  useGetChatsQuery,
  useSendMessageMutation,
  useGetAllMessagesQuery,
} = chatApi;
