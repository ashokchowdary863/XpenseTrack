import React from "react";
import { Form, Button, Alert } from "react-bootstrap";
import fetch from "../../api/fetch";
import { LoginInfo } from "../../models/LoginInfo";
interface RegisterProps { }
interface RegisterState {
  registerInfo: any
  errorsInfo: any
}

export default class Register extends React.Component<RegisterProps, RegisterState> {
  constructor(props: any) {
    super(props)
    this.state = {
      registerInfo: {},
      errorsInfo: {}
    }
  }
  register = async () => {
    console.log(this.state.registerInfo);
    const response = await fetch(
      "http://localhost:53898/api/Registration",
      "POST",
      this.state.registerInfo
    );
    console.log(response);
    if (response !== null && response.msg !== null) {
      window.location.href = "/login";
    }
  }

  checkUserExist = async () => {
    let data = {
      userName: this.state.registerInfo.userName
    }
    const response = await fetch(
      "http://localhost:53898/checkUser",
      "GET",
      data
    )
    return response;
  }

  onRegister = () => {
    this.setState({
      errorsInfo: {}
    })
    this.validateRegisterInfo();
    console.log(this.state.errorsInfo)
    console.log(this.state.registerInfo)
    if (this.isEmpty(this.state.errorsInfo)) {
      this.register();
    }
  }
  validateRegisterInfo = () => {
    this.validateEmail();
    this.validateUserName();
    this.validateFirstName();
    this.validatePassword();
    this.validateLastName();
  }

  validateUserName = () => {
    let userName = this.state.registerInfo.userName;
    let errorsInfo = this.state.errorsInfo;
    if (userName.length < 4) {
      errorsInfo.userName = "UserName Should Contains Atleast 4 Characters !";
    } else {
      let regex = /^[a-z\d\-_\s]+$/i
      if (regex.test(userName)) {
        if (this.checkUserExist()) {
          errorsInfo.userName = "A User Already Exists with this UserName !";
        }
      } else {
        errorsInfo.userName = "Only Alphanumneric Underscore Space Allowed !";

      }
    }
    this.setErrorsInfo(errorsInfo)
  }

  validateEmail = () => {
    var email = this.state.registerInfo.email
    var errors = this.state.errorsInfo;
    var regex = /^[a-zA-Z0-9]+@(?:[a-zA-Z0-9]+\.)+[A-Za-z]+$/
    if (!regex.test(email)) {
      errors.email = "Email is not Valid !"
    }
    this.setErrorsInfo(errors)
  }

  validatePassword = () => {
    let password = this.state.registerInfo.password;
    let errorsInfo = this.state.errorsInfo;
    if (password.length < 8) {
      errorsInfo.password = "Password Should Contains Atleast 8 Characters !";
    }
    this.setErrorsInfo(errorsInfo)
  }
  validateFirstName = () => {
    let firstName = this.state.registerInfo.firstName;
    let errorsInfo = this.state.errorsInfo;
    if (firstName.length < 3) {
      errorsInfo.firstName = "FirstName Should Contains Atleast 3 Characters !";
    }
    this.setErrorsInfo(errorsInfo)
  }

  validateLastName = () => {
    let lastName = this.state.registerInfo.lastName;
    let errorsInfo = this.state.errorsInfo;
    if (lastName.length < 3) {
      errorsInfo.lastName = "LastName Should Contains Atleast 3 Characters !";
    }
    this.setErrorsInfo(errorsInfo)
  }

  updateUserName = (e: any) => {
    let registerInfo = this.state.registerInfo;
    registerInfo.userName = e.target.value;
    this.setRegisterInfo(registerInfo);
  }

  updatePassword = (e: any) => {
    let registerInfo = this.state.registerInfo;
    registerInfo.password = e.target.value;
    this.setRegisterInfo(registerInfo);
  }

  updateFirstName = (e: any) => {
    let registerInfo = this.state.registerInfo;
    registerInfo.firstName = e.target.value;
    this.setRegisterInfo(registerInfo);
  }

  updateLastName = (e: any) => {
    let registerInfo = this.state.registerInfo;
    registerInfo.lastName = e.target.value;
    this.setRegisterInfo(registerInfo);
  }

  updateEmail = (e: any) => {
    let registerInfo = this.state.registerInfo;
    registerInfo.email = e.target.value;
    this.setRegisterInfo(registerInfo);
  }

  isEmpty(obj: any) {
    for (var key in obj) {
      if (obj.hasOwnProperty(key))
        return false;
    }
    return true;
  }

  setRegisterInfo = (registerInfo: any) => {
    this.setState({
      registerInfo: registerInfo
    })
  }

  setErrorsInfo = (errorsInfo: any) => {
    this.setState({
      errorsInfo: errorsInfo
    })
  }

  render() {
    return (
      <div className="col-md-12 row">
        <div className="col-md-4"></div>
        <div className="col-md-4">
          <Alert className="col-md-12 vertical-spacing" variant="warning">
            User Registration
          </Alert>
          <Form className="vertical-spacing">
            <Form.Group controlId="formBasicEmail">
              <Form.Label>Username *</Form.Label>
              <Form.Control
                type="username"
                placeholder="Enter Username"
                onChange={this.updateUserName}
              />
              <span className="isa_error">{this.state.errorsInfo.userName}</span>
            </Form.Group>
            <Form.Group controlId="formBasicEmail">
              <Form.Label>Email Address *</Form.Label>
              <Form.Control
                type="username"
                placeholder="Enter Email Address"
                onChange={this.updateEmail}
              />
              <span className="isa_error">{this.state.errorsInfo.email}</span>
            </Form.Group>
            <Form.Group controlId="formBasicEmail">
              <Form.Label>First name *</Form.Label>
              <Form.Control
                type="username"
                placeholder="Enter First name"
                onChange={this.updateFirstName}
              />
              <span className="isa_error">{this.state.errorsInfo.firstName}</span>
            </Form.Group>
            <Form.Group controlId="formBasicEmail">
              <Form.Label>Last name *</Form.Label>
              <Form.Control
                type="username"
                placeholder="Enter Last name"
                onChange={this.updateLastName}
              />
              <span className="isa_error">{this.state.errorsInfo.lastName}</span>
            </Form.Group>
            <Form.Group controlId="formBasicPassword">
              <Form.Label>Password *</Form.Label>
              <Form.Control type="password" placeholder="Password" onChange={this.updatePassword} />
              <span className="isa_error">{this.state.errorsInfo.password}</span>
            </Form.Group>

            <Button variant="success" type="button" onClick={this.onRegister}>
              Register
            </Button>
          </Form>
        </div>
        <div className="col-md-4"></div>
      </div>
    );
  }
}
