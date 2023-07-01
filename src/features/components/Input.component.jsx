import React from "react";
import { TextInput } from "react-native-paper";
import colors from "../../infrastructure/theme/colors";

const Input = ({ label, state, setState, icon, iconPress, ...props }) => {
    return (
        <TextInput
            mode="outlined"
            label={label}
            value={state}
            onChangeText={setState}
            textColor={colors.primary}
            style={{
                width: "80%",
                minHeight: 40,
                color: colors.secondary,
                fontFamily: "Poppins",
                backgroundColor: colors.moreMuted,
            }}
            outlineColor={colors.secondary}
            right={
                <TextInput.Icon
                    icon={icon}
                    color={() => colors.secondary}
                    onPress={() => iconPress && iconPress((prev) => !prev)}
                />
            }
            {...props}
        />
    );
};

export default Input;
