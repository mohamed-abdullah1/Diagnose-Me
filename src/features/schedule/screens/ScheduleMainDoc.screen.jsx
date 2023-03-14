import { useEffect, useState } from "react";
import { Text, View } from "react-native";
import { Calendar } from "react-native-calendars";
import { Appbar, Button } from "react-native-paper";
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
import Modal from "react-native-modal";
import { DateTimePickerAndroid } from "@react-native-community/datetimepicker";
import { meetingsForDoctor } from "../../../helpers/consts";
import uuid from "react-native-uuid";

const ScheduleMainDoc = ({}) => {
    const [marked, setMarked] = useState({
        dateString: "2023-03-08",
        day: 8,
        month: 3,
        timestamp: 1678233600000,
        year: 2023,
    });
    const [bookedMeetings, setBookedMeetings] = useState([]);
    const [bookedAppointment, setbookedAppointment] = useState([]); //appointements
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
    const onChange = (event, selectedDate) => {
        const currentDate = selectedDate;
        setDate(currentDate);
        // console.log("👉", currentDate);
        // console.log("👉ببببببببببببببب", v4());
        // console.log(
        //     "👉",
        //     currentDate.toTimeString().replace(/.*(\d{2}:\d{2}:\d{2}).*/, "$1"),
        //     dateFns.format(currentDate, "h:mm bbb")
        // );
        // console.log("👉marked", marked);
        const meeting = bookedMeetings?.find((b) => b.date === dayCalendar);
        console.log("👉👉👉", meeting.available, dayCalendar);
        if (!meeting) {
            setBookedMeetings((prev) => [
                ...prev,
                {
                    id: uuid.v4(),
                    date: dayCalendar,
                    appointements: [],
                    available: [],
                },
            ]);
        } else {
            setBookedMeetings((prev) =>
                prev.map((ele) => {
                    if (ele.date !== dayCalendar) {
                        return ele;
                    }
                    return {
                        ...ele,
                        available: [
                            ...ele.available,
                            {
                                id: uuid.v4(),
                                time: dateFns.format(currentDate, "h:mm bbb"),
                            },
                        ],
                    };
                })
            );
        }
    };
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
        setMarked((prev) => ({
            [day.dateString]: { selected: true },
        }));
        setDayCalendar(day.dateString);
        const { appointements, available: availableMeetings } =
            bookedMeetings.find((m) => m.date === day.dateString);
        setbookedAppointment(appointements);
        setAvailable(availableMeetings);
    };
    useEffect(() => {
        setBookedMeetings(meetingsForDoctor);
    }, []);
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
            <Container>
                <Calendar
                    // current={format(baseDate)}
                    onDayPress={dayPressHandler}
                    // showWeekNumbers={true}
                    // markedDates={getMarkedDates(baseDate, APPOINTMENTS)}
                    markedDates={marked}
                    theme={{
                        selectedDayBackgroundColor: colors.secondary,
                        selectedDayTextColor: colors.light,

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
                    <Title>Available Meetings</Title>
                    <AvailableMeetings>
                        {available?.map((m) => (
                            <MeetItemContainer
                                style={{ elevation: 3 }}
                                key={m.id}
                            >
                                <MeetItem>{m.time}</MeetItem>
                            </MeetItemContainer>
                        ))}
                    </AvailableMeetings>
                    <Button
                        buttonColor={colors.secondary}
                        textColor={colors.light}
                        labelStyle={{ fontFamily: "Poppins" }}
                        style={{ width: "60%", alignSelf: "center" }}
                        onPress={() => showTimepicker()}
                    >
                        Add New Meeting
                    </Button>
                </Section>
                <Section>
                    <Title>Booked Meetings</Title>
                    {bookedAppointment ? (
                        <CardsSection
                            contentContainerStyle={{
                                marginLeft: 0,
                                paddingTop: 10,
                                paddingBottom: 10,
                                paddingLeft: 4,
                                paddingRight: 4,
                            }}
                            style={{
                                // borderColor: "red",
                                // borderWidth: 1,
                                marginLeft: -20,
                            }}
                        >
                            {bookedAppointment?.map((t) => (
                                <View
                                    key={t.id}
                                    elevation={2}
                                    style={{
                                        marginRight: 16,
                                        borderRadius: 32,
                                        width: 130,
                                        backgroundColor: colors.light,
                                    }}
                                >
                                    <MeetingCard>
                                        <UpperSectionMeeting>
                                            <PatientImg
                                                style={{
                                                    width: 30,
                                                    height: 30,
                                                    borderRadius: 15,
                                                }}
                                                source={t.img}
                                            />
                                            <Time style={{ fontSize: 12 }}>
                                                {t.time}
                                            </Time>
                                        </UpperSectionMeeting>
                                        <Name style={{ fontSize: 13 }}>
                                            {t.patientName}
                                        </Name>
                                    </MeetingCard>
                                </View>
                            ))}
                        </CardsSection>
                    ) : (
                        <>
                            <NoMeetingContainer>
                                <NoMeetingImg
                                    source={require("../../../../assets/helpers/no_meeting_2.png")}
                                />
                                <NoMeetingTitle>
                                    No Booked Meetings!! 😞
                                </NoMeetingTitle>
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
                                <DateTxt>
                                    {dateFns.format(date, "yyy/MM/dd")}
                                </DateTxt>

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
                                        .replace(
                                            /.*(\d{2}:\d{2}:\d{2}).*/,
                                            "$1"
                                        )}
                                </DateTxt>

                                <ClockIcon />
                            </DateInfoContainer>
                        </DateContainer>
                    </View>
                </ContainerModal>
            </Modal>
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
