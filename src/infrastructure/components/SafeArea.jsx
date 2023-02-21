import styled from "styled-components/native";
import { SafeAreaView, Platform, StatusBar } from "react-native";
const SafeArea = styled(SafeAreaView)`
    flex: 1;
    margin-top: ${Platform.OS === "android"
        ? StatusBar.currentHeight - 20
        : 0}px;
    background-color: white;
`;
export default SafeArea;
