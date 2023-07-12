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
import {
  ActivityIndicator,
  Appbar,
  Button,
  Searchbar,
  Text,
} from "react-native-paper";
import colors from "../../../infrastructure/theme/colors";
import { useGetDoctorsQuery } from "../../../services/apis/medicalService";
import { useSelector } from "react-redux";
import { selectToken } from "../../../services/slices/auth.slice";
import { View } from "react-native";

const Doctors = ({ navigation, route }) => {
  const token = useSelector(selectToken);
  const [page, setPage] = useState(1);
  const [search, setSearch] = useState("");
  const {
    data: allDoctors,
    isLoading,
    isSuccess,
    isError,
    error,
    isFetching,
  } = useGetDoctorsQuery({ token, page, qSearch: search });
  const [doctors, setDoctors] = useState([]);
  const [tempDoctors, setTempDoctors] = useState([]);
  const [title, setTitle] = useState("Doctors");
  const { category } = route.params;
  useFocusEffect(
    useCallback(() => {
      // navigation.getParent().setOptions({
      //   tabBarStyle: { display: "none" },
      // });
    }, [])
  );
  // useEffect(() => {
  //   setDoctors(loadedDoctors);
  //   if (category === "all") {
  //     setTempDoctors(loadedDoctors);
  //   } else {
  //     const filteredDoctors = loadedDoctors.filter(
  //       (doctor) => doctor.specialty === category
  //     );
  //     setTempDoctors(filteredDoctors);
  //   }
  // }, []);
  console.log("docotrs🔥", allDoctors);
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
  };
  const handlePagination = (type) => {
    scrollViewRef.current?.scrollTo({ y: 0, animated: true });
    setPage((prev) => (type === "add" ? prev + 1 : prev - 1));
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
      <Searchbar
        placeholder="Search for Doctors you need"
        value={search}
        onChangeText={searchHandler}
        style={{
          width: "90%",
          alignSelf: "center",
          borderRadius: 32,
          backgroundColor: colors.light,
          fontFamily: "Poppins",
        }}
      />
      {isLoading || isFetching ? (
        <ActivityIndicator
          animating={isLoading || isFetching}
          color={colors.primary}
        />
      ) : allDoctors?.objects?.length === 0 ? (
        <NotFoundContainer>
          <Img source={require("../../../../assets/helpers/404.png")} />
          <ButtonContainer onPress={seeAllDoctorsHandler}>
            <ButtonContent>See All Doctors</ButtonContent>
          </ButtonContainer>
        </NotFoundContainer>
      ) : (
        <>
          <AllDoctors
            doctors={allDoctors}
            isLoading={isLoading}
            isSuccess={isSuccess}
            isFetching={isFetching}
            error={error}
            isError={isError}
          />
          {
            <View
              style={{
                flexDirection: "row",
                width: "50%",
                justifyContent: "space-between",
                alignSelf: "center",
              }}
            >
              <Button
                mode="outlined"
                onPress={() => handlePagination("minus")}
                textColor={colors.secondary}
                disabled={page === 1}
              >
                Prev
              </Button>
              <Button
                mode="outlined"
                onPress={() => handlePagination("add")}
                textColor={colors.secondary}
                loading={isFetching}
                disabled={!allDoctors?.isNextPage}
              >
                Next
              </Button>
            </View>
          }
        </>
      )}
    </BgContainer>
  );
};
export default Doctors;
