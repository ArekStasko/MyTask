import idpApi from "../../../app/idpApi";

export const loginUserApi = idpApi.injectEndpoints({
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