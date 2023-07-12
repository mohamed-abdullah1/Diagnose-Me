import { useFocusEffect } from "@react-navigation/native";
import { useCallback, useEffect, useState } from "react";
import { View, Text, FlatList, Dimensions } from "react-native";
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
import { useSelector } from "react-redux";
import { selectToken } from "../../../services/slices/auth.slice";
import { useGetAvailableDatesForDoctorQuery } from "../../../services/apis/appointment.api";
import { compareAsc, format, parseISO } from "date-fns";
import { ActivityIndicator, Appbar, Button } from "react-native-paper";
import theme from "../../../infrastructure/theme";

const MakeAppointment = ({ route, navigation }) => {
  const [selected, setSelected] = useState();
  const [times, setTimes] = useState();
  const [selectedTime, setSelectedTime] = useState();
  const { doctorId, doctor } = route.params;
  const token = useSelector(selectToken);
  const {
    data: appointments,
    isSuccess: appointmentsIsSuccess,
    isLoading: appointmentsIsLoading,
    isError: appointmentsIsError,
    error: appointmentsError,
  } = useGetAvailableDatesForDoctorQuery({ token, doctorId });
  const {
    id,
    profilePictureUrl: doctorImg,
    fullName: name,
    pricePerSession: pricePerHour,
    averageRate: rate,
    yearsOfExperience: yearsOfExperience,
    numberOfPatients: numberOfPatients,
    bio: aboutDoctor,
    reviews,
    clinicAddress: location = "location",
    specialty: specialty = "specialty",
  } = doctor;
  const nextPressHandler = () => {
    console.log("🎉", { selectedTime: selectedTime, selected: selected });
    navigation.navigate({
      name: "MakeAppointmentNote",
      params: {
        doctorName: name,
        doctorImg: doctorImg,
        rate: rate,
        specialty: specialty,
        numberOfReviews: 69,
        selectedTime: selectedTime,
        selected: selected,
        doctorId: id,
      },
    });
  };
  const cardSelectedHandler = (date) => setSelected(date);
  const timePressHandler = (item) => setSelectedTime(item);
  useFocusEffect(
    useCallback(() => {
      navigation.getParent().setOptions({
        tabBarStyle: { display: "none" },
      });
    }, [])
  );
  useEffect(() => {
    console.log("🎉س", appointments);
  }, [appointmentsIsSuccess]);
  useEffect(() => {
    if (appointmentsError) {
      console.error(appointmentsError);
    }
  }, [appointmentsIsError]);
  // useEffect(() => {
  //   const dateTimes = timesForEachDates.find(
  //     (ele) => ele.dateId === selected
  //   ).times;
  //   setTimes(dateTimes);
  // }, [selected]);
  console.log("doctor from make appointment", doctor);
  return (
    <BgContainer>
      <Container>
        <Wrapper>
          <Appbar.Header style={{ width: "100%" }}>
            <Appbar.BackAction
              color={colors.primary}
              onPress={() => {
                navigation.goBack();
              }}
            />
            <Appbar.Content
              title="Booking"
              titleStyle={{
                color: colors.primary,
                fontFamily: "Poppins",
              }}
            />
          </Appbar.Header>

          <InfoSection
            doctorName={name}
            doctorImg={doctorImg}
            rate={rate}
            specialty={specialty}
            numberOfReviews={69}
          />
          {/* // ##############################{SelectDateSection}###################
           */}
          <SelectDateSection>
            <SelectDateTitle>Available Dates</SelectDateTitle>
            <DateCards>
              {appointmentsIsLoading ? (
                <ActivityIndicator
                  animating={appointmentsIsLoading}
                  color={theme.colors.primary}
                  style={{
                    flex: 1,
                    justifyContent: "center",
                    alignItems: "center",
                  }}
                />
              ) : (
                appointments
                  // ?.sort((a, b) =>
                  //   compareAsc(new Date(a.startTime), new Date(b.startTime))
                  // )
                  ?.map(({ day }) => (
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
                      key={day}
                      selected={selected}
                      dateCard={day}
                      onPress={() => cardSelectedHandler(day)}
                    >
                      <Day selected={selected} dateCard={day}>
                        {format(new Date(day), "MMM")}
                      </Day>
                      <DayNum dateCard={day} selected={selected}>
                        {format(new Date(day), "dd")}
                      </DayNum>
                    </DateCard>
                  ))
              )}
            </DateCards>
          </SelectDateSection>

          <TimeSelection>
            <TimeTitle>Select a Time Slot</TimeTitle>
            <TimeGrid>
              <FlatList
                data={appointments?.find((ele) => ele.day === selected)?.times}
                numColumns={4}
                keyExtractor={(item, index) => item._id}
                renderItem={({ item, index }) => {
                  // const { id: timeId, time, amOrPm } = item;
                  return (
                    <TimeItem
                      onPress={() => timePressHandler(item)}
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
                      selectedTime={selectedTime?._id}
                      timeId={item._id}
                    >
                      <TimeItemText
                        selectedTime={selectedTime?._id}
                        timeId={item._id}
                      >
                        {format(new Date(item?.startTime), "hh:mm a")}
                      </TimeItemText>
                    </TimeItem>
                  );
                }}
              />
            </TimeGrid>
          </TimeSelection>
        </Wrapper>
      </Container>

      {/* <BottomButton label={"Next"} pressFunction={nextPressHandler} /> */}
      <Button
        textColor="#fff"
        buttonColor={selectedTime ? theme.colors.secondary : theme.colors.muted}
        labelStyle={{ fontFamily: "Poppins" }}
        disabled={!selectedTime}
        onPress={nextPressHandler}
        mode="contained"
        style={{
          width: "50%",
          alignSelf: "center",
          marginBottom: 20,
          marginTop: 20,
        }}
      >
        Next
      </Button>
    </BgContainer>
  );
};
export default MakeAppointment;
