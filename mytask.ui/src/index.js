import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import store from "./store/store";
import { Provider } from "react-redux";
import { Context } from "./store/context";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <Provider store={store}>
      <Context.Provider
        value={{
          isAlert: false,
          alertType: "",
          setIsAlert: (value) => {
            this.isAlert = value;
          },
          setAlertType: (value) => {
            this.alertType = value;
          },
        }}
      >
        <App />
      </Context.Provider>
    </Provider>
  </React.StrictMode>
);

reportWebVitals();
