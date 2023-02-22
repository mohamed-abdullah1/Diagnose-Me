import { ScrollView } from "react-native";
import styled from "styled-components/native";

export const BgContainer = styled.View`
    background-color: #fffefe;
    flex: 1;
    /* border: solid red 1px; */
`;
export const HeaderContainer = styled.View`
    flex-direction: row;
    padding: 10px 24px;
    align-items: center;
`;
export const Hello = styled.Text`
    font-size: 24px;
    font-family: "PoppinsBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const Emoji = styled.Image`
    width: 33.52px;
    height: 33px;
    margin-left: 17px;
`;
export const CategoriesSection = styled.View`
    /* border: solid red 1px; */
    margin-top: ${(props) => (props.marginTop ? props.marginTop : 20)}px;
`;

export const CardsSection = styled(ScrollView).attrs({
    horizontal: true,
    showsHorizontalScrollIndicator: false,
})`
    padding: 0 ${(props) => (props.padding ? props.padding : 24)}px;
    margin-top: ${(props) => (props.marginTop ? props.marginTop : 8)}px;
    /* border: solid red 1px; */
`;
export const DoctorsSection = styled.View`
    margin-top: 20px;
    /* border: solid red 1px; */
`;
export const TrendQuestionsSection = styled.View`
    margin-top: 20px;
`;
