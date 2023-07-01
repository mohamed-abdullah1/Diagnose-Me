import { useState } from "react";
import { View } from "react-native";
import Top from "../components/Top";
import Upper from "../components/Upper";
import {
    Background,
    BottomBtnWrapper,
    Btn,
    ItemContent,
    ItemIcon,
    ItemRowEle,
    MainContentSpecialty,
    SelectWrapper,
    SpecialtyImg,
    SpecialtyImgContainer,
} from "../styles/Shared.styles";
import colors from "../../../infrastructure/theme/colors";
import SelectDropdown from "react-native-select-dropdown";
import { AntDesign } from "@expo/vector-icons";

//💁 HELPER /////////////////////
import { specialties as items } from "../../../helpers/consts";
const Icon = () => (
    <View
        style={{
            flex: 0.25,
            alignItems: "flex-end",
        }}
    >
        <AntDesign name="down" size={24} color={colors.primary} />
    </View>
);
const ItemRow = (item, index) => {
    return (
        <ItemRowEle>
            <ItemIcon source={items[index].src} />
            <ItemContent>{item}</ItemContent>
        </ItemRowEle>
    );
};
const BoxButton = ({ specialty }) => {
    return (
        <ItemRowEle>
            {specialty ? (
                <ItemIcon
                    source={
                        items?.filter((item) => item.value === specialty)[0].src
                    }
                />
            ) : null}
            <MainContentSpecialty>
                {specialty ? specialty : "Choose Your Specialty"}
            </MainContentSpecialty>
        </ItemRowEle>
    );
};

//😱 COMPONENT /////////////////////
const RegistrationSpecialty = ({ navigation }) => {
    const [specialty, setSpecialty] = useState("");
    const nextPressHandler = () => navigation.navigate("RegistrationHourPrice");
    return (
        <Background>
            <Upper navigation={navigation} />
            <Top
                title="What is your Specialty?"
                desc="Specify Your Specialty"
                widthDesc={323}
            />
            <SelectWrapper>
                <SelectDropdown
                    data={items.map((item) => item.value)}
                    onSelect={(selectedItem, index) =>
                        setSpecialty(selectedItem)
                    }
                    renderDropdownIcon={Icon}
                    renderCustomizedRowChild={ItemRow}
                    statusBarTranslucent={true}
                    renderCustomizedButtonChild={() => (
                        <BoxButton specialty={specialty} />
                    )}
                    buttonStyle={{
                        backgroundColor: colors.muted,
                        width: 322,
                        height: 73,
                        alignItems: "center",
                        justifyContent: "space-around",
                        borderColor: "red",
                        dropdownIconPosition: "right",
                        borderColor: "#fff",
                        borderRadius: 16,
                    }}
                    dropdownStyle={{
                        flex: 1,
                        borderRadius: 8,
                        backgroundColor: "white",
                        borderColor: "white",
                        padding: 8,
                    }}
                />
            </SelectWrapper>
            <SpecialtyImgContainer margin={0}>
                <SpecialtyImg
                    source={require("../../../../assets/helpers/doctors_2.png")}
                />
            </SpecialtyImgContainer>
            <BottomBtnWrapper>
                <Btn
                    onPress={nextPressHandler}
                    bgColor="secondary"
                    textColor="#fff"
                    width={323}
                >
                    Next
                </Btn>
            </BottomBtnWrapper>
        </Background>
    );
};
export default RegistrationSpecialty;
