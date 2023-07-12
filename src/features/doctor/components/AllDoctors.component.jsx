import { View } from "react-native";
import { FlatList } from "react-native";
import DoctorCard from "../../components/DoctorCard.component";
import { DoctorCardContainer } from "../styles/AllDoctors.styles";
import { Text } from "react-native";

const AllDoctors = ({ doctors }) => {
  return (
    <>
      <FlatList
        contentContainerStyle={{
          paddingTop: 18,
          paddingBottom: 18,
        }}
        data={doctors.objects}
        renderItem={({ item }) => {
          console.log("item🔥", item);
          return (
            //<DoctorCardContainer>
            <DoctorCard
              withOutMargins={true}
              doctor={{ ...item, ...item.user }}
              total={doctors?.objects?.length}
              index={item.id}
              margin
            />
            //</DoctorCardContainer>
          );
        }}
        ItemSeparatorComponent={<View style={{ width: "100%", padding: 8 }} />}
        keyExtractor={(item) => item.id}
        numColumns={2}
      />
    </>
  );
};
export default AllDoctors;
