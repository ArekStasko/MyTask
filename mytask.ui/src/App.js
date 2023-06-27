import logo from './logo.svg';
import './App.css';
import MainRouting from "./routing/MainRouting";
import {BrowserRouter} from "react-router-dom";

function App() {
  return (
      <BrowserRouter>
              <div className="App">
                  <MainRouting />
              </div>
      </BrowserRouter>
  );
}

export default App;
