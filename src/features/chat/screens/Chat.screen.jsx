import { useFocusEffect } from "@react-navigation/native";
import { useCallback, useEffect, useRef } from "react";
import { Dimensions } from "react-native";
import { TextInput } from "react-native-paper";
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
    State,
    TopSection,
} from "../styles/Chat.styles";

const Chat = ({ route, navigation }) => {
    const ref = useRef();
    console.log(route.name, route.params);
    const { patientId, doctorId } = route.params;
    const { messages, doctorActive } = msgs.find(
        (m) => m.patientId === patientId && m.doctorId === doctorId
    );
    console.log(messages);
    //if we in the patient component
    const { name, doctorImg } = doctors.find((doc) => doc.id === doctorId);
    useFocusEffect(
        useCallback(() => {
            navigation.getParent().setOptions({
                tabBarStyle: { display: "none" },
            });
        }, [])
    );
    const backPressHandler = () => {
        navigation.goBack();
    };
    const getScrollHeight = () => {
        let h = 0;
        let xChar = (Dimensions.get("window").width * 61) / 392.7;
        messages.forEach((msg, i) => {
            h += Math.ceil(msg.content.length / xChar);
        });
        console.log("🆓", Dimensions.get("window").height);
        return h;
    };
    getScrollHeight();
    useEffect(() => {
        ref.current.scrollToEnd({
            animated: true,
        });
    }, []);
    return (
        <BgContainer>
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
                    <Img source={doctorImg} />
                </ImgContainer>
                <InfoData>
                    <Name>{"Dr. " + name}</Name>
                    <State>
                        {doctorActive ? "Active" : "Active  1 min ago"}
                    </State>
                </InfoData>
                <CloseIcon onPress={backPressHandler}>
                    <Icon />
                </CloseIcon>
            </TopSection>
            <MessagesSection>
                <MessageScroll
                    onLayout={(e) => console.log("🍠", e.nativeEvent.layout)}
                    ref={ref}
                    length={getScrollHeight()}
                    total={messages.length}
                >
                    {messages.map((mes) => (
                        <MessageContainer key={mes.id}>
                            <MessageContent
                                mySelf="patient"
                                doctorOrPatient={mes.owner}
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
                    />
                    <IconWrapper>
                        <MicroPhoneIcon />
                    </IconWrapper>
                    <IconWrapper>
                        <ImgIcon />
                    </IconWrapper>
                    <AttachIcon />
                </InputContainer>
            </BottomSection>
        </BgContainer>
    );
};

export default Chat;
