import { useState } from "react";
import { FlatList } from "react-native";
import Top from "../components/Top";
import Upper from "../components/Upper";
import {
    Background,
    BloodGroup,
    BloodItem,
    BloodItemContent,
    BloodItemsContainer,
    BottomBtnWrapper,
    Btn,
    VectorBgContainer,
    VectorImg,
} from "../styles/Shared.styles";

const bloodGroups = [
    {
        id: 1,
        blood: "A+",
    },

    {
        id: 2,
        blood: "A-",
    },

    {
        id: 3,
        blood: "B+",
    },

    {
        id: 4,
        blood: "B-",
    },

    {
        id: 5,
        blood: "O+",
    },

    {
        id: 6,
        blood: "O-",
    },

    {
        id: 7,
        blood: "AB+",
    },

    {
        id: 8,
        blood: "AB-",
    },
];

const Item = ({ item, blood, setBlood }) => (
    <BloodItem
        onPress={() => setBlood(item.blood)}
        blood={blood}
        itemBlood={item.blood}
    >
        <BloodItemContent>{item.blood}</BloodItemContent>
    </BloodItem>
);

const RegistrationBloodType = ({ navigation }) => {
    const [blood, setBlood] = useState("none");
    const nextPressHandler = () => {
        console.log("hi");
        navigation.navigate("RegistrationSpecialty");
    };
    return (
        <Background>
            <Upper navigation={navigation} />
            <Top
                widthDesc={250}
                title="Blood Group"
                desc="Most Doctors Need it"
            />
            <BloodGroup>
                <BloodItemsContainer>
                    <FlatList
                        data={bloodGroups}
                        renderItem={({ item }) => (
                            <Item
                                setBlood={setBlood}
                                item={item}
                                blood={blood}
                            />
                        )}
                        keyExtractor={(item) => item.id}
                        numColumns={2}
                    />
                </BloodItemsContainer>
            </BloodGroup>
            <BottomBtnWrapper>
                <Btn
                    activeOpacity={blood === "none" ? 1 : 0.7}
                    disabled={blood === "none"}
                    mode="contained"
                    bgColor="secondary"
                    textColor="#fff"
                    width={323}
                    onPress={nextPressHandler}
                >
                    Next
                </Btn>
            </BottomBtnWrapper>
            <VectorBgContainer>
                <VectorImg
                    source={require("../../../../assets/helpers/bg.png")}
                />
            </VectorBgContainer>
        </Background>
    );
};
export default RegistrationBloodType;
