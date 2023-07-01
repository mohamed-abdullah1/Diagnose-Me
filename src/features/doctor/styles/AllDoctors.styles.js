import { AntDesign, Feather, FontAwesome, Ionicons } from "@expo/vector-icons";
import { ScrollView, TouchableOpacity } from "react-native";
import styled from "styled-components/native";

import responsive from "../../../helpers/responsive";

const { getX, getY } = responsive(832, 372);

export const DoctorCardContainer = styled.View`
    flex: 1;
    max-width: 50%;
    align-items: center;
    justify-content: center;
    margin-top: 8;
    margin-bottom: 8;
`;
