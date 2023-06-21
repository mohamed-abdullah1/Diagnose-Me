import { useEffect, useState } from "react";
import {
  Appbar,
  Button,
  Portal,
  Searchbar,
  Text,
  Provider,
  TextInput,
  ActivityIndicator,
} from "react-native-paper";
import Modal from "react-native-modal";
import { trendQuestions } from "../../../helpers/consts";
import colors from "../../../infrastructure/theme/colors";
import QuestionCard from "../../components/QuestionCard.component";
import { BgContainer } from "../../home/styles/Global.styles";
import { Content } from "../../schedule/styles/ScheduleMain.styles";
import {
  AddQuestionModal,
  Btn,
  BtnContent,
  Container,
  Wrapper,
} from "../styles/MainQuestions.styles";
import { specialties as items } from "../../../helpers/consts";
import SelectDropdown from "react-native-select-dropdown";
import {
  ItemContent,
  ItemIcon,
  ItemRowEle,
  MainContentSpecialty,
  SelectWrapper,
} from "../../account/styles/Shared.styles";
import { Alert, View } from "react-native";
import { AntDesign, Ionicons } from "@expo/vector-icons";
import {
  InputContainer,
  InputField,
} from "../../doctor/styles/MakeAppointmentNote.styles";
import { selectToken } from "../../../services/slices/auth.slice";
import { useSelector } from "react-redux";
import {
  useAskMutation,
  useGetQuestionsQuery,
} from "../../../services/apis/questions.api";
import theme from "../../../infrastructure/theme";
import { useRef } from "react";
import {
  CategoriesContainer,
  CategoryItem,
} from "../../medicine/styles/MedicineMain.styles";
import { TouchableOpacity } from "react-native";

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
          source={items?.filter((item) => item.value === specialty)[0].src}
        />
      ) : null}
      <MainContentSpecialty>
        {specialty ? specialty : "Choose Specialty 🚀"}
      </MainContentSpecialty>
    </ItemRowEle>
  );
};

