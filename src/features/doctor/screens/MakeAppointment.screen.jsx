import { useFocusEffect } from "@react-navigation/native";
import { useCallback, useEffect, useState } from "react";
import { View, Text, FlatList } from "react-native";
import { doctors } from "../../../helpers/consts";
import colors from "../../../infrastructure/theme/colors";
import BottomButton from "../../components/BottomButton.component";
import { BgContainer } from "../../home/styles/Global.styles";
import InfoSection from "../components/InfoSection.component";
import UpperBack from "../components/UpperBack.component";
import {
    Container,
    DateCard,
    DateCards,
    Day,
    DayNum,
    SelectDateSection,
    SelectDateTitle,
    TimeGrid,
    TimeItem,
    TimeItemText,
    TimeSelection,
    TimeTitle,
    Wrapper,
} from "../styles/MakeAppointments.styles";

//todo backend
const dates = [
    { id: 1, day: "THU", dayNum: 13 },
    { id: 2, day: "FRI", dayNum: 14 },
    { id: 3, day: "MON", dayNum: 15 },
    { id: 4, day: "TUE", dayNum: 16 },
    { id: 5, day: "WED", dayNum: 17 },
    { id: 6, day: "SAN", dayNum: 18 },
];

const timesForEachDates = [
    {
        dateId: 1,
        times: [
            { id: 1, time: 9, amOrPm: "am" },
            { id: 2, time: 10, amOrPm: "am" },
            { id: 3, time: 11, amOrPm: "am" },
            { id: 4, time: 12, amOrPm: "pm" },
            { id: 5, time: 1, amOrPm: "pm" },
            { id: 6, time: 3, amOrPm: "pm" },
            { id: 7, time: 2, amOrPm: "pm" },
        ],
    },
    {
        dateId: 2,
        times: [
            { id: 1, time: 12, amOrPm: "pm" },
            { id: 2, time: 1, amOrPm: "pm" },
            { id: 3, time: 3, amOrPm: "pm" },
            { id: 4, time: 2, amOrPm: "pm" },
        ],
    },
    {
        dateId: 3,
        times: [
            { id: 1, time: 9, amOrPm: "am" },
            { id: 2, time: 10, amOrPm: "am" },
            { id: 3, time: 11, amOrPm: "am" },
            { id: 4, time: 12, amOrPm: "pm" },
        ],
    },
    {
        dateId: 4,
        times: [
            { id: 1, time: 9, amOrPm: "am" },
            { id: 2, time: 10, amOrPm: "am" },
            { id: 3, time: 11, amOrPm: "am" },
            { id: 4, time: 12, amOrPm: "pm" },
            { id: 5, time: 1, amOrPm: "pm" },
            { id: 6, time: 3, amOrPm: "pm" },
            { id: 7, time: 2, amOrPm: "pm" },
        ],
    },
    {
        dateId: 5,
        times: [
            { id: 1, time: 1, amOrPm: "pm" },
            { id: 2, time: 3, amOrPm: "pm" },
            { id: 3, time: 2, amOrPm: "pm" },
        ],
    },
    {
        dateId: 6,
        times: [
            { id: 1, time: 9, amOrPm: "am" },
            { id: 2, time: 10, amOrPm: "am" },
            { id: 3, time: 11, amOrPm: "am" },
            { id: 4, time: 12, amOrPm: "pm" },
            { id: 5, time: 1, amOrPm: "pm" },
            { id: 6, time: 3, amOrPm: "pm" },
            { id: 7, time: 2, amOrPm: "pm" },
        ],
    },
];

const MakeAppointment = ({ route, navigation }) => {
    const [selected, setSelected] = useState(1);
    const [times, setTimes] = useState();
    const [selectedTime, setSelectedTime] = useState(1);
    const { doctorId } = route.params;
    const {
        id,
        doctorImg,
        name,
        specialty,
        pricePerHour,
        rate,
        yearsOfExperience,
        numberOfPatients,
        aboutDoctor,
        reviews,
        location,
    } = doctors.find((doc) => doc.id === doctorId);
    const nextPressHandler = () => {
        navigation.navigate({
            name: "MakeAppointmentNote",
            params: {
                doctorName: name,
                doctorImg: doctorImg,
                rate: rate,
                specialty: specialty,
                numberOfReviews: reviews.length,
            },
        });
    };
    const cardSelectedHandler = (id) => setSelected(id);
    const timePressHandler = (timeId) => setSelectedTime(timeId);
    useFocusEffect(
        useCallback(() => {
            navigation.getParent().setOptions({
                tabBarStyle: { display: "none" },
            });
        }, [])
    );
    useEffect(() => {
        const dateTimes = timesForEachDates.find(
            (ele) => ele.dateId === selected
        ).times;
        setTimes(dateTimes);
    }, [selected]);
    console.log("asd");

    return (
        <BgContainer>
            <Container>
                <Wrapper>
                    <UpperBack top={30} left={30} />
                    <InfoSection
                        doctorName={name}
                        doctorImg={doctorImg}
                        rate={rate}
                        specialty={specialty}
                        numberOfReviews={reviews.length}
                    />
                    {/* // ##############################{SelectDateSection}###################
                     */}
                    <SelectDateSection style={{ width: "100%" }}>
                        <SelectDateTitle>Select Date</SelectDateTitle>
                        <DateCards>
                            {dates.map(({ id, day, dayNum }) => (
                                <DateCard
                                    style={{
                                        shadowColor: "#000000b9",
                                        shadowOffset: {
                                            width: -10,
                                            height: 10,
                                        },
                                        shadowOpacity: 0.25,
                                        shadowRadius: 16,

                                        elevation: 10,
                                    }}
                                    key={id}
                                    selected={selected}
                                    dateCard={id}
                                    onPress={() => cardSelectedHandler(id)}
                                >
                                    <Day selected={selected} dateCard={id}>
                                        {day}
                                    </Day>
                                    <DayNum dateCard={id} selected={selected}>
                                        {dayNum}
                                    </DayNum>
                                </DateCard>
                            ))}
                        </DateCards>
                    </SelectDateSection>

                    <TimeSelection>
                        <TimeTitle>Select Time</TimeTitle>
                        <TimeGrid>
                            <FlatList
                                data={times}
                                numColumns={3}
                                keyExtractor={(item, index) => index}
                                renderItem={({ item }) => {
                                    const { id: timeId, time, amOrPm } = item;
                                    return (
                                        <TimeItem
                                            onPress={() =>
                                                timePressHandler(timeId)
                                            }
                                            style={{
                                                shadowColor: "#000000b9",
                                                shadowOffset: {
                                                    width: -10,
                                                    height: 10,
                                                },
                                                shadowOpacity: 0.25,
                                                shadowRadius: 16,

                                                elevation: 5,
                                            }}
                                            selectedTime={selectedTime}
                                            timeId={timeId}
                                        >
                                            <TimeItemText
                                                selectedTime={selectedTime}
                                                timeId={timeId}
                                            >
                                                {time + ":00 " + amOrPm}
                                            </TimeItemText>
                                        </TimeItem>
                                    );
                                }}
                            />
                        </TimeGrid>
                    </TimeSelection>
                </Wrapper>
            </Container>

            <BottomButton label={"Next"} pressFunction={nextPressHandler} />
        </BgContainer>
    );
};
export default MakeAppointment;
