import { useEffect, useState } from "react";
import { ActivityIndicator, Appbar } from "react-native-paper";
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
  StatusIcon,
  Title,
} from "../styles/BloodDonationMain.styles";
import { bloodDonations as loadedDonations } from "../../../helpers/consts";
import {
  Btn as Button,
  BtnContent,
} from "../../questions/styles/MainQuestions.styles";
import { Button as ButtonPaper } from "react-native-paper";
import SelectDropdown from "react-native-select-dropdown";
import { Ionicons, MaterialIcons } from "@expo/vector-icons";
import { selectToken, selectUser } from "../../../services/slices/auth.slice";
import { useSelector } from "react-redux";
import {
  useGetRequestsQuery,
  useMakeDonationReqMutation,
} from "../../../services/apis/blood.api";
import { Alert, Pressable, View } from "react-native";
import theme from "../../../infrastructure/theme";
import { imgUrl } from "../../../services/apiEndPoint";
import {
  CategoriesContainer,
  CategoryItem,
} from "../../medicine/styles/MedicineMain.styles";
import { useRef } from "react";
import { StyleSheet } from "react-native";
import { Content } from "../../schedule/styles/ScheduleMain.styles";
import { useCreateAccessChatMutation } from "../../../services/apis/chat.api";
import useSocketSetup from "../../../helpers/useSocketSetup";

const bloodTypes = [
  { key: 1, value: "A+" },
  { key: 2, value: "A-" },
  { key: 3, value: "B+" },
  { key: 4, value: "B-" },
  { key: 5, value: "AB+" },
  { key: 6, value: "AB-" },
  { key: 7, value: "O+" },
  { key: 8, value: "O-" },
];

