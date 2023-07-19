import emptyApi from "../../../app/emptyApi";

export const createProjectApi = emptyApi.injectEndpoints({
  endpoints: (build) => ({
    CreateProject: build.mutation({
      query: ({ ...rest }) => ({
        url: "/projects/Create/",
        method: "POST",
        body: rest,
      }),
    }),
  }),
  overrideExisting: false,
});

export const { useCreateProjectMutation } = createProjectApi;
