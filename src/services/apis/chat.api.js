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
            query: (body) => ({
                url: "/chat",
                method: "POST",
                body,
            }),
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
            providesTags: ["Chat"],
        }),
        sendMessage: builder.mutation({
            query: (body) => {
                const { token, ...payload } = body;
                return {
                    url: "/chat/message",
                    method: "POST",
                    payload,
                    headers: {
                        Authorization: token,
                    },
                };
            },
            providesTags: ["Chat"],
        }),
    }),
});

export const {
    useCreateAccessChatMutation,
    useGetChatsQuery,
    useSendMessageMutation,
} = chatApi;
