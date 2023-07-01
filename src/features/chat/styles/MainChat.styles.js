import { ScrollView, TouchableOpacity } from "react-native";
import styled from "styled-components/native";

import responsive from "../../../helpers/responsive";

const { getX, getY } = responsive(832, 372);

export const Wrapper = styled(ScrollView)`
    flex: 1;
    /* margin-top: 40px; */
    /* border: solid red 1px; */
`;
export const Title = styled.Text`
    font-size: 24px;
    font-family: "PoppinsBold";
    color: ${(props) => props.theme.colors.primary};
    padding-top: 20px;
    padding-bottom: 8px;
    padding-left: 24px;
`;
