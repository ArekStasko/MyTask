import emptyApi from "../../../app/emptyApi";

export const loginUserApi = emptyApi.injectEndpoints({
    endpoints: (build) => ({
        Login: build.mutation({
            query: ({ ...rest }) => ({
                url: '/users/Login/',
                method: 'POST',
                body: rest,
            })
        }),
    }),
    overrideExisting: false,
});

export const { useLoginMutation } = loginUserApi;