import { useEffect, useState } from "react";
import { Alert, Image, View } from "react-native";
import {
  ActivityIndicator,
  Appbar,
  Button,
  MD2Colors,
} from "react-native-paper";
import QuestionCard from "../../components/QuestionCard.component";
import Rate from "../../components/Rate.Component";
import { BgContainer } from "../../home/styles/Global.styles";
import {
  Bottom,
  CommentCard,
  CommentsContainer,
  CommentTitle,
  Container,
  Date as DateComponent,
  Img,
  Info,
  InfoWrapper,
  LowerIcon,
  Middle,
  Name,
  Specialty,
  SpecialtyContainer,
  Total,
  UpIcon,
  Upper,
} from "../styles/Question.styles";
import {
  useAnswerMutation,
  useGetAnswersQuery,
  useGetSingleQuestionQuery,
} from "../../../services/apis/questions.api";
import { useSelector } from "react-redux";
import { selectToken, selectUser } from "../../../services/slices/auth.slice";
import theme from "../../../infrastructure/theme";
import colors from "../../../infrastructure/theme/colors";
import { formatDistanceToNow } from "date-fns";
import { Content } from "../../schedule/styles/ScheduleMain.styles";

import {
  AddQuestionModal,
  Btn,
  BtnContent,
  Wrapper,
} from "../styles/MainQuestions.styles";
import { Ionicons, MaterialIcons } from "@expo/vector-icons";
import { InputField } from "../../doctor/styles/MakeAppointmentNote.styles";
import { imgUrl } from "../../../services/apiEndPoint";
const Question = ({ route, navigation }) => {
  const { questionId } = route.params;
  const token = useSelector(selectToken);
  const [page, setPage] = useState(1);
  const user = useSelector(selectUser);
  const [visible, setVisible] = useState(false);
  const [input, setInput] = useState("");
  const [
    answerQ,
    {
      isSuccess: answerQisSuccess,
      isLoading: answerQisLoading,
      isError: answerQIsError,
      error: answerError,
    },
  ] = useAnswerMutation();
  const {
    data: question,
    isError: questionIsError,
    isLoading: questionIsLoading,
    error: questionError,
    refetch: questionRefetch,
  } = useGetSingleQuestionQuery({ token, questionId });
  const {
    data: answers,
    isError: answersIsError,
    isLoading: answersIsLoading,
    error: answersError,
    refetch: answersRefetch,
    isFetching: answersIsFetching,
  } = useGetAnswersQuery({ token, questionId, page });
  useEffect(() => {
    if (questionIsError) {
      Alert.alert(
        "Error",
        "Something went wrong, please try again later" +
          questionIsError.message,
        [
          {
            text: "Cancel",
            style: "cancel",
          },
          {
            text: "Retry",
            onPress: () => {
              console.log(questionError);
              questionRefetch();
              // dispatch(getSingleQuestion({ token, questionId }));
            },
          },
        ],
        { cancelable: false }
      );
    }
  }, [questionIsError]);
  useEffect(() => {
    if (answersIsError) {
      Alert.alert(
        "Error",
        "Something went wrong, please try again later" + answersError.message,
        [
          {
            text: "Cancel",
            style: "cancel",
          },
          {
            text: "Retry",
            onPress: () => {
              console.log(answersError);
              answersRefetch();
              // dispatch(getSingleQuestion({ token, questionId }));
            },
          },
        ],
        { cancelable: false }
      );
    }
  }, [answersIsError]);
  useEffect(() => {
    if (answerQisSuccess) {
      setVisible(false);
      setInput("");
    }
  }, [answerQisSuccess]);
  useEffect(() => {
    if (answerQIsError) {
      console.error(answerError);
      Alert.alert("Something wrong");
    }
  }, [answerQIsError]);
  const handlePagination = (type) => {
    setPage((prev) => (type === "add" ? prev + 1 : prev - 1));
  };
  const handleSubmitAnswer = () => {
    answerQ({ token, questionId: question.id, answerString: input });
  };
  return (
    <BgContainer>
      <AddQuestionModal
        coverScreen={false}
        backdropColor={"#000"}
        style={{
          borderTopLeftRadius: 32,
          borderTopRightRadius: 32,
          flex: 1,
          height: "100%",
        }}
        animationIn="slideInUp"
        isVisible={visible}
        onBackdropPress={() => setVisible(false)}
      >
        {
          <Wrapper
            style={{
              justifyContent: "flex-start",
            }}
          >
            <Appbar.Header style={{ width: "100%" }}>
              <Appbar.BackAction
                onPress={() => {
                  setVisible(false);
                }}
              />
              <Content title="Answer this Question" />
            </Appbar.Header>

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
                placeholder="Enter your answer"
                value={input}
                onChangeText={setInput}
              />
            </View>
            <Button
              mode="contained"
              onPress={handleSubmitAnswer}
              buttonColor={colors.secondary}
              contentStyle={{ width: "100%" }}
              loading={answerQisLoading}
              disabled={answerQisLoading}
              style={{ marginBottom: 16 }}
            >
              Answer
            </Button>
          </Wrapper>
        }
      </AddQuestionModal>
      <Appbar.Header>
        <Appbar.BackAction onPress={() => navigation.goBack()} />
      </Appbar.Header>
      <Container>
        {questionIsLoading ? (
          <ActivityIndicator
            animating={questionIsLoading}
            color={theme.colors.primary}
          />
        ) : (
          <QuestionCard
            question={question}
            viewAllQuestion={true}
            styles={{
              // maxHeight: 192,
              alignSelf: "center",
              // justifySelf: "center",
              width: "90%",
              marginRight: 0,
            }}
          />
        )}
        <CommentTitle>Answers 🗣️</CommentTitle>
        <CommentsContainer>
          {answersIsLoading ? (
            <ActivityIndicator
              animating={questionIsLoading}
              color={theme.colors.primary}
            />
          ) : question?.answersCount > 0 ? (
            <>
              {answers?.objects?.map((c) => (
                <CommentCard
                  style={{
                    elevation: 4,
                    shadowColor: "#000000bb",
                    shadowOffset: { width: -2, height: 4 },
                    shadowOpacity: 0.82,
                    shadowRadius: 3,
                  }}
                  key={c.id}
                >
                  <Upper>
                    <InfoWrapper>
                      <Img
                        source={
                          c.answeringDoctor.profilePictureUrl
                            ? {
                                uri:
                                  imgUrl + c.answeringDoctor.profilePictureUrl,
                              }
                            : require("../../../../assets/characters/male.png")
                        }
                      />
                      <Info>
                        <Name>{"Dr. " + c.answeringDoctor.fullName}</Name>
                        <SpecialtyContainer>
                          <Specialty>
                            {c.specialization ? c.specialization : "specialty"}
                          </Specialty>
                          <Rate rate={c.rating ? c.rating : 3} />
                        </SpecialtyContainer>
                      </Info>
                    </InfoWrapper>
                    <DateComponent>
                      {
                        c.modifiedOn
                          ? formatDistanceToNow(new Date(c.modifiedOn), {
                              addSuffix: true,
                            })
                          : // ?.split("about")[1]
                            // ?.trim()
                            formatDistanceToNow(new Date(c.createdOn), {
                              addSuffix: true,
                            })
                        // ?.split("about")[1]
                        // ?.trim()
                      }
                    </DateComponent>
                  </Upper>
                  <Middle>{c.answerString}</Middle>
                  <Bottom>
                    <UpIcon />
                    <LowerIcon />
                    <Total>{c.agreementCount - c.disagreementCount}</Total>
                  </Bottom>
                </CommentCard>
              ))}
              <View
                style={{
                  flexDirection: "row",
                  width: "100%",
                  justifyContent: "center",
                  justifySelf: "center",
                  marginTop: 8,
                  marginBottom: 8,
                }}
              >
                <Button
                  mode="outlined"
                  onPress={() => handlePagination("minus")}
                  textColor={colors.secondary}
                  disabled={page === 1}
                  style={{ marginRight: 8 }}
                >
                  Prev
                </Button>
                <Button
                  mode="outlined"
                  onPress={() => handlePagination("add")}
                  textColor={colors.secondary}
                  loading={answersIsFetching}
                  disabled={!answers?.isNextPage}
                >
                  next
                </Button>
              </View>
            </>
          ) : (
            <View
              style={{
                alignSelf: "center",
                justifySelf: "center",
                // borderColor: "red",
                // borderWidth: 1,
                flex: 1,
                width: "60%",
                height: "10%",
                padding: 16,
              }}
            >
              <Image
                source={require("../../../../assets/helpers/comment.png")}
                style={{
                  width: "100%",
                  height: 250,
                }}
              />
            </View>
          )}
        </CommentsContainer>

        {user.isDoctor &&
          (visible ? null : (
            <Btn onPress={() => setVisible((prev) => !prev)}>
              <BtnContent>
                <MaterialIcons name="question-answer" size={24} color="white" />
              </BtnContent>
            </Btn>
          ))}
      </Container>
    </BgContainer>
  );
};
export default Question;
