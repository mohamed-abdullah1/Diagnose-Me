import { useState } from "react";
import Top from "../components/Top";
import Upper from "../components/Upper";
import {
  Background,
  BottomBtnWrapper,
  Btn,
  CharImg,
  CharImgContainer,
  GenderContainer,
  GenderType,
  MalesContainer,
} from "../styles/Shared.styles";
import { Appbar, Button } from "react-native-paper";
import { View } from "react-native";
import colors from "../../../infrastructure/theme/colors";
import {
  addInfo,
  selectRegisterUser,
} from "../../../services/slices/registration.slice";
import { useDispatch, useSelector } from "react-redux";
import { useEffect } from "react";

const data = [
  {
    id: 1,
    title: "Male",
    src: require("../../../../assets/helpers/male_1.png"),
  },
  {
    id: 2,
    title: "Female",
    src: require("../../../../assets/helpers/female_1.png"),
  },
];

const RegistrationGender = ({ navigation, route }) => {
  const [maleOrFemale, setMaleOrFemale] = useState("none");
  const registerUser = useSelector(selectRegisterUser);
  const dispatch = useDispatch();

  const pressHandler = (type) => {
    setMaleOrFemale(type);
  };
  const nextPressHandler = () => {
    if (maleOrFemale !== "none") {
      navigation.navigate("RegistrationBloodType");
      // if (!registerUser.gender) {
      dispatch(addInfo({ gender: maleOrFemale }));
      // }
    }
  };
  useEffect(() => {
    setMaleOrFemale(registerUser?.gender ? registerUser.gender : "none");
  }, []);
  return (
    <Background>
      <Upper navigation={navigation} showSkip={false} />
      <View style={{ marginBottom: 60 }}>
        <Top
          title="What Is Your GENDER?"
          desc="To get better experience we need to know your gender"
          widthDesc={250}
        />
      </View>
      <MalesContainer>
        {data.map((ele) => (
          <GenderContainer
            onPress={() => pressHandler(ele.title)}
            key={ele.id}
            title={ele.title}
            maleOrFemale={maleOrFemale}
          >
            <GenderType>{ele.title}</GenderType>
            <CharImgContainer>
              <CharImg source={ele.src} />
            </CharImgContainer>
          </GenderContainer>
        ))}
      </MalesContainer>
      <BottomBtnWrapper>
        <Btn
          activeOpacity={maleOrFemale === "none" ? 1 : 0.7}
          disabled={maleOrFemale === "none"}
          mode="contained"
          bgColor="secondary"
          textColor="#fff"
          width={323}
          onPress={nextPressHandler}
        >
          Next
        </Btn>
      </BottomBtnWrapper>
    </Background>
  );
};

export default RegistrationGender;
