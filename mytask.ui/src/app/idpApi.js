import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

const idpApi = createApi({
    reducerPath: 'idpApi',
    baseQuery: fetchBaseQuery({
        baseUrl: "http://localhost:8080/idp",
    }),
    endpoints: build => ({})
});

export default idpApi