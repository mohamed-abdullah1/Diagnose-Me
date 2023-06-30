import { AntDesign, MaterialIcons } from "@expo/vector-icons";
import { ScrollView, TouchableOpacity } from "react-native";
import styled from "styled-components/native";

export const Container = styled(ScrollView).attrs({
  contentContainerStyle: {
    paddingTop: 8,
    paddingBottom: 8,
  },
})``;

export const Section = styled.View`
  /* border: solid red 1px; */
  width: 90%;
  align-self: center;
  margin-top: 16px;
`;
export const Title = styled.Text`
  font-size: 16px;
  font-family: "PoppinsSemiBold";
  color: ${(props) => props.theme.colors.primary};
`;
export const NoMeetingContainer = styled.View`
  justify-content: center;
  align-items: center;
`;
export const NoMeetingImg = styled.Image`
  width: 40%;
  height: 150px;
`;
export const NoMeetingTitle = styled.Text`
  font-size: 14px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.black};
`;
export const ContainerModal = styled(ScrollView).attrs({
  contentContainerStyle: {},
})`
  padding: 10px 20px;
`;
export const ButtonsContainer = styled.View`
  flex-direction: row;
  justify-content: space-around;
  width: 100%;
`;
export const DateContainer = styled.View`
  flex: 1;
  padding: 12px;
`;
export const DateTitle = styled.Text`
  font-size: 15px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
  margin-left: 9px;
`;
export const DateInfoContainer = styled(TouchableOpacity)`
  /* border: solid red 1px; */
  flex-direction: row;
  padding: 10px;
  border-radius: 32px;
  justify-content: space-between;
  background-color: ${(p) => p.theme.colors.light};
  margin-right: 10px;
  align-items: center;
`;
export const DateTxt = styled.Text`
  font-size: 14px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
`;
export const DateIcon = styled(MaterialIcons).attrs((p) => ({
  name: "date-range",
  size: 18,
  color: p.theme.colors.secondary,
}))``;
export const ClockIcon = styled(AntDesign).attrs((p) => ({
  name: "clockcircle",
  size: 18,
  color: p.theme.colors.secondary,
}))``;
export const AvailableMeetings = styled(ScrollView).attrs({
  horizontal: true,
  contentContainerStyle: {
    paddingTop: 10,
    paddingBottom: 10,
  },
})``;
export const MeetItemContainer = styled(TouchableOpacity)`
  background-color: ${(p) => p.theme.colors.light};
  margin-right: 10px;
  border-radius: 16px;
`;
export const MeetItem = styled.Text`
  font-size: 12px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.Primary};
  padding: 4px 8px;
`;
