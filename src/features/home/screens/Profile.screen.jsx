import { Appbar, Button } from "react-native-paper";
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
const Profile = ({ navigation }) => {
    const [user, setUser] = useState();
    const [editImg, setEditImg] = useState(false);
    const [image, setImage] = useState(null);
    const [flash, setFlash] = useState(Camera.Constants.FlashMode.off);
    const [type, setType] = useState(Camera.Constants.Type.front);
    const [hasCameraPermission, setHasCameraPermission] = useState(null);
    const cameraRef = useRef();

    const handleChangeType = () => {
        setType((prev) =>
            prev === Camera.Constants.Type.front
                ? Camera.Constants.Type.back
                : Camera.Constants.Type.front
        );
    };
    const handleFlash = () => {
        setFlash((prev) =>
            prev === Camera.Constants.FlashMode.off
                ? Camera.Constants.FlashMode.on
                : Camera.Constants.FlashMode.off
        );
    };
    const handleTakePic = () => {
        if (cameraRef) {
            (async () => {
                const data = await cameraRef.current.takePictureAsync();
                setImage({ uri: data.uri });
                saveLocalStorage({ uri: data.uri });
                setEditImg(false);
            })();
        }
    };
    const saveLocalStorage = async (item) => {
        try {
            const jsonValue = JSON.stringify(item);
            await AsyncStorage.setItem("@personalImg", jsonValue);
        } catch (e) {}
    };
    const getLocalStorage = async (key) => {
        try {
            const jsonValue = await AsyncStorage.getItem(key);
            console.log("👉🍀🍀", JSON.parse(jsonValue));
            return jsonValue !== null ? JSON.parse(jsonValue) : null;
        } catch (e) {
            // error reading value
        }
    };
    useEffect(() => {
        setUser(loadedUser);

        getLocalStorage("@personalImg")
            .then((d) => {
                setImage(d);
            })
            .catch((e) => setImage(loadedUser?.img));
    }, []);
    useEffect(() => {
        (async () => {
            MediaLibrary.requestPermissionsAsync();
            const cameraStatus = await Camera.requestCameraPermissionsAsync();
            setHasCameraPermission(cameraStatus === "granted");
        })();
    }, [editImg]);
    useFocusEffect(
        useCallback(() => {
            navigation.getParent().setOptions({
                tabBarStyle: { display: "none" },
            });
        }, [])
    );

    return (
        <BgContainer>
            {editImg ? (
                <View style={{ flex: 1 }}>
                    <Appbar.Header>
                        <Appbar.BackAction
                            onPress={() => setEditImg(false)}
                            color={colors.primary}
                        />
                    </Appbar.Header>
                    <TopContainer>
                        <ChangeContainerIcon onPress={handleChangeType}>
                            <AntDesign
                                style={{
                                    shadowColor: "black",
                                    shadowOpacity: 0.5,
                                    shadowRadius: 5,
                                    // iOS
                                    shadowOffset: {
                                        width: 0, // These can't both be 0
                                        height: 1, // i.e. the shadow has to be offset in some way
                                    },
                                    elevation: 10,
                                    // Android
                                    shadowOffset: {
                                        width: 0, // Same rules apply from above
                                        height: 1, // Can't both be 0
                                    },
                                }}
                                name="retweet"
                                size={30}
                                color={colors.primary}
                            />
                        </ChangeContainerIcon>
                        <FlashContainerIcon onPress={handleFlash}>
                            <Ionicons
                                name="flash"
                                size={30}
                                color={colors.primary}
                            />
                        </FlashContainerIcon>
                    </TopContainer>
                    <Camera
                        flashMode={flash}
                        type={type}
                        ref={cameraRef}
                        style={{
                            flex: 1,
                            borderRadius: 20,
                            maxHeight: "65%",
                        }}
                    ></Camera>
                    <TopContainer
                        style={{ maxHeight: 100, justifyContent: "center" }}
                    >
                        <TouchableOpacity onPress={handleTakePic}>
                            <Entypo
                                name="circle"
                                size={70}
                                color={colors.primary}
                                style={{
                                    alignSelf: "center",
                                }}
                            />
                        </TouchableOpacity>
                    </TopContainer>
                </View>
            ) : (
                <>
                    <Appbar.Header>
                        <Appbar.BackAction
                            onPress={() => navigation.goBack()}
                            color={colors.primary}
                        />
                    </Appbar.Header>
                    <Container>
                        <ImgWrapper>
                            <Img source={image} />
                            <IconContainerCamera
                                onPress={() => setEditImg(true)}
                            >
                                <FontAwesome
                                    name="camera"
                                    size={18}
                                    color={colors.light}
                                />
                            </IconContainerCamera>
                        </ImgWrapper>
                        <Name>{user?.name}</Name>
                        <Wrapper>
                            <UserInfo>{user?.age + " years ago"}</UserInfo>
                            <UserInfo>{user?.gender}</UserInfo>
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
                        <Ele
                            style={{
                                borderBottomWidth: 1,
                                borderBottomColor: colors.primary,
                            }}
                        >
                            <Info>
                                <Title>Weight</Title>
                                <Value>{user?.weight + " KG"}</Value>
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
                                <Value>{user?.height + " CM"}</Value>
                            </Info>

                            <EditBtn>
                                <EditBtnContent>Edit</EditBtnContent>
                            </EditBtn>
                        </Ele>
                    </Container>
                </>
            )}
        </BgContainer>
    );
};

export default Profile;
