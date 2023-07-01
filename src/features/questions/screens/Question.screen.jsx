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
  Date,
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
  useGetAnswersQuery,
  useGetSingleQuestionQuery,
} from "../../../services/apis/questions.api";
import { useSelector } from "react-redux";
import { selectToken } from "../../../services/slices/auth.slice";
import theme from "../../../infrastructure/theme";
import colors from "../../../infrastructure/theme/colors";
const Question = ({ route, navigation }) => {
  const { questionId } = route.params;
  const token = useSelector(selectToken);
  const [page, setPage] = useState(1);
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
  const handlePagination = (type) => {
    setPage((prev) => (type === "add" ? prev + 1 : prev - 1));
  };
  return (
    <BgContainer>
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
                            ? c.profilePictureUrl
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
                    <Date>{c.modifiedOn ? c.modifiedOn : c.createdOn}</Date>
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
      </Container>
    </BgContainer>
  );
};
export default Question;
