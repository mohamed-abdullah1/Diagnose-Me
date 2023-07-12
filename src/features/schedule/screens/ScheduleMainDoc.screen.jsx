import { useEffect, useState } from "react";
import { Text, View } from "react-native";
import { Calendar } from "react-native-calendars";
import { ActivityIndicator, Appbar, Button } from "react-native-paper";
import colors from "../../../infrastructure/theme/colors";
import {
  BgContainer,
  CardsSection,
  MeetingCard,
  PatientImg,
  Time,
  UpperSectionMeeting,
  Name,
} from "../../home/styles/Global.styles";
import * as dateFns from "date-fns";
import {
  AvailableMeetings,
  AvailableMeetingsSection,
  BookedMeetingsSection,
  ButtonsContainer,
  ClockIcon,
  Container,
  ContainerModal,
  DateContainer,
  DateIcon,
  DateInfoContainer,
  DateTitle,
  DateTxt,
  MeetItem,
  MeetItemContainer,
  NoMeetingContainer,
  NoMeetingImg,
  NoMeetingTitle,
  Section,
  Title,
} from "../styles/ScheduleMainDoc.styles";
import { Toast } from "toastify-react-native";

import Modal from "react-native-modal";
import { DateTimePickerAndroid } from "@react-native-community/datetimepicker";
import { meetingsForDoctor } from "../../../helpers/consts";
import uuid from "react-native-uuid";
import {
  useAddAvailableAppointmentMutation,
  useChangeStatusMutation,
  useClearAvailableAppointmentMutation,
  useGetAppointmentsQuery,
  useGetAvailableAppointmentsQuery,
  useGetAvailableDatesForDoctorQuery,
} from "../../../services/apis/appointment.api";
import { useSelector } from "react-redux";
import { selectToken, selectUser } from "../../../services/slices/auth.slice";
import {
  DateContent,
  DateItem,
  Img,
  Info,
  LowerContainer,
  MeetCard,
  MiddleContainer,
  StatusContent,
  StatusIcon,
  StatusItem,
  TimeContent,
  TimeIcon,
  TimeItem,
  UpperContainer,
} from "../styles/ScheduleMain.styles";
import { imgUrl } from "../../../services/apiEndPoint";
import { Alert } from "react-native";

