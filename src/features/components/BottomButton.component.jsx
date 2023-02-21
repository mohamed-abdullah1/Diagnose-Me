import { View } from "react-native";
import { Btn, ButtonWrapper, ContentBtn } from "../styles/BottomButton.styles";

const BottomButton = ({ label, bgColor }) => {
    return (
        <ButtonWrapper bgColor={bgColor}>
            <View style={{ borderRadius: 32, overflow: "hidden" }}>
                <Btn onPress={() => console.log("asdas")}>
                    <ContentBtn>{label}</ContentBtn>
                </Btn>
            </View>
        </ButtonWrapper>
    );
};
export default BottomButton;
