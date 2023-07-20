import emptyApi from "../../../app/emptyApi";

export const generateRaportApi = emptyApi.injectEndpoints({
  endpoints: (build) => ({
    GenerateRaport: build.mutation({
      query: ({ projectId, ...rest }) => ({
        url: `/raports/Generate?projectId=${projectId}`,
        method: "POST",
      }),
    }),
  }),
  overrideExisting: false,
});

export const { useGenerateRaportMutation } = generateRaportApi;
