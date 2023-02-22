import { Button, Dimensions, Pressable } from "react-native";
import styled from "styled-components/native";
import { View } from "react-native";
import responsive from "../../helpers/responsive";

const { getX, getY } = responsive(840, 395);

export const ButtonWrapper = styled(View).attrs({})`
    /* background-color: ${(props) => props.bgColor}; */
    position: absolute;
    bottom: 0;
    left: 0;
    flex: 1;
    width: ${Dimensions.get("window").width}px;
    height: ${getY(66)}px;
    justify-content: center;
    align-items: center;
    /* border: solid red 1px; */
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
