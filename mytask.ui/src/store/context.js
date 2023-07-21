import { createContext } from "react";

export const Context = createContext({
  isAlert: false,
  alertType: "",
  setIsAlert: () => {},
  setAlertType: () => {},
});
