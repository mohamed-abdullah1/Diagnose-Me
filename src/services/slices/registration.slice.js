import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  user: null,
  waitPinCode: false,
};

const registrationSlice = createSlice({
  name: "registration",
  initialState,
  reducers: {
    addInfo(state, action) {
      state.user = { ...state.user, ...action.payload };
    },
    editSingleField(state, action) {
      state.user[Object.keys(action.payload)[0]] = Object.values(
        action.payload
      )[0];
    },
    finish(state) {
      state.waitPinCode = true;
    },
    deleteInfo(state) {
      state.user = null;
      state.waitPinCode = false;
    },
  },
});

export const selectRegisterUser = (state) => state.registration.user;
export const selectWaitPinCode = (state) => state.registration.waitPinCode;

export const { addInfo, editSingleField, finish, deleteInfo } =
  registrationSlice.actions;
export default registrationSlice.reducer;
