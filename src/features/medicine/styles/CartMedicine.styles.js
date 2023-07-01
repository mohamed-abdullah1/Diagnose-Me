import { Button, ScrollView } from "react-native";
import styled from "styled-components/native";

export const Container = styled(ScrollView).attrs({
    contentContainerStyle: {
        alignItems: "center",
        paddingTop: 16,
        paddingBottom: 16,
    },
})``;

export const ProductCard = styled.View`
    background-color: ${(p) => p.theme.colors.light};
    border-radius: 16px;
    width: 90%;
    margin-bottom: 16px;
    padding: 8px;
    flex-direction: row;
    align-items: center;
`;
export const Img = styled.Image`
    width: 88px;
    height: 93px;
    border-radius: 16px;
    /* border: solid ${(p) => p.theme.colors.secondary} 1px; */
`;
export const InfoContainer = styled.View`
    width: 40%;
    justify-content: center;
    /* border: solid red 1px; */
`;
export const Title = styled.Text`
    font-size: 14px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
    padding: 8px 8px;
    /* justify-content: center; */
`;

export const CountContainer = styled.View`
    flex-direction: row;
    align-items: center;
    justify-content: space-around;
`;
export const Count = styled.Text`
    /* margin: 0 16px; */
`;
export const DeleteContainer = styled.View`
    width: 40%;
    /* border: solid red 1px; */
    /* justify-content: space-around; */
    align-items: center;
`;
export const Price = styled.Text`
    margin-top: 24px;
    font-size: 16px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
