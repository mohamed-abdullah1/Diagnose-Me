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
import useSocketSetup from "../../../helpers/useSocketSetup";
import { useEffect } from "react";
const ChatCard = ({
  senderImg,
  senderName,
  message,
  navigation,
  senderId,
  createdAt,
  chatId,
  otherPerson,
  refetch,
}) => {
  const { userId } = useSelector(selectChat);
  const socket = useSocketSetup();
  const pressHandler = () =>
    navigation.navigate({
      name: "Chat",
      params: {
        chatId,
        otherPerson,
        socket,
      },
    });
  useEffect(() => {
    socket.emit("join chat", chatId);
    socket.on("message received", () => {
      if (message) {
        (async () => {
          try {
            await refetch();
          } catch (err) {
            console.error(err);
          }
        })();
      }
    });
  }, []);
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
        <Name>{senderName}</Name>
        <Message>
          {(userId === senderId ? "You:" : "") + message.substring(0, 25)}
        </Message>
      </DataContainer>
      <Time>{dateFns.format(dateFns.parseISO(createdAt), "h:mm aaa")}</Time>
    </Container>
  );
};

export default ChatCard;
