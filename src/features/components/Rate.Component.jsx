import { AntDesign } from "@expo/vector-icons";
import styled from "styled-components/native";

const Wrapper = styled.View`
    width: 45.89px;
    height: 19px;
    background-color: ${(props) => props.theme.colors.yellow};
    border-radius: 50px;
    flex-direction: row;
    align-items: center;
    justify-content: center;
`;
const Icon = styled(AntDesign).attrs((props) => ({
    color: props.theme.colors.light,
    name: "star",
    size: 12,
}))``;
const Value = styled.Text`
    font-size: 11px;
    font-family: "PoppinsBold";
    color: ${(props) => props.theme.colors.light};
    margin-left: 5px;
`;
const Rate = ({ rate }) => {
    return (
        <Wrapper>
            <Icon />
            <Value>{rate}</Value>
        </Wrapper>
    );
};
export default Rate;
