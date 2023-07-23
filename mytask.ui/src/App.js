import "./App.css";
import MainRouting from "./routing/MainRouting";
import { BrowserRouter } from "react-router-dom";
import InfoService from "./common/services/InfoService";

function App() {
  return (
    <BrowserRouter>
      <div className="App">
        <MainRouting />
        <InfoService />
      </div>
    </BrowserRouter>
  );
}

export default App;
