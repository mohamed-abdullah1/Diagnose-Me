import { ScrollView } from "react-native";
import { TouchableOpacity } from "react-native";
import Modal from "react-native-modal";
import styled from "styled-components/native";
export const Container = styled(ScrollView)`
    z-index: -1;
`;
export const Btn = styled(TouchableOpacity)`
    width: 60px;
    height: 60px;
    background-color: ${(props) => props.theme.colors.secondary};
    align-items: center;
    justify-content: center;
    border-radius: 30px;
    position: absolute;
    bottom: 16px;
    right: 16px;
    z-index: 10000;
`;

export const BtnContent = styled.Text`
    color: ${(props) => props.theme.colors.light};
    font-size: 24px;
    font-family: "Poppins";
`;
export const AddQuestionModal = styled(Modal)`
    height: 500px;
    background-color: ${(props) => props.theme.colors.light};
    position: absolute;
    bottom: 0;
    left: 0;
    width: 100%;
    padding: 0;
    margin: 0;
`;
export const Wrapper = styled.View`
    flex: 1;
    align-items: center;
`;
