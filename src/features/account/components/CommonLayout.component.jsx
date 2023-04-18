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
import { Formik } from "formik";
import Input from "../../components/Input.component";
import {
    addInfo,
    selectRegisterUser,
} from "../../../services/slices/registration.slice";
import { useDispatch, useSelector } from "react-redux";

const ComponentLayout = ({
    topTitle,
    topDesc,
    topWidth,
    imgSrc,
    navigationObj,
    navigateTo,
    imgWidth,
    imgHeight,
    regSchema,
    route,
    inputPlaceHolder,
    paramName,
    ...rest
}) => {
    const [isKeyVisible, setIsKeyVisible] = useState(false);
    const registerUser = useSelector(selectRegisterUser);
    const dispatch = useDispatch();

    const pressHandler = (values) => {
        navigationObj.navigate(navigateTo);
        if (!Object.keys(registerUser).includes(paramName)) {
            dispatch(addInfo(values));
        }
    };
    Keyboard.addListener("keyboardDidShow", () => {
        setIsKeyVisible(true);
    });
    Keyboard.addListener("keyboardDidHide", () => {
        setIsKeyVisible(false);
    });
    console.log("👉👉👉", paramName);
    return (
        <Background>
            <Upper navigation={navigationObj} showSkip={false} />
            <Top title={topTitle} desc={topDesc} widthDesc={topWidth} />
            <Formik
                initialValues={{
                    [paramName]: registerUser[paramName]
                        ? registerUser[paramName]
                        : "",
                }}
                onSubmit={pressHandler}
                validationSchema={regSchema}
            >
                {({
                    handleChange,
                    handleBlur,
                    handleSubmit,
                    values,
                    errors,
                    touched,
                }) => (
                    <>
                        <Form isKeyVisible={isKeyVisible}>
                            <Input
                                label={inputPlaceHolder}
                                state={paramName && values[paramName]}
                                setState={handleChange(paramName)}
                                onBlur={handleBlur(paramName)}
                                error={errors.age && touched.age}
                                {...rest}
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
                                onPress={handleSubmit}
                                bgColor="secondary"
                                textColor="#fff"
                                width={323}
                            >
                                Next
                            </Btn>
                        </BottomBtnWrapper>
                    </>
                )}
            </Formik>
        </Background>
    );
};
export default ComponentLayout;