const ScheduleMainDoc = ({}) => {
  const token = useSelector(selectToken);
  const user = useSelector(selectUser);
  const {
    data: bookedAppointments,
    isLoading: bookedAppointmentsIsLoading,
    isSuccess: bookedAppointmentsIsSuccess,
  } = useGetAppointmentsQuery(token);
  const {
    data: availableAppointments,
    isLoading: availableAppointmentsIsLoading,
    isFetching: availableAppointmentsIsFetching,
    isSuccess: availableAppointmentsIsSuccess,
    refetch,
  } = useGetAvailableDatesForDoctorQuery({ token, doctorId: user.id });
  const [
    addAvailableAppointment,
    {
      data: addResponse,
      isSuccess: addIsSuccess,
      error: addError,
      isLoading: addIsLoading,
    },
  ] = useAddAvailableAppointmentMutation();
  const [clear, {}] = useClearAvailableAppointmentMutation();
  const [marked, setMarked] = useState({
    dateString: "2023-06-08",
    day: 8,
    month: 3,
    timestamp: 1678233600000,
    year: 2023,
  });
  const [currentSelect, setCurrentSelect] = useState({
    [dateFns.format(Date.now(), "yyyy-MM-dd")]: {
      selected: true,
      selectedColor: colors.secondary,
    },
  });
  const [currentBooking, setCurrentBooking] = useState([]);
  const [currentAvailable, setCurrentAvailable] = useState([]);
  const [
    cancelAppointment,
    {
      data: cancelData,
      isSuccess: cancelIsSuccess,
      isLoading: cancelIsLoading,
    },
  ] = useChangeStatusMutation();

  const [available, setAvailable] = useState([]); //available
  const [visible, setVisible] = useState(false);
  const [dayCalendar, setDayCalendar] = useState();
  // console.log("👉", new Date().toLocaleDateString());
  // console.log("👉", dateFns.format(new Date(), "yyy-MM-dd"));
  // console.log("👉", dateFns.getHours(new Date()));
  // // console.log(
  //     "👉===",
  //     date?.toTimeString().replace(/.*(\d{2}:\d{2}:\d{2}).*/, "$1") // get the hour
  // );
  const [date, setDate] = useState(new Date());
  const generateNewAvailableMeet = (dateTimeString1, dateTimeString2) => {
    const dateObject1 = new Date(dateTimeString1);
    const dateObject2 = new Date(dateTimeString2);

    const hour = dateObject1.getUTCHours();
    const minute = dateObject1.getUTCMinutes();
    const year = dateObject2.getUTCFullYear();
    const month = dateObject2.getUTCMonth();
    const day = dateObject2.getUTCDate();

    const combinedDateTime = dateFns.set(
      dateFns.set(dateObject2, { year, month, date: day }),
      { hours: hour, minutes: minute }
    );

    return dateFns.formatISO(combinedDateTime, { representation: "complete" });
  };
  useEffect(() => {
    if (addError) {
      Alert.alert("Problem", addError?.data?.message);
    }
  }, [addError]);
  const onChange = (event, selectedDate) => {
    const currentDate = generateNewAvailableMeet(
      selectedDate,
      Object.keys(currentSelect)[0]
    );
    // setDate(currentDate);
    console.log("👉🤢", currentDate);
    console.log("👉🤢", selectedDate);
    //   {
    //     "date":"2023-06-30T04:00:00.000Z",
    //     "times":[{"start_time":"2023-06-04T18:00:00.000Z", "end_time":"2023-06-04T19:00:00.000Z"}]
    // // }
    // console.log("👉🤢🏡", dateFns.format(currentDate, "hh:mm a"));
    console.log("👉🤢🏡", {
      date: dateFns.format(
        dateFns.startOfDay(dateFns.parseISO(currentDate)),
        "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'"
      ),
      time: dateFns.format(dateFns.parseISO(currentDate), "HH:mm:ss"),
    });
    addAvailableAppointment({
      token,
      date: dateFns.format(
        dateFns.startOfDay(dateFns.parseISO(currentDate)),
        "yyyy-MM-dd'T'HH:mm:ss.SSS'Z'"
      ),
      time: dateFns.format(dateFns.parseISO(currentDate), "HH:mm:ss"),
    });
    // console.log("👉marked", marked);
    // const meeting = bookedMeetings?.find((b) => b.date === dayCalendar);
    // console.log("👉👉👉", meeting.available, dayCalendar);
    // if (!meeting) {
    //   setBookedMeetings((prev) => [
    //     ...prev,
    //     {
    //       id: uuid.v4(),
    //       date: dayCalendar,
    //       appointements: [],
    //       available: [],
    //     },
    //   ]);
    // } else {
    //   setBookedMeetings((prev) =>
    //     prev.map((ele) => {
    //       if (ele.date !== dayCalendar) {
    //         return ele;
    //       }
    //       return {
    //         ...ele,
    //         available: [
    //           ...ele.available,
    //           {
    //             id: uuid.v4(),
    //             time: dateFns.format(currentDate, "h:mm bbb"),
    //           },
    //         ],
    //       };
    //     })
    //   );
    // }
  };
  useEffect(() => {
    if (addIsSuccess) {
      console.log("✅✅✅✅", addResponse);
      refetch();
    }
  }, [addIsSuccess]);
  const showMode = (currentMode) => {
    DateTimePickerAndroid.open({
      value: date,
      onChange,
      mode: currentMode,
      is24Hour: true,
      is24Hour: false,
      themeVariant: "dark",
    });
  };
  const showDatepicker = () => {
    showMode("date");
  };
  const showTimepicker = () => {
    showMode("time");
  };
  const dayPressHandler = (day) => {
    console.log("⭐selected day", day);
    console.log("⭐selected day", day.dateString);
    setCurrentSelect({
      [day.dateString]: {
        selected: true,
        selectedColor: colors.secondary,
      },
    });
  };

  useEffect(() => {
    if (bookedAppointmentsIsSuccess) {
      setMarked((prev) => {
        let temp = {};
        bookedAppointments
          ?.filter((b) => b.patient)
          ?.forEach((meet) => {
            temp[dateFns.format(new Date(meet.day), "yyyy-MM-dd")] = {
              marked: true,
              selectedDotColor: "orange",
            };
          });
        return { ...prev, ...temp };
      });
      console.log("👉🔡", currentSelect);
      console.log(
        "👉🏡",

        { ...marked, ...currentSelect }
      );
      setCurrentBooking(
        bookedAppointments.filter(
          (m) =>
            dateFns.format(new Date(m.day), "yyyy-MM-dd") ===
            Object.keys(currentSelect)[0]
        )
      );
    }
  }, [bookedAppointmentsIsSuccess]);
  useEffect(() => {
    if (availableAppointmentsIsSuccess) {
      console.log("👉👉👉", availableAppointments);
      setMarked((prev) => {
        let temp = {};
        availableAppointments?.forEach((meet) => {
          temp[dateFns.format(new Date(meet.day), "yyyy-MM-dd")] = {
            marked: true,
            selectedDotColor: "orange",
          };
        });
        return { ...prev, ...temp };
      });
      setCurrentAvailable(
        availableAppointments?.filter(
          (m) =>
            dateFns.format(new Date(m.day), "yyyy-MM-dd") ===
            Object.keys(currentSelect)[0]
        )
      );
    }
  }, [availableAppointmentsIsSuccess]);
  useEffect(() => {
    if (bookedAppointments) {
      setCurrentBooking(
        bookedAppointments?.filter(
          (m) =>
            dateFns.format(new Date(m.day), "yyyy-MM-dd") ===
            Object.keys(currentSelect)[0]
        )
      );
    }
    if (availableAppointments) {
      setCurrentAvailable(
        availableAppointments?.filter(
          (m) =>
            dateFns.format(new Date(m.day), "yyyy-MM-dd") ===
            Object.keys(currentSelect)[0]
        )
      );
    }
    console.log("👉 currentBooking", currentBooking);
    console.log("👉 currentAvailable", currentAvailable);
  }, [currentSelect]);
  useEffect(() => {
    if (availableAppointments) {
      setCurrentAvailable(
        availableAppointments?.filter(
          (m) =>
            dateFns.format(new Date(m.day), "yyyy-MM-dd") ===
            Object.keys(currentSelect)[0]
        )
      );
    }
  }, [availableAppointments]);
  useEffect(() => {
    if (bookedAppointments) {
      setCurrentBooking(
        bookedAppointments?.filter(
          (m) =>
            dateFns.format(new Date(m.day), "yyyy-MM-dd") ===
            Object.keys(currentSelect)[0]
        )
      );
    }
  }, [bookedAppointments]);

  const changeStatus = (id, status) => {
    cancelAppointment({ token, appointmentId: id, status });
  };
  return (
    <BgContainer>
      <Appbar.Header>
        <Appbar.Content
          title="Calendar  📅"
          titleStyle={{
            color: colors.primary,
            fontFamily: "PoppinsBold",
          }}
        />
      </Appbar.Header>
      {bookedAppointmentsIsLoading || availableAppointmentsIsLoading ? (
        <ActivityIndicator
          animating={
            bookedAppointmentsIsLoading || availableAppointmentsIsLoading
          }
          color={colors.secondary}
          style={{
            flex: 1,
            alignSelf: "center",
            justifySelf: "center",
          }}
        />
      ) : (
        <>
          <Container>
            <Calendar
              // current={format(baseDate)}
              onDayPress={dayPressHandler}
              // showWeekNumbers={true}
              // markedDates={getMarkedDates(baseDate, APPOINTMENTS)}
              markedDates={{ ...marked, ...currentSelect }}
              // markedDates={marked}
              theme={{
                selectedDayBackgroundColor: colors.secondary,
                selectedDayTextColor: colors.light,
                todayTextColor: colors.secondary,

                dayTextColor: colors.primary,

                monthTextColor: colors.muted,
                textMonthFontWeight: "bold",

                arrowColor: colors.secondary,
                arrowStyle: {
                  backgroundColor: colors.moreMuted,
                  borderRadius: 100,
                },
              }}
              style={{
                width: "92%",
                alignSelf: "center",
                borderColor: "red",
                // borderWidth: 1,
                elevation: 4,
                borderRadius: 16,
                padding: 8,
              }}
              renderHeader={(date) => {
                /*Return JSX*/
                const d = dateFns.format(new Date(date), "LLLL   yyyy");
                return (
                  <View>
                    <Text
                      style={{
                        fontFamily: "Poppins",
                        color: colors.primary,
                        fontSize: 18,
                      }}
                    >
                      {d}
                    </Text>
                  </View>
                );
              }}
            />
            <Section>
              <View
                style={{
                  flexDirection: "row",
                  justifyContent: "space-between",
                  alignItems: "center",
                }}
              >
                <Title>Available Meetings</Title>
                <Button
                  buttonColor={addIsLoading ? colors.muted : colors.secondary}
                  textColor={colors.light}
                  labelStyle={{ fontFamily: "Poppins", fontSize: 12 }}
                  style={{ alignSelf: "center" }}
                  onPress={() => showTimepicker()}
                  loading={addIsLoading}
                  disabled={addIsLoading}
                >
                  Add
                </Button>
              </View>
              <AvailableMeetings>
                {availableAppointmentsIsLoading ||
                availableAppointmentsIsFetching ? (
                  <ActivityIndicator
                    animating={
                      availableAppointmentsIsLoading ||
                      availableAppointmentsIsFetching
                    }
                    color={colors.secondary}
                  />
                ) : (
                  currentAvailable?.map((m) =>
                    m.times.map((t) => (
                      <MeetItemContainer
                        onPress={() => clear({ token, dateId: m._id })}
                        style={{ elevation: 3 }}
                        key={t._id}
                      >
                        <MeetItem>
                          {dateFns.format(
                            dateFns.parseISO(t.startTime),
                            "hh:mm a"
                          )}
                        </MeetItem>
                      </MeetItemContainer>
                    ))
                  )
                )}
              </AvailableMeetings>
            </Section>
            <Section>
              <Title>Booked Meetings</Title>
              {bookedAppointmentsIsLoading || cancelIsLoading ? (
                <ActivityIndicator
                  animating={{ bookedAppointmentsIsLoading }}
                  color={colors.secondary}
                />
              ) : currentBooking?.length > 0 ? (
                currentBooking.map((meeting) => (
                  <>
                    {meeting && (
                      <MeetCard
                        key={meeting._id}
                        style={{
                          elevation: 6,
                          shadowColor: "#000000bb",
                          shadowOffset: { width: -2, height: 4 },
                          shadowOpacity: 0.82,
                          shadowRadius: 3,
                        }}
                      >
                        <UpperContainer>
                          <Info>
                            <Name style={{ fontSize: 16 }}>
                              {meeting.patient.name}
                            </Name>
                          </Info>
                          <Img
                            source={
                              meeting?.patient?.pic
                                ? { uri: imgUrl + meeting.patient.pic }
                                : require("../../../../assets/characters/doctor_male_1.png")
                            }
                          />
                        </UpperContainer>
                        <MiddleContainer>
                          <DateItem>
                            <DateIcon />
                            <DateContent>
                              {dateFns.format(
                                dateFns.parseISO(meeting.startTime),
                                "dd/MMM/yyyy"
                              )}
                            </DateContent>
                          </DateItem>
                          <TimeItem>
                            <TimeIcon />
                            <TimeContent>
                              {dateFns.format(
                                dateFns.parseISO(meeting.startTime),
                                "hh:mm a"
                              )}
                            </TimeContent>
                          </TimeItem>
                          <StatusItem>
                            <StatusIcon status={meeting.status} />
                            <StatusContent status={meeting.status}>
                              {meeting.status}
                            </StatusContent>
                          </StatusItem>
                        </MiddleContainer>
                        <LowerContainer>
                          <Button
                            mode="outlined"
                            textColor={colors.secondary}
                            onPress={() =>
                              changeStatus(meeting._id, "canceled")
                            }
                          >
                            Cancel
                          </Button>
                          <Button
                            mode="contained"
                            buttonColor={colors.secondary}
                            onPress={() =>
                              changeStatus(meeting._id, "approved")
                            }
                          >
                            Approve
                          </Button>
                        </LowerContainer>
                      </MeetCard>
                    )}
                  </>
                ))
              ) : (
                <>
                  <NoMeetingContainer>
                    <NoMeetingImg
                      source={require("../../../../assets/helpers/no_meeting_2.png")}
                    />
                    <NoMeetingTitle>No Booked Meetings!! 😞</NoMeetingTitle>
                  </NoMeetingContainer>
                </>
              )}
            </Section>
          </Container>
          <Modal
            isVisible={visible}
            onBackdropPress={() => setVisible(false)}
            style={{
              height: "50%",
              width: "100%",
              margin: 0,
              padding: 0,
              backgroundColor: colors.light,
              position: "absolute",
              left: 0,
              bottom: 0,
            }}
          >
            <ContainerModal>
              {/* <Title>Schedule New Appointment</Title> */}
              <View
                style={{
                  flexDirection: "row",
                  justifyContent: "space-between",
                }}
              >
                <DateContainer>
                  <DateTitle>Date</DateTitle>
                  <DateInfoContainer
                    style={{ elevation: 2 }}
                    onPress={() => showDatepicker()}
                  >
                    <DateTxt>{dateFns.format(date, "yyy/MM/dd")}</DateTxt>

                    <DateIcon />
                  </DateInfoContainer>
                </DateContainer>
                <DateContainer>
                  <DateTitle>Time</DateTitle>
                  <DateInfoContainer
                    style={{ elevation: 2 }}
                    onPress={() => showTimepicker()}
                  >
                    <DateTxt>
                      {date
                        ?.toTimeString()
                        .replace(/.*(\d{2}:\d{2}:\d{2}).*/, "$1")}
                    </DateTxt>

                    <ClockIcon />
                  </DateInfoContainer>
                </DateContainer>
              </View>
            </ContainerModal>
          </Modal>
        </>
      )}
    </BgContainer>
  );
};

