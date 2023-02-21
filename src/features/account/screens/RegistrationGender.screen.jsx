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

const RegistrationGender = ({ navigation }) => {
    const [maleOrFemale, setMaleOrFemale] = useState("none");
    const pressHandler = (type) => {
        setMaleOrFemale(type);
    };
    const nextPressHandler = () => {
        if (maleOrFemale !== "none") {
            navigation.navigate("RegistrationTypeOfAccount");
        }
    };
    return (
        <Background>
            <Upper navigation={navigation} />
            <Top
                title="What Is Your GENDER?"
                desc="To get better experience we need to know your gender"
                widthDesc={250}
            />
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
