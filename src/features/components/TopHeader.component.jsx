import { CharImg, Container } from "../styles/TopHeader.styles";
import { Feather } from "@expo/vector-icons";
import colors from "../../infrastructure/theme/colors";
import { TouchableOpacity } from "react-native";
const TopHeader = () => {
    return (
        <Container>
            <TouchableOpacity>
                <Feather name="align-left" size={32} color={colors.primary} />
            </TouchableOpacity>
            <CharImg source={require("../../../assets/characters/male.png")} />
        </Container>
    );
};
export default TopHeader;
