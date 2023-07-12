import { useEffect, useState } from "react";
import { StyleSheet, View } from "react-native";
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
import { TextInput } from "react-native-paper";
import {
  useAddSpecialtyBioForDoctorMutation,
  useGetSpecialtiesQuery,
} from "../../../services/apis/medicalService";
import { selectToken, selectUser } from "../../../services/slices/auth.slice";
import { useSelector } from "react-redux";
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
        // source={items?.filter((item) => item.value === specialty.value)[0].src} //TODO: add it when the backend be in azure
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
  const [title, setTitle] = useState("");
  const [bio, setBio] = useState("");
  const user = useSelector(selectUser);
  const token = useSelector(selectToken);
  const [addDocInfo, { isSuccess, isLoading, error }] =
    useAddSpecialtyBioForDoctorMutation();
  const { data: specialties } = useGetSpecialtiesQuery({ token, page: 1 });
  console.log(token, specialty);
  const nextPressHandler = () => {
    addDocInfo({
      token,
      doctorId: user.id,
      clinicId: specialty.key,
      title,
      bio,
    }); //TODO: FIX THE LICENCE AND ASK ALI FOR IT🤬
  };
  useEffect(() => {
    if (isSuccess) {
      navigation.navigate("RegistrationClinicLocation", { specialty });
    }
  }, [isSuccess]);
  useEffect(() => {
    if (error) {
      console.error(error);
    }
  }, [error]);
  return (
    <Background>
      {/* <Upper navigation={navigation} showSkip={false} /> */}
      <Top
        title="What is your Specialty?"
        desc="Specify Your Specialty"
        widthDesc={323}
        style={{
          justifyContent: "flex-start",
          marginTop: 0,
          marginBottom: 0,
        }}
        skip
      />
      <SelectWrapper>
        <SelectDropdown
          data={specialties?.map((item) => item.value)}
          onSelect={(selectedItem, index) => {
            console.log(
              selectedItem,
              specialties,
              specialties?.filter((x) => x.value === selectedItem)[0]
            );
            setSpecialty(
              specialties?.filter((x) => x.value === selectedItem)[0]
            );
          }}
          renderDropdownIcon={Icon}
          renderCustomizedRowChild={ItemRow}
          statusBarTranslucent={true}
          renderCustomizedButtonChild={() => (
            <BoxButton specialty={specialty?.value} />
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
        <View styles={{ alignItems: "center", width: "100%" }}>
          <TextInput
            placeholder="Title"
            style={[styles.input, { marginTop: 16 }]}
            mode="outlined"
            value={title}
            onChangeText={setTitle}
          />
          <TextInput
            placeholder="Bio"
            style={styles.input}
            mode="outlined"
            value={bio}
            onChangeText={setBio}
          />
        </View>
        <Btn
          onPress={nextPressHandler}
          bgColor="secondary"
          textColor="#fff"
          width={323}
          loading={isLoading}
        >
          Next
        </Btn>
      </SelectWrapper>
      {/* <SpecialtyImgContainer margin={0}>
                <SpecialtyImg
                    source={require("../../../../assets/helpers/doctors_2.png")}
                />
            </SpecialtyImgContainer> */}

      {/* <BottomBtnWrapper> */}
      {/* </BottomBtnWrapper> */}
    </Background>
  );
};
export default RegistrationSpecialty;
const styles = StyleSheet.create({
  container: {},
  input: {
    width: 323,
    height: 53,
    backgroundColor: colors.muted,
    borderRadius: 32,
    marginBottom: 16,
    paddingHorizontal: 16,
    justifyContent: "center",
  },
});
