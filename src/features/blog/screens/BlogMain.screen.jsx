import { Appbar, Button, TextInput } from "react-native-paper";
import colors from "../../../infrastructure/theme/colors";
import BlogSection from "../../components/BlogSection.component";
import { BgContainer } from "../../home/styles/Global.styles";
import { useSelector } from "react-redux";
import { selectToken, selectUser } from "../../../services/slices/auth.slice";
import {
  AddBloodDonation,
  InputField,
  Title,
} from "../../bloodDonation/styles/BloodDonationMain.styles";
import * as ImagePicker from "expo-image-picker";
import { Alert, Image, View } from "react-native";
import { useCreateBlogMutation } from "../../../services/apis/blogs.api";
import { StyleSheet } from "react-native";
import { useState } from "react";
import {
  BtnContent,
  Btn as B,
} from "../../questions/styles/MainQuestions.styles";
import { useEffect } from "react";
import { FontAwesome, Ionicons } from "@expo/vector-icons";

const BlogMain = ({ navigation }) => {
  const [visible, setVisible] = useState(false);
  const user = useSelector(selectUser);
  const [img, setImg] = useState("");
  const [title, setTitle] = useState("");
  const [content, setContent] = useState("");
  const [tags, setTags] = useState("");
  const token = useSelector(selectToken);
  const [createBlog, { isLoading, error, data, isSuccess, isError }] =
    useCreateBlogMutation();
  const pickImage = async () => {
    // No permissions request is necessary for launching the image library
    let result = await ImagePicker.launchImageLibraryAsync({
      mediaTypes: ImagePicker.MediaTypeOptions.All,
      allowsEditing: true,
      aspect: [4, 3],
      quality: 1,
      base64: true,
    });

    console.log(result.assets[0]);
    setImg(result.assets[0]);
    if (!result.canceled) {
      // uploadImg({ token, base64Picture: result.assets[0].base64 });
    }
  };
  const submit = () => {
    if (title && tags && content && img.base64) {
      const tagsArr = tags?.split(" ");
      createBlog({
        token,
        title,
        tags: tagsArr,
        content,
        Base64Images: [img.base64],
      });
    } else {
      Alert.alert("Please fill all fields");
    }
  };
  useEffect(() => {
    if (isSuccess) {
      setVisible(false);
      setTitle("");
      setContent("");
      setTags("");
      setImg("");
    }
  }, [isSuccess]);

  useEffect(() => {
    if (isError) {
      Alert.alert("Error", "some error happened try later");
      console.log(error);
    }
  }, [isError]);

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
          title="Blogs 📓"
          titleStyle={{
            color: colors.primary,
            fontFamily: "PoppinsBold",
          }}
        />
      </Appbar.Header>

      <BlogSection />
      <AddBloodDonation
        style={{ flex: 1, height: "100%", justifyContent: "flex-start" }}
        onBackdropPress={() => setVisible(false)}
        isVisible={visible}
      >
        {/* <Title></Title> */}
        <View style={styles.container}>
          <Appbar.Header>
            <Appbar.BackAction
              color={colors.primary}
              onPress={() => {
                setVisible(false);
              }}
            />
            <Appbar.Content
              title="Create New Blog"
              titleStyle={{
                color: colors.primary,
                fontFamily: "PoppinsBold",
              }}
            />
          </Appbar.Header>
        </View>
        <TextInput
          style={styles.input}
          placeholder="Title"
          value={title}
          onChangeText={setTitle}
          mode="outlined"
        />
        <TextInput
          style={styles.input}
          placeholder="Content"
          value={content}
          onChangeText={setContent}
          mode="outlined"
        />
        <TextInput
          style={styles.input}
          placeholder="Tags"
          value={tags}
          onChangeText={setTags}
          mode="outlined"
        />
        <View style={[styles.imgContainer, { flex: img ? 0.8 : 0.4 }]}>
          {img.uri && <Image source={{ uri: img?.uri }} style={styles.img} />}
          <Button onPress={pickImage} style={styles.pickBtn} icon="camera">
            Pick image
          </Button>
        </View>
        <Button
          buttonColor={colors.secondary}
          textColor={colors.light}
          style={{
            marginTop: 8,
            marginBottom: 8,

            width: "50%",
          }}
          labelStyle={{ fontFamily: "Poppins" }}
          onPress={submit}
          loading={isLoading}
          disabled={isLoading}
        >
          Add
        </Button>
      </AddBloodDonation>
      {user.isDoctor &&
        (visible ? null : (
          // <View style={styles.floatBtn}>
          //   <Button
          //     buttonColor={colors.secondary}
          //     onPress={() => setVisible((prev) => !prev)}
          //     mode="contained"
          //     style={styles.innerBtn}
          //   >
          //     +
          //   </Button>
          // </View>
          <B onPress={() => setVisible((prev) => !prev)}>
            <BtnContent>
              <FontAwesome name="pencil" size={24} color="white" />
            </BtnContent>
          </B>
        ))}
    </BgContainer>
  );
};
export default BlogMain;
const styles = StyleSheet.create({
  floatBtn: {
    position: "absolute",
    bottom: 5,
    right: 5,
  },
  innerBtn: {
    height: 50,
    width: 50,
    borderRadius: 25,
  },
  input: {
    width: "90%",
    marginTop: 8,
  },
  imgContainer: {
    marginTop: 8,
    width: "100%",
    alignItems: "center",
  },
  img: {
    width: "70%",
    // height: 200,
    flex: 1,
    borderColor: colors.secondary,
    borderWidth: 2,
    objectFit: "contain",
    borderRadius: 8,
  },
  container: {
    width: "100%",
  },
});
