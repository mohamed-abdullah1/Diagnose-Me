import { ScrollView, TouchableOpacity } from "react-native";
import styled from "styled-components/native";

import responsive from "../../../helpers/responsive";

const { getX, getY } = responsive(832, 372);

export const Container = styled.View`
    /* border: solid red 1px; */
    flex: 1;
    justify-content: center;
    align-items: center;
`;

export const Wrapper = styled.View`
    flex: 1;
    justify-content: space-around;
    align-items: center;
    align-content: flex-start;
    flex-shrink: 2;
    /* max-height: 600px; */
    /* border: solid red 1px; */
`;

// ##############################{SelectDateSection}###################
export const SelectDateSection = styled.View`
    flex: 1;
    /* border: solid red 1px; */
    padding: 0 ${getX(26)}px;
`;
export const SelectDateTitle = styled.Text`
    margin-bottom: 5px;
    font-size: 14px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const DateCards = styled(ScrollView).attrs((props) => ({
    horizontal: true,
}))`
    max-height: 130px;
`;
export const DateCard = styled(TouchableOpacity)`
    background-color: ${(props) =>
        props.selected === props.dateCard
            ? props.theme.colors.secondary
            : props.theme.colors.light};
    width: 56px;
    height: 112px;
    border-radius: 32px;
    flex: 1;
    justify-content: space-around;
    align-items: center;
    margin-right: 18px;
    margin-left: 4px;
`;
export const Day = styled.Text`
    font-size: 14px;
    font-family: "Poppins";
    color: ${(props) =>
        props.selected === props.dateCard
            ? props.theme.colors.light
            : props.theme.colors.primary};
`;
export const DayNum = styled.Text`
    font-size: 14px;
    font-family: "Poppins";
    color: ${(props) =>
        props.selected === props.dateCard
            ? props.theme.colors.light
            : props.theme.colors.primary};
`;

// ##############################{🎗️ End }###################

// ##############################{TimeSelection}###################

export const TimeSelection = styled.View`
    flex: 1;
    padding: 0 ${getX(26)}px;
    margin-top: -80px;
`;
export const TimeTitle = styled.Text`
    margin-bottom: 5px;

    font-size: 14px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const TimeGrid = styled.View`
    flex: 1;
`;
export const TimeItem = styled(TouchableOpacity)`
    width: 33.33%;
    background-color: ${(props) =>
        props.selectedTime === props.timeId
            ? props.theme.colors.secondary
            : props.theme.colors.light};
    border-radius: 32px;
    max-width: ${getX(80)}px;
    height: 32px;
    justify-content: center;
    align-items: center;
    margin: 8px;
`;
export const TimeItemText = styled.Text`
    font-size: 14px;
    font-family: "PoppinsSemiBold";
    color: ${(props) =>
        props.selectedTime === props.timeId
            ? props.theme.colors.light
            : props.theme.colors.primary};
`;

// ##############################{🎗️ End}###################
