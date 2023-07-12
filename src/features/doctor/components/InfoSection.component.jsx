import { imgUrl } from "../../../services/apiEndPoint";
import Rate from "../../components/Rate.Component";
import {
  Container,
  DataContainer,
  Img,
  Name,
  Number,
  RatingContainer,
  Specialty,
} from "../styles/InfoSection";

const InfoSection = ({
  doctorName,
  doctorImg,
  rate,
  specialty,
  numberOfReviews,
}) => {
  console.log("👉", doctorImg);
  return (
    <Container style={{ width: "100%" }}>
      <Img
        source={
          doctorImg
            ? { uri: imgUrl + doctorImg }
            : require("../../../../assets/characters/male.png")
        }
      />
      <DataContainer>
        <Name>{"Dr. " + doctorName}</Name>
        <Specialty>{specialty}</Specialty>
        <RatingContainer>
          <Rate rate={rate} />
          <Number>{"( " + numberOfReviews + " )"}</Number>
        </RatingContainer>
      </DataContainer>
    </Container>
  );
};
export default InfoSection;
