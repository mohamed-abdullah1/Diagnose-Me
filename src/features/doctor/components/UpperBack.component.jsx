import { Ionicons } from "@expo/vector-icons";
import { useNavigation } from "@react-navigation/native";
import { Platform, StatusBar } from "react-native";
import styled from "styled-components/native";

import { w, h } from "../../../helpers/responsive";
import responsive from "../../../helpers/responsive";

const { getX, getY } = responsive(840, 395);
const Container = styled.Pressable`
    width: ${w}px;
    /* border: solid red 1px; */
    position: absolute;
    /* top: ${Platform.OS === "android"
        ? getY(StatusBar.currentHeight)
        : 0}px; */
    top: ${(props) => props.top}px;
    left: ${(props) => props.left}px;
    z-index: -2;
`;
const Icon = styled(Ionicons).attrs((props) => ({
    name: "arrow-back",
    size: 24,
    color: props.theme.colors.primary,
}))``;
const UpperBack = ({ top, left }) => {
    const navigation = useNavigation();
    return (
        <Container top={top} left={left} onPress={() => navigation.goBack()}>
            <Icon />
        </Container>
    );
};
export default UpperBack;
