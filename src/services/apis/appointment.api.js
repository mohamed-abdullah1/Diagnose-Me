import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import appointment_url from "../apiEndPoint";
import { format } from "date-fns";
import uuid from "react-native-uuid";

export const appointmentApi = createApi({
  reducerPath: "appointmentApi",
  baseQuery: fetchBaseQuery({
    baseUrl: `${appointment_url}/node-service/api/`,
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
          const { doctorId: doctor, patientId: patient, ...rest } = ele;

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
        method: "POST",
        body,
        headers: {
          Authorization: token,
        },
      }),

      invalidatesTags: ["Appointment"],
    }),
    addAvailableAppointment: builder.mutation({
      query: ({ token, ...body }) => ({
        url: `appointment/add-available-time`,
        method: "POST",
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
    getAvailableDatesForDoctor: builder.query({
      query: ({ token, doctorId }) => {
        console.log("👉 Available Appointments 💖 ", token);
        return {
          url: `appointment/get-available-times/${doctorId}`,
          method: "GET",
          headers: {
            Authorization: token,
          },
        };
      },
      providesTags: ["Appointment"],
      // transformResponse: (response) => {
      //   let temp = [];
      //   return response?.individual_dates
      //     ?.map((item) => ({
      //       id: item._id,
      //       day: format(new Date(item.date), "MMM"),
      //       dayNum: format(new Date(item.date), "dd"),
      //       startTime: item.times[0].start_time,
      //       date: item.date,
      //       startTimeId: item.times[0]._id,
      //     }))
      //     .sort((a, b) => new Date(a.date) - new Date(b.date))
      //     .reduce((acc, curr) => {
      //       const existingObj = acc.find(
      //         (obj) =>
      //           format(new Date(obj.date), "yyyy-MM-dd") ===
      //           format(new Date(curr.date), "yyyy-MM-dd")
      //       );
      //       if (existingObj) {
      //         existingObj.startTime.push({
      //           t: curr.startTime,
      //           id: curr.startTimeId,
      //         });
      //       } else {
      //         acc.push({
      //           id: uuid.v4(),
      //           date: curr.date,
      //           startTime: [{ id: curr.startTimeId, t: curr.startTime }],
      //         });
      //       }
      //       return acc;
      //     }, []);
      // },
    }),
    bookAppointment: builder.mutation({
      query: ({ token, ...body }) => ({
        url: `/appointment/book-appointment/`,
        method: "POST",
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
  useGetAvailableDatesForDoctorQuery,
  useBookAppointmentMutation,
} = appointmentApi;
