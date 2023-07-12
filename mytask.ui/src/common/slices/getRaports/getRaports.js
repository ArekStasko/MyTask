import emptyApi from "../../../app/emptyApi";

export const getRaports = emptyApi.injectEndpoints({
  endpoints: (build) => ({
    GetRaports: build.query({
      query: () => "/raports/Get/",
    }),
  }),
  overrideExisting: false,
});

export const { useGetRaportsQuery } = getRaports;
