import { useFocusEffect } from "@react-navigation/native";
import { useCallback, useEffect, useState } from "react";
import colors from "../../../infrastructure/theme/colors";
import { BgContainer } from "../../home/styles/Global.styles";
import { Container, Title, Wrapper } from "../styles/MainChat.styles";
import { doctors, messages as loadedMessages } from "../../../helpers/consts";
import ChatCard from "../components/ChatCard.component";
import { View } from "react-native";
import UpperBack from "../../doctor/components/UpperBack.component";
const MainChat = ({ navigation }) => {
    const [messages, setMessages] = useState(null);
    useEffect(() => {
        setMessages(
            loadedMessages.map((msg) => {
                const { name: doctorName, doctorImg } = doctors.find(
                    (d) => d.id === msg.doctorId
                );
                return { ...msg, doctorName, doctorImg };
            })
        );
    }, []);
    useFocusEffect(
        useCallback(() => {
            navigation.setOptions({
                tabBarStyle: {
                    backgroundColor: colors.light,
                    height: 60,
                    alignItems: "center",
                    paddingBottom: 6,
                    paddingTop: 6,
                },
            });
        }, [])
    );
    const getChatCards = () => {};
    return (
        <BgContainer>
            <Title>Chats</Title>
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
                        ({ id, doctorImg, doctorName, message, time }) => (
                            <ChatCard
                                key={id}
                                doctorImg={doctorImg}
                                doctorName={doctorName}
                                message={message}
                                time={time}
                            />
                        )
                    )}
                </View>
            </Wrapper>
        </BgContainer>
    );
};

export default MainChat;
