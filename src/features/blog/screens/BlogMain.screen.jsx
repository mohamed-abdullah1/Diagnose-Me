import { Appbar } from "react-native-paper";
import colors from "../../../infrastructure/theme/colors";
import BlogSection from "../../components/BlogSection.component";
import { BgContainer } from "../../home/styles/Global.styles";

const BlogMain = ({ navigation }) => {
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
    </BgContainer>
  );
};
export default BlogMain;
