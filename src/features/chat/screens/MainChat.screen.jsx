import { useFocusEffect } from "@react-navigation/native";
import { useCallback, useEffect, useState } from "react";
import colors from "../../../infrastructure/theme/colors";
import { BgContainer } from "../../home/styles/Global.styles";
import { Container, Title, Wrapper } from "../styles/MainChat.styles";
import { doctors, msgs as loadedMessages } from "../../../helpers/consts";
import ChatCard from "../components/ChatCard.component";
import { View } from "react-native";
import UpperBack from "../../doctor/components/UpperBack.component";
import { Appbar } from "react-native-paper";
import { Content } from "../../schedule/styles/ScheduleMain.styles";
import { useGetChatsQuery } from "../../../services/apis/chat.api";
import { useSelector } from "react-redux";
import { selectChat } from "../../../services/slices/chat.slice";
const MainChat = ({ navigation }) => {
    const [messages, setMessages] = useState(null);
    const chatsInfo = useSelector(selectChat);
    const {
        data: chats,
        isLoading: chatsLoading,
        isSuccess: chatsIsSuccess,
        isError: chatsIsError,
        error: chatsError,
    } = useGetChatsQuery(chatsInfo.token);

    useEffect(() => {
        if (chatsIsSuccess) {
            setMessages(
                chats.map((chat) => {
                    const otherPerson = chat.users.filter(
                        (user) => user.id !== chatsInfo.userId
                    )[0];
                    const {
                        _id: msgId,
                        sender,
                        content: msgContent,
                        createdAt,
                        chat: chatId,
                    } = chat.latestMessage;
                    const {
                        _id: senderId,
                        name: senderName,
                        pic: senderImg,
                    } = sender;
                    return {
                        otherPerson,
                        msgId,
                        senderId,
                        senderImg,
                        senderName,
                        msgContent,
                        createdAt,
                        chatId,
                    };
                })
            );
        }
    }, [chatsIsSuccess]);
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
    console.log(loadedMessages);
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
    return (
        <BgContainer>
            <Appbar.Header>
                <Content title="Chats 📭" />
            </Appbar.Header>
            <Wrapper>
                <View
                    style={{
                        flex: 1,
                        height: "100%",
                        alignItems: "center",
                        justifyContent: "space-around",
                    }}
                >
                    {messages?.map(
                        ({
                            senderId,
                            msgId,
                            senderImg,
                            senderName,
                            msgContent,
                            createdAt,
                            otherPerson,
                        }) => (
                            <ChatCard
                                senderId={senderId}
                                navigation={navigation}
                                key={msgId}
                                senderImg={senderImg}
                                senderName={senderName}
                                message={msgContent}
                                createdAt={createdAt}
                                otherPerson={otherPerson}
                            />
                        )
                    )}
                </View>
            </Wrapper>
        </BgContainer>
    );
};

export default MainChat;
