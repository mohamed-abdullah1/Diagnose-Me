import { ScrollView } from "react-native";
import { Button } from "react-native-paper";
import styled from "styled-components/native";

export const Container = styled(ScrollView).attrs({
  contentContainerStyle: {
    paddingTop: 16,
    paddingBottom: 150,
  },
})``;
export const BlogCard = styled.View`
  margin-bottom: 24px;
  background-color: ${(props) => props.theme.colors.light};
  width: 95%;
  align-self: center;
  border-radius: 16px;
  padding: 16px;
  justify-content: center;
  align-items: center;
`;
export const Img = styled.Image`
  width: 100%;
  height: 193px;
  border-radius: 16px;
  border: solid ${(props) => props.theme.colors.secondary} 2px;
`;
export const Info = styled.View`
  /* border: solid red 1px; */
  margin-top: 8px;
  margin-bottom: 8px;
  flex: 1;
  width: 100%;
  flex-direction: row;
  justify-content: space-between;
`;
export const CategoryList = styled.View`
  flex: 1;
  /* border: solid red 1px; */
  flex-direction: row;
`;
export const CategoryItem = styled.Text`
  background-color: ${(props) => props.theme.colors.moreMuted};
  margin-right: 4px;
  border-radius: 16px;
  padding: 2px 4px;
  font-size: 11px;

  color: ${(props) => props.theme.colors.primary};
  font-family: "Poppins";
`;
export const Date = styled.Text`
  font-size: 13px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
  margin-right: 8px;
`;
export const BlogTitle = styled.Text`
  font-size: 16px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
  /* border: solid red 1px; */
  width: 100%;
`;
export const DocInfo = styled.View`
  flex-direction: row;
  width: 100%;
  margin-top: 8px;
  align-items: center;
`;
export const DocImg = styled.Image`
  width: 55px;
  height: 55px;
  border-radius: ${55 / 2}px;
`;
export const DocData = styled.View`
  margin-left: 12px;
`;
export const Name = styled.Text`
  font-size: 14px;
  font-family: "PoppinsBold";
  color: ${(props) => props.theme.colors.primary};
`;
export const Specialty = styled.Text`
  font-size: 12px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
`;
export const ReadMoreBtn = styled(Button).attrs((props) => ({
  buttonColor: props.theme.colors.secondary,
  textColor: props.theme.colors.light,
  contentStyle: {
    height: 38,
  },
  labelStyle: {
    fontFamily: "Poppins",
    fontSize: 12,
  },
}))`
  position: absolute;
  right: 0;
`;
