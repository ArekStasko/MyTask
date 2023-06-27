import emptyApi from "../../../app/emptyApi";

export const registerUserApi = emptyApi.injectEndpoints({
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