import emptyApi from "../../../app/emptyApi";


export const getProjects = emptyApi.injectEndpoints({
    endpoints: (build) => ({
        GetProjects:  build.query({
            query: () => '/projects/Get/',
        })
    }),
    overrideExisting: false,
})

export const { useGetProjectsQuery } = getProjects;