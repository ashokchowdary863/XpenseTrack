import React from "react";
import { BrowserRouter } from 'react-router-dom';
import "./App.css";
import AppBar from "./components/AppBar/AppBar";
import {  Route, Switch } from "react-router";
import Login from "./components/Login/Login";
import Dashboard from "./components/Dashboard/Dashboard";
import Expenses from "./components/Expenses/Expenses";
import Reports from "./components/Reports/Reports";
import Register from "./components/Register/Register";
import Profile from "./components/Profile/Profile";

function App() {
  return (
    <div>
      <BrowserRouter>
      <AppBar />
      <div className="mainContent">
        <Switch>
          <Route path="/home" component={Dashboard} />
          <Route path="/dashboard" component={Dashboard} />
          <Route path="/expenses" component={Expenses} />
          <Route path="/reports" component={Reports} />
          <Route path="/profile" component={Profile} />

          <Route path="/login" component={Login} />
          <Route path="/register" component={Register} />
        </Switch>
      </div>
      </BrowserRouter>
    </div>
  );
}

export default App;