export default ScheduleMainDoc;

// import React, { useState } from "react";
// import { StyleSheet, Text, View } from "react-native";
// import { Calendar, CalendarList } from "react-native-calendars";
// import * as dateFns from "date-fns";

// const format = (date = new Date()) => dateFns.format(date, "yyyy-mm-dd");
// const getMarkedDates = (baseDate, appointments) => {
//     const markedDates = {};

//     markedDates[format(baseDate)] = { selected: true };

//     appointments.forEach((appointment) => {
//         const formattedDate = format(new Date(appointment.date));
//         markedDates[formattedDate] = {
//             ...markedDates[formattedDate],
//             marked: true,
//         };
//     });

//     return markedDates;
// };

// export default () => {
//     const [marked, setMarked] = useState({});
//     const baseDate = new Date(2019, 6, 15);
//     const APPOINTMENTS = [
//         {
//             date: "2019-07-13T05:00:00.000Z",
//             title: "It's a past thing!",
//         },
//         {
//             date: "2019-07-15T05:00:00.000Z",
//             title: "It's a today thing!",
//         },
//         {
//             date: "2019-07-18T05:00:00.000Z",
//             title: "It's a future thing!",
//         },
//     ];

//     return (
//         <View style={styles.container}>
//             <Calendar
//                 // current={format(baseDate)}
//                 onDayPress={(day) => {
//                     console.log("⭐selected day", day);
//                     console.log("⭐selected day", day.dateString);
//                     setMarked((prev) => ({
//                         [day.dateString]: { selected: true },
//                     }));
//                 }}
//                 // showWeekNumbers={true}
//                 // markedDates={getMarkedDates(baseDate, APPOINTMENTS)}
//                 markedDates={marked}
//                 // theme={{
//                 //     calendarBackground: "#166088",

//                 //     selectedDayBackgroundColor: "#C0D6DF",
//                 //     selectedDayTextColor: "#166088",
//                 //     selectedDotColor: "#166088",

//                 //     dayTextColor: "#DBE9EE",
//                 //     textDisabledColor: "#729DAF",
//                 //     dotColor: "#DBE9EE",

//                 //     monthTextColor: "#DBE9EE",
//                 //     textMonthFontWeight: "bold",

//                 //     arrowColor: "#DBE9EE",
//                 // }}
//             />
//         </View>
//     );
// };

// const styles = StyleSheet.create({
//     container: {
//         flex: 1,
//         // backgroundColor: "#166088",
//         justifyContent: "center",
//     },
// });
