import Card from "./Card.component";
import styled from "styled-components/native";
import { AntDesign, MaterialCommunityIcons } from "@expo/vector-icons";
import { Pressable } from "react-native";
import { formatDistanceToNow } from "date-fns";
import { useSelector } from "react-redux";
import { selectToken, selectUser } from "../../services/slices/auth.slice";
import colors from "../../infrastructure/theme/colors";
import { useState } from "react";
import { useAgreementMutation } from "../../services/apis/questions.api";
import { imgUrl } from "../../services/apiEndPoint";

const Container = styled.View`
  flex-direction: row;
  align-items: center;
`;
const IconsContainer = styled.View`
  flex-direction: row;
`;
const Icon = styled(AntDesign).attrs((props) => ({
  name: props.name,
  size: 24,
  color: props.color,
}))``;
const Value = styled.Text`
  font-size: 15px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
  margin-left: 5px;
`;
const RightContainer = styled.View`
  flex-direction: row;
  align-items: center;
`;
const CommentIcon = styled(MaterialCommunityIcons).attrs((props) => ({
  color: props.theme.colors.primary,
  size: 24,
  name: "comment-outline",
}))``;

const BottomLeft = ({ value, currentUser: user, askingUser, handleClick }) => {
  const [iconPress, setIconPress] = useState(false);
  const [iconPressDown, setIconPressDown] = useState(false);
  return (
    <Container>
      <IconsContainer>
        {user.isDoctor ? (
          <>
            <Pressable
              onPressIn={() => setIconPress(true)}
              onPressOut={() => setIconPress(false)}
              onPress={() => handleClick(true)}
            >
              <Icon
                name="arrowup"
                color={iconPress ? colors.secondary : colors.primary}
              />
            </Pressable>
            <Pressable
              onPressIn={() => setIconPressDown(true)}
              onPressOut={() => setIconPressDown(false)}
              onPress={() => handleClick(false)}
            >
              <Icon
                name="arrowdown"
                color={iconPressDown ? colors.secondary : colors.primary}
              />
            </Pressable>
          </>
        ) : (
          <>
            <Icon name="arrowup" />
            <Icon name="arrowdown" />
          </>
        )}
      </IconsContainer>
      <Value>{value}</Value>
    </Container>
  );
};
const BottomRight = ({ value }) => {
  return (
    <RightContainer>
      <CommentIcon />
      <Value>{value}</Value>
    </RightContainer>
  );
};

const QuestionCard = ({ question, styles, onPress, viewAllQuestion }) => {
  const user = useSelector(selectUser);
  const token = useSelector(selectToken);
  const [agree, {}] = useAgreementMutation();
  const handleClick = (val) => {
    agree({ token, questionId: question.id, value: val });
  };
  console.log(question, "🩸");
  return (
    <Card
      onPress={onPress}
      styles={styles}
      BottomLeft={() => (
        <BottomLeft
          value={question?.agreementCount - question?.disagreementCount}
          askingUser={question?.askingUser}
          currentUser={user}
          handleClick={handleClick}
        />
      )}
      BottomRight={() => <BottomRight value={question?.answersCount} />}
      img={question?.askingUser?.profilePictureUrl}
      name={question?.askingUser?.fullName}
      date={
        question.modifiedOn
          ? formatDistanceToNow(new Date(question.modifiedOn), {
              addSuffix: true,
            })
          : // ?.split("about")[1]
            // ?.trim()
            formatDistanceToNow(new Date(question.createdOn), {
              addSuffix: true,
            })
        // ?.split("about")[1]
        // ?.trim()
      }
      content={question?.questionString}
      viewAllQuestion={viewAllQuestion}
    />
  );
};
export default QuestionCard;
