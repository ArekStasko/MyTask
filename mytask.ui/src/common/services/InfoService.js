import * as React from "react";
import Snackbar from "@mui/material/Snackbar";
import MuiAlert from "@mui/material/Alert";
import { useContext } from "react";
import { Context } from "../../store/context";

const Alert = React.forwardRef(function Alert(props, ref) {
  return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
});

const InfoService = () => {
  const { isAlert, alertType, setIsAlert, setAlertType } = useContext(Context);

  const handleClose = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }

    setIsAlert(false);
    setAlertType("");
  };

  return (
    <>
      <Snackbar open={isAlert} autoHideDuration={6000} onClose={handleClose}>
        <Alert
          onClose={handleClose}
          severity={alertType}
          sx={{ width: "100%" }}
        >
          This is a success message!
        </Alert>
      </Snackbar>
    </>
  );
};

export default InfoService();
