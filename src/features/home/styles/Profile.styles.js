import { Dimensions, ScrollView } from "react-native";
import { TouchableOpacity } from "react-native";
import { Button } from "react-native-paper";
import styled from "styled-components/native";

export const Container = styled(ScrollView).attrs((props) => ({
    contentContainerStyle: {
        alignItems: "center",
    },
}))``;
export const ImgWrapper = styled.View`
    /* border: solid red 1px; */
`;
export const Img = styled.Image`
    width: 107px;
    height: 107px;
    border-radius: ${107 / 2}px;
    border: solid ${(p) => p.theme.colors.secondary} 3px;
`;
export const IconContainerCamera = styled(TouchableOpacity)`
    background-color: ${(p) => p.theme.colors.secondary};
    border-radius: 50px;
    justify-content: center;
    align-items: center;
    position: absolute;
    right: -10px;
    bottom: -10px;
    width: 40px;
    height: 40px;
    border: solid ${(p) => p.theme.colors.light} 2px;
`;
export const TopContainer = styled.View`
    /* position: absolute; */
    /* top: 0;
    left: 0; */
    width: 100%;
    max-height: 50px;
    flex-direction: row;
    flex: 1;
    justify-content: space-between;
    align-items: center;
    padding: 10px 24px;
    /* border: solid red 1px; */
`;
export const ChangeContainerIcon = styled(TouchableOpacity)``;
export const FlashContainerIcon = styled(TouchableOpacity)``;
export const Name = styled.Text`
    font-size: 16px;
    font-family: "PoppinsBold";
    color: ${(props) => props.theme.colors.primary};
    margin: 8px 0;
`;
export const Wrapper = styled.View`
    flex-direction: row;
    width: 70%;
    margin: 24px 0;
    justify-content: space-between;
`;
export const UserInfo = styled.Text`
    background-color: ${(props) => props.theme.colors.muted};
    font-size: 15px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
    padding: 8px 16px;
    border-radius: 32px;
`;
export const Ele = styled.View`
    /* border: solid red 1px; */
    width: 80%;
    flex-direction: row;
    justify-content: space-between;
    margin-bottom: 12px;
    padding-bottom: 16px;
`;
export const Info = styled.View`
    /* border: solid red 1px; */
`;
export const Title = styled.Text`
    font-size: 14px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const Value = styled.Text`
    font-size: 12px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
    background-color: ${(props) => props.theme.colors.muted};
    align-self: baseline;
    padding: 4px 8px;
    border-radius: 12px;
`;
export const EditBtn = styled(TouchableOpacity)`
    background-color: ${(props) => props.theme.colors.secondary};
    border-radius: 16px;
    height: 28px;
`;
export const EditBtnContent = styled.Text`
    font-size: 12px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.light};
    padding: 4px 12px;
`;
