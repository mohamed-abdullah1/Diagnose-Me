import { Feather, Ionicons, Octicons } from "@expo/vector-icons";
import { Dimensions, ScrollView, View } from "react-native";

import styled from "styled-components/native";
import responsive from "../../../helpers/responsive";

const { getX, getY } = responsive(840, 395);
export const Wrapper = styled(View).attrs({})`
    width: ${getX(346)}px;
    height: ${getY(628)}px;
    background-color: ${(props) => props.theme.colors.light};
    border-radius: 32px;
    z-index: -1;
`;
export const ImgContainer = styled.View`
    position: absolute;
    top: 0;
    left: 0;
    z-index: 100;
    /* border: solid red 1px; */
    left: ${getX(346 / 2 - 157 / 2)}px;
    top: -${154 / 2}px;
`;
export const Img = styled.Image`
    width: 157px;
    height: 154px;
    border-radius: ${157 / 2}px;
`;
export const Icon = styled(Feather).attrs((props) => ({
    name: "message-circle",
    size: getX(24),
    color: props.theme.colors.primary,
}))`
    position: absolute;
    right: ${getX(10)}px;
    bottom: 0;
    background-color: ${(props) => props.theme.colors.pantone};
    padding: 8px;
    border-radius: 18px;
`;

export const Name = styled.Text`
    /* border: solid red 1px; */
    font-size: 20px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const Specialty = styled.Text`
    font-size: 15px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.blue};
    margin-top: -5px;
`;
export const Container = styled(View).attrs({
    style: {},
})`
    flex-direction: row;
    /* border: solid red 1px; */
    width: ${getX(319.41)}px;
    justify-content: space-around;
    align-items: center;
`;
export const Patients = styled.View`
    flex-direction: row;
    /* border: solid red 1px; */
    align-items: center;
`;
export const PatientIcon = styled(Octicons).attrs((props) => ({
    name: "people",
    size: 24,
    color: props.theme.colors.primary,
}))`
    margin-right: ${getX(5)}px;
`;
export const NumberOfPatient = styled.Text`
    font-size: 14px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const Experience = styled.View`
    flex-direction: row;
    align-items: center;
`;
export const WorkIcon = styled(Feather).attrs((props) => ({
    name: "briefcase",
    size: 24,
    color: props.theme.colors.primary,
}))``;
export const NumberOfYears = styled.Text`
    font-size: 14px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
    margin-top: 4px;
    margin-left: 5px;
`;
export const About = styled.View`
    /* border: solid red 1px; */
    margin-top: 20px;
    padding: 0 16px;
`;
export const AboutTitle = styled.Text`
    font-size: 15px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const AboutContent = styled.Text`
    /* margin-top: 2px; */
    font-size: 12px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
    padding: 4px;
`;
export const Location = styled.View`
    /* border: solid red 1px; */
    width: ${getX(299)}px;
`;
export const LocationTitle = styled.Text`
    font-size: 15px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const LocationContainer = styled.View`
    /* border: solid red 1px; */
    flex-direction: row;
`;
export const IconContainer = styled.View`
    margin-right: 12px;
    width: ${getX(45)}px;
    height: ${getY(45)}px;
    background-color: ${(props) => props.theme.colors.pantone};
    justify-content: center;
    align-items: center;
    border-radius: 22.5px;
`;
export const LocationIcon = styled(Ionicons).attrs((props) => ({
    name: "location-outline",
    size: 32,
    color: props.theme.colors.primary,
}))``;
export const LocationContentContainer = styled.View``;
export const LocationMainAddress = styled.Text`
    font-size: 12px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const LocationDescAddress = styled.Text`
    font-size: 12px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
export const PriceContainer = styled(View).attrs({})`
    width: ${getX(347)}px;
    height: ${getY(50)}px;
    background-color: ${(props) => props.theme.colors.pantone};
    margin-top: 20px;
    flex-direction: row;
    align-items: center;
    justify-content: space-around;
`;
export const PriceTitle = styled.Text`
    font-size: 18px;
    font-family: "PoppinsBold";
    color: ${(props) => props.theme.colors.blue};
`;
export const Price = styled.Text`
    font-size: 18px;
    font-family: "PoppinsBold";
    color: ${(props) => props.theme.colors.blue};
`;
// <Ionicons name="location-outline" size={24} color="black" />
// <Feather name="briefcase" size={24} color="black" />
// <Octicons name="people" size={24} color="black" />

export const ReviewsSection = styled.View`
    /* border: solid red 1px; */
    height: ${getY(188.17)}px;
`;
export const ReviewsCards = styled(ScrollView).attrs({
    horizontal: true,
    paddingHorizontal: 20,
})`
    /* margin-top: ${getY(8)}px; */
    /* margin-bottom: ${getY(8)}px; */
    /* border: solid red 1px; */
`;
export const ReviewCard = styled.View`
    background-color: ${(props) => props.theme.colors.light};
    width: ${getX(240)}px;
    height: ${getY(125.17)}px;
    margin-right: 20px;
    margin-left: 10px;
    border-radius: 16px;
    padding: 8px;
    margin-top: 8px;
    margin-bottom: 8px;
`;
export const Upper = styled.View`
    flex-direction: row;
`;
export const ReviewerImg = styled.Image`
    width: ${getX(43)}px;
    height: ${getY(43)}px;
`;
export const PatientInfoContainer = styled.View`
    /* border: solid red 1px; */
    margin-left: 10px;
    margin-right: 20px;
`;
export const PatientName = styled.Text`
    font-size: 11px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const Date = styled.Text`
    font-size: 10px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
export const ReviewContent = styled.Text`
    font-size: 11px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
    margin-top: 10px;
`;
