import { useState } from "react";
import { Keyboard } from "react-native";
import {
    Background,
    BottomBtnWrapper,
    Btn,
    DoctorsImg,
    DoctorsImgContainer,
    Form,
    InputField,
} from "../styles/Shared.styles";
import Top from "./Top";
import Upper from "./Upper";

const ComponentLayout = ({
    topTitle,
    topDesc,
    topWidth,
    inputPlaceHolder,
    imgSrc,
    navigationObj,
    navigateTo,
    state,
    setState,
    imgWidth,
    imgHeight,
}) => {
    const [isKeyVisible, setIsKeyVisible] = useState(false);
    const pressHandler = () => navigationObj.navigate(navigateTo);
    Keyboard.addListener("keyboardDidShow", () => {
        setIsKeyVisible(true);
    });
    Keyboard.addListener("keyboardDidHide", () => {
        setIsKeyVisible(false);
    });
    return (
        <Background>
            <Upper navigation={navigationObj} />
            <Top title={topTitle} desc={topDesc} widthDesc={topWidth} />
            <Form isKeyVisible={isKeyVisible}>
                <InputField
                    placeholder={inputPlaceHolder}
                    onChangeText={setState}
                    value={state}
                />
            </Form>
            {!isKeyVisible && (
                <DoctorsImgContainer>
                    <DoctorsImg
                        imgHeight={imgHeight}
                        imgWidth={imgWidth}
                        source={imgSrc}
                    />
                </DoctorsImgContainer>
            )}
            <BottomBtnWrapper>
                <Btn
                    onPress={pressHandler}
                    bgColor="secondary"
                    textColor="#fff"
                    width={323}
                >
                    Next
                </Btn>
            </BottomBtnWrapper>
        </Background>
    );
};
export default ComponentLayout;
