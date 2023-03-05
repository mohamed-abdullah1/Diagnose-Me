import { AntDesign, FontAwesome, FontAwesome5 } from "@expo/vector-icons";
import { ScrollView } from "react-native";
import styled from "styled-components/native";

export const Container = styled(ScrollView).attrs({
    contentContainerStyle: {
        alignItems: "center",
    },
})`
    margin: 18px 0;
`;
export const Title = styled.Text`
    font-size: 20px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
    text-align: center;
    width: 80%;
    /* border: solid red 1px; */
`;
export const DocData = styled.View`
    /* border: solid red 1px; */
    width: 50%;
    flex-direction: row;
    justify-content: space-between;
    margin-top: 20px;
    margin-bottom: 12px;
`;
export const Img = styled.Image`
    width: 65px;
    height: 65px;
    border-radius: ${65 / 2}px;
`;
export const Info = styled.View`
    margin-left: 8px;
`;
export const Name = styled.Text`
    font-size: 14px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const Specialty = styled.Text`
    font-size: 13px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
export const Date = styled.Text`
    font-size: 12px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
export const BlogImg = styled.Image`
    width: 95%;
    height: 191px;
    border-radius: 16px;
    border: solid ${(props) => props.theme.colors.secondary} 2px;
`;
export const Content = styled.Text`
    padding: 16px;
    font-size: 14px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
export const Wrapper = styled.View`
    flex-direction: row;
    width: 90%;
    justify-content: space-between;
    padding-top: 8px;
`;
export const LikesContainer = styled.View`
    flex-direction: row;
`;
export const LikeIcon = styled(AntDesign).attrs((props) => ({
    name: "heart",
    size: 24,
    color: props.theme.colors.red,
}))``;
export const UnLikeIcon = styled(AntDesign).attrs((props) => ({
    name: "hearto",
    size: 24,
    color: props.theme.colors.red,
}))``;
export const Likes = styled.Text`
    font-size: 16px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
    margin-right: 8px;
`;
export const SocialIcons = styled.View`
    flex-direction: row;
`;
export const Facebook = styled(FontAwesome).attrs((props) => ({
    name: "facebook-square",
    size: 24,
    color: props.theme.colors.primary,
}))`
    margin-right: 6px;
`;

export const Twitter = styled(FontAwesome).attrs((props) => ({
    name: "twitter-square",
    size: 24,
    color: props.theme.colors.primary,
}))`
    margin-right: 6px;
`;
export const LinkedIn = styled(FontAwesome5).attrs((props) => ({
    name: "linkedin",
    size: 24,
    color: props.theme.colors.primary,
}))``;
