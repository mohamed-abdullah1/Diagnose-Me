import Top from "../components/Top";
import { Background, Btn, Form, Reg, RegOption } from "../styles/Shared.styles";
import { useState } from "react";
import { Alert, Keyboard, Text, View } from "react-native";
import { useDispatch, useSelector } from "react-redux";
import { login, setUserInfo } from "../../../services/slices/auth.slice";
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
    const {
        data: userInfo,
        isLoading: infoLoading,
        error: infoError,
    } = useGetInfoQuery(data?.token);

    const [isKeyVisible, setIsKeyVisible] = useState(false);
    Keyboard.addListener("KeyboardDidShow", () => setIsKeyVisible(true));
    Keyboard.addListener("KeyboardDidHide", () => setIsKeyVisible(false));

    const submitHandler = async (values) => {
        await loginUser(values);
    };
    console.log("👉", infoLoading);
    useEffect(() => {
        if (!isSuccess) return console.log("👉", "not successful 🥲", data);
        if (data) {
            const { token } = data;
            dispatch(login({ token }));
            // console.log("👉data", data);
        }
    }, [data]);
    //
    useEffect(() => {
        if (userInfo) {
            dispatch(setUserInfo(userInfo));
        }
    }, [userInfo]);
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
                                error={errors.email && touched.email}
                            />
                            {errors.email && touched.email && (
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
                        </View>
                        <Btn
                            onPress={handleSubmit}
                            bgColor={isValid ? "secondary" : "muted"}
                            textColor="#fff"
                            width={323}
                            disabled={!isValid}
                            loading={isLoading || infoLoading}
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
        </Background>
    );
};
export default LoginScreen;
