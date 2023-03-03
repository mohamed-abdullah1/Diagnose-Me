import { AntDesign, Fontisto, MaterialIcons } from "@expo/vector-icons";
import { ScrollView } from "react-native";
import { Appbar, Button } from "react-native-paper";
import styled from "styled-components/native";

export const Content = styled(Appbar.Content).attrs((props) => ({
    titleStyle: {
        fontFamily: "PoppinsBold",
        fontSize: 24,
        color: props.theme.colors.primary,
        paddingLeft: 10,
    },
    mode: "contained",
}))``;
export const Container = styled(ScrollView).attrs({
    paddingTop: 15,
})``;
export const MeetCard = styled.View`
    /* border: solid red 1px; */
    padding-top: 18px;
    margin-bottom: 24px;
    width: 85%;
    height: 180px;
    align-self: center;
    border-radius: 16px;
    background-color: ${(props) => props.theme.colors.light};
    padding: 16px;
    flex: 1;
    justify-content: space-between;
`;

export const UpperContainer = styled.View`
    flex-direction: row;
    justify-content: space-between;
`;
export const Info = styled.View``;
export const Name = styled.Text`
    font-size: 12px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const Specialty = styled.Text`
    font-size: 10px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
export const Img = styled.Image`
    width: 50px;
    height: 50px;
    border-radius: 25px;
`;

export const MiddleContainer = styled.View`
    flex-direction: row;
    justify-content: space-between;
    padding-top: 16px;
    padding-bottom: 16px;
`;
export const DateItem = styled.View`
    flex-direction: row;
`;
export const DateIcon = styled(MaterialIcons).attrs((props) => ({
    name: "date-range",
    size: 14,
    color: props.theme.colors.primary,
}))``;
export const DateContent = styled.Text`
    font-size: 11px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
    margin-left: 5px;
`;
export const TimeItem = styled.View`
    flex-direction: row;
`;
export const TimeIcon = styled(AntDesign).attrs((props) => ({
    name: "clockcircleo",
    size: 14,
    color: props.theme.colors.primary,
}))``;
export const TimeContent = styled.Text`
    font-size: 11px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
    margin-left: 5px;
`;
export const StatusItem = styled.View`
    flex-direction: row;
`;
export const StatusIcon = styled(Fontisto).attrs((props) => ({
    name: "radio-btn-active",
    size: 14,
    color: props.status === "Confirmed" ? props.theme.colors.success : "red",
}))``;
export const StatusContent = styled.Text`
    font-size: 11px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
    margin-left: 5px;
`;

export const LowerContainer = styled.View`
    flex-direction: row;
    justify-content: space-around;
`;
export const Btn = styled(Button).attrs((props) => ({
    mode: props.type === "active" ? "contained" : "outlined",
}))`
    ${(props) =>
        props.type === "passive" &&
        `border:solid ${props.theme.colors.secondary} 1.2px;`}
`;
