import styled from "styled-components/native";
import { TouchableOpacity } from "react-native";
export const UpperContainer = styled.View`
    position: absolute;
    top: 64px;
    width: 100%;
    flex-direction: row;
    align-items: center;
    justify-content: space-between;
    padding: 0 20px;
`;
export const Back = styled(TouchableOpacity)`
    justify-content: center;
    align-items: center;
`;
export const Skip = styled(TouchableOpacity)`
    width: 81.98px;
    height: 35.26px;
    background-color: ${(props) => props.theme.colors.blue};
    justify-content: center;
    align-items: center;
    border-radius: 32px;
`;
export const SkipContent = styled.Text`
    color: #fff;
    font-size: 14px;
    font-family: "Poppins";
`;
