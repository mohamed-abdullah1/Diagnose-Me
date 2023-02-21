import { Button, Pressable } from "react-native";
import styled from "styled-components/native";
import { View } from "react-native";
export const ButtonWrapper = styled(View).attrs({
    style: {
        width: "100%",
    },
})`
    background-color: ${(props) => props.bgColor};
    position: absolute;
    bottom: 0;
    left: 0;
    width: 395px;
    height: 66px;
    justify-content: center;
    align-items: center;
`;
export const Btn = styled(Pressable).attrs((props) => ({
    style: (pressData) => pressData.pressed,
    android_ripple: {
        color: (props) => props.theme.colors.secondary,
    },
}))`
    height: 47px;
    width: 347px;
    background-color: ${(props) => props.theme.colors.secondary};
    border-radius: 32px;
    align-items: center;
    justify-content: center;
`;
export const ContentBtn = styled.Text`
    font-size: 20px;
    font-family: "PoppinsBold";
    color: ${(props) => props.theme.colors.light};
`;
