import { CharImg, Container } from "../styles/TopHeader.styles";
import { Feather } from "@expo/vector-icons";
import colors from "../../infrastructure/theme/colors";
import { TouchableOpacity } from "react-native";
const TopHeader = ({ onPress, onPressImg, userImg }) => {
  return (
    <Container>
      <TouchableOpacity onPress={onPress}>
        <Feather name="align-left" size={32} color={colors.primary} />
      </TouchableOpacity>
      <TouchableOpacity
        style={{
          borderColor: colors.secondary,
          borderWidth: 2,
          borderRadius: 50,
        }}
        onPress={onPressImg}
      >
        <CharImg source={{ uri: userImg }} />
      </TouchableOpacity>
    </Container>
  );
};
export default TopHeader;
