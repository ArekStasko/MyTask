import idpApi from "../../../app/idpApi";

export const registerUserApi = idpApi.injectEndpoints({
    endpoints: (build) => ({
        Register: build.mutation({
            query: ({ ...rest }) => ({
                url: '/users/Register/',
                method: 'POST',
                body: rest,
            })
        }),
    }),
    overrideExisting: false,
});

export const { useRegisterMutation } = registerUserApi;