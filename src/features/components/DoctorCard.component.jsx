import { useNavigation } from "@react-navigation/native";
import { useState } from "react";
import {
    After,
    Before,
    IconContainer,
    Img,
    Name,
    Price,
    Specialty,
    Wrapper,
    Icon,
} from "../styles/DoctorCard.styles";
import Rate from "./Rate.Component";

const DoctorCard = ({ doctor, total, index, withOutMargins }) => {
    const [pinned, setPinned] = useState(false);
    const navigation = useNavigation();
    const { id, doctorImg, name, specialty, pricePerHour, rate } = doctor;

    const handlePinPress = () => setPinned((prev) => !prev);
    const doctorPressHandler = () => {
        console.log("I am Here 👊");
        navigation.navigate({
            name: "DoctorDetails",
            params: {
                doctorId: id,
            },
        });
    };
    return (
        <Wrapper
            withOutMargins={withOutMargins}
            style={{
                elevation: 8,
                shadowColor: "#000000bb",
                shadowOffset: { width: -2, height: 4 },
                shadowOpacity: 0.82,
                shadowRadius: 3,
            }}
            onPress={doctorPressHandler}
            total={total}
            index={index}
        >
            <IconContainer onPress={handlePinPress}>
                <Icon pinned={pinned} />
            </IconContainer>
            <Img
                style={{
                    elevation: 15,
                    shadowColor: "#000000bb",
                    shadowOffset: { width: -2, height: 4 },
                    shadowOpacity: 0.82,
                    shadowRadius: 3,
                }}
                source={doctorImg}
            />
            <Name>{"Dr. " + name}</Name>
            <Specialty>{specialty}</Specialty>
            <Price>
                <Before>{pricePerHour - 10 + ".00 LE"}</Before>
                <After>{pricePerHour + ".00 LE"}</After>
            </Price>
            <Rate rate={rate} />
        </Wrapper>
    );
};
export default DoctorCard;
