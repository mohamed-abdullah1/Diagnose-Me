import { useFocusEffect } from "@react-navigation/native";
import { useCallback, useEffect, useState } from "react";
import colors from "../../../infrastructure/theme/colors";
import { BgContainer } from "../../home/styles/Global.styles";
import { Container, Title, Wrapper } from "../styles/MainChat.styles";
import { doctors, msgs as loadedMessages } from "../../../helpers/consts";
import ChatCard from "../components/ChatCard.component";
import { View } from "react-native";
import UpperBack from "../../doctor/components/UpperBack.component";
import { ActivityIndicator, Appbar, Button } from "react-native-paper";
import { Content } from "../../schedule/styles/ScheduleMain.styles";
import { useGetChatsQuery } from "../../../services/apis/chat.api";
import { useDispatch, useSelector } from "react-redux";
import { setUser } from "../../../services/slices/chat.slice";
import useSocketSetup from "../../../helpers/useSocketSetup";
import { selectToken, selectUser } from "../../../services/slices/auth.slice";

const MainChat = ({ navigation }) => {
  const token = useSelector(selectToken);
  const currentUser = useSelector(selectUser);
  const {
    data: chats,
    isLoading: chatsLoading,
    isSuccess: chatsIsSuccess,
    isError: chatsIsError,
    error: chatsError,
    isFetching: chatsIsFetching,
    refetch: chatsRefetch,
  } = useGetChatsQuery(token);

  console.log("👉💖💖💖", currentUser);
  useEffect(() => {
    if (chatsIsSuccess) {
      console.log("🥗", chats);
    }
    if (chatsIsError) {
      console.log("🥗", chatsError);
    }
  }, [chatsIsSuccess, chatsIsError]);

  useFocusEffect(
    useCallback(() => {
      navigation.setOptions({
        tabBarStyle: {
          backgroundColor: colors.light,
          height: 58,
          alignItems: "center",
          paddingBottom: 0,
          paddingTop: 4,
        },
      });
    }, [])
  );
  // console.log(loadedMessages);
  useFocusEffect(
    useCallback(() => {
      navigation.getParent().setOptions({
        tabBarStyle: {
          backgroundColor: colors.light,
          height: 58,
          alignItems: "center",
          paddingBottom: 0,
          paddingTop: 4,
        },
      });
    }, [])
  );

  //ui functions
  const previewChats = chats?.map(
    ({ msgId, msgContent, createdAt, chatUsers, chatId }) => {
      console.log("👉👈 CHAT USERS... ", chatUsers);
      const otherPerson = chatUsers.filter(
        (user) => user._id !== currentUser.id
      )[0];
      return (
        <ChatCard
          senderId={otherPerson._id}
          navigation={navigation}
          key={msgId}
          senderImg={otherPerson.pic}
          senderName={otherPerson.name}
          message={msgContent}
          createdAt={createdAt}
          otherPerson={otherPerson}
          chatId={chatId}
          refetch={chatsRefetch}
        />
      );
    }
  );

  return (
    <BgContainer>
      <Appbar.Header>
        <Content title="Chats 📭" />
      </Appbar.Header>
      {chatsLoading ? (
        <ActivityIndicator
          animating={chatsIsFetching}
          color={colors.secondary}
          style={{
            flex: 1,
            alignSelf: "center",
            justifySelf: "center",
          }}
        />
      ) : (
        <Wrapper>
          <View
            style={{
              flex: 1,
              height: "100%",
              alignItems: "center",
              justifyContent: "space-around",
            }}
          >
            {previewChats}
          </View>
        </Wrapper>
      )}
    </BgContainer>
  );
};

export default MainChat;
