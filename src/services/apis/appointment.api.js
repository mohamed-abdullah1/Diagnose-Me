import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { chat_url as appointment_url } from "../apiEndPoint";

export const appointmentApi = createApi({
  reducerPath: "appointmentApi",
  baseQuery: fetchBaseQuery({
    baseUrl: appointment_url,
    headers: {
      "Content-Type": "application/json",
    },
  }),
  tagTypes: ["Appointment"],
  endpoints: (builder) => ({
    getAppointments: builder.query({
      query: (token) => {
        console.log("👉 BODY CHAT:-🚓💖 ", token);
        return {
          url: `appointment/get-all-booked-appointments/`,
          method: "GET",
          headers: {
            Authorization: token,
          },
        };
      },
      transformResponse: (response) => {
        console.log("😏💖", response);
        return response?.map((ele) => {
          const { doctor_id: doctor, patient_id: patient, ...rest } = ele;

          return { doctor, patient, ...rest };
        });
      },
      providesTags: ["Appointment"],
    }),
    getAvailableAppointments: builder.query({
      query: (token) => {
        console.log("👉 Available Appointments 💖 ", token);
        return {
          url: `appointment/get-available-dates/`,
          method: "GET",
          headers: {
            Authorization: token,
          },
        };
      },
      providesTags: ["Appointment"],
      transformResponse: (response) =>
        response?.calendarFetched?.individual_dates,
    }),
    changeStatus: builder.mutation({
      query: ({ token, appointmentId, ...body }) => ({
        url: `/appointment/change-booked-status/${appointmentId}`,
        method: "PATCH",
        body,
        headers: {
          Authorization: token,
        },
      }),

      invalidatesTags: ["Appointment"],
    }),
    addAvailableAppointment: builder.mutation({
      query: ({ token, ...body }) => ({
        url: `/appointment/add-available-individual-date/`,
        method: "PATCH",
        body,
        headers: {
          Authorization: token,
        },
      }),

      invalidatesTags: ["Appointment"],
    }),
    clearAvailableAppointment: builder.mutation({
      query: ({ token, ...body }) => ({
        url: `/appointment/delete-available-date/`,
        method: "PATCH",
        body,
        headers: {
          Authorization: token,
        },
      }),

      invalidatesTags: ["Appointment"],
    }),
  }),
});

export const {
  useGetAppointmentsQuery,
  useChangeStatusMutation,
  useGetAvailableAppointmentsQuery,
  useAddAvailableAppointmentMutation,
  useClearAvailableAppointmentMutation,
} = appointmentApi;
