import {configureStore} from "@reduxjs/toolkit";
import emptyApi from "../app/emptyApi";
import idpApi from "../app/idpApi";


const store = configureStore({
    reducer: {
        [emptyApi.reducerPath]: emptyApi.reducer,
        [idpApi.reducerPath]: idpApi.reducer,
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(
            emptyApi.middleware,
            idpApi.middleware
        ),
});

export default store
