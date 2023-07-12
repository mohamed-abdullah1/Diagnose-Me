import { Alert, Pressable, View } from "react-native";
import { BgContainer } from "../../home/styles/Global.styles";
import { StyleSheet } from "react-native";
import { Text } from "react-native";
import colors from "../../../infrastructure/theme/colors";
import { useState } from "react";
import {
  AddQuestionModal,
  Wrapper,
} from "../../questions/styles/MainQuestions.styles";
import { Appbar, Button } from "react-native-paper";
import { Content } from "../../schedule/styles/ScheduleMain.styles";
import { InputField } from "../../doctor/styles/MakeAppointmentNote.styles";
import { useAskModelMutation } from "../../../services/apis/ai.api";
import { useEffect } from "react";

const specialties = {
  Neurology: [
    "(vertigo) Paroymsal Positional Vertigo",
    "Migraine",
    "Paralysis (brain hemorrhage)",
  ],
  "Infectious Diseases": [
    "AIDS",
    "Chicken pox",
    "Dengue",
    "Hepatitis B",
    "Hepatitis C",
    "Hepatitis D",
    "Hepatitis E",
    "Malaria",
    "Tuberculosis",
    "Typhoid",
  ],
  Dermatology: ["Acne", "Fungal infection", "Psoriasis", "Varicose veins"],
  Gastroenterology: [
    "Alcoholic hepatitis",
    "Chronic cholestasis",
    "GERD",
    "Gastroenteritis",
    "Peptic ulcer diseae",
    "Jaundice",
  ],
  Endocrinology: [
    "Diabetes",
    "Hyperthyroidism",
    "Hypoglycemia",
    "Hypothyroidism",
  ],
  Rheumatology: ["Arthritis", "Osteoarthristis"],
  "Respiratory Medicine": ["Bronchial Asthma", "Pneumonia"],
  Cardiology: ["Heart attack", "Hypertension"],
  Nephrology: ["Urinary tract infection"],
  Other: [
    "Allergy",
    "Common Cold",
    "Dimorphic hemmorhoids(piles)",
    "Drug Reaction",
    "Impetigo",
    "Chronic cholestasis",
  ],
};

export default function App({ navigation }) {
  const [press, setPress] = useState(false);
  const [showModalDiagnose, setShowModalDiagnose] = useState(false);
  const [symptom, setSymptom] = useState("");
  const [askModel, { data, isSuccess, isError, isLoading }] =
    useAskModelMutation();
  const handleDiagnoseMe = () => setShowModalDiagnose(true);
  const handleSubmit = () => {
    askModel({ text: symptom });
  };
  useEffect(() => {
    if (isSuccess) {
      console.log("🤖", data);
      Alert.alert(`The Predicted Diseases are ${data}`);
      navigation.navigate({
        name: "Doctors",
        params: {
          category: Object.keys(specialties).filter((s) =>
            specialties[s].includes(data.split(",")[0].trim())
          )[0],
        },
      });
    }
  }, [isSuccess]);

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
        isVisible={showModalDiagnose}
        // onBackdropPress={() => setShowModalDiagnose(false)}
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
                  setShowModalDiagnose(false);
                }}
              />
              <Content title="Diagnose Me using AI" />
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
                placeholder="Enter Your Symptoms"
                value={symptom}
                onChangeText={setSymptom}
              />
            </View>
            <Button
              mode="contained"
              onPress={handleSubmit}
              buttonColor={colors.secondary}
              loading={isLoading}
              disabled={isLoading}
              style={{ marginBottom: 16, height: 60, borderRadius: 8 }}
              contentStyle={{
                justifyContent: "center",
                alignItems: "center",
                width: "100%",
                flex: 1,
              }}
            >
              SUBMIT
            </Button>
          </Wrapper>
        }
      </AddQuestionModal>
      <View style={styles.container}>
        <Pressable
          onPress={handleDiagnoseMe}
          onPressIn={() => setPress(true)}
          onPressOut={() => setPress(false)}
        >
          <View
            style={[
              {
                shadowColor: "#0000006e",
                elevation: 24,
                shadowOffset: { width: 0, height: 1 },
                shadowOpacity: 0.2,
                shadowRadius: 40,
              },
              styles.content,
              {
                backgroundColor: press ? colors.secondary : colors.light,
              },
            ]}
          >
            <Text style={([styles.title], { fontSize: 24, marginBottom: 12 })}>
              🤖
            </Text>
            <Text
              style={[
                styles.title,
                { color: !press ? colors.primary : colors.light },
              ]}
            >
              Diagnose Me
            </Text>
          </View>
        </Pressable>
      </View>
    </BgContainer>
  );
}

const styles = StyleSheet.create({
  container: {
    padding: 24,
    // borderColor: "red",
    // borderWidth: 1,
  },
  content: {
    padding: 20,
    height: 100,
    width: 150,
    // borderColor: "red",
    // borderWidth: 1,
    backgroundColor: colors.light,
    borderRadius: 16,
    justifyContent: "center",
    alignItems: "center",
  },
  title: {
    fontFamily: "Poppins",
    fontSize: 16,
  },
});
