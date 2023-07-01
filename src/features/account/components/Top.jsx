import Logo from "../../../infrastructure/components/Logo";
import { Container } from "../styles/Shared.styles";
import { Header, Desc } from "../styles/Shared.styles";
import Spacer from "../../../infrastructure/components/Spacer";
const Top = ({ title, desc, widthDesc }) => {
    return (
        <Container>
            <Logo />
            <Spacer position="top" size="12">
                <Header>{title}</Header>
            </Spacer>
            <Spacer position="top" size="12">
                <Desc width={widthDesc}>{desc}</Desc>
            </Spacer>
        </Container>
    );
};
export default Top;
