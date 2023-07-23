import { configureStore } from "@reduxjs/toolkit";
import emptyApi from "../app/emptyApi";
import idpApi from "../app/idpApi";
import alertReducer from "../common/slices/infoService/infoService";

const store = configureStore({
  reducer: {
    [emptyApi.reducerPath]: emptyApi.reducer,
    [idpApi.reducerPath]: idpApi.reducer,
    alert: alertReducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(emptyApi.middleware, idpApi.middleware),
});

export default store;
