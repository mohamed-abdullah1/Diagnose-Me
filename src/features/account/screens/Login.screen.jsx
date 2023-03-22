import Top from "../components/Top";
import { Background, Btn, Form, Reg, RegOption } from "../styles/Shared.styles";
import { useState } from "react";
import { Alert, Keyboard, Text, View } from "react-native";
import { useDispatch, useSelector } from "react-redux";
import {
    login,
    selectError,
    setUserInfo,
} from "../../../services/slices/auth.slice";
import { useEffect } from "react";
import {
    useGetInfoQuery,
    useLoginMutation,
} from "../../../services/apis/auth.api";
import Input from "../../components/Input.component";
import * as yup from "yup";
import { Formik } from "formik";

const loginSchema = yup.object({
    email: yup
        .string()
        .email("Please Enter Valid email")
        .required("Your Email is Required"),
    password: yup.string().required("Your Password is Required"),
});

const LoginScreen = ({ navigation }) => {
    const [showPassword, setShowPassword] = useState(false);

    const [
        loginUser,
        { data, isSuccess, isError, error: loginError, isLoading },
    ] = useLoginMutation();
    const dispatch = useDispatch();
    const { data: userInfo } = useGetInfoQuery(data?.token);
    // const error = useSelector(selectError);
    const [isKeyVisible, setIsKeyVisible] = useState(false);
    Keyboard.addListener("KeyboardDidShow", () => setIsKeyVisible(true));
    Keyboard.addListener("KeyboardDidHide", () => setIsKeyVisible(false));

    const submitHandler = async (values) => {
        console.log("👉👉👉", values);
        await loginUser(values);
    };

    useEffect(() => {
        if (!isSuccess) return console.log("👉", "not successful 🥲", data);
        if (data) {
            const { token } = data;
            dispatch(login({ token }));
            console.log("👉data", data);
        }
        if (userInfo) {
            dispatch(setUserInfo(userInfo));
            console.log("👉userInfo", userInfo);
        }
    }, [data]);
    useEffect(() => {
        if (!isError) return;
        console.log("👉🚩", loginError.data.title);
        Alert.alert(
            //title
            "Error 📛",
            //body
            loginError.data.title,
            [
                {
                    text: "Try Again 🔁",
                    onPress: () => console.log("OK Pressed"),
                },
                {
                    text: "Forget Password ",
                    onPress: () => console.log("OK Pressed"),
                },
            ],
            { cancelable: true }
        );
    }, [isError]);
    return (
        <Background>
            <Top
                title="LOGIN"
                desc="Please enter your phone number and email address"
                widthDesc={250}
            />
            <Formik
                initialValues={{ email: "", password: "" }}
                onSubmit={submitHandler}
                validationSchema={loginSchema}
            >
                {({
                    handleChange,
                    handleBlur,
                    handleSubmit,
                    values,
                    errors,
                    isValid,
                    touched,
                }) => (
                    <Form isKeyVisible={isKeyVisible}>
                        <View style={{ width: "100%", alignItems: "center" }}>
                            <Input
                                label="Email"
                                state={values.email}
                                setState={handleChange("email")}
                                onBlur={handleBlur("email")}
                                textContentType="emailAddress"
                                keyboardType="email-address"
                                autoCapitalize="none"
                                icon="email"
                                error={errors.email}
                            />
                            {errors && touched && (
                                <Text
                                    style={{
                                        color: "red",
                                        width: "80%",
                                    }}
                                >
                                    {errors.email}
                                </Text>
                            )}
                        </View>
                        <View style={{ width: "100%", alignItems: "center" }}>
                            <Input
                                label="Password"
                                state={values.password}
                                setState={handleChange("password")}
                                onBlur={handleBlur("password")}
                                icon={showPassword ? "eye-off-outline" : "eye"}
                                iconPress={setShowPassword}
                                secureTextEntry={!showPassword}
                                error={errors.password}
                            />
                            {errors && touched && (
                                <Text
                                    style={{
                                        color: "red",
                                        width: "80%",
                                    }}
                                >
                                    {errors.password}
                                </Text>
                            )}
                        </View>
                        <Btn
                            onPress={handleSubmit}
                            bgColor={isValid ? "secondary" : "muted"}
                            textColor="#fff"
                            width={323}
                            disabled={!isValid}
                            loading={isLoading}
                        >
                            LOGIN
                        </Btn>
                    </Form>
                )}
            </Formik>
            <RegOption>
                Don't Have An Account ?{" "}
                <Reg onPress={() => navigation.navigate("RegistrationMain")}>
                    Register
                </Reg>
            </RegOption>
            {/* <BottomContainer>
        {!txtFocus ? <TitleOption>Or Continue With </TitleOption> : null}
        <FaceAndGoogleContainer>
          <Btn textColor="#fff" width="142" bgColor="blue">
            Facebook
          </Btn>
          <Btn
            textColor="#fff"
            width="142"
            bgColor="success"
            onPres={() => console.log("👉", "google")}
          >
            Google
          </Btn>
        </FaceAndGoogleContainer>
      </BottomContainer> */}
        </Background>
    );
};
export default LoginScreen;
