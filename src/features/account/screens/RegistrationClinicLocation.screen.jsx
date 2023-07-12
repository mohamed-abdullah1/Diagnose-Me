import { useState } from "react";
import ComponentLayout from "../components/CommonLayout.component";
import { useAddClinicForDoctorMutation } from "../../../services/apis/medicalService";
import { BgContainer } from "../../home/styles/Global.styles";
import { Alert, ScrollView, StyleSheet } from "react-native";
import colors from "../../../infrastructure/theme/colors";
import { useEffect } from "react";
import {
  changeIsReg,
  changeWantToBeDoctor,
} from "../../../services/slices/registration.slice";
import { useDispatch, useSelector } from "react-redux";
import { selectToken, setUserInfo } from "../../../services/slices/auth.slice";
import { Button, TextInput } from "react-native-paper";

const RegistrationClinicLocation = ({ navigation, route }) => {
  const [location, setLocation] = useState("");
  const { specialty } = route.params;
  const [name, setName] = useState("");
  const [street, setStreet] = useState("");
  const [city, setCity] = useState("");
  const [state, setState] = useState("");
  const [country, setCountry] = useState("");
  const [zipCode, setZipCode] = useState("");
  const [openTime, setOpenTime] = useState("");
  const [closeTime, setCloseTime] = useState("");
  const [addClinic, { isSuccess, isLoading, error }] =
    useAddClinicForDoctorMutation();
  const token = useSelector(selectToken);
  const dispatch = useDispatch();
  const pressHandler = () => {
    addClinic({
      token,
      clinicId: specialty.key,
      name: name,
      street: street,
      city: city,
      state: state,
      country: country,
      zipCode: zipCode,
      openTime: openTime,
      closeTime: closeTime,
      latitude: "1",
      longitude: "1",
    });
  };
  // {
  //   "clinicId": "string",
  //   "name": "string",
  //   "street": "string",
  //   "city": "string",
  //   "state": "string",
  //   "country": "string",
  //   "zipCode": "string",
  //   "latitude": "string",
  //   "longitude": "string",
  //   "openTime": "string",
  //   "closeTime": "string",
  //   "base64Picture": "string"
  // }
  useEffect(() => {
    if (isSuccess) {
      console.log("xxx");
      navigation.navigate("RegistrationHourPrice");
    }
  }, [isSuccess]);
  useEffect(() => {
    if (error) {
      console.error(error);
    }
  }, [error]);
  return (
    <BgContainer>
      <ScrollView
        contentContainerStyle={{ flex: 1, alignItems: "center", width: "100%" }}
      >
        <TextInput
          placeholder="Name Of Clinic"
          style={[styles.input]}
          mode="outlined"
          value={name}
          onChangeText={setName}
        />
        <TextInput
          placeholder="Street"
          style={styles.input}
          mode="outlined"
          value={street}
          onChangeText={setStreet}
        />
        <TextInput
          placeholder="City"
          style={[styles.input]}
          mode="outlined"
          value={city}
          onChangeText={setCity}
        />
        <TextInput
          placeholder="State"
          style={styles.input}
          mode="outlined"
          value={state}
          onChangeText={setState}
        />
        <TextInput
          placeholder="Title"
          style={[styles.input]}
          mode="outlined"
          value={country}
          onChangeText={setCountry}
        />
        <TextInput
          placeholder="zipCode"
          style={styles.input}
          mode="outlined"
          value={zipCode}
          onChangeText={setZipCode}
        />
        <TextInput
          placeholder="openTime"
          style={[styles.input]}
          mode="outlined"
          value={openTime}
          onChangeText={setOpenTime}
        />
        <TextInput
          placeholder="closeTime"
          style={styles.input}
          mode="outlined"
          value={closeTime}
          onChangeText={setCloseTime}
        />
      </ScrollView>
      <Button onPress={pressHandler} loading={isLoading}>
        FINISH
      </Button>
    </BgContainer>
  );
};
export default RegistrationClinicLocation;
const styles = StyleSheet.create({
  container: {},
  input: {
    width: 323,
    height: 53,
    backgroundColor: colors.muted,
    borderRadius: 32,
    marginBottom: 8,
    paddingHorizontal: 16,
    justifyContent: "center",
  },
});
