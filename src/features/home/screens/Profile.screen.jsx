import { Appbar } from "react-native-paper";
import colors from "../../../infrastructure/theme/colors";
import { BgContainer } from "../styles/Global.styles";
import { user as loadedUser } from "../../../helpers/consts";
import { useEffect, useState } from "react";
import {
    Container,
    EditBtn,
    EditBtnContent,
    Ele,
    Img,
    Info,
    Name,
    Title,
    UserInfo,
    Value,
    Wrapper,
} from "../styles/Profile.styles";
const Profile = ({ navigation }) => {
    const [user, setUser] = useState();
    useEffect(() => {
        setUser(loadedUser);
    }, []);
    return (
        <BgContainer>
            <Appbar.Header>
                <Appbar.BackAction
                    onPress={() => navigation.goBack()}
                    color={colors.primary}
                />
            </Appbar.Header>
            <Container>
                <Img source={user?.img} />
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
        </BgContainer>
    );
};

export default Profile;
