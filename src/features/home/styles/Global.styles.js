import { ScrollView, TouchableOpacity } from "react-native";
import styled from "styled-components/native";

export const BgContainer = styled.View`
  background-color: #fffefe;
  flex: 1;
  /* border: solid red 1px; */
`;
export const HeaderContainer = styled.View`
  flex-direction: row;
  padding: 10px 24px;
  align-items: center;
`;
export const Hello = styled.Text`
  font-size: 24px;
  font-family: "PoppinsBold";
  color: ${(props) => props.theme.colors.primary};
`;
export const Emoji = styled.Image`
  width: 33.52px;
  height: 33px;
  margin-left: 17px;
`;
export const CategoriesSection = styled.View`
  /* border: solid red 1px; */
  margin-top: ${(props) => (props.marginTop ? props.marginTop : 20)}px;
`;

export const CardsSection = styled(ScrollView).attrs({
  horizontal: true,
  showsHorizontalScrollIndicator: false,
})`
  padding: 4px ${(props) => (props.padding ? props.padding : 24)}px;
  margin-top: ${(props) => (props.marginTop ? props.marginTop : 8)}px;
  /* border: solid red 1px; */
`;
export const DoctorsSection = styled.View`
  margin-top: 20px;
  /* border: solid red 1px; */
`;
export const TrendQuestionsSection = styled.View`
  margin-top: 20px;
`;
export const TodayMeetings = styled.View``;
export const MeetingCard = styled(TouchableOpacity)`
  flex: 1;
  padding: 16px;
`;
export const UpperSectionMeeting = styled.View`
  flex-direction: row;
  justify-content: space-between;
  align-items: center;
  margin-bottom: 12px;
`;
export const PatientImg = styled.Image`
  width: 45px;
  height: 45px;
  border-radius: ${45 / 2}px;
`;
export const Time = styled.Text`
  align-self: baseline;
  background-color: ${(p) => p.theme.colors.moreMuted};
  font-size: 14px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
  padding: 4px 6px;
  border-radius: 16px;
`;
export const Name = styled.Text`
  font-size: 20px;
  font-family: "PoppinsSemiBold";
  color: ${(props) => props.theme.colors.primary};
`;
