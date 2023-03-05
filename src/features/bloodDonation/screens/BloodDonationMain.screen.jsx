import { useEffect, useState } from "react";
import { Appbar } from "react-native-paper";
import colors from "../../../infrastructure/theme/colors";
import { BgContainer } from "../../home/styles/Global.styles";
import { Container } from "../styles/BloodDonationMain.styles";
import { bloodDonations as loadedDonations } from "../../../helpers/consts";

const BloodDonationMain = ({ navigation }) => {
    const [donations, setDonations] = useState([]);
    useEffect(() => {
        setDonations(loadedDonations);
    }, []);
    console.log("👉");
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
                {/* {donations?.map(d=><DonationCard key={d.id}>
                    <Info>
                        <Img/>
                        <Name>{d.patientName}</Name>
                    </Info>
                    <BloodType>
                        <BloodIcon/>
                        <Blood>{d.bloodGroup}</Blood>
                    </BloodType>
                </DonationCard>)} */}
            </Container>
        </BgContainer>
    );
};

export default BloodDonationMain;
