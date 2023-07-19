import emptyApi from "../../../app/emptyApi";

export const createTaskApi = emptyApi.injectEndpoints({
  endpoints: (build) => ({
    CreateTask: build.mutation({
      query: ({ ...rest }) => ({
        url: "/tasks/Create/",
        method: "POST",
        body: rest,
      }),
    }),
  }),
  overrideExisting: false,
});

export const { useCreateTaskMutation } = createTaskApi;
