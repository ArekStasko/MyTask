import { createSlice } from "@reduxjs/toolkit";

const alertSlice = createSlice({
  name: "alert",
  initialState: {
    isAlert: false,
    alertType: "",
  },
  reducers: {
    setIsAlert: (state, action) => {
      state.isAlert = action.payload;
    },
    setAlertType: (state, action) => {
      state.alertType = action.payload;
    },
  },
});

export const { setIsAlert, setAlertType } = alertSlice.actions;
export default alertSlice.reducer;
