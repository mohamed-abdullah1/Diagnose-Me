import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import endPoint from "../apiEndPoint";

export const blogsApi = createApi({
  reducerPath: "blogs",
  baseQuery: fetchBaseQuery({
    baseUrl: `${endPoint}/medical-blog/v1`,
    headers: {
      "Content-Type": "application/json",
    },
  }),
  tagTypes: ["Blogs"],
  endpoints: (builder) => ({
    // Blog endpoints
    getBlogs: builder.query({
      query: ({ token, page }) => ({
        url: `/posts/page-number/${page}`,
        method: "GET",
        headers: {
          Authorization: token,
        },
      }),
      providesTags: ["Blogs"],
    }),
    getBlog: builder.query({
      query: ({ token, blogId }) => ({
        url: `/posts/post-id/${blogId}`,
        method: "GET",
        headers: {
          Authorization: token,
        },
      }),
      providesTags: ["Blogs"],
    }),
  }),
});

export const { useGetBlogsQuery, useGetBlogQuery } = blogsApi;
