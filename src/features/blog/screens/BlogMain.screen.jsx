import { useEffect, useState } from "react";
import { Appbar, Searchbar } from "react-native-paper";
import colors from "../../../infrastructure/theme/colors";
import BlogSection from "../../components/BlogSection.component";
import { BgContainer } from "../../home/styles/Global.styles";
import { blogs as loadedBlogs } from "../../../helpers/consts";

const BlogMain = ({ navigation }) => {
    const [searchQuery, setQuery] = useState("");
    const [blogs, setBlogs] = useState([]);
    useEffect(() => {
        setBlogs(loadedBlogs);
    }, []);
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
            <Searchbar
                placeholder="Search for Blogs you need"
                value={searchQuery}
                style={{
                    width: "90%",
                    alignSelf: "center",
                    borderRadius: 32,
                    backgroundColor: colors.light,
                    fontFamily: "Poppins",
                }}
            />
            <BlogSection blogs={blogs} />
        </BgContainer>
    );
};
export default BlogMain;
