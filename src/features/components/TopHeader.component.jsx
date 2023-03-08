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
            <TouchableOpacity onPress={onPressImg}>
                <CharImg source={userImg} />
            </TouchableOpacity>
        </Container>
    );
};
export default TopHeader;
