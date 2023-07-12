import { ActivityIndicator, Appbar, Button } from "react-native-paper";
import colors from "../../../infrastructure/theme/colors";
import { BgContainer } from "../styles/Global.styles";
import { user as loadedUser } from "../../../helpers/consts";
import { useCallback, useEffect, useRef, useState } from "react";
import {
  ChangeContainerIcon,
  Container,
  EditBtn,
  EditBtnContent,
  Ele,
  FlashContainerIcon,
  IconContainerCamera,
  Img,
  ImgWrapper,
  Info,
  Name,
  Title,
  TopContainer,
  UserInfo,
  Value,
  Wrapper,
} from "../styles/Profile.styles";
import { Camera } from "expo-camera";
import * as MediaLibrary from "expo-media-library";
import { AntDesign, Entypo, FontAwesome, Ionicons } from "@expo/vector-icons";
import { View, Text, Platform, StatusBar } from "react-native";
import { useFocusEffect } from "@react-navigation/native";
import { TouchableOpacity } from "react-native";
import AsyncStorage from "@react-native-async-storage/async-storage";
import { useDispatch, useSelector } from "react-redux";
import {
  logout,
  selectToken,
  selectUser,
  setPersonalPic,
  setUserInfo,
} from "../../../services/slices/auth.slice";
import apiEndPoint, { imgUrl } from "../../../services/apiEndPoint";
import * as ImagePicker from "expo-image-picker";
import { useUploadProfilePicMutation } from "../../../services/apis/auth.api";
import { Toast } from "toastify-react-native";

const Profile = ({ navigation }) => {
  const [editImg, setEditImg] = useState(false);
  const [image, setImage] = useState(null);
  const [flash, setFlash] = useState(Camera.Constants.FlashMode.off);
  const [type, setType] = useState(Camera.Constants.Type.front);
  const [hasCameraPermission, setHasCameraPermission] = useState(null);
  const cameraRef = useRef();
  const user = useSelector(selectUser);
  const token = useSelector(selectToken);
  const [isLoadingImg, setIsLoadingImg] = useState(true);

  const [uploadImg, { isSuccess, error, isLoading, data: userInfo }] =
    useUploadProfilePicMutation();
  const dispatch = useDispatch();

  const logoutHandler = () => {
    dispatch(logout());
  };
  useEffect(() => {
    console.log(user);
  }, []);

  useFocusEffect(
    useCallback(() => {
      navigation.getParent().setOptions({
        tabBarStyle: { display: "none" },
      });
    }, [])
  );
  const pickImage = async () => {
    // No permissions request is necessary for launching the image library
    let result = await ImagePicker.launchImageLibraryAsync({
      mediaTypes: ImagePicker.MediaTypeOptions.All,
      allowsEditing: true,
      aspect: [4, 3],
      quality: 1,
      base64: true,
    });

    console.log(result.assets[0].base64);
    if (!result.canceled) {
      setImage(result.assets[0].uri);
      uploadImg({ token, base64Picture: result.assets[0].base64 });
    }
  };
  const handlePickImage = () => {
    pickImage();
  };
  useEffect(() => {
    if (isSuccess) {
      Toast.success("upload image successfully", "bottom");
      dispatch(setUserInfo(userInfo.user));
    }
  }, [isSuccess]);
  console.log(user, "😂😂😂😂😂");
  return (
    <BgContainer>
      <>
        <Appbar.Header>
          <Appbar.BackAction
            onPress={() => navigation.goBack()}
            color={colors.primary}
          />
        </Appbar.Header>
        <Container>
          <ImgWrapper>
            <ActivityIndicator animating={isLoading} />
            <Img
              source={{ uri: `${imgUrl}${user.profilePictureUrl}` }}
              onLoadStart={() => setIsLoadingImg(true)}
              onLoadEnd={() => setIsLoadingImg(false)}
            />

            <IconContainerCamera onPress={handlePickImage}>
              <FontAwesome name="camera" size={18} color={colors.light} />
            </IconContainerCamera>
          </ImgWrapper>
          <Name>{user?.name}</Name>
          <Wrapper>
            <UserInfo>{user?.age ?? 25 + " years ago"}</UserInfo>
            <UserInfo>{user?.gender ?? "Male"}</UserInfo>
          </Wrapper>
          <Ele
            style={{
              borderBottomWidth: 1,
              borderBottomColor: colors.primary,
            }}
          >
            <Info>
              <Title>Blood Type</Title>
              <Value>{user?.bloodType}</Value>
            </Info>
            <EditBtn>
              <EditBtnContent>Edit</EditBtnContent>
            </EditBtn>
          </Ele>
          {!user.isDoctor && (
            <>
              <Ele
                style={{
                  borderBottomWidth: 1,
                  borderBottomColor: colors.primary,
                }}
              >
                <Info>
                  <Title>Weight</Title>
                  <Value>{user?.weight ?? "80" + " KG"}</Value>
                </Info>
                <EditBtn>
                  <EditBtnContent>Edit</EditBtnContent>
                </EditBtn>
              </Ele>
              <Ele
                style={{
                  borderBottomWidth: 1,
                  borderBottomColor: colors.primary,
                }}
              >
                <Info>
                  <Title>Height</Title>
                  <Value>{user?.height ?? "185" + " CM"}</Value>
                </Info>

                <EditBtn>
                  <EditBtnContent>Edit</EditBtnContent>
                </EditBtn>
              </Ele>
            </>
          )}
          <Button
            mode="contained"
            onPress={logoutHandler}
            buttonColor={colors.secondary}
            labelStyle={{ fontFamily: "Poppins" }}
          >
            Logout
          </Button>
        </Container>
      </>
    </BgContainer>
  );
};

export default Profile;
