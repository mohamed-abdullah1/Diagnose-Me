import { AntDesign, Feather } from "@expo/vector-icons";
import { ScrollView } from "react-native";
import { Button } from "react-native-paper";
import styled from "styled-components/native";

export const Container = styled(ScrollView).attrs({
    contentContainerStyle: {
        alignItems: "center",
    },
})``;
export const Img = styled.Image`
    width: 326px;
    height: 317px;
    border-radius: 16px;
    border: 1px solid ${(p) => p.theme.colors.secondary};
`;
export const Title = styled.Text`
    font-size: 20px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
    margin: 8px 0;
    /* text-align: flex-start; */
    width: 85%;
`;
export const Price = styled.Text`
    font-size: 20px;
    font-family: "PoppinsBold";
    color: ${(props) => props.theme.colors.primary};
    /* margin: 8px 0; */
    /* text-align: flex-start; */
    width: 85%;
`;
export const SoldBy = styled.View`
    flex-direction: row;
    width: 85%;
    margin-top: 8px;
`;
export const SoldByIcon = styled(Feather).attrs((props) => ({
    name: "shopping-bag",
    size: 20,
    color: props.theme.colors.primary,
}))``;
// <Feather name="shopping-bag" size={24} color="black" />;
export const SoldByContent = styled.Text`
    margin-left: 8px;
    font-size: 12px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
export const Delivery = styled.View`
    flex-direction: row;
    width: 85%;
    margin-top: 8px;
`;
export const DeliveryIcon = styled(AntDesign).attrs((p) => ({
    color: p.theme.colors.primary,
    size: 20,
    name: "clockcircleo",
}))``;
<AntDesign name="clockcircleo" size={24} color="black" />;
export const DeliveryContent = styled.Text`
    margin-left: 8px;
    font-size: 12px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
export const AddBtn = styled(Button).attrs((props) => ({
    buttonColor: props.theme.colors.secondary,
    textColor: props.theme.colors.light,
    labelStyle: { fontSize: 16, fontFamily: "PoppinsBold" },
}))`
    margin: 16px;
    width: 50%;
`;
export const ProductInfo = styled.View`
    padding: 16px 0;
    width: 80%;
`;
export const InfoTitle = styled.Text`
    font-size: 20px;
    font-family: "PoppinsBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const Content = styled.Text`
    font-size: 14px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
