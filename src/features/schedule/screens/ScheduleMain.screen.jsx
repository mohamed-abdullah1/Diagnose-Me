import { useEffect, useState } from "react";
import { Appbar, Button, Card, Text } from "react-native-paper";
import { schedules } from "../../../helpers/consts";
import { BgContainer } from "../../home/styles/Global.styles";
import {
    Btn,
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

const ScheduleMain = ({ navigation }) => {
    const [meetings, setMeetings] = useState([]);
    useEffect(() => {
        setMeetings(schedules);
    }, []);
    const talkNowHandler = (doctorId, patientId) => {
        console.log({ doctorId, patientId });
        navigation.navigate("Messages", {
            screen: "Chat",
            params: {
                patientId,
                doctorId,
            },
        });
    };
    return (
        <BgContainer>
            <Appbar.Header>
                <Content title="Up Coming Meets 🚀" />
            </Appbar.Header>
            <Container>
                {meetings?.map((meeting) => (
                    <MeetCard
                        key={meeting.doctorId}
                        style={{
                            elevation: 18,
                            shadowColor: "#000000bb",
                            shadowOffset: { width: -2, height: 4 },
                            shadowOpacity: 0.82,
                            shadowRadius: 3,
                        }}
                    >
                        <UpperContainer>
                            <Info>
                                <Name>{"Dr. " + meeting.doctorName}</Name>
                                <Specialty>{meeting.specialty}</Specialty>
                            </Info>
                            <Img source={meeting.doctorImg} />
                        </UpperContainer>
                        <MiddleContainer>
                            <DateItem>
                                <DateIcon />
                                <DateContent>{`${meeting.day}/${meeting.month}/${meeting.year}`}</DateContent>
                            </DateItem>
                            <TimeItem>
                                <TimeIcon />
                                <TimeContent>{`${meeting.time.hour}:${meeting.time.minutes} ${meeting.time.amOrPm}`}</TimeContent>
                            </TimeItem>
                            <StatusItem>
                                <StatusIcon status={meeting.status} />
                                <StatusContent>
                                    {meeting.status === "Confirmed"
                                        ? "Confirmed"
                                        : "Un Confirmed"}
                                </StatusContent>
                            </StatusItem>
                        </MiddleContainer>
                        <LowerContainer>
                            <Btn type="passive">Cancel</Btn>
                            <Btn
                                onPress={() =>
                                    talkNowHandler(
                                        meeting.doctorId,
                                        meeting.patientId
                                    )
                                }
                                type="active"
                            >
                                Talk Now
                            </Btn>
                        </LowerContainer>
                    </MeetCard>
                ))}
            </Container>
        </BgContainer>
    );
};

export default ScheduleMain;
