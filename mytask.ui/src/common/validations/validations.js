import * as yup from "yup";

const registerSchema = yup.object().shape({
  username: yup.string().required(),
  password: yup
    .string()
    .required()
    .min(8, "Password should be at least 8 characters long"),
  passwordRepeat: yup
    .string()
    .required()
    .min(8, "Password should be at least 8 characters long")
    .oneOf([yup.ref("password"), null], "Passwords don't match!"),
});

const loginSchema = yup.object().shape({
  username: yup.string().required(),
  password: yup.string().required(),
});

const addProjectSchema = yup.object().shape({
  name: yup.string().required(),
});

const addTaskSchema = yup.object().shape({
  name: yup.string().required(),
  project: yup.number().required(),
  description: yup.string().required(),
});

export default {
  registerSchema,
  loginSchema,
  addProjectSchema,
  addTaskSchema,
};
