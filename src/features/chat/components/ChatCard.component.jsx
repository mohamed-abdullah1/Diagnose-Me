import {
    Container,
    DataContainer,
    Img,
    Message,
    Name,
    Time,
} from "../styles/ChatCard.styles";

const ChatCard = ({
    doctorImg,
    doctorName,
    message,
    navigation,
    doctorId,
    patientId,
}) => {
    const messageContent =
        (message.owner === "patient" ? "You: " : "") + message.content;
    const { time } = message;
    const formatTime = (t) => {
        const hour = [10, 11, 12].includes(t.hour) ? t.hour : "0" + t.hour;
        const minute = [0, 1, 2, 3, 4, 5, 6, 7, 8, 9].includes(t.minute)
            ? "0" + t.minute
            : t.minute;
        return `${hour}:${minute} ${t.amOrPm}`;
    };
    const pressHandler = () =>
        navigation.navigate({
            name: "Chat",
            params: {
                doctorId,
                patientId,
            },
        });
    return (
        <Container
            style={{
                elevation: 5,
                shadowColor: "#000000a6",
                shadowOffset: { width: -2, height: 4 },
                shadowOpacity: 0.82,
                shadowRadius: 8,
            }}
            onPress={pressHandler}
        >
            <Img source={doctorImg} />
            <DataContainer>
                <Name>{"Dr. " + doctorName}</Name>
                <Message>{messageContent.substring(0, 25)}</Message>
            </DataContainer>
            <Time>{formatTime(time)}</Time>
        </Container>
    );
};

export default ChatCard;
