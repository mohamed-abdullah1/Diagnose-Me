import { useSelector } from "react-redux";
import { selectChat } from "../../../services/slices/chat.slice";
import {
    Container,
    DataContainer,
    Img,
    Message,
    Name,
    Time,
} from "../styles/ChatCard.styles";
import * as dateFns from "date-fns";
const ChatCard = ({
    senderImg,
    senderName,
    message,
    navigation,
    senderId,
    createdAt,
    otherPerson,
}) => {
    const { userId } = useSelector(selectChat);
    // const messageContent =
    //     (message.owner === "patient" ? "You: " : "") + message.content;
    // const { time } = message;

    const pressHandler = () =>
        navigation.navigate({
            name: "Chat",
            params: {
                otherId: otherPerson._id,
                userId,
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
            <Img source={{ uri: senderImg }} />
            <DataContainer>
                <Name>{"Dr. " + senderName}</Name>
                <Message>{message.substring(0, 25)}</Message>
            </DataContainer>
            <Time>
                {dateFns.format(dateFns.parseISO(createdAt), "h:mm aaa")}
            </Time>
        </Container>
    );
};

export default ChatCard;
