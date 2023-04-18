import { useEffect, useState } from "react";
import { Appbar } from "react-native-paper";
import colors from "../../../infrastructure/theme/colors";
import { BgContainer } from "../../home/styles/Global.styles";
import {
    AddBloodDonation,
    Blood,
    BloodIcon,
    BloodType,
    Btn,
    Container,
    DonationCard,
    Img,
    Info,
    InputField,
    LocationIcon,
    LocationInfo,
    LocationMain,
    LocationSecondary,
    LocationSection,
    Name,
    Title,
} from "../styles/BloodDonationMain.styles";
import { bloodDonations as loadedDonations } from "../../../helpers/consts";
import {
    Btn as Button,
    BtnContent,
} from "../../questions/styles/MainQuestions.styles";
import { Button as ButtonPaper } from "react-native-paper";
import SelectDropdown from "react-native-select-dropdown";

const BloodDonationMain = ({ navigation, route }) => {
    const [donations, setDonations] = useState([]);
    const [visible, setVisible] = useState(false);
    useEffect(() => {
        setDonations(loadedDonations);
    }, []);
    return (
        <BgContainer>
            <Appbar.Header>
                <Appbar.BackAction
                    color={colors.primary}
                    onPress={() => {
                        navigation.goBack();
                    }}
                />
                <Appbar.Content
                    title="Blood Donation 🩸"
                    titleStyle={{
                        color: colors.primary,
                        fontFamily: "PoppinsBold",
                    }}
                />
            </Appbar.Header>
            <Container>
                {donations?.map((d) => (
                    <DonationCard
                        key={d.id}
                        style={{
                            elevation: 10,
                        }}
                    >
                        <Info>
                            <Img source={d.patientImg} />
                            <Name>{d.patientName}</Name>
                        </Info>
                        <BloodType>
                            <BloodIcon />
                            <Blood>{d.bloodGroup}</Blood>
                        </BloodType>
                        <LocationSection>
                            <LocationIcon />
                            <LocationInfo>
                                <LocationMain>
                                    {d.location.mainAddress}
                                </LocationMain>
                                <LocationSecondary>
                                    {d.location.secondaryAddress}
                                </LocationSecondary>
                            </LocationInfo>
                        </LocationSection>
                        <Btn onPress={() => console.log("👉", "handle")}>
                            Help
                        </Btn>
                    </DonationCard>
                ))}
            </Container>
            <AddBloodDonation
                onBackdropPress={() => setVisible(false)}
                isVisible={visible}
            >
                <Title>Add Donation Request</Title>
                <SelectDropdown
                    buttonStyle={{
                        backgroundColor: colors.moreMuted,
                        borderRadius: 32,
                        width: "90%",
                    }}
                    buttonTextStyle={{
                        fontFamily: "Poppins",
                        color: colors.primary,
                    }}
                    rowStyle={{
                        backgroundColor: colors.moreMuted,
                    }}
                    rowTextStyle={{
                        fontFamily: "Poppins",
                        color: colors.primary,
                    }}
                    search={true}
                    searchPlaceHolder="Enter Blood Type"
                    defaultButtonText="Select Blood Type"
                    data={["AB+", "AB-", "O+", "O-", "B+", "B-", "A+", "A-"]}
                    onSelect={(selectedItem, index) => {
                        console.log(selectedItem, index);
                    }}
                    buttonTextAfterSelection={(selectedItem, index) => {
                        // text represented after item is selected
                        // if data array is an array of objects then return selectedItem.property to render after item is selected
                        return selectedItem;
                    }}
                    rowTextForSelection={(item, index) => {
                        // text represented for each item in dropdown
                        // if data array is an array of objects then return item.property to represent item in dropdown
                        return item;
                    }}
                />
                <InputField placeholder="Enter Main Address" />
                <InputField placeholder="Enter detailed Address" />
                <ButtonPaper
                    buttonColor={colors.secondary}
                    textColor={colors.light}
                    style={{
                        marginTop: 8,
                        marginBottom: 8,

                        width: "50%",
                    }}
                    labelStyle={{ fontFamily: "Poppins" }}
                >
                    Add
                </ButtonPaper>
            </AddBloodDonation>
            {visible ? null : (
                <Button onPress={() => setVisible((prev) => !prev)}>
                    <BtnContent>+</BtnContent>
                </Button>
            )}
        </BgContainer>
    );
};

export default BloodDonationMain;
