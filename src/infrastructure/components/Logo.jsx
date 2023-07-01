import { View } from "react-native";
import styled from "styled-components/native";

const Bg = styled.View`
  width: 86px;
  height: 86px;
  border-radius: ${86 / 2}px;
  /* background-color: ${(props) => "#fff"}; */

  background-color: ${(props) => props.theme.colors.muted};
  justify-content: center;
  align-items: center;
`;
const Img = styled.Image`
  width: 106px;
  height: 86px;
`;

const Logo = () => {
  return (
    <View>
      <Bg>
        <Img style={{}} source={require("../../../assets/logo_3.png")} />
      </Bg>
    </View>
  );
};
export default Logo;
