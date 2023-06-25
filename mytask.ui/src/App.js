import logo from './logo.svg';
import './App.css';
import MainRouting from "./routing/MainRouting";
import {BrowserRouter} from "react-router-dom";
import {Provider} from "react-redux";
import store from "./store/store";

function App() {
  return (
      <BrowserRouter>
          <Provider store={store}>
              <div className="App">
                  <MainRouting />
              </div>
          </Provider>
      </BrowserRouter>
  );
}

export default App;
