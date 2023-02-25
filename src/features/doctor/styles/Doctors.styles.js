import { AntDesign, Ionicons } from "@expo/vector-icons";
import { ScrollView, TextInput, TouchableOpacity } from "react-native";
import styled from "styled-components/native";

import responsive from "../../../helpers/responsive";

const { getX, getY } = responsive(832, 372);

export const BackContainer = styled(TouchableOpacity)`
    /* border: solid red 1px; */
    width: 90%;
    align-self: center;
    margin-top: 16px;
`;
export const BackIcon = styled(Ionicons).attrs((props) => ({
    name: "arrow-back-outline",
    size: 24,
    color: props.theme.colors.primary,
}))``;

export const Title = styled.Text`
    font-size: 24px;
    font-family: "PoppinsBold";
    color: ${(props) => props.theme.colors.primary};
    align-self: center;
    width: 90%;
    /* border: solid red 1px; */
    /* margin-top: 16px; */
`;
export const SearchContainer = styled.View`
    flex-direction: row;
    background-color: ${(props) => props.theme.colors.light};
    border-radius: 32px;
    /* border: solid ${(props) => props.theme.colors.primary} 1px; */
    justify-content: space-between;
    align-items: center;
    align-self: center;
    width: 90%;
    height: 50px;
    padding: 14px;
    margin-top: 8px;
    margin-bottom: 16px;
`;
export const SearchIcon = styled(AntDesign).attrs((props) => ({
    name: "search1",
    size: 24,
    color: props.theme.colors.primary,
}))``;
export const SearchText = styled(TextInput)`
    flex: 1;
    margin-left: 8px;
    margin-right: 8px;
    &:placeholder {
        color: ${(props) => props.theme.colors.primary};
    }
`;
export const FilterIcon = styled(Ionicons).attrs((props) => ({
    name: "filter-outline",
    size: 24,
    color: props.theme.colors.primary,
}))``;
export const NotFoundContainer = styled.View`
    flex: 1;
    align-items: center;
    justify-content: center;
`;
export const ButtonContainer = styled(TouchableOpacity)`
    /* border: solid red 1px; */
    align-items: baseline;
    background-color: ${(props) => props.theme.colors.secondary};
    padding: 10px;
    border-radius: 32px;
`;
export const Button = styled.View``;
export const ButtonContent = styled.Text`
    font-size: 12px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.light};
`;

export const Img = styled.Image`
    object-fit: cover;
    align-self: center;
    justify-self: center;
    /* flex: 1; */
    max-width: 300px;
    max-height: 200px;
    /* border: solid red 1px; */
`;
