import { useFocusEffect } from "@react-navigation/native";
import { useCallback, useEffect, useState } from "react";
import colors from "../../../infrastructure/theme/colors";
import { BgContainer } from "../../home/styles/Global.styles";
import { Container, Title, Wrapper } from "../styles/MainChat.styles";
import { doctors, msgs as loadedMessages } from "../../../helpers/consts";
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
    console.log(loadedMessages);
    useFocusEffect(
        useCallback(() => {
            navigation.getParent().setOptions({
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
                        ({
                            doctorId,
                            patientId,
                            id,
                            doctorImg,
                            doctorName,
                            messages,
                        }) => (
                            <ChatCard
                                patientId={patientId}
                                doctorId={doctorId}
                                navigation={navigation}
                                key={id}
                                doctorImg={doctorImg}
                                doctorName={doctorName}
                                message={messages[messages.length - 1]}
                            />
                        )
                    )}
                </View>
            </Wrapper>
        </BgContainer>
    );
};

export default MainChat;
