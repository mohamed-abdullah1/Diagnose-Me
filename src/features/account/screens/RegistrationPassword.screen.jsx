import { useState } from "react";
import { Keyboard, Text } from "react-native";
import Top from "../components/Top";
import {
    Circle,
    Background,
    Btn,
    Content,
    Form,
    InputField,
    Instruction,
    InstructionList,
    ContentContainer,
} from "../styles/Shared.styles";
import * as yup from "yup";
import Input from "../../components/Input.component";
import { Formik } from "formik";
import {
    addInfo,
    selectRegisterUser,
} from "../../../services/slices/registration.slice";
import { useDispatch, useSelector } from "react-redux";

const regSchema = yup.object({
    password: yup
        .string()
        .required("Your Password is Required")
        .min(8, "Password must be at least 8 characters")
        .matches(
            /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$/,
            "Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character"
        ),

    rePassword: yup
        .string()
        .required("Confirm Password is Required")
        .oneOf([yup.ref("password"), null], "Passwords must match"),
});
const RegistrationPassword = ({ navigation, route }) => {
    const [isKeyVisible, setKeyboardVisible] = useState(false);
    const [showPassword, setShowPassword] = useState(false);

    const registerUser = useSelector(selectRegisterUser);
    const dispatch = useDispatch();

    const proceedPressHandler = (values) => {
        navigation.navigate("RegistrationGender");
        if (!registerUser?.password) {
            dispatch(addInfo({ password: values.password }));
        }
    };
    Keyboard.addListener("keyboardDidShow", () => {
        setKeyboardVisible(true); // or some other action
    });
    Keyboard.addListener("keyboardDidHide", () => {
        setKeyboardVisible(false); // or some other action
    });

    return (
        <Background>
            <Top
                title="PASSWORD"
                desc="Please enter your New Password and Confirm it"
                widthDesc={250}
            />
            <Formik
                initialValues={{
                    password: registerUser?.password
                        ? registerUser.password
                        : "",
                    rePassword: registerUser?.password
                        ? registerUser.password
                        : "",
                }}
                onSubmit={proceedPressHandler}
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
                    <Form isKeyVisible={isKeyVisible} flexKeyIsHide={0.4}>
                        <Input
                            label="Password"
                            state={values.password}
                            setState={handleChange("password")}
                            onBlur={handleBlur("password")}
                            icon={showPassword ? "eye-off-outline" : "eye"}
                            iconPress={setShowPassword}
                            secureTextEntry={!showPassword}
                            error={errors.password && touched.password}
                        />
                        {errors.password && touched.password && (
                            <Text
                                style={{
                                    color: "red",
                                    width: "80%",
                                }}
                            >
                                {errors.password}
                            </Text>
                        )}
                        <Input
                            label="Confirm Password"
                            state={values.rePassword}
                            setState={handleChange("rePassword")}
                            onBlur={handleBlur("rePassword")}
                            icon={showPassword ? "eye-off-outline" : "eye"}
                            iconPress={setShowPassword}
                            secureTextEntry={!showPassword}
                            error={errors.rePassword && touched.rePassword}
                        />
                        {errors.rePassword && touched.rePassword && (
                            <Text
                                style={{
                                    color: "red",
                                    width: "80%",
                                }}
                            >
                                {errors.rePassword}
                            </Text>
                        )}
                        {!isKeyVisible && (
                            <InstructionList>
                                <Instruction>
                                    <Circle />
                                    <ContentContainer>
                                        <Content>At Least 8 Characters</Content>
                                    </ContentContainer>
                                </Instruction>
                                <Instruction>
                                    <Circle />
                                    <ContentContainer>
                                        <Content>
                                            Both uppercase and lowercase
                                        </Content>
                                    </ContentContainer>
                                </Instruction>
                                <Instruction>
                                    <Circle />
                                    <ContentContainer>
                                        <Content>
                                            at least one number or symbol
                                        </Content>
                                    </ContentContainer>
                                </Instruction>
                            </InstructionList>
                        )}
                        <Btn
                            onPress={handleSubmit}
                            bgColor="secondary"
                            textColor="#fff"
                            width={323}
                        >
                            Proceed
                        </Btn>
                    </Form>
                )}
            </Formik>
        </Background>
    );
};

export default RegistrationPassword;