const MainQuestions = ({ navigation }) => {
  const [searchQuery, setSearchQuery] = useState("");
  // const [questions, setQuestions] = useState([]);
  const [visible, setVisible] = useState(false);
  const [specialty, setSpecialty] = useState("");
  const [qSpecialty, setQSpecialty] = useState("all");
  const [page, setPage] = useState(1);
  const token = useSelector(selectToken);
  const scrollViewRef = useRef(null);
  const {
    data: questions,
    isLoading: questionsIsLoading,
    isError: questionsIsError,
    error: questionsError,
    isFetching: questionsIsFetching,
    isSuccess: getQuestionsIsSuccess,
  } = useGetQuestionsQuery({
    token,
    pageNumber: page,
    searchQuery,
    qSpecialty,
  });
  const [
    ask,
    {
      isLoading: askIsLoading,
      isError: askIsError,
      error: askError,
      isSuccess: askIsSuccess,
    },
  ] = useAskMutation();
  const [input, setInput] = useState("");

  useEffect(() => {
    if (questionsIsError) {
      Alert.alert(
        "Error",
        `error: ${questionsError}`,
        [
          {
            text: "Something Went Wrong",
            onPress: () => {
              console.log("👉", questionsError);
            },
          },
        ],
        { cancelable: false }
      );
    }
  }, [questionsIsError]);
  useEffect(() => {
    if (askIsError) {
      Alert.alert(
        "Error",
        `error: ${askError}`,
        [
          {
            text: "Something Went Wrong",
            onPress: () => {
              console.log("👉", askError);
            },
          },
        ],
        { cancelable: false }
      );
    }
  }, [askIsError]);
  useEffect(() => {
    if (askIsSuccess) {
      setVisible(false);
      setInput("");
      setSpecialty("");
      setPage(1);
      //TODO: add toast
    }
  }, [askIsSuccess]);

  const inputChangeHandler = (text) => {
    setInput(text);
  };
  const handleSubmitQuestion = () => {
    console.log("submitting question ==============", specialty);
    if (!specialty)
      return Alert.alert("Error", "Please choose a specialty First", [
        { text: "OK" },
      ]);
    if (!input)
      return Alert.alert("Error", "Please write your question First", [
        { text: "OK" },
      ]);
    ask({ token, body: { questionString: input, tags: [specialty] } }); //DONE: add the speciality to the body
  };
  const handlePagination = (type) => {
    scrollViewRef.current?.scrollTo({ y: 0, animated: true });
    setPage((prev) => (type === "add" ? prev + 1 : prev - 1));
  };
  const onChangeSearch = (query) => {
    setSearchQuery(query);
  };
  return (
    <BgContainer>
      <Appbar.Header>
        <Content title="Questions 🤔" />
      </Appbar.Header>
      <Searchbar
        placeholder="Search for Question you need"
        value={searchQuery}
        onChangeText={onChangeSearch}
        style={{
          width: "90%",
          alignSelf: "center",
          borderRadius: 32,
          backgroundColor: colors.light,
          fontFamily: "Poppins",
        }}
      />
      <CategoriesContainer style={{ maxHeight: 55, marginBottom: 4 }}>
        {items?.map((s) => (
          <TouchableOpacity key={s.key} onPress={() => setQSpecialty(s.value)}>
            <CategoryItem category={s} current={s.value}>
              {s.value}
            </CategoryItem>
          </TouchableOpacity>
        ))}
      </CategoriesContainer>
      <Container
        ref={scrollViewRef}
        contentContainerStyle={{
          alignItems: "center",
          paddingTop: 20,
          paddingBottom: 20,
        }}
      >
        {questionsIsLoading || questionsIsFetching ? (
          <View>
            {/* TODO: add activity indicator */}
            <ActivityIndicator
              animating={questionsIsLoading || questionsIsFetching}
              color={theme.colors.primary}
            />
          </View>
        ) : (
          <>
            {questions?.objects
              ?.filter(
                (q) =>
                  q?.questionString?.includes(searchQuery) ||
                  searchQuery?.length === 0
              )
              ?.map((q) => (
                <QuestionCard
                  onPress={() => {
                    navigation.navigate("Questions", {
                      screen: "QuestionPage",
                      params: {
                        questionId: q?.id,
                      },
                    });
                  }}
                  key={q.id}
                  styles={{
                    marginLeft: 0,
                    marginRight: 0,
                    marginBottom: 20,
                    width: "90%",
                  }}
                  question={q}
                />
              ))}
            {
              <View
                style={{
                  flexDirection: "row",
                  width: "50%",
                  justifyContent: "space-between",
                }}
              >
                <Button
                  mode="outlined"
                  onPress={() => handlePagination("minus")}
                  textColor={colors.secondary}
                  loading={questionsIsFetching}
                  disabled={page === 1}
                >
                  Prev
                </Button>
                <Button
                  mode="outlined"
                  onPress={() => handlePagination("add")}
                  textColor={colors.secondary}
                  loading={questionsIsFetching}
                  disabled={!questions?.isNextPage}
                >
                  more
                </Button>
              </View>
            }
          </>
        )}
      </Container>
      <AddQuestionModal
        coverScreen={false}
        backdropColor={"#000"}
        style={{
          borderTopLeftRadius: 32,
          borderTopRightRadius: 32,
        }}
        animationIn="slideInUp"
        isVisible={visible}
        onBackdropPress={() => setVisible(false)}
      >
        {
          <Wrapper>
            <Appbar.Header style={{ width: "100%" }}>
              <Appbar.BackAction
                onPress={() => {
                  setVisible(false);
                }}
              />
              <Content title="Add Question" />
            </Appbar.Header>
            <SelectWrapper>
              <SelectDropdown
                data={items.map((item) => item.value)}
                onSelect={(selectedItem, index) => setSpecialty(selectedItem)}
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
            <View
              style={{
                width: "80%",
                // borderColor: "red",
                // borderWidth: 1,
                margin: 0,
                padding: 0,
              }}
            >
              <InputField
                style={{
                  textAlignVertical: "top",
                  marginTop: 16,
                  marginBottom: 16,
                  // elevation: 15,
                  // shadowColor: "#000000bb",
                  // shadowOffset: { width: -2, height: 4 },
                  // shadowOpacity: 0.82,
                  // shadowRadius: 3,
                }}
                multiline={true}
                placeholder="Enter Information for the Doctor ......"
                value={input}
                onChangeText={inputChangeHandler}
              />
            </View>
            <Button
              mode="contained"
              onPress={handleSubmitQuestion}
              buttonColor={colors.secondary}
              contentStyle={{ width: "100%" }}
              loading={askIsLoading}
              disabled={askIsLoading}
            >
              ASK
            </Button>
          </Wrapper>
        }
      </AddQuestionModal>
      {visible ? null : (
        <Btn onPress={() => setVisible((prev) => !prev)}>
          <BtnContent>
            <Ionicons name="add-outline" size={24} color="white" />
          </BtnContent>
        </Btn>
      )}
    </BgContainer>
  );
};
export default MainQuestions;
