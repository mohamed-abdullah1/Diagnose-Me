import { TouchableOpacity } from "react-native";
import styled from "styled-components/native";

export const Wrapper = styled(TouchableOpacity)`
  margin-right: 15px;
  /* height: ${(props) =>
    props.viewAllQuestion ? "auto" : props.height + "px"}; */
  min-height: 80px;
  height: auto;
  width: ${(props) => props.width}px;
  border-radius: 16px;
  background-color: ${(props) => props.theme.colors.moreMuted};
  padding: 14px 12px;
  /* flex: 1; */
  /* flex-grow: 1; */
`;
export const Upper = styled.View`
  flex-direction: row;
  align-items: center;
`;
export const Img = styled.Image`
  width: ${(props) => (props.imgSize ? props.imgSize : 48)}px;
  height: ${(props) => (props.imgSize ? props.imgSize : 48)}px;
  border: solid 2px ${(p) => p.theme.colors.secondary};
  border-radius: 100px;
`;
export const Name = styled.Text`
  font-size: ${(props) => (props.nameTextSize ? props.nameTextSize : 14)}px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
  margin-left: 17px;
`;

export const Date = styled.Text`
  font-size: ${(props) => (props.dateTextSize ? props.dateTextSize : 12)}px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.blue};
  position: absolute;
  right: 5px;
  top: 13px;
`;
export const Content = styled.View`
  margin-top: 16px;
  margin-left: 8px;
  /* flex: 1; */
`;
export const ContentText = styled.Text`
  font-size: ${(props) =>
    props.contentTextSize ? props.contentTextSize : 15}px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
`;
export const Text = styled.Text``;
export const Bottom = styled.View`
  flex-direction: row;
  justify-content: space-between;
  margin-top: 16px;
`;
