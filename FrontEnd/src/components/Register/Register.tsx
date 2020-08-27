import React from "react";
import { Form, Button, Alert } from "react-bootstrap";
import { LoginInfo } from "../../models/LoginInfo";

export default class Register extends React.Component {
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
              <Form.Label>Username </Form.Label>
              <Form.Control
                type="username"
                placeholder="Enter Username"
              />
            </Form.Group>
            <Form.Group controlId="formBasicEmail">
              <Form.Label>Email Address</Form.Label>
              <Form.Control
                type="username"
                placeholder="Enter Email Address"
              />
            </Form.Group>
            <Form.Group controlId="formBasicEmail">
              <Form.Label>First name</Form.Label>
              <Form.Control
                type="username"
                placeholder="Enter First name"
              />
            </Form.Group>
            <Form.Group controlId="formBasicEmail">
              <Form.Label>Last name</Form.Label>
              <Form.Control
                type="username"
                placeholder="Enter Last name"
              />
            </Form.Group>
            <Form.Group controlId="formBasicPassword">
              <Form.Label>Password</Form.Label>
              <Form.Control type="password" placeholder="Password" />
            </Form.Group>
            <Button variant="success" type="submit">
              Register
            </Button>
          </Form>
        </div>
        <div className="col-md-4"></div>
      </div>
    );
  }
}
