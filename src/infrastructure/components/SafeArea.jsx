import styled from "styled-components/native";
import { SafeAreaView, Platform, StatusBar } from "react-native";
import colors from "../theme/colors";
const SafeArea = styled(SafeAreaView)`
    flex: 1;
    padding-top: ${Platform.OS === "android"
        ? StatusBar.currentHeight - 20
        : 0}px;
    background-color: ${colors.light};
`;
export default SafeArea;
