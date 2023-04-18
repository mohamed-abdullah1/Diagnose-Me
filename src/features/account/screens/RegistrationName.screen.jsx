import { useState } from "react";
import { Keyboard } from "react-native";
import Top from "../components/Top";
import { Background, Btn, Form, InputField } from "../styles/Shared.styles";
import * as yup from "yup";
import { Formik } from "formik";
import Input from "../../components/Input.component";
import { Text } from "react-native";
import {
    selectRegisterUser,
    addInfo,
} from "../../../services/slices/registration.slice";
import { useDispatch, useSelector } from "react-redux";

const regNameSchema = yup.object({
    firstName: yup.string().required("First Name is Required"),
    lastName: yup.string().required("Last Name is Required"),
});

const RegistrationName = ({ navigation }) => {
    const [isKeyVisible, setIsKeyVisible] = useState(false);
    Keyboard.addListener("KeyboardDidShow", () => setIsKeyVisible(true));
    Keyboard.addListener("KeyboardDidHide", () => setIsKeyVisible(false));

    const dispatch = useDispatch();
    const registerUser = useSelector(selectRegisterUser);
    const proceedPressHandler = (values) => {
        navigation.navigate("RegistrationUserName");
        dispatch(addInfo(values));
    };

    return (
        <Background>
            <Top
                title="REGISTER"
                desc="Please enter your  First and Last name"
                widthDesc={250}
            />
            <Formik
                initialValues={{
                    firstName: registerUser?.firstName
                        ? registerUser.firstName
                        : "",
                    lastName: registerUser?.lastName
                        ? registerUser.lastName
                        : "",
                }}
                onSubmit={proceedPressHandler}
                validationSchema={regNameSchema}
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
                            label="First Name"
                            state={values.firstName}
                            setState={handleChange("firstName")}
                            onBlur={handleBlur("firstName")}
                            autoCapitalize="none"
                            error={errors.firstName && touched.firstName}
                        />
                        {errors.firstName && touched.firstName && (
                            <Text
                                style={{
                                    color: "red",
                                    width: "80%",
                                }}
                            >
                                {errors.firstName}
                            </Text>
                        )}
                        <Input
                            label="Last Name"
                            state={values.lastName}
                            setState={handleChange("lastName")}
                            onBlur={handleBlur("lastName")}
                            autoCapitalize="none"
                            error={errors.lastName && touched.lastName}
                        />
                        {errors.lastName && touched.lastName && (
                            <Text
                                style={{
                                    color: "red",
                                    width: "80%",
                                }}
                            >
                                {errors.lastName}
                            </Text>
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

export default RegistrationName;
