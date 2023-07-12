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
  changeIsReg,
  changeWantToBeDoctor,
  selectRegisterUser,
} from "../../../services/slices/registration.slice";
import { useDispatch, useSelector } from "react-redux";
import { useAddPriceMutation } from "../../../services/apis/medicalService";
import { logout, selectToken } from "../../../services/slices/auth.slice";
import { useEffect } from "react";

import { Toast } from "toastify-react-native";

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
  const [price, setPrice] = useState(0);
  const dispatch = useDispatch();
  const token = useSelector(selectToken);
  const [addPrice, { isSuccess, data, isLoading, isError, error }] =
    useAddPriceMutation();
  const pressHandler = (values) => {
    // if (!Object.keys(registerUser).includes(paramName)) {
    //   dispatch(addInfo(values));
    // }
    if (topTitle === "What is your Hour Price?") {
      console.log("👉", token);
      addPrice({ price, token });
    }
  };
  useEffect(() => {
    if (isSuccess) {
      Toast.success("Registered Successfully 🎉");
      dispatch(changeIsReg(false));
      dispatch(changeWantToBeDoctor(false));
      dispatch(logout());
      // navigationObj.navigate(navigateTo);
    }
  }, [isSuccess]);
  useEffect(() => {
    if (isError) {
      Toast.error(`Something went wrong 😢 ${Object.values(error)}`);
      console.error(error);
    }
  }, [error]);
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
      {/* <Formik
        initialValues={
          {
            //   [paramName]: registerUser[paramName] ? registerUser[paramName] : "",
          }
        }
        onSubmit={pressHandler}
        // validationSchema={regSchema}
      >
        {({
          handleChange,
          handleBlur,
          handleSubmit,
          values,
          errors,
          touched,
        }) => (
          <> */}
      <Form isKeyVisible={isKeyVisible}>
        <Input
          value={price}
          onChangeText={setPrice}
          label="Price Per session EGP"
          keyboardType="numeric"
          // label={inputPlaceHolder}
          // state={paramName && values[paramName]}
          // setState={handleChange(paramName)}
          // onBlur={handleBlur(paramName)}
          // error={errors.age && touched.age}
          // {...rest}
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
          loading={isLoading}
          disabled={price === 0}
          bgColor={price !== 0 ? "secondary" : "muted"}
          labelStyle={{ fontFamily: "Poppins" }}
        >
          Next
        </Btn>
      </BottomBtnWrapper>
      {/* </> */}
      {/* // )} */}
      {/* // </Formik> */}
    </Background>
  );
};
export default ComponentLayout;
