import { useFocusEffect } from "@react-navigation/native";
import { useCallback, useEffect, useRef, useState } from "react";
import { Dimensions, TouchableOpacity } from "react-native";
import { ActivityIndicator, Button, TextInput } from "react-native-paper";
import { doctors, msgs } from "../../../helpers/consts";
import { BgContainer } from "../../home/styles/Global.styles";
import {
  AttachIcon,
  BottomSection,
  CloseIcon,
  Icon,
  IconWrapper,
  Img,
  ImgContainer,
  ImgIcon,
  InfoData,
  InputContainer,
  InputField,
  MessageContainer,
  MessageContent,
  MessageScroll,
  MessagesSection,
  MicroPhoneIcon,
  Name,
  SendIcon,
  State,
  TopSection,
} from "../styles/Chat.styles";
import {
  useGetAllMessagesQuery,
  useSendMessageMutation,
} from "../../../services/apis/chat.api";
import { useSelector } from "react-redux";
import { selectChat } from "../../../services/slices/chat.slice";
import colors from "../../../infrastructure/theme/colors";
import { selectToken, selectUser } from "../../../services/slices/auth.slice";
import theme from "../../../infrastructure/theme";

const Chat = ({ route, navigation }) => {
  const ref = useRef();
  const currentUser = useSelector(selectUser);
  const token = useSelector(selectToken);
  const [focus, setFocus] = useState(false);
  const [content, setContent] = useState("");
  const { chatId, otherPerson, socket } = route.params;
  const {
    data: msgs,
    isLoading: msgsLoading,
    isSuccess: msgsIsSuccess,
    isError: msgsIsError,
    error: msgsError,
    isFetching: msgsIsFetching,
    refetch: msgsRefetch,
  } = useGetAllMessagesQuery({ chatId, token });
  const [
    sendMsg,
    {
      data: sendMsgResponse,
      isSuccess: sendMsgIsSuccess,
      isError: sendMsgIsError,
      error: sendMsgError,
      isLoading: sendMsgLoading,
    },
  ] = useSendMessageMutation();
  // const { messages, doctorActive } = msgs.find(
  //     (m) => m.patientId === patientId && m.doctorId === doctorId
  // );
  // console.log(messages, "yep");
  //if we in the patient component
  // const { name, doctorImg } = doctors.find((doc) => doc.id === doctorId);

  // const [
  //     createAccessChat,
  //     {
  //         data: chatRes,
  //         error: chatErr,
  //         isError: chatIsErr,
  //         isSuccess: chatIsSuccess,
  //     },
  // ] = useCreateAccessChatMutation();

  const handleFocus = () => setFocus(true);
  const handleBlur = () => setFocus(false);
  const backPressHandler = () => {
    navigation.goBack();
  };
  const sendHandler = () => {
    if (content) {
      sendMsg({ token, content, chatId });
    }
  };
  const navigateCallHandler = () => {
    navigation.navigate("VideoCall", { chatId, otherPerson, socket });
  };
  useFocusEffect(
    useCallback(() => {
      navigation.getParent().setOptions({
        tabBarStyle: { display: "none" },
      });
    }, [])
  );
  useEffect(() => {
    socket.on("message received", () => {
      console.log("🖋️🚓", "called");
      (async () => {
        try {
          if (!msgs) {
            await msgsRefetch();
          }
        } catch (err) {
          console.error(err);
        }
      })();
    });
  }, []);
  useEffect(() => {
    if (focus && ref) {
      socket.emit("typing", chatId);
      ref?.current?.scrollToEnd({ animated: true });
    } else {
      socket.emit("stop typing", chatId);
    }
  }, [focus]);
  useEffect(() => {
    if (msgsIsSuccess) {
      console.log("RESPONSE:-💚", msgs);
    }
    if (msgsIsError) {
      console.log("ERROR:-🍎", msgsError);
    }
  }, [msgsIsSuccess, msgsIsError]);
  useEffect(() => {
    if (sendMsgIsSuccess) {
      setContent("");
      socket.emit("new message", chatId);
      console.log("👉", sendMsgResponse);
    }
  }, [sendMsgIsSuccess]);
  useEffect(() => {
    if (sendMsgIsError) {
      console.log("👉", sendMsgError);
    }
  }, [sendMsgIsError]);
  useEffect(() => {
    if (ref) {
      ref?.current?.scrollToEnd({
        animated: true,
      });
    }
  }, [msgs]);
  return (
    <BgContainer>
      {msgsLoading ? (
        <ActivityIndicator
          animating={msgsIsFetching}
          color={colors.secondary}
          style={{
            flex: 1,
            alignSelf: "center",
            justifySelf: "center",
          }}
        />
      ) : (
        <>
          <TopSection
            style={{
              elevation: 10,
              shadowColor: "#000000a6",
              shadowOffset: { width: -2, height: 4 },
              shadowOpacity: 0.82,
              shadowRadius: 8,
            }}
          >
            <ImgContainer>
              <Img source={{ uri: otherPerson.pic }} />
            </ImgContainer>
            <InfoData>
              <Name>{otherPerson.name}</Name>
              <State>
                {/* // todo: change the state to the real state */}
                {true ? "Active" : "Active  1 min ago"}
              </State>
            </InfoData>
            <CloseIcon onPress={navigateCallHandler}>
              <Icon />
            </CloseIcon>
          </TopSection>
          <MessagesSection>
            <MessageScroll ref={ref}>
              {msgs?.map((mes) => (
                <MessageContainer key={mes.id}>
                  <MessageContent
                    mySelf={currentUser.id}
                    doctorOrPatient={mes.sender}
                  >
                    {mes.content}
                  </MessageContent>
                </MessageContainer>
              ))}
            </MessageScroll>
          </MessagesSection>
          <BottomSection>
            <InputContainer>
              <InputField
                multiline={true}
                placeholder="Type Your Message"
                onFocus={handleFocus}
                onBlur={handleBlur}
                onChangeText={setContent}
                value={content}
              />
              <TouchableOpacity
                style={{
                  backgroundColor: colors.secondary,
                  // padding: 5,
                  width: 45,
                  height: 45,
                  borderRadius: 45 / 2,
                  justifyContent: "center",
                  alignItems: "center",
                }}
                onPress={sendHandler}
              >
                {focus ? (
                  sendMsgLoading ? (
                    <ActivityIndicator
                      animating={sendMsgLoading}
                      color="white"
                    />
                  ) : (
                    <SendIcon />
                  )
                ) : (
                  <AttachIcon />
                )}
              </TouchableOpacity>
            </InputContainer>
          </BottomSection>
        </>
      )}
    </BgContainer>
  );
};

export default Chat;
