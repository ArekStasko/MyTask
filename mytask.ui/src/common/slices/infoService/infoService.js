import { createSlice } from "@reduxjs/toolkit";

const alertSlice = createSlice({
  name: "alert",
  initialState: {
    isAlert: false,
    alertType: "",
    alertMessage: "",
  },
  reducers: {
    setIsAlert: (state, action) => {
      state.isAlert = action.payload;
    },
    setAlertType: (state, action) => {
      state.alertType = action.payload;
    },
    setAlertMessage: (state, action) => {
      state.alertMessage = action.payload;
    },
  },
});

export const { setIsAlert, setAlertType, setAlertMessage } = alertSlice.actions;
export default alertSlice.reducer;
