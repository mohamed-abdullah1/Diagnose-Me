import { Appbar } from "react-native-paper";
import colors from "../../../infrastructure/theme/colors";
import BlogContent from "../../components/BlogContent.component";
import { BgContainer } from "../../home/styles/Global.styles";

const Blog = ({ navigation, route }) => {
    // console.log(route.params.blog);
    const { blog } = route.params;
    return (
        <BgContainer>
            <Appbar.Header>
                <Appbar.BackAction
                    color={colors.primary}
                    onPress={() => {
                        navigation.goBack();
                    }}
                />
            </Appbar.Header>
            <BlogContent blog={blog} />
        </BgContainer>
    );
};
export default Blog;
