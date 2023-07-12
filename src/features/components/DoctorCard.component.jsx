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
import { imgUrl } from "../../services/apiEndPoint";
import colors from "../../infrastructure/theme/colors";

const DoctorCard = ({ doctor, total, index, withOutMargins }) => {
  const [pinned, setPinned] = useState(false);
  const navigation = useNavigation();
  console.log("doctor card ==", doctor);
  const {
    id,
    profilePictureUrl,
    fullName,
    clinicSpecialization: specialty,
    pricePerSession: pricePerHour,
    averageRate: rate,
  } = doctor;
  console.log(doctor);
  const handlePinPress = () => setPinned((prev) => !prev);
  const doctorPressHandler = () => {
    navigation.navigate({
      name: "DoctorDetails",
      params: {
        doctorId: id,
      },
    });
  };
  // const x = {
  //   averageRate: 0,
  //   bio: "I am a doctor",
  //   clinicAddresses: [],
  //   clinicId: "100fffa3-2f7e-0255-e693-9c2a0f6a42da",
  //   clinicSpecialization: "Dental",
  //   fullName: "Doctor",
  //   id: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
  //   isDoctor: true,
  //   isLicenseVerified: true,
  //   license: "123456789",
  //   name: "Doctor",
  //   numberOfPatients: 0,
  //   pricePerSession: 0,
  //   profilePictureUrl: "",
  //   title: "Dr",
  //   user: {
  //     fullName: "Doctor",
  //     id: "657cb6cb-abf2-00d1-5d46-939a7b3aff5f",
  //     isDoctor: true,
  //     name: "Doctor",
  //     profilePictureUrl: "",
  //   },
  //   yearsOfExperience: 0,
  // };
  return (
    <Wrapper
      withOutMargins={withOutMargins}
      style={{
        elevation: 4,
        shadowColor: "#000000bb",
        shadowOffset: { width: -2, height: 4 },
        shadowOpacity: 0.82,
        shadowRadius: 3,
        // borderColor: "red",
        // borderWidth: 1,
        marginLeft: 4,
      }}
      onPress={doctorPressHandler}
      total={total}
      index={index}
    >
      {/* <IconContainer onPress={handlePinPress}>
        <Icon pinned={pinned} />
      </IconContainer> */}
      <Img
        style={{
          elevation: 15,
          shadowColor: "#000000bb",
          shadowOffset: { width: -2, height: 4 },
          shadowOpacity: 0.82,
          shadowRadius: 3,
          borderColor: colors.secondary,
          borderWidth: 2,
        }}
        source={
          profilePictureUrl
            ? { uri: imgUrl + profilePictureUrl }
            : require("../../../assets/characters/male.png")
        }
      />
      <Name>{"Dr. " + fullName}</Name>
      <Specialty>{specialty}</Specialty>
      <Price>
        <Before>{pricePerHour + ".00 LE"}</Before>
        <After>{pricePerHour - 10 + ".00 LE"}</After>
      </Price>
      <Rate rate={rate} />
    </Wrapper>
  );
};
export default DoctorCard;
