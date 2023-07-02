import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import apiEndPoint from "../apiEndPoint";
export const medicalServicesApi = createApi({
  reducerPath: "medicalServicesApi",
  baseQuery: fetchBaseQuery({
    baseUrl: `${apiEndPoint}/medical-services/v1`,
    headers: {
      "Content-Type": "application/json",
    },
  }),
  tagTypes: ["MedicalServices"],
  endpoints: (builder) => ({
    getPopularDoctors: builder.query({
      query: ({ token, specialty }) => ({
        url: `/doctors/popuplar/${specialty}`,
        method: "GET",
        headers: {
          Authorization: token,
        },
      }),
      providesTags: ["MedicalServices"],
    }),
    getDoctors: builder.query({
      query: ({ token, page, qSearch }) => ({
        url: `/doctors/page-number/${page}?q=${qSearch}`,
        method: "GET",
        headers: {
          Authorization: token,
        },
      }),
      providesTags: ["MedicalServices"],
    }),
    getSingleDoctor: builder.query({
      query: ({ token, doctorId }) => ({
        url: `doctors/${doctorId}`,
        method: "GET",
        headers: {
          Authorization: token,
        },
      }),
      providesTags: ["MedicalServices"],
    }),
    getSpecialties: builder.query({
      query: ({ token, page }) => ({
        url: `clinics/page-number/${page}`,
        method: "GET",
        headers: {
          Authorization: token,
        },
      }),
      providesTags: ["MedicalServices"],
    }),
    addClinicForDoctor: builder.mutation({
      query: ({ token, specialtyId, ...body }) => {
        return {
          url: `clinics/${specialtyId}/addresses/add`,
          method: "POST",
          body,
          headers: {
            Authorization: token,
          },
        };
      },
      invalidatesTags: ["MedicalServices"],
    }),
    addSpecialtyBioForDoctor: builder.mutation({
      query: ({ token, doctorId, ...body }) => {
        return {
          url: `doctors/Add/${doctorId}`,
          method: "POST",
          body,
          headers: {
            Authorization: token,
          },
        };
      },
      invalidatesTags: ["MedicalServices"],
    }),
    updateDoctorBio,
  }),
});

export const {
  useGetPopularDoctorsQuery,
  useGetDoctorsQuery,
  useGetSingleDoctorQuery,
  useGetSpecialtiesQuery,
  useAddClinicForDoctorMutation,
} = medicalServicesApi;
