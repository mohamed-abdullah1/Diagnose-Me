import { useState } from "react";
import Top from "../components/Top";
import { Background, Btn, Form, InputField } from "../styles/Shared.styles";
import { Keyboard } from "react-native";
import * as yup from "yup";
import Input from "../../components/Input.component";
import { Formik } from "formik";
import { Text } from "react-native";
import { useDispatch, useSelector } from "react-redux";
import {
    selectRegisterUser,
    addInfo,
} from "../../../services/slices/registration.slice";

const regSchema = yup.object({
    email: yup
        .string()
        .email("Please Enter Valid email")
        .required("Your Email is Required"),
    phoneNumber: yup
        .string()
        .matches(/^\+?\d{10,14}$/, "Phone number is not valid")
        .required("Phone Number Is Required"),
});

const RegistrationMain = ({ navigation }) => {
    const [isKeyVisible, setIsKeyVisible] = useState(false);

    const dispatch = useDispatch();

    const registerUser = useSelector(selectRegisterUser);
    Keyboard.addListener("KeyboardDidShow", () => setIsKeyVisible(true));
    Keyboard.addListener("KeyboardDidHide", () => setIsKeyVisible(false));
    const submitHandler = async (values) => {
        dispatch(addInfo(values));
        navigation.navigate("RegistrationName");
    };
    return (
        <Background>
            <Top
                title="REGISTER"
                desc="Please enter your Phone Number and Email"
                widthDesc={250}
            />
            <Formik
                initialValues={{
                    email: registerUser?.email ? registerUser?.email : "",
                    phoneNumber: registerUser?.phoneNumber
                        ? registerUser?.phoneNumber
                        : "",
                }}
                onSubmit={submitHandler}
                validationSchema={regSchema}
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
                        <Input
                            label="Phone Number"
                            keyboardType="numeric"
                            state={values.phoneNumber}
                            setState={handleChange("phoneNumber")}
                            onBlur={handleBlur("phoneNumber")}
                            autoCapitalize="none"
                            icon="cellphone"
                            error={errors.phoneNumber && touched.phoneNumber}
                        />
                        {errors.phoneNumber && touched.phoneNumber && (
                            <Text
                                style={{
                                    color: "red",
                                    width: "80%",
                                }}
                            >
                                {errors.phoneNumber}
                            </Text>
                        )}
                        {/* <Input placeholder="Phone Number" /> */}

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

export default RegistrationMain;
