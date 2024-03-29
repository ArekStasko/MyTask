import {
  Box,
  Button,
  CircularProgress,
  Container,
  Link,
  TextField,
  Typography,
} from "@mui/material";
import InputAdornment from "@mui/material/InputAdornment";
import KeyIcon from "@mui/icons-material/Key";
import PersonIcon from "@mui/icons-material/Person";
import { FormProvider, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import validations from "../../common/validations/validations";
import { SaveToken } from "../../common/services/cookieService";
import { useLoginMutation } from "../../common/slices/login/loginSlice";
import { useNavigate } from "react-router-dom";
import RoutingPaths from "../../routing/RoutingConstants";
import { useAlertService } from "../../common/services/alertSetter";

const Login = () => {
  const [login, { isLoading: loginLoading }] = useLoginMutation();
  const navigate = useNavigate();
  const alertService = useAlertService();

  const methods = useForm({
    mode: "onChange",
    resolver: yupResolver(validations.loginSchema),
  });

  const {
    trigger,
    setValue,
    setError,
    clearErrors,
    formState: { errors },
  } = methods;

  const loginUser = async () => {
    const username = methods.getValues("username");
    const password = methods.getValues("password");

    try {
      const result = await login({ username, password });
      if (result.error.status === "FETCH_ERROR") {
        alertService.setAlert(
          true,
          "error",
          "You have provided wrong credentials"
        );
        setError("username", { message: "Wrong Value" });
        setError("password", { message: "Wrong Value" });
        return;
      }
      SaveToken(result.error.data);
      navigate(RoutingPaths.dashboard);
      alertService.setAlert(true, "success", "You have successfuly logged in");
    } catch (error) {
      alertService.setAlert(true, "error", "We ran into some error");
    }
  };

  const areFieldsCorrect = () => {
    const username = methods.getValues("username");
    const password = methods.getValues("password");

    if (username === undefined || password === undefined) return false;
    if (Object.keys(errors).length !== 0) return false;
    return true;
  };

  const handleChange = (e) => {
    clearErrors("username");
    clearErrors("password");

    const {
      target: { value, id },
    } = e;
    setValue(id, value);
    trigger(id);
  };

  return (
    <Container
      sx={{
        height: "100%",
        width: "100%",
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
      }}
    >
      <Box
        sx={{
          height: "60%",
          width: "25%",
          display: "flex",
          flexDirection: "column",
          justifyContent: "space-between",
          alignItems: "center",
        }}
      >
        <Typography variant="h3" gutterBottom>
          Log In
        </Typography>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            height: "35%",
            width: "100%",
            justifyContent: "space-around",
          }}
        >
          <FormProvider {...methods}>
            <TextField
              color="primary"
              id="username"
              label="Username"
              variant="outlined"
              error={!!errors.username}
              helperText={errors?.username?.message}
              onChange={(e) => handleChange(e)}
              fullWidth
              InputProps={{
                startAdornment: (
                  <InputAdornment position="start">
                    <PersonIcon color="primary" />
                  </InputAdornment>
                ),
              }}
              sx={{
                mb: 2,
              }}
            />
            <TextField
              color="primary"
              id="password"
              type="password"
              label="Password"
              variant="outlined"
              error={!!errors.password}
              helperText={errors?.password?.message}
              onChange={(e) => handleChange(e)}
              fullWidth
              InputProps={{
                startAdornment: (
                  <InputAdornment position="start">
                    <KeyIcon color="primary" />
                  </InputAdornment>
                ),
              }}
              sx={{
                mb: 1,
              }}
            />
          </FormProvider>
        </Box>
        {loginLoading ? (
          <CircularProgress />
        ) : (
          <Button
            variant="contained"
            sx={{ width: "100%", p: 1 }}
            onClick={() => loginUser()}
            disabled={!areFieldsCorrect()}
          >
            Login
          </Button>
        )}
        <Link href={RoutingPaths.register} underline="none" sx={{ mt: 0.5 }}>
          I don't have an account
        </Link>
      </Box>
    </Container>
  );
};

export default Login;
