import Top from "../components/Top";
import {
    Background,
    BottomBtnWrapper,
    Btn,
    Img,
    ImgContainer,
    Info,
    InfoDesc,
    InfoTitle,
    Type,
    TypesContainer,
} from "../styles/Shared.styles";
import Upper from "../components/Upper";
import { useState } from "react";

const typeOfAccounts = [
    {
        id: 1,
        title: "I Am A Patient",
        desc: "Find a doctor faster and medicines",
        src: require("../../../../assets/helpers/people.png"),
    },
    {
        id: 2,
        title: "I Am A Doctor",
        desc: "Manage your patients and meet online",
        src: require("../../../../assets/helpers/Doctor.png"),
    },
];

const RegistrationTypeOfAccount = ({ navigation }) => {
    const [typeAccount, setTypeAccount] = useState("none");
    const typePressHandler = (t) => setTypeAccount(t);
    const nextPressHandler = () => navigation.navigate("RegistrationAge");
    return (
        <Background>
            <Upper navigation={navigation} />
            <Top
                title="Type Of Account"
                desc="Choose the type and be carefull because it is impossible to change it again"
                widthDesc={250}
            />
            <TypesContainer>
                {typeOfAccounts.map((type) => (
                    <Type
                        onPress={() => typePressHandler(type.title)}
                        key={type.id}
                        typeAccount={typeAccount}
                        title={type.title}
                    >
                        <Info>
                            <InfoTitle>{type.title}</InfoTitle>
                            <InfoDesc>{type.desc}</InfoDesc>
                        </Info>
                        <ImgContainer>
                            <Img source={type.src} />
                        </ImgContainer>
                    </Type>
                ))}
            </TypesContainer>
            <BottomBtnWrapper>
                <Btn
                    mode="contained"
                    bgColor="secondary"
                    textColor="#fff"
                    width={323}
                    onPress={nextPressHandler}
                    disabled={typeAccount === "none"}
                >
                    Next
                </Btn>
            </BottomBtnWrapper>
        </Background>
    );
};
export default RegistrationTypeOfAccount;
