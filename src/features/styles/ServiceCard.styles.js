import { TouchableOpacity } from "react-native";
import styled from "styled-components/native";

export const Wrapper = styled(TouchableOpacity)`
    height: 110px;
    width: 116px;
    margin-right: ${(props) => (props.index === props.total ? 24 + 15 : 15)}px;
    border-radius: 16px;
    flex: 1;
    align-items: center;
    background-color: ${(props) => props.theme.colors.light};
    /* border: solid red 1px; */
    margin-top: 8px;
    margin-bottom: 8px;
`;
export const Img = styled.Image`
    width: 69px;
    height: 69px;
    /* border: solid red 1px; */
`;
export const Title = styled.Text`
    font-size: 11px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
    margin-top: 8px;
`;
