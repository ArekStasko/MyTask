import {configureStore} from "@reduxjs/toolkit";
import emptyApi from "../app/emptyApi";


const store = configureStore({
    reducer: {
    [emptyApi.reducerPath]: emptyApi.reducer,
    },
    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(
            emptyApi.middleware
        ),
});

export default store
