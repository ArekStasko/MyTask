import {
  Box,
  Button,
  Container,
  Link,
  TextField,
  Typography,
  CircularProgress,
} from "@mui/material";
import InputAdornment from "@mui/material/InputAdornment";
import KeyIcon from "@mui/icons-material/Key";
import PersonIcon from "@mui/icons-material/Person";
import { yupResolver } from "@hookform/resolvers/yup";
import { FormProvider, useForm } from "react-hook-form";
import validations from "../../common/validations/validations";
import { useRegisterMutation } from "../../common/slices/register/registerSlice";
import { SaveToken } from "../../common/services/cookieService";
import { useNavigate } from "react-router-dom";
import RoutingPaths from "../../routing/RoutingConstants";

const Register = () => {
  const [register, { isLoading: registerLoading }] = useRegisterMutation();
  const navigate = useNavigate();

  const methods = useForm({
    mode: "onChange",
    resolver: yupResolver(validations.registerSchema),
  });

  const {
    trigger,
    setValue,
    formState: { errors },
  } = methods;

  const isPasswordCorrect = () => {
    const username = methods.getValues("username");
    const password = methods.getValues("password");
    const passwordRepeat = methods.getValues("passwordRepeat");

    if (
      username === undefined ||
      password === undefined ||
      passwordRepeat === undefined
    )
      return false;
    if (username.length === 0) return false;
    if (password.length < 8 || passwordRepeat.length < 8) return false;
    if (Object.keys(errors).length !== 0) return false;
    return true;
  };

  const registerUser = async () => {
    const username = methods.getValues("username");
    const password = methods.getValues("password");

    try {
      const result = await register({ username, password });
      SaveToken(result.error.data);
      navigate(RoutingPaths.dashboard);
    } catch (error) {
      console.log(error);
    }
  };

  const handleChange = (e) => {
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
          height: "70%",
          width: "25%",
          display: "flex",
          flexDirection: "column",
          justifyContent: "space-between",
          alignItems: "center",
        }}
      >
        <Typography variant="h3" gutterBottom>
          Register
        </Typography>
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            height: "45%",
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
              type="password"
              color="primary"
              id="password"
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
                mb: 2,
              }}
            />
            <TextField
              type="password"
              color="primary"
              id="passwordRepeat"
              label="Repeat Password"
              variant="outlined"
              error={!!errors.passwordRepeat}
              helperText={errors?.passwordRepeat?.message}
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
        {registerLoading ? (
          <CircularProgress />
        ) : (
          <Button
            variant="contained"
            sx={{ width: "100%", p: 1 }}
            onClick={() => registerUser()}
            disabled={!isPasswordCorrect()}
          >
            Register
          </Button>
        )}
        <Link href="/login" underline="none" sx={{ mt: 0.5 }}>
          I already have an account
        </Link>
      </Box>
    </Container>
  );
};

export default Register;
