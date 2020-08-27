import React from "react";
import { Form, Button, Alert } from "react-bootstrap";
import { LoginInfo } from "../../models/LoginInfo";
import fetch from "../../api/fetch";
import { SetToken } from "../../api/storageHelper";
export interface LoginProps {}
export interface LoginState {
  loginInfo: LoginInfo;
}
export default class Login extends React.Component<LoginProps, LoginState> {
  login = async () => {
    console.log(this.state.loginInfo);
    const response = await fetch(
      "http://localhost:53898/api/Login",
      "POST",
      this.state.loginInfo
    );
    if (response !== null && response.token !== null) {
      SetToken(response.token);
      window.location.href = "/dashboard";
    }
  };

  updatePassword = (e: any) => {
    let loginInfo = this.state.loginInfo;
    loginInfo.password = e.target.value;
    this.setState({
      loginInfo: loginInfo,
    });
  };
  updateUsername = (e: any) => {
    let loginInfo = this.state.loginInfo;
    loginInfo.username = e.target.value;
    this.setState({
      loginInfo: loginInfo,
    });
  };
  componentDidMount() {
    this.setState({
      loginInfo: {} as LoginInfo,
    });
  }
  render() {
    return (
      <div className="col-md-12 row">
        <div className="col-md-4"></div>
        <div className="col-md-4">
          <Alert className="col-md-12 vertical-spacing" variant="primary">
            Login
          </Alert>
          <Form className="vertical-spacing">
            <Form.Group controlId="formBasicEmail">
              <Form.Label>Username or Email Address</Form.Label>
              <Form.Control
                type="username"
                placeholder="Enter Username or Email Address"
                onChange={this.updateUsername}
              />
            </Form.Group>
            <Form.Group controlId="formBasicPassword">
              <Form.Label>Password</Form.Label>
              <Form.Control
                type="password"
                placeholder="Password"
                onChange={this.updatePassword}
              />
            </Form.Group>
            <Button variant="warning" onClick={this.login}>
              Forgot Password?
            </Button>
            <Button variant="primary" onClick={this.login}>
              Login
            </Button>
          </Form>
        </div>
        <div className="col-md-4"></div>
      </div>
    );
  }
}
