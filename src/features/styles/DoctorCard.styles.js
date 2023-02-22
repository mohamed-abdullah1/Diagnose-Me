import { Ionicons } from "@expo/vector-icons";
import { TouchableOpacity } from "react-native";
import styled from "styled-components/native";

export const Wrapper = styled(TouchableOpacity)`
    height: 249px;
    width: 154px;
    margin-right: ${(props) => (props.total === props.index ? 24 + 16 : 16)}px;
    margin-top: 8px;
    margin-bottom: 8px;
    /* border: solid red 1px; */
    flex: 1;
    align-items: center;
    background-color: ${(props) => props.theme.colors.light};
    border-radius: 16px;
`;

export const Img = styled.Image`
    width: 90px;
    height: 90px;
    border-radius: ${90 / 2}px;
    margin-top: 28px;
    margin-bottom: 25px;
`;
export const Name = styled.Text`
    font-size: 14px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const Specialty = styled.Text`
    font-size: 11px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
export const Price = styled.View`
    flex-direction: row;
    align-items: center;
`;
export const Before = styled.Text`
    font-size: 13px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.blue};
    margin-right: 11px;
    text-decoration: line-through;
`;
export const After = styled.Text`
    font-size: 16px;
    font-family: "PoppinsBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const IconContainer = styled(TouchableOpacity)`
    position: absolute;
    top: 7px;
    right: 10px;
`;
export const Icon = styled(Ionicons).attrs((props) => ({
    name: props.pinned ? "add-circle" : "add-circle-outline",
    size: 24,
    color: props.theme.colors.primary,
}))``;
