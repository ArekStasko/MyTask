import * as yup from "yup";

const registerSchema = yup.object().shape({
    username: yup
        .string()
        .required(),
    password: yup
        .string()
        .required()
        .min(8, "Password should be at least 8 characters long"),
    passwordRepeat: yup
        .string()
        .required()
        .min(8, "Password should be at least 8 characters long")
        .oneOf([yup.ref('password'), null], "Passwords don't match!")
})

const loginSchema = yup.object().shape({
    username: yup
        .string()
        .required(),
    password: yup
        .string()
        .required()
})

export default {
    registerSchema,
    loginSchema
}