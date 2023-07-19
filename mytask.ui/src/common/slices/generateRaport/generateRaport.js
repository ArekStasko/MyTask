import emptyApi from "../../../app/emptyApi";

export const generateRaportApi = emptyApi.injectEndpoints({
  endpoints: (build) => ({
    GenerateRaport: build.mutation({
      query: ({ RaportId, ...rest }) => ({
        url: "/raports/Generate/",
        params: { RaportId },
        method: "POST",
        body: rest,
      }),
    }),
  }),
  overrideExisting: false,
});

export const { useGenerateRaportMutation } = generateRaportApi;
