import { Feather, Ionicons, Octicons } from "@expo/vector-icons";
import { Dimensions, ScrollView, View } from "react-native";
import styled from "styled-components/native";
export const Wrapper = styled(View).attrs({
    style: {
        shadowColor: "#470000",
        shadowOffset: { width: 10, height: 1 },
        shadowOpacity: 0.2,
        elevation: 12,
    },
})`
    width: 346px;
    height: 603px;
    background-color: ${(props) => props.theme.colors.muted};
    border-radius: 32px;
`;
export const ImgContainer = styled.View`
    position: absolute;
    top: -55px;
    left: ${Dimensions.get("window").width / 2 - 75}px;
    z-index: 100;
`;
export const Img = styled.Image`
    width: 152px;
    height: 150px;
    /* margin-top: -${120 / 2}px; */
`;
export const Icon = styled(Feather).attrs((props) => ({
    name: "message-circle",
    size: 24,
    color: props.theme.colors.primary,
}))`
    position: absolute;
    right: 10px;
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
    width: 320px;
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
    margin-right: 5px;
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
    margin-top: 2px;
    font-size: 12px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
export const Location = styled.View`
    /* border: solid red 1px; */
    width: 299px;
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
export const LocationIcon = styled(Ionicons).attrs((props) => ({
    name: "location-outline",
    size: 32,
    color: props.theme.colors.primary,
}))`
    background-color: ${(props) => props.theme.colors.focused};
    padding: 10px;
    border-radius: 30px;
    margin-right: 12px;
`;
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
    width: 347px;
    height: 50px;
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
    height: 158.17px;
`;
export const ReviewsCards = styled(ScrollView).attrs({
    horizontal: true,
    paddingHorizontal: 20,
})`
    margin-top: 4px;
`;
export const ReviewCard = styled.View`
    background-color: ${(props) => props.theme.colors.moreMuted};
    width: 240px;
    height: 115.17px;
    margin-right: 20px;
    border-radius: 16px;
    padding: 8px;
`;
export const Upper = styled.View`
    flex-direction: row;
`;
export const ReviewerImg = styled.Image`
    width: 43px;
    height: 43px;
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
