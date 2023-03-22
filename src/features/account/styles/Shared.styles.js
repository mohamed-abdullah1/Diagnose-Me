import styled from "styled-components/native";
import { Image, TextInput, TouchableOpacity } from "react-native";
import { Button } from "react-native-paper";
import { SelectList } from "react-native-dropdown-select-list";

export const Background = styled.View`
    background-color: #fff;
    flex: 1;
    justify-content: center;
`;

export const Container = styled.View`
    align-items: center;
    height: 150px;
    margin-bottom: 30px;
`;
export const Header = styled.Text`
    font-family: "PoppinsBold";
    font-size: 24px;
    color: ${(props) => props.theme.colors.primary};
    text-align: center;
`;
export const Desc = styled.Text`
    font-family: "PoppinsMedium";
    font-size: 13px;
    text-align: center;
    color: ${(props) => props.theme.colors.primary};
    width: ${(props) => (props.width ? props.width : 300)}px;
    /* border: solid red 1px; */
`;
export const Form = styled.View`
    flex: ${(props) =>
        props.isKeyVisible
            ? 0.7
            : props.flexKeyIsHide
            ? props.flexKeyIsHide
            : 0.3};
    justify-content: space-around;
    align-items: center;
    margin-top: 33px;
    min-height: ${(props) => (props.isKeyVisible ? 40 : 160)}px;
`;
export const InputField = styled(TextInput)`
    width: 323px;
    height: 53px;
    background-color: ${(props) => props.theme.colors.muted};
    color: ${(props) => props.theme.colors.primary};
    border-radius: 8px;
    padding: 14px;
    font-size: 14px;
    font-family: "Poppins";
    &::placeholder {
        color: ${(props) => props.theme.colors.primary};
    }
`;

export const Btn = styled(Button)`
    /* elevation: 5; */
    box-shadow: 0px 2px 10px rgba(0, 0, 0, 0.2);
    background-color: ${(props) => props.theme.colors[props.bgColor]};
    border-radius: 32px;
    height: ${(props) => (props.height ? props.height : 43)}px;
    width: ${(props) => props.width}px;
    font-family: ${(props) =>
        props.fontType ? props.fontType : "PoppinsBold"};
    justify-content: center;
`;
export const RegOption = styled.Text`
    font-family: "Poppins";
    text-align: center;
    justify-content: center;
    color: ${(props) => props.theme.colors.primary};
    /* border: solid red 1px; */
`;
export const Reg = styled.Text`
    font-family: "PoppinsBold";
    text-decoration: underline;
`;

export const BottomContainer = styled.View`
    flex: 0.1;
    align-items: center;
    /* border: solid red 1px; */
`;
export const TitleOption = styled.Text`
    text-align: center;
    color: ${(props) => props.theme.colors.primary};
    font-family: "PoppinsMedium";
`;
export const FaceAndGoogleContainer = styled.View`
    flex: 0.5;
    margin-top: 24px;
    width: 100%;
    flex-direction: row;
    justify-content: space-around;
    align-items: center;
    margin-bottom: 32px;
`;
export const InstructionList = styled.View`
    width: 300px;
`;
export const Instruction = styled.View`
    flex-direction: row;
    align-items: center;
    min-width: 250px;
    max-width: 250px;
`;
export const Circle = styled.View`
    width: 8px;
    height: 8px;
    background-color: ${(props) => props.theme.colors.primary};
    margin-right: 10px;
    border-radius: ${10 / 2}px;
`;
export const ContentContainer = styled.View``;

export const Content = styled.Text`
    font-family: "Poppins";
    color: ${(props) => props.theme.colors.primary};
`;
export const MalesContainer = styled.View`
    flex-direction: row;
    justify-content: space-around;
    /* border: solid red 1px; */
    margin-top: 90px;
`;
export const GenderContainer = styled(TouchableOpacity)`
    background-color: ${(props) =>
        props.title === props.maleOrFemale
            ? props.theme.colors.focused
            : props.theme.colors.muted};
    height: 198px;
    width: 142px;
    border-radius: 16px;
`;
export const GenderType = styled.Text`
    font-size: 20px;
    font-family: "PoppinsMedium";
    text-align: center;
    padding: 16px;
`;
export const CharImgContainer = styled.View``;
export const CharImg = styled(Image)`
    width: 143.22px;
    height: 170.33px;
    /* border: solid red 1px; */
`;

export const BottomBtnWrapper = styled.View`
    position: absolute;
    bottom: 16px;
    width: 100%;
    justify-content: center;
    align-items: center;
`;

export const TypesContainer = styled.View`
    margin-top: 90px;
    align-items: center;
`;
export const Type = styled(TouchableOpacity)`
    background-color: ${(props) =>
        props.typeAccount === props.title
            ? props.theme.colors.focused
            : props.theme.colors.muted};
    margin-bottom: 20px;
    width: 323px;
    height: 105px;
    border-radius: 8px;
    flex-direction: row;
    padding: 12px;
    justify-content: space-between;
    overflow: hidden;
`;
export const Info = styled.View``;
export const InfoTitle = styled.Text`
    font-size: 20px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const InfoDesc = styled.Text`
    width: 148px;
    font-size: 12px;
    font-family: "PoppinsMedium";
    color: ${(props) => props.theme.colors.primary};
`;
export const ImgContainer = styled.View``;
export const Img = styled(Image)`
    width: 128px;
    height: 100px;
`;
export const DoctorsImgContainer = styled.View`
    margin-top: -50px;
    justify-content: center;
    align-items: center;
`;
export const DoctorsImg = styled(Image)`
    height: ${(props) => (props.imgHeight ? props.imgHeight : 244)}px;
    width: ${(props) => (props.imgWidth ? props.imgWidth : 343)}px;
`;
export const VectorBgContainer = styled.View`
    position: absolute;
    bottom: 16px;
    z-index: -1;
`;
export const VectorImg = styled(Image)``;
export const BloodGroup = styled.View`
    align-items: center;
`;
export const BloodItemsContainer = styled.View`
    /* align-items: stretch; */
    width: 300px;
    margin-bottom: 32px;
`;
export const BloodItem = styled(TouchableOpacity)`
    flex: 1;
    max-width: 50%;
    width: 100.64px;
    height: 93px;
    border-radius: 16px;
    background-color: ${(props) =>
        props.blood === props.itemBlood
            ? props.theme.colors.focused
            : props.theme.colors.muted};
    justify-content: center;
    align-items: center;
    margin: 10px;
`;
export const BloodItemContent = styled.Text`
    font-size: 20px;
    font-family: "PoppinsSemiBold";
    color: ${(props) => props.theme.colors.primary};
`;
export const Select = styled(SelectList)`
    border: solid red 1px;
`;
export const SelectWrapper = styled.View`
    align-items: center;
    margin-top: 10px;
    /* border: solid red 1px; */
`;
export const SpecialtyImgContainer = styled.View`
    margin-top: 60px;
    align-items: center;
`;
export const SpecialtyImg = styled(Image)`
    width: 333px;
    height: 287px;
`;
export const ItemRowEle = styled.View`
    flex: 1;
    flex-direction: row;
    align-items: center;

    /* justify-content:; */
`;
export const ItemContent = styled.Text`
    color: ${(props) => props.theme.colors.primary};
    font-family: "Poppins";
`;
export const ItemIcon = styled(Image)`
    width: 50px;
    height: 50px;
    margin-right: 16px;
`;
export const MainContentSpecialty = styled.Text`
    color: ${(props) => props.theme.colors.primary};
    font-family: "PoppinsSemiBold";
    font-size: 16px;
    margin-left: 8px;
`;
