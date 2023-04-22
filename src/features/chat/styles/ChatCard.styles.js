import { ScrollView, TouchableOpacity } from "react-native";
import styled from "styled-components/native";

import responsive from "../../../helpers/responsive";

const { getX, getY } = responsive(832, 372);

export const Container = styled(TouchableOpacity)`
    padding: 24px;
    /* border: solid red 1px; */
    width: ${getX(324)}px;
    height: ${getY(83)}px;
    flex-direction: row;
    margin-bottom: 17px;
    align-items: center;
    justify-content: space-between;
    border-radius: 8px;
    background-color: ${(props) => props.theme.colors.light};
`;
export const Img = styled.Image`
    width: 50px;
    height: 50px;
    border-radius: 25px;
`;
export const DataContainer = styled.View`
    /* border: solid red 1px; */
    flex: 4;
    margin-left: 16px;
    margin-right: 8px;
`;
export const Name = styled.Text`
    font-size: 10px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const Message = styled.Text`
    font-size: 10px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
export const Time = styled.Text`
    flex: 1.2;
    font-size: 10px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.blue};
    margin-bottom: 9px;
`;
