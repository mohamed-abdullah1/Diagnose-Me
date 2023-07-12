import { AntDesign } from "@expo/vector-icons";
import { ScrollView } from "react-native";
import styled from "styled-components/native";
export const Container = styled.View`
  /* border: solid red 1px; */
  flex: 1;
  align-items: center;
  padding: 0;
`;

export const CommentTitle = styled.Text`
  /* border: solid red 1px; */
  width: 90%;
  margin-top: 16px;
  font-size: 16px;
  font-family: "PoppinsSemiBold";
  color: ${(props) => props.theme.colors.primary};
`;
export const CommentsContainer = styled(ScrollView)`
  /* border: solid red 1px; */
  flex: 1;
  width: 90%;
`;
export const CommentCard = styled.View`
  margin-bottom: 16px;
  padding: 16px;
  background-color: ${(props) => props.theme.colors.light};
  border-radius: 16px;
  margin: 4px;
`;

export const Upper = styled.View`
  flex-direction: row;
  justify-content: space-between;
  margin-bottom: 8px;
`;
export const InfoWrapper = styled.View`
  flex-direction: row;
`;
export const Img = styled.Image`
  width: 47px;
  height: 47px;
  border-radius: ${47 / 2}px;
  border: solid 2px ${(p) => p.theme.colors.secondary};
`;
export const Info = styled.View`
  margin-left: 16px;
`;
export const Name = styled.Text`
  font-size: 14px;
  font-family: "PoppinsSemiBold";
  color: ${(props) => props.theme.colors.primary};
`;
export const SpecialtyContainer = styled.View`
  flex-direction: row;
  /* border: solid red 1px; */
  justify-content: center;
  align-items: center;
`;
export const Specialty = styled.Text`
  font-size: 12px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
  margin-right: 8px;
`;
export const Date = styled.Text`
  font-size: 12px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
  margin-right: 8px;
`;
export const Middle = styled.Text`
  font-size: 14px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
  padding: 8px;
`;
export const Bottom = styled.View`
  flex-direction: row;
  margin-top: 8px;
`;
export const UpIcon = styled(AntDesign).attrs((props) => ({
  name: "arrowup",
  size: 24,
  color: props.theme.colors.primary,
}))``;
export const LowerIcon = styled(AntDesign).attrs((props) => ({
  name: "arrowdown",
  size: 24,
  color: props.theme.colors.primary,
}))`
  margin-left: -4px;
`;
export const Total = styled.Text`
  font-size: 14px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
`;
