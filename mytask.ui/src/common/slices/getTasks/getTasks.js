import emptyApi from "../../../app/emptyApi";


export const getTasks = emptyApi.injectEndpoints({
    endpoints: (build) => ({
        GetTasks:  build.query({
            query: () => '/tasks/GetTasks/',
        })
    }),
    overrideExisting: false,
})

export const { useGetTasksQuery } = getTasks;