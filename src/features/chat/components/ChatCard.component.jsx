import {
    Container,
    DataContainer,
    Img,
    Message,
    Name,
    Time,
} from "../styles/ChatCard.styles";

const ChatCard = ({ doctorImg, doctorName, message, time }) => {
    const messageContent =
        (message.owner === "patient" ? "You: " : "") + message.content;
    return (
        <Container
            style={{
                elevation: 5,
                shadowColor: "#000000a6",
                shadowOffset: { width: -2, height: 4 },
                shadowOpacity: 0.82,
                shadowRadius: 8,
            }}
        >
            <Img source={doctorImg} />
            <DataContainer>
                <Name>{"Dr. " + doctorName}</Name>
                <Message>{messageContent.substring(0, 25)}</Message>
            </DataContainer>
            <Time>{time.timeValue + time.amOrPm}</Time>
        </Container>
    );
};

export default ChatCard;
