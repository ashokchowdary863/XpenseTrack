import React from "react";
import {
  Navbar,
  Form,
  FormControl,
  Button,
  Nav,
  Container,
} from "react-bootstrap";
import { RemoveToken } from "../../api/storageHelper";

class AppBar extends React.Component {
  logout = () =>{
    RemoveToken();
    window.location.href="/login";
  }
  render() {
    return (
      <Container>
        <Navbar bg="light" variant="light">
          <Navbar.Brand href="/home">
            XpenseTrack - Personal Expense Tracking
          </Navbar.Brand>
          <Nav className="mr-auto">
            <Nav.Link href="/dashboard">Dashboard</Nav.Link>
            <Nav.Link href="/expenses">Expenses</Nav.Link>
            <Nav.Link href="/reports">Reports</Nav.Link>
          </Nav>
          <Form inline>
            <Nav.Link href="/profile">Profile</Nav.Link>
            <Nav.Link onClick={this.logout}>Logout</Nav.Link>
            <Nav.Link href="/login">Login</Nav.Link>
            <Nav.Link href="/register">Register</Nav.Link>
          </Form>
        </Navbar>
      </Container>
    );
  }
}

export default AppBar;
