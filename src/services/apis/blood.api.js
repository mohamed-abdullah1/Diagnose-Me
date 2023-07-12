import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import apiEndPoint from "../apiEndPoint";
export const bloodApi = createApi({
  reducerPath: "bloodApi",
  baseQuery: fetchBaseQuery({
    baseUrl: `${apiEndPoint}/blood-donation/v1`,
    headers: {
      "Content-Type": "application/json",
    },
  }),
  tagTypes: ["Blood"],
  endpoints: (builder) => ({
    getRequests: builder.query({
      query: ({ token, bloodType, page }) => ({
        url: `requests/page-number/${page}?bloodType=${bloodType}`,
        method: "GET",
        headers: {
          Authorization: token,
        },
      }),
      providesTags: ["Blood"],
    }),
    makeDonationReq: builder.mutation({
      query: ({ token, ...body }) => {
        return {
          url: `request`,
          method: "POST",
          body,
          headers: {
            Authorization: token,
          },
        };
      },
      invalidatesTags: ["Blood"],
    }),
    // popularDoctors: builder.query({
    //   query: ({ token }) => ({
    //     url: `/doctors/popuplar`,
    //     method: "GET",
    //     headers: {
    //       Authorization: token,
    //     },
    //   }),
    //   transformResponse: (response) =>
    //     response.objects.map((obj) => ({ ...obj, ...obj.user })),
    //   providesTags: ["MedicalServices"],
    // }),
    // getDoctors: builder.query({
    //   query: ({ token, page, qSearch }) => ({
    //     url: `/doctors/page-number/${page}?name=${qSearch}`,
    //     method: "GET",
    //     headers: {
    //       Authorization: token,
    //     },
    //   }),
    //   providesTags: ["MedicalServices"],
    // }),
    // getSingleDoctor: builder.query({
    //   query: ({ token, doctorId }) => ({
    //     url: `doctors/${doctorId}`,
    //     method: "GET",
    //     headers: {
    //       Authorization: token,
    //     },
    //   }),
    //   transformResponse: (response) => ({ ...response, ...response.user }),
    //   providesTags: ["MedicalServices"],
    // }),
    // getSpecialties: builder.query({
    //   query: ({ token, page }) => ({
    //     url: `clinics/page-number/${page}`,
    //     method: "GET",
    //     headers: {
    //       Authorization: token,
    //     },
    //   }),
    //   transformResponse: (response) =>
    //     response.objects.map((obj) => ({
    //       key: obj.id,
    //       value: obj.specialization,
    //       src: `https://${apiEndPoint}/static/${obj.pictureUrl}`,
    //     })),
    //   providesTags: ["MedicalServices"],
    // }),

    // addSpecialtyBioForDoctor: builder.mutation({
    //   query: ({ token, doctorId, ...body }) => {
    //     return {
    //       url: `doctors/update`,
    //       method: "POST",
    //       body,
    //       headers: {
    //         Authorization: token,
    //       },
    //     };
    //   },
    //   invalidatesTags: ["MedicalServices"],
    // }),
    // addPrice: builder.mutation({
    //   query: ({ token, ...body }) => {
    //     return {
    //       url: `doctor/update-price-per-session`,
    //       method: "POST",
    //       body,
    //       headers: {
    //         Authorization: token,
    //       },
    //     };
    //   },
    //   invalidatesTags: ["MedicalServices"],
    // }),
    // updateDoctorBio,
  }),
});

export const { useGetRequestsQuery, useMakeDonationReqMutation } = bloodApi;
