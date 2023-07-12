import { Image } from "react-native";
import styled from "styled-components/native";
export const Container = styled.View`
  /* border: solid red 1px; */
  flex-flow: row;
  justify-content: space-between;
  align-items: center;
  padding: 10px 24px;
  margin-top: 16px;
`;
export const CharImg = styled(Image)`
  width: 50px;
  height: 50px;
  border-radius: 50px;
`;
