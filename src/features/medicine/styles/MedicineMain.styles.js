import { ScrollView, TouchableOpacity } from "react-native";
import { Button } from "react-native-paper";
import styled from "styled-components/native";

export const MedicineCard = styled(TouchableOpacity)`
    max-width: 45%;
    min-width: 45%;
    /* border: solid red 1px; */
    justify-content: space-between;
    align-items: center;
    border-radius: 16px;
    background-color: ${(props) => props.theme.colors.light};
    padding: 16px;
    /* margin-bottom: 16px; */
    margin: 8px;
`;
export const Img = styled.Image`
    width: 116px;
    height: 140px;
    border-radius: 16px;
    border: solid 1px ${(props) => props.theme.colors.secondary};
`;
export const Title = styled.Text`
    margin: 8px 0;
    font-size: 14px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
export const AddBtn = styled(Button).attrs((props) => ({
    buttonColor: props.theme.colors.secondary,
    textColor: props.theme.colors.light,
    labelStyle: {
        fontFamily: "Poppins",
        fontSize: 12,
    },
}))`
    width: 80%;
    height: 38px;
`;
export const CategoriesContainer = styled(ScrollView).attrs({
    horizontal: true,
    contentContainerStyle: {
        height: 60,
    },
})`
    padding: 0px 8px;
    /* border: solid red 1px; */
    margin-top: 16px;
`;
export const CategoryItem = styled.Text`
    margin-right: 12px;
    background-color: ${(props) =>
        props.current === props.category
            ? props.theme.colors.focused
            : props.theme.colors.moreMuted};
    align-self: baseline;
    padding: 8px 16px;
    border-radius: 16px;
    font-size: 14px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
