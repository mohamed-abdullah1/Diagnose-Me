import { useEffect, useState } from "react";
import {
  ActivityIndicator,
  Appbar,
  Button,
  Card,
  Text,
} from "react-native-paper";
import { schedules } from "../../../helpers/consts";
import { BgContainer } from "../../home/styles/Global.styles";
import {
  Btn,
  BtnContent,
  Container,
  Content,
  DateContent,
  DateIcon,
  DateItem,
  Img,
  Info,
  LowerContainer,
  MeetCard,
  MiddleContainer,
  Name,
  Specialty,
  StatusContent,
  StatusIcon,
  StatusItem,
  TimeContent,
  TimeIcon,
  TimeItem,
  UpperContainer,
} from "../styles/ScheduleMain.styles";
import {
  useChangeStatusMutation,
  useGetAppointmentsQuery,
} from "../../../services/apis/appointment.api";
import { useSelector } from "react-redux";
import { selectToken, selectUser } from "../../../services/slices/auth.slice";
import { format, parseISO } from "date-fns";
import colors from "../../../infrastructure/theme/colors";
import { enUS } from "date-fns/locale";
import { View } from "react-native";
import useSocketSetup from "../../../helpers/useSocketSetup";
import { useCreateAccessChatMutation } from "../../../services/apis/chat.api";
import { Image } from "react-native";

const ScheduleMain = ({ navigation }) => {
  const token = useSelector(selectToken);
  const currentUser = useSelector(selectUser);
  const socket = useSocketSetup();
  const {
    data: appointments,
    isError,
    error,
    isLoading,
    isSuccess,
  } = useGetAppointmentsQuery(token);
  const [
    makeChat,
    { data: chat, isSuccess: chatIsSuccess, isLoading: makeChatIsLoading },
  ] = useCreateAccessChatMutation();
  const [
    cancelAppointment,
    {
      data: cancelData,
      isSuccess: cancelIsSuccess,
      isLoading: cancelIsLoading,
    },
  ] = useChangeStatusMutation();
  useEffect(() => {
    if (isError) {
      console.error(error);
    }
  }, [isError]);
  useEffect(() => {
    if (cancelIsSuccess) {
      console.log("🔡", cancelData);
    }
  }, [cancelIsSuccess]);
  useEffect(() => {
    if (chatIsSuccess) {
      console.log("👉🗣️chat", chat.users.length);
      navigation.navigate("Messages", {
        screen: "Chat",
        params: {
          chatId: chat?._id,
          otherPerson: chat?.users.filter(
            (user) => user._id !== currentUser.id
          )[0],
          socket,
        },
      });
    }
  }, [chatIsSuccess]);

  const talkNowHandler = (doctorId, patientId) => {
    // create or access a chat between patient and doctor and start talking
    makeChat({ token, userId: doctorId });
  };
  const cancelHandler = (id) => {
    cancelAppointment({ token, appointmentId: id, status: "canceled" });
  };
  return (
    <BgContainer>
      <Appbar.Header>
        <Content title="Up Coming Meets 🚀" />
      </Appbar.Header>
      <Container>
        {isLoading ? (
          <ActivityIndicator
            animating={isLoading}
            color={colors.secondary}
            style={{
              flex: 1,
              alignSelf: "center",
              justifySelf: "center",
            }}
          />
        ) : appointments?.length > 0 ? (
          appointments?.map((meeting) => (
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
                  <Name>{"Dr. " + meeting.doctor.name}</Name>
                  <Specialty>
                    {meeting.doctor?.specialty
                      ? meeting.doctor?.specialty
                      : "Specialty"}
                  </Specialty>
                </Info>
                <Img
                  source={
                    meeting?.doctor?.pic
                      ? { uri: meeting.doctor.pic }
                      : require("../../../../assets/characters/doctor_male_1.png")
                  }
                />
              </UpperContainer>
              <MiddleContainer>
                <DateItem>
                  <DateIcon />
                  <DateContent>
                    {format(parseISO(meeting.start_date), "dd/MMM/yyyy", {
                      locale: enUS,
                    })}
                  </DateContent>
                </DateItem>
                <TimeItem>
                  <TimeIcon />
                  <TimeContent>
                    {format(parseISO(meeting.start_date), "hh:mm a", {
                      locale: enUS,
                    })}
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
                  loading={cancelIsLoading}
                  onPress={() => cancelHandler(meeting._id)}
                >
                  Cancel
                </Button>
                <Button
                  mode="contained"
                  buttonColor={colors.secondary}
                  onPress={() =>
                    talkNowHandler(meeting.doctor._id, meeting.patient._id)
                  }
                  loading={makeChatIsLoading}
                  disabled={meeting.status !== "approved"}
                >
                  Talk Now
                </Button>
              </LowerContainer>
            </MeetCard>
          ))
        ) : (
          <View
            style={{
              alignSelf: "center",
              justifySelf: "center",
              // borderColor: "red",
              // borderWidth: 1,
              flex: 1,
              width: "100%",
              height: "100%",
              padding: 16,
            }}
          >
            <Image
              source={require("../../../../assets/helpers/comment.png")}
              style={{
                width: "100%",
                height: 300,
              }}
            />
            <Text
              style={{
                textAlign: "center",
                fontFamily: "Poppins",
                fontWeight: "bold",
                color: colors.secondary,
              }}
            >
              NO APPOINTMENTS 😢
            </Text>
          </View>
        )}
      </Container>
    </BgContainer>
  );
};

export default ScheduleMain;
