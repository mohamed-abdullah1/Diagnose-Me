import {
  BottomContainer,
  Btn,
  FaceAndGoogleContainer,
  TitleOption,
} from "../styles/Shared.styles";

const Bottom = ({ txtFocus }) => {
  return (
    <BottomContainer>
      {!txtFocus ? <TitleOption>Or Continue With </TitleOption> : null}
      <FaceAndGoogleContainer>
        <Btn textColor="#fff" width="142" bgColor="blue">
          Facebook
        </Btn>
        <Btn
          textColor="#fff"
          width="142"
          bgColor="success"
          onPres={() => console.log("👉", "google")}
        >
          Google
        </Btn>
      </FaceAndGoogleContainer>
    </BottomContainer>
  );
};

export default Bottom;
