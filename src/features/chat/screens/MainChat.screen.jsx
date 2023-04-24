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
import { selectChat } from "../../../services/slices/chat.slice";
import { setUser } from "../../../services/slices/chat.slice";
import { SocketIoEndPoint } from "../../../infrastructure/Constants";
import { io } from "socket.io-client";

let socket;

const MainChat = ({ navigation }) => {
    const chatsInfo = useSelector(selectChat);
    const {
        data: chats,
        isLoading: chatsLoading,
        isSuccess: chatsIsSuccess,
        isError: chatsIsError,
        error: chatsError,
        isFetching: chatsIsFetching,
        refetch: chatsRefetch,
    } = useGetChatsQuery(chatsInfo.token);
    const dispatch = useDispatch();
    const patientHandler = () => {
        console.log("👉", "Iam here!");
        dispatch(
            setUser({
                userId: "59c3809e-570a-48ff-8842-99a596b3a4e1",
                token: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjU5YzM4MDllLTU3MGEtNDhmZi04ODQyLTk5YTU5NmIzYTRlMSIsImlhdCI6MTY4MjMxNjM5MiwiZXhwIjoxNjg0OTA4MzkyfQ.jUbo6aHiRUs94faf6cr_7cU3Ve6112t_BgyXqnIdu7A",
            })
        );
    };

    useEffect(() => {
        if (chatsIsSuccess) {
            console.log("🥗", chats);
            socket = io(SocketIoEndPoint);
            chats.forEach((c) => {
                socket.emit("join chat", c._id);
                socket.on("new message", () => chatsRefetch());
            });
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
            const otherPerson = chatUsers.filter(
                (user) => user._id !== chatsInfo.userId
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
                    <Button onPress={patientHandler}>Patient 2</Button>
                </Wrapper>
            )}
        </BgContainer>
    );
};

export default MainChat;
