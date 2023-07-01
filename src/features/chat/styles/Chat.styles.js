import { AntDesign, Feather, FontAwesome, Ionicons } from "@expo/vector-icons";
import { ScrollView, TouchableOpacity } from "react-native";
import styled from "styled-components/native";

import responsive from "../../../helpers/responsive";

const { getX, getY } = responsive(832, 372);

export const TopSection = styled.View`
  /* flex: 1.5; */
  background-color: ${(props) => props.theme.colors.light};
  padding-top: 10px;
  flex-direction: row;
  /* border: solid red 1px; */
  justify-content: space-between;
  align-items: center;
  min-height: 95px;
  max-height: 95px;
`;

export const ImgContainer = styled.View`
  flex: 2;
  /* border: solid red 1px; */
  justify-content: center;
  align-items: center;
`;
export const Img = styled.Image`
  width: 60px;
  height: 60px;
  border-radius: 30px;
`;
export const InfoData = styled.View`
  flex: 4;
  /* border: solid red 1px; */
`;
export const Name = styled.Text`
  font-size: 16px;
  font-family: "PoppinsSemiBold";
  color: ${(props) => props.theme.colors.primary};
`;
export const State = styled.Text`
  font-size: 10px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
`;
export const CloseIcon = styled(TouchableOpacity)`
  flex: 1;
  /* border: solid red 1px; */
  justify-content: center;
  align-items: center;
`;
export const Icon = styled(Ionicons).attrs((props) => ({
  name: "close",
  size: 24,
  color: props.theme.colors.primary,
}))``;

export const MessagesSection = styled.View`
  /* border: solid red 1px; */
  flex: 10;
  justify-content: flex-end;
`;
export const MessageScroll = styled(ScrollView).attrs({})`
  /* border: solid red 1px; */
  /* max-height: ${(props) => props.length * (51 - 26) + props.total * 38}px; */
  padding: 8px 24px;
  margin: 10px 0;
  height: 100%;
`;
export const MessageContainer = styled.View`
  /* border: solid red 1px; */
  margin-bottom: 10px;
  align-items: baseline;
`;
export const MessageContent = styled.Text`
  background-color: ${(props) =>
    props.mySelf === props.doctorOrPatient
      ? props.theme.colors.secondary
      : props.theme.colors.muted};
  padding: 16px;
  border-radius: 16px;
  align-self: ${(props) =>
    props.mySelf === props.doctorOrPatient ? "flex-end" : "flex-start"};
  font-size: 12px;
  font-family: "Poppins";
  color: ${(props) =>
    props.mySelf === props.doctorOrPatient
      ? props.theme.colors.light
      : props.theme.colors.primary};
`;

export const BottomSection = styled.View`
  /* border: solid red 1px; */
  flex: 1.5;
  min-height: 60px;
  max-height: 60px;
  justify-content: center;
  align-items: center;
  margin-bottom: 12px;
`;
export const InputContainer = styled.View`
  /* border: solid green 1px; */
  /* margin: 14px 24px; */
  height: 60px;
  width: 92%;
  background-color: ${(props) => props.theme.colors.moreMuted};
  border-radius: 32px;
  /* height: 100%; */
  justify-content: space-between;
  align-items: center;
  flex-direction: row;
  padding: 8px;
`;
export const InputField = styled.TextInput`
  flex: 1;
  padding: 10px;
  font-size: 12px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
`;

export const MicroPhoneIcon = styled(FontAwesome).attrs((props) => ({
  name: "microphone",
  size: 20,
  color: props.theme.colors.primary,
}))`
  margin-right: 8px;
`;
export const ImgIcon = styled(Feather).attrs((props) => ({
  name: "image",
  size: 20,
  color: props.theme.colors.primary,
}))`
  /* border: solid red 1px; */
  margin-right: 8px;
`;
export const AttachIcon = styled(Ionicons).attrs((props) => ({
  name: "attach",
  size: 24,
  color: props.theme.colors.light,
}))`
  /* margin-right: 5px; */
`;
export const SendIcon = styled(Ionicons).attrs((props) => ({
  name: "ios-send",
  size: 20,
  color: props.theme.colors.light,
}))`
  /* margin-right: 5px; */
`;
export const IconWrapper = styled.View`
  justify-content: center;
  align-items: center;
  /* border: solid red 1px; */
`;
