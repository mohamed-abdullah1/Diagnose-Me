import { createSlice } from "@reduxjs/toolkit";

const initialState = {
  user: null,
  waitPinCode: false,
  isReg: false,
  wantToBeDoctor: false,
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
    changeIsReg(state, action) {
      state.isReg = action.payload;
    },
    changeWantToBeDoctor(state, action) {
      state.wantToBeDoctor = action.payload;
    },
  },
});

export const selectRegisterUser = (state) => state.registration.user;
export const selectWaitPinCode = (state) => state.registration.waitPinCode;
export const selectIsReg = (state) => state.registration.isReg;
export const selectWantToBeDoctor = (state) =>
  state.registration.wantToBeDoctor;
export const {
  addInfo,
  editSingleField,
  finish,
  deleteInfo,
  changeIsReg,
  changeWantToBeDoctor,
} = registrationSlice.actions;
export default registrationSlice.reducer;
