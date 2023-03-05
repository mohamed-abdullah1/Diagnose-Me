import { useEffect, useState } from "react";
import {
    Appbar,
    Button,
    Portal,
    Searchbar,
    Text,
    Provider,
    TextInput,
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
import { View } from "react-native";
import { AntDesign } from "@expo/vector-icons";
import {
    InputContainer,
    InputField,
} from "../../doctor/styles/MakeAppointmentNote.styles";

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
                {specialty ? specialty : "Choose Specialty 🚀"}
            </MainContentSpecialty>
        </ItemRowEle>
    );
};

const MainQuestions = ({ navigation }) => {
    const [searchQuery, setSearchQuery] = useState();
    const [questions, setQuestions] = useState([]);
    const [visible, setVisible] = useState(false);
    const [specialty, setSpecialty] = useState("");
    useEffect(() => {
        setQuestions(trendQuestions);
    }, []);
    return (
        <BgContainer>
            <Appbar.Header>
                <Content title="Questions 🤔" />
            </Appbar.Header>
            <Searchbar
                placeholder="Search for Question you need"
                value={searchQuery}
                style={{
                    width: "90%",
                    alignSelf: "center",
                    borderRadius: 32,
                    backgroundColor: colors.light,
                    fontFamily: "Poppins",
                }}
            />
            <Container
                contentContainerStyle={{
                    alignItems: "center",
                    paddingTop: 20,
                    paddingBottom: 20,
                }}
            >
                {questions?.map((q) => (
                    <QuestionCard
                        onPress={() => {
                            navigation.navigate("Questions", {
                                screen: "QuestionPage",
                                params: {
                                    question: q,
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
                            />
                        </View>
                        <Button
                            mode="contained"
                            onPress={() => console.log("Pressed")}
                            buttonColor={colors.secondary}
                            contentStyle={{ width: "100%" }}
                        >
                            ASK
                        </Button>
                    </Wrapper>
                }
            </AddQuestionModal>
            {visible ? null : (
                <Btn onPress={() => setVisible((prev) => !prev)}>
                    <BtnContent>+</BtnContent>
                </Btn>
            )}
        </BgContainer>
    );
};
export default MainQuestions;
