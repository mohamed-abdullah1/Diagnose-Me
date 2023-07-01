import { AntDesign } from "@expo/vector-icons";
import styled from "styled-components/native";

const Wrapper = styled.View`
    width: 50.89px;
    height: 30px;
    background-color: ${(props) => props.theme.colors.yellowLight};
    border-radius: 50px;
    flex-direction: row;
    align-items: center;
    justify-content: center;
    padding: 4px;
`;
const Icon = styled(AntDesign).attrs((props) => ({
    color: props.theme.colors.yellowMore,
    name: "star",
    size: 12,
}))``;
const Value = styled.Text`
    font-size: 11px;
    font-family: "PoppinsBold";
    color: ${(props) => props.theme.colors.black};
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
