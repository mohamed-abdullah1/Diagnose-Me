import Card from "./Card.component";
import styled from "styled-components/native";
import { AntDesign, MaterialCommunityIcons } from "@expo/vector-icons";

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
  color: props.theme.colors.primary,
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

const BottomLeft = ({ value }) => {
  return (
    <Container>
      <IconsContainer>
        <Icon name="arrowup" />
        <Icon name="arrowdown" />
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
  return (
    <Card
      onPress={onPress}
      styles={styles}
      BottomLeft={() => (
        <BottomLeft
          value={question?.agreementCount - question?.disagreementCount}
        />
      )}
      BottomRight={() => <BottomRight value={question?.answersCount} />}
      img={question?.profilePictureUrl?.patientImg}
      name={question?.askingUser?.fullName}
      date={question?.modifiedOn}
      content={question?.questionString}
      viewAllQuestion={viewAllQuestion}
    />
  );
};
export default QuestionCard;
