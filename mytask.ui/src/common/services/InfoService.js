import * as React from "react";
import Snackbar from "@mui/material/Snackbar";
import MuiAlert from "@mui/material/Alert";
import { useDispatch, useSelector } from "react-redux";
import { setIsAlert, setAlertType } from "../slices/infoService/infoService";

const Alert = React.forwardRef(function Alert(props, ref) {
  return <MuiAlert elevation={6} ref={ref} variant="filled" {...props} />;
});

const InfoService = () => {
  const dispatch = useDispatch();
  const isAlert = useSelector((state) => state.alert.isAlert);
  const alertType = useSelector((state) => state.alert.alertType);
  const handleClose = (event, reason) => {
    if (reason === "clickaway") {
      return;
    }

    dispatch(setIsAlert(false));
    dispatch(setAlertType(""));
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

export default InfoService;
