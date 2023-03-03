import { TouchableOpacity } from "react-native";
import styled from "styled-components/native";

export const Wrapper = styled.View`
    /* border: solid red 1px; */
    flex-direction: row;
    justify-content: space-between;
    align-items: center;
    padding: 0 24px;
`;
export const Title = styled.Text`
    font-size: 18px;
    color: ${(props) => props.theme.colors.blue};
    font-family: "PoppinsBold";
`;
export const Btn = styled(TouchableOpacity)`
    width: 54px;
    height: 23.23px;
    justify-content: center;
    align-items: center;
    justify-content: center;
    background-color: ${(props) => props.theme.colors.secondary};
    color: ${(props) => props.theme.colors.light};
    border-radius: 16px;
`;
export const Content = styled.Text`
    color: ${(props) => props.theme.colors.light};
    font-family: "Poppins";
    font-size: 10;
`;
