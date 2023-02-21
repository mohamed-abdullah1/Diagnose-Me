import styled from "styled-components/native";

const marginPos = {
  top: "margin-top",
  bottom: "margin-bottom",
  left: "margin-left",
  right: "margin-right",
};

const SpacerCom = styled.View`
  ${(props) => marginPos[props.pos]} : ${(props) => props.s}px;
`;
const Spacer = ({ children, position, size }) => {
  return (
    <SpacerCom pos={position} s={size}>
      {children}
    </SpacerCom>
  );
};
export default Spacer;
