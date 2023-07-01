import {
    Skip,
    Back,
    UpperContainer,
    SkipContent,
} from "../styles/Upper.styles";
import { AntDesign } from "@expo/vector-icons";
import colors from "../../../infrastructure/theme/colors";
import { Btn } from "../styles/Shared.styles";
const Upper = ({ navigation, showSkip = true }) => {
    return (
        <UpperContainer>
            <Back onPress={() => navigation.goBack()}>
                <AntDesign name="arrowleft" size={24} color={colors.primary} />
            </Back>
            {showSkip ? (
                <Btn
                    height={35.26}
                    textColor="#fff"
                    width={81.98}
                    bgColor="blue"
                >
                    SKIP
                </Btn>
            ) : null}
        </UpperContainer>
    );
};

export default Upper;
