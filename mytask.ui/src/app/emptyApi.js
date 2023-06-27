import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import {GetToken} from "../common/services/cookieService";

const emptyApi = createApi({
    reducerPath: 'emptyApi',
    baseQuery: fetchBaseQuery({
        baseUrl: "http://localhost:8080/idp",
        prepareHeaders: (headers, { getState }) => {
            const token = GetToken();
            if (token) {
                headers.set('authorization', `Bearer ${token}`);
            }
            return headers;
        },
    }),
    endpoints: build => ({})
});

export default emptyApi