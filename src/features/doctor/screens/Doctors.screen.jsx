import { useFocusEffect } from "@react-navigation/native";
import { useCallback, useEffect, useState } from "react";
import { BgContainer } from "../../home/styles/Global.styles";

import { doctors as loadedDoctors } from "../../../helpers/consts";
import AllDoctors from "../components/AllDoctors.component";
import {
    FilterIcon,
    SearchContainer,
    SearchIcon,
    SearchText,
    Img,
    NotFoundContainer,
    ButtonContainer,
    ButtonContent,
    BackIcon,
    Title,
} from "../styles/Doctors.styles";
import { Appbar } from "react-native-paper";

const Doctors = ({ navigation, route }) => {
    const [doctors, setDoctors] = useState([]);
    const [tempDoctors, setTempDoctors] = useState([]);
    const [title, setTitle] = useState("Doctors");
    const [search, setSearch] = useState("");
    const { category } = route.params;
    useFocusEffect(
        useCallback(() => {
            navigation.getParent().setOptions({
                tabBarStyle: { display: "none" },
            });
        }, [])
    );
    useEffect(() => {
        setDoctors(loadedDoctors);
        if (category === "all") {
            setTempDoctors(loadedDoctors);
        } else {
            const filteredDoctors = loadedDoctors.filter(
                (doctor) => doctor.specialty === category
            );
            setTempDoctors(filteredDoctors);
        }
    }, []);
    const backHandler = () => navigation.goBack();
    const searchHandler = (val) => {
        setSearch(val);
        // if (val === "") return setTempDoctors(doctors);
        const filteredDoctors = doctors.filter((doctor) =>
            doctor.name?.toUpperCase().includes(val?.toUpperCase())
        );
        setTempDoctors(filteredDoctors);
    };
    const seeAllDoctorsHandler = () => {
        setSearch("");
        setTempDoctors(doctors);
    };
    return (
        <BgContainer>
            <Appbar.Header>
                <BackIcon onPress={backHandler} />
                <Title />
            </Appbar.Header>
            {/* <BackContainer onPress={backHandler}>
                <BackIcon />
            </BackContainer>
            <Title>{title}</Title> */}
            <SearchContainer
                style={{
                    elevation: 10,
                    shadowColor: "#000000bb",
                    shadowOffset: { width: -2, height: 4 },
                    shadowOpacity: 0.82,
                    shadowRadius: 3,
                }}
            >
                <SearchIcon />
                <SearchText
                    value={search}
                    onChangeText={searchHandler}
                    placeholder="Search For Doctors You Need"
                />
                <FilterIcon />
            </SearchContainer>
            {tempDoctors.length === 0 ? (
                <NotFoundContainer>
                    <Img
                        source={require("../../../../assets/helpers/404.png")}
                    />
                    <ButtonContainer onPress={seeAllDoctorsHandler}>
                        <ButtonContent>See All Doctors</ButtonContent>
                    </ButtonContainer>
                </NotFoundContainer>
            ) : (
                <AllDoctors doctors={tempDoctors} />
            )}
        </BgContainer>
    );
};
export default Doctors;
