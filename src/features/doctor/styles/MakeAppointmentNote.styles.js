import { ScrollView, TouchableOpacity, TextInput } from "react-native";
import styled from "styled-components/native";

import responsive from "../../../helpers/responsive";

const { getX, getY } = responsive(832, 372);

export const Wrapper = styled.View`
    flex: 1;
`;
export const InputContainer = styled.View`
    flex: 1;
    padding: 0 ${getX(26)}px;
`;
export const InputField = styled(TextInput)`
    background-color: ${(props) => props.theme.colors.muted};
    color: ${(props) => props.theme.colors.primary};
    border-radius: 8px;
    font-size: 14px;
    font-family: "Poppins";
    &::placeholder {
        color: ${(props) => props.theme.colors.primary};
    }
    height: 196px;
    padding: 14px;
`;
