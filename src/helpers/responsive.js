import { Dimensions } from "react-native";

export const w = Dimensions.get("window").width;
export const h = Dimensions.get("window").height;

export default (uiHeight, uiWidth) => {
    const getY = (ele) => (ele * h) / uiHeight; //for any height
    const getX = (ele) => (ele * w) / uiWidth; //for any width
    return { getX, getY };
};
