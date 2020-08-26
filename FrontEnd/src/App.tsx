import React from "react";
import logo from "./logo.svg";
import { BrowserRouter } from 'react-router-dom';
import "./App.css";
import AppBar from "./components/AppBar/AppBar";
import { withRouter, Route, Switch } from "react-router";
import Login from "./components/Login/Login";

function App() {
  return (
    <div>
      <BrowserRouter>
      <AppBar />
      <div className="mainContent">
        <Switch>
          <Route path="/" component={Login} />
          <Route path="/login" component={Login} />
        </Switch>
      </div>
      </BrowserRouter>
    </div>
  );
}

export default App;
