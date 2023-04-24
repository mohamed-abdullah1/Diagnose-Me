import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const chatApi = createApi({
    reducerPath: "chatApi",
    baseQuery: fetchBaseQuery({
        baseUrl: "http://192.168.1.155:6969/api",
        headers: {
            "Content-Type": "application/json",
        },
    }),
    tagTypes: ["Chat"],
    endpoints: (builder) => ({
        createAccessChat: builder.mutation({
            query: ({ token, ...body }) => {
                console.log("👉 BODY CHAT:- ", body);
                return {
                    url: "/chat",
                    method: "POST",
                    body,
                    headers: {
                        Authorization: `Bearer ${token}`,
                    },
                };
            },
            invalidatesTags: ["Chat"],
        }),
        getChats: builder.query({
            query: (token) => ({
                url: "/chat",
                method: "GET",
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            }),
            transformResponse: (response) =>
                response.map((chat) => {
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
                    Authorization: `Bearer ${token}`,
                },
            }),

            invalidatesTags: ["Chat"],
        }),
        getAllMessages: builder.query({
            query: ({ token, chatId }) => ({
                url: `/message/${chatId}`,
                method: "GET",
                headers: {
                    Authorization: `Bearer ${token}`,
                },
            }),
            transformResponse: (response) => {
                const msgs = response.map(({ _id, content, sender }) => ({
                    id: _id,
                    content,
                    senderId: sender._id,
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