const BloodDonationMain = ({ navigation, route }) => {
  // const [donations, setDonations] = useState([]);
  const [visible, setVisible] = useState(false);
  const token = useSelector(selectToken);
  const currentUser = useSelector(selectUser);
  const [page, setPage] = useState(1);
  const [press, setPress] = useState(false);
  const scroll = useRef();
  const [location, setLocation] = useState("");
  const [reason, setReason] = useState("");
  const [selectedBloodType, setSelectedBloodType] = useState("");

  //get the donations requests
  const {
    data: donations,
    isLoading: donationIsLoading,
    error: donationError,
    isSuccess: donationIsSuccess,
    isError: donationIsError,
    isFetching: donationIsFetching,
    refetch,
  } = useGetRequestsQuery({ token, page, bloodType: currentUser.bloodType });
  console.log("xxxxxx", currentUser);
  //make donation request
  const [
    make,
    {
      isLoading: makeDonationIsLoading,
      error: makeDonationError,
      isSuccess: makeDonationIsSuccess,
      isError: makeDonationIsError,
    },
  ] = useMakeDonationReqMutation();

  //chat
  const [
    makeChat,
    { data: chat, isSuccess: chatIsSuccess, isLoading: makeChatIsLoading },
  ] = useCreateAccessChatMutation();

  const handlePagination = (type) => {
    scrollViewRef.current?.scrollTo({ y: 0, animated: true });
    setPage((prev) => (type === "add" ? prev + 1 : prev - 1));
  };
  useEffect(() => {
    if (donationIsError) {
      Alert.alert("Error", "Something went wrong, please try again later");
      console.error(donationError);
    }
  }, [donationIsError]);

  const handleSubmit = () => {
    console.log({ reason, location, selectedBloodType });
    if (location !== "" && reason !== "" && selectedBloodType !== "") {
      make({
        token,
        reason,
        type: "Blood",
        location,
        bloodType: selectedBloodType,
      });
    } else {
      Alert.alert("Error", "Please fill all the fields");
    }
  };
  const socket = useSocketSetup();
  const handleChat = (userId) => {
    // create or access a chat between patient and doctor and start talking
    makeChat({ token, userId: userId });
    console.log("handled");
  };
  useEffect(() => {
    if (chatIsSuccess) {
      console.log("👉🗣️chat", chat.users.length, chat?.users);
      chat?.users.filter((user) => user._id !== currentUser.id)[0];
      navigation.navigate("Messages", {
        screen: "Chat",
        params: {
          chatId: chat?._id,
          otherPerson: chat?.users.filter(
            (user) => user._id !== currentUser.id
          )[0],
          socket,
        },
      });
    }
  }, [chatIsSuccess]);

  useEffect(() => {
    if (makeDonationIsError) {
      Alert.alert("Error", "Something went wrong, please try again late");
      console.error(makeDonationError);
    }
  }, [makeDonationError]);
  useEffect(() => {
    if (makeDonationIsSuccess) {
      setVisible(false);
      setLocation("");
      setReason("");
      setSelectedBloodType("");
      refetch();
    }
  }, [makeDonationIsSuccess]);
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
      {/* <CategoriesContainer
        style={{ maxHeight: 58, marginBottom: 6, marginLeft: 32 }}
        ref={scroll}
      >
        {bloodTypes?.map((s) => (
          <Pressable
            key={s.key}
            onPress={() => {
              setBloodType(s.value === "all" ? "" : s.value);
              setPage(1);
              setPress(true);
            }}
            onPressOut={() => setPress(false)}
          >
            <CategoryItem
              // style={{
              //   backgroundColor: press ? colors.primary : colors.secondary,
              // }}
              category={s.value}
              current={bloodType === "" ? "all" : bloodType}
            >
              {s.value}
            </CategoryItem>
          </Pressable>
        ))}
      </CategoriesContainer> */}

      <Container>
        {donationIsFetching || donationIsLoading ? (
          <View>
            {/* TODO: add activity indicator */}
            <ActivityIndicator
              animating={donationIsLoading || donationIsFetching}
              color={theme.colors.primary}
            />
          </View>
        ) : (
          <>
            {donations?.objects?.map((d) => (
              <DonationCard
                key={d.id}
                style={{
                  elevation: 10,
                }}
              >
                <Info>
                  <Img
                    source={
                      d.requester.profilePictureUrl
                        ? { uri: imgUrl + d.requester.profilePictureUrl }
                        : require("../../../../assets/characters/male.png")
                    }
                  />
                  <Name>{d.requester.fullName}</Name>
                </Info>
                <View style={styles.container}>
                  <View style={styles.row}>
                    <BloodType>
                      <BloodIcon />
                      <Blood>{d.bloodType}</Blood>
                    </BloodType>
                    <BloodType>
                      <StatusIcon />
                      <LocationInfo>
                        <LocationMain>Status</LocationMain>
                        <LocationSecondary>{d.status}</LocationSecondary>
                      </LocationInfo>
                    </BloodType>
                  </View>
                  <LocationSection>
                    <LocationIcon />
                    <LocationInfo>
                      <LocationMain>{d.location}</LocationMain>
                      <LocationSecondary>{d.reason}</LocationSecondary>
                    </LocationInfo>
                  </LocationSection>
                </View>
                {currentUser.id !== d.requester.id && (
                  <Btn onPress={() => handleChat(d?.requester?.id)}>Donate</Btn>
                )}
              </DonationCard>
            ))}
            {
              <View
                style={{
                  flexDirection: "row",
                  width: "50%",
                  justifyContent: "space-between",
                }}
              >
                <ButtonPaper
                  mode="outlined"
                  onPress={() => handlePagination("minus")}
                  textColor={colors.secondary}
                  disabled={page === 1}
                >
                  Prev
                </ButtonPaper>
                <ButtonPaper
                  mode="outlined"
                  onPress={() => handlePagination("add")}
                  textColor={colors.secondary}
                  loading={donationIsFetching || donationIsLoading}
                  disabled={!donations?.isNextPage}
                >
                  Next
                </ButtonPaper>
              </View>
            }
          </>
        )}
      </Container>
      <AddBloodDonation
        isVisible={visible}
        style={{
          flex: 1,
          height: "100%",
          width: "100%",
        }}
        animationIn="slideInUp"
      >
        <View
          style={{
            justifyContent: "flex-start",
            flex: 1,
            // borderColor: "red",
            // borderWidth: 1,
            width: "100%",
            alignItems: "center",
          }}
        >
          <Appbar.Header style={{ width: "100%" }}>
            <Appbar.BackAction
              onPress={() => {
                setVisible(false);
              }}
            />
            <Content title="Add Donation Request" />
          </Appbar.Header>
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
              setSelectedBloodType(selectedItem);
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
          <InputField
            placeholder="location"
            value={location}
            onChangeText={setLocation}
          />
          <InputField
            value={reason}
            onChangeText={setReason}
            placeholder="reason"
            multiline={true}
            style={{
              height: 100,
              paddingTop: 16,
              textAlignVertical: "top",
            }}
          />
          <ButtonPaper
            buttonColor={colors.secondary}
            textColor={colors.light}
            style={{
              marginTop: 8,
              marginBottom: 8,
              width: "40%",
              height: 40,
            }}
            labelStyle={{ fontFamily: "Poppins" }}
            onPress={handleSubmit}
            loading={makeDonationIsLoading}
            disabled={makeDonationIsLoading}
          >
            Add
          </ButtonPaper>
        </View>
      </AddBloodDonation>
      {visible ? null : (
        <Button onPress={() => setVisible((prev) => !prev)}>
          <BtnContent>
            <Ionicons name="add-outline" size={24} color="white" />
          </BtnContent>
        </Button>
      )}
    </BgContainer>
  );
};

export default BloodDonationMain;
const styles = StyleSheet.create({
  container: {
    justifyContent: "space-between",
  },
  row: {
    flexDirection: "row",
    justifyContent: "space-between",
  },
});
