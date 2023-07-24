import { useDispatch } from "react-redux";
import {
  setIsAlert,
  setAlertType,
  setAlertMessage,
} from "../slices/infoService/infoService";

export const useAlertService = () => {
  const dispatch = useDispatch();

  const setAlert = (setValue, alertType, message) => {
    dispatch(setIsAlert(setValue));
    dispatch(setAlertType(alertType));
    dispatch(setAlertMessage(message));
  };

  return { setAlert };
};
