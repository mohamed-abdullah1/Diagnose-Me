import { Entypo, Fontisto, Ionicons } from "@expo/vector-icons";
import { Dimensions, ScrollView } from "react-native";
import { Button } from "react-native-paper";
import styled from "styled-components/native";
import Modal from "react-native-modal";

export const Container = styled(ScrollView).attrs({
  contentContainerStyle: {
    paddingTop: 16,
    paddingLeft: 8,
    paddingRight: 8,
    alignItems: "center",
  },
})`
  /* border: solid red 1px; */
`;
export const DonationCard = styled.View`
  /* border: solid red 1px; */
  margin-bottom: 16px;
  padding: 16px;
  border-radius: 16px;
  background-color: ${(props) => props.theme.colors.light};
  width: 95%;
`;
export const Info = styled.View`
  flex-direction: row;
  align-items: center;
`;
export const Img = styled.Image`
  width: 50px;
  height: 50px;
  border-radius: ${50 / 2}px;
`;
export const Name = styled.Text`
  margin-left: 8px;
  font-size: 14px;
  font-family: "PoppinsSemiBold";
  color: ${(props) => props.theme.colors.primary};
`;
export const BloodType = styled.View`
  margin: 8px 0;
  flex-direction: row;
  align-items: center;
`;
export const BloodIcon = styled(Fontisto).attrs((props) => ({
  name: "blood-drop",
  size: 24,
  color: props.theme.colors.secondary,
}))`
  background-color: ${(props) => props.theme.colors.moreMuted};
  align-self: baseline;
  border-radius: 100px;
  padding: 8px;
`;
export const StatusIcon = styled(Entypo).attrs((props) => ({
  name: "circle",
  size: 24,
  color: props.theme.colors.secondary,
}))`
  background-color: ${(props) => props.theme.colors.moreMuted};
  align-self: baseline;
  border-radius: 100px;
  padding: 8px;
`;
{
  /* <Fontisto name="blood-drop" size={24} color="black" /> */
}
export const Blood = styled.Text`
  font-size: 16px;
  font-family: "PoppinsBold";
  color: ${(props) => props.theme.colors.primary};
  margin-left: 8px;
`;
export const LocationSection = styled.View`
  flex-direction: row;
  max-width: 80%;
  margin: 8px 0;
`;
export const LocationIcon = styled(Ionicons).attrs((props) => ({
  name: "location-outline",
  size: 24,
  color: props.theme.colors.secondary,
}))`
  background-color: ${(props) => props.theme.colors.moreMuted};
  align-self: baseline;
  border-radius: 100px;
  padding: 8px;
`;
export const LocationInfo = styled.View`
  margin-left: 8px;
`;
export const LocationMain = styled.Text`
  font-size: 12px;
  font-family: "PoppinsSemiBold";
  color: ${(props) => props.theme.colors.primary};
`;
export const LocationSecondary = styled.Text`
  font-size: 11px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
`;
export const Btn = styled(Button).attrs((props) => ({
  buttonColor: props.theme.colors.secondary,
  textColor: props.theme.colors.light,
  labelStyle: {
    fontFamily: "Poppins",
  },
}))`
  width: 40%;
  margin: 8px 0;
  align-self: center;
`;
export const AddBloodDonation = styled(Modal)`
  background-color: ${(p) => p.theme.colors.light};
  width: 100%;
  margin: 0;
  justify-self: flex-end;
  position: absolute;
  left: 0;
  bottom: 0px;
  height: ${Dimensions.get("window").height * 0.8}px;
  align-items: center;
`;
export const Title = styled.Text`
  margin-bottom: 16px;
  font-size: 24px;
  font-family: "PoppinsBold";
  width: 90%;
  color: ${(props) => props.theme.colors.primary};
`;
export const InputField = styled.TextInput`
  background-color: ${(p) => p.theme.colors.moreMuted};
  height: 55px;
  margin: 8px 0;
  width: 90%;
  padding: 8px 16px;
  border-radius: 8px;
  /* border: solid ${(p) => p.theme.colors.secondary} 2px; */
`;
