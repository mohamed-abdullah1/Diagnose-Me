import { View } from "react-native";
import { Btn, ButtonWrapper, ContentBtn } from "../styles/BottomButton.styles";

const BottomButton = ({ label, bgColor, pressFunction }) => {
    return (
        <ButtonWrapper
            style={{
                width: "100%",
            }}
            bgColor={bgColor}
        >
            <View style={{ borderRadius: 32, overflow: "hidden" }}>
                <Btn onPress={() => pressFunction()}>
                    <ContentBtn>{label}</ContentBtn>
                </Btn>
            </View>
        </ButtonWrapper>
    );
};
export default BottomButton;
