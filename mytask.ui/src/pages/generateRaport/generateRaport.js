import {
  Backdrop,
  CircularProgress,
  Container,
  InputLabel,
  MenuItem,
  Select,
} from "@mui/material";
import * as React from "react";
import Box from "@mui/material/Box";
import Card from "@mui/material/Card";
import CardActions from "@mui/material/CardActions";
import CardContent from "@mui/material/CardContent";
import Button from "@mui/material/Button";
import Typography from "@mui/material/Typography";
import { FormProvider, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import validations from "../../common/validations/validations";
import { useNavigate } from "react-router-dom";
import RoutingPaths from "../../routing/RoutingConstants";
import SelectProject from "../../common/components/selectProject";
import { useGenerateRaportMutation } from "../../common/slices/generateRaport/generateRaport";
import { useContext, useEffect, useState } from "react";
import { useAlertService } from "../../common/services/alertSetter";

const GenerateRaport = () => {
  const [generateRaport, { isLoading: generateRaportLoadng }] =
    useGenerateRaportMutation();
  const navigate = useNavigate();
  const [correct, setCorret] = useState(false);
  const alertService = useAlertService();

  const methods = useForm({
    mode: "onChange",
    resolver: yupResolver(validations.generateRaportSchema),
  });

  const {
    control,
    watch,
    formState: { errors },
  } = methods;

  const areFieldsCorrect = () => {
    const project = methods.getValues("project");

    if (project === undefined) return false;
    if (Object.keys(errors).length !== 0) return false;
    return true;
  };

  useEffect(() => {
    setCorret(areFieldsCorrect());
  }, [watch("project")]);

  const generateNewRaport = async () => {
    const project = methods.getValues("project");

    try {
      await generateRaport({ projectId: project });
      navigate(RoutingPaths.dashboard);
      alertService.setAlert(true, "success", "Raport successfuly generated");
    } catch (error) {
      alertService.setAlert(true, "error", "We ran into some error");
    }
  };

  return (
    <Container
      sx={{
        width: "100%",
        height: "100%",
        display: "flex",
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      <Card variant="outlined">
        <CardContent>
          <Typography variant="h5" component="div">
            Generate new Raport
          </Typography>
          <Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
            Fill the form and submit to generate new raport
          </Typography>
          <Box sx={{ p: 4 }}>
            <FormProvider {...methods}>
              <SelectProject errors={errors} control={control} />
            </FormProvider>
          </Box>
        </CardContent>
        <CardActions sx={{ display: "flex", justifyContent: "space-between" }}>
          <Button
            sx={{ m: 2 }}
            variant="outlined"
            size="medium"
            onClick={() => navigate(RoutingPaths.dashboard)}
          >
            Cancel
          </Button>
          {generateRaportLoadng ? (
            <CircularProgress />
          ) : (
            <Button
              disabled={!correct}
              sx={{ m: 2 }}
              variant="outlined"
              size="medium"
              onClick={() => generateNewRaport()}
            >
              Submit
            </Button>
          )}
        </CardActions>
      </Card>
    </Container>
  );
};

export default GenerateRaport;
