import styled from "styled-components/native";

import responsive from "../../../helpers/responsive";

const { getX, getY } = responsive(832, 372);

export const Container = styled.View`
    /* border: solid red 1px; */
    flex: 1;
    width: ${getX(329)}px;
    padding-top: 24px;
    flex-direction: row;
    justify-content: space-around;
    align-items: center;
`;
export const Img = styled.Image`
    width: 88px;
    height: 86px;
`;
export const DataContainer = styled.View``;
export const Name = styled.Text`
    font-size: 20px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
    margin-left: -8px;
`;
export const Specialty = styled.Text`
    /* margin-top: ${getY(15)}px; */
    font-size: 15px;
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
export const RatingContainer = styled.View`
    flex-direction: row;
    /* border: solid red 1p x; */
    align-items: center;
`;
export const Number = styled.Text`
    margin-left: 8px;
    margin-bottom: 4px;
`;
