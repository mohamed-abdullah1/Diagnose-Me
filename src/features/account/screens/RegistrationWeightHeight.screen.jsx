import { useState } from "react";
import { Keyboard, Text } from "react-native";
import Top from "../components/Top";
import Upper from "../components/Upper";
import { Background, Btn, Form, InputField } from "../styles/Shared.styles";
import Input from "../../components/Input.component";
import { Formik } from "formik";
import * as yup from "yup";
import {
    addInfo,
    selectRegisterUser,
} from "../../../services/slices/registration.slice";
import { useDispatch, useSelector } from "react-redux";

const regSchema = yup.object({
    weight: yup.number().required("Your weight is Required"),
    height: yup.number().required("Your Height is Required"),
});
const RegistrationWeightHeight = ({ navigation, route }) => {
    const [isKeyVisible, setIsKeyVisible] = useState(false);

    Keyboard.addListener("KeyboardDidShow", () => setIsKeyVisible(true));
    Keyboard.addListener("KeyboardDidHide", () => setIsKeyVisible(false));
    console.log("👉 in weight", route.params);

    const registerUser = useSelector(selectRegisterUser);
    const dispatch = useDispatch();

    const pressHandler = (values) => {
        navigation.navigate("RegistrationBloodType");
        if (!Object.keys(registerUser).includes("weight")) {
            dispatch(addInfo(values));
        }
    };
    return (
        <Background>
            <Upper navigation={navigation} showSkip={false} />
            <Top
                title="Weight and Height"
                desc="Most Doctors Need it"
                widthDesc={250}
            />
            <Formik
                initialValues={{
                    weight: registerUser.weight ? registerUser.weight : "",
                    height: registerUser.height ? registerUser.height : "",
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
                    <Form isKeyVisible={isKeyVisible}>
                        <Input
                            label="Weight in Kg"
                            state={values.weight}
                            setState={handleChange("weight")}
                            onBlur={handleBlur("weight")}
                            icon={"weight-kilogram"}
                            error={errors.weight && touched.weight}
                            keyboardType="numeric"
                        />
                        {errors.weight && touched.weight && (
                            <Text
                                style={{
                                    color: "red",
                                    width: "80%",
                                }}
                            >
                                {errors.weight}
                            </Text>
                        )}
                        <Input
                            label="Height in meter"
                            state={values.height}
                            setState={handleChange("height")}
                            onBlur={handleBlur("height")}
                            icon={"human-male-height"}
                            error={errors.height && touched.height}
                            keyboardType="numeric"
                        />
                        {errors.height && touched.height && (
                            <Text
                                style={{
                                    color: "red",
                                    width: "80%",
                                }}
                            >
                                {errors.height}
                            </Text>
                        )}
                        <Btn
                            onPress={handleSubmit}
                            bgColor="secondary"
                            textColor="#fff"
                            width={323}
                        >
                            Next
                        </Btn>
                    </Form>
                )}
            </Formik>
        </Background>
    );
};

export default RegistrationWeightHeight;
