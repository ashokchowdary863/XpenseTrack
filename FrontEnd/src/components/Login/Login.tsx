import React from "react";
import { makeStyles } from "@material-ui/core/styles";
import { TextField, Container, Grid, Paper } from "@material-ui/core";

export default class Login extends React.Component {
  render() {
    return (
      <Container fixed>
        <Grid container spacing={3}>
          <Grid item xs={12}>
            <Paper>xs=12</Paper>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Paper>xs=12 sm=6</Paper>
          </Grid>
          <Grid item xs={12} sm={6}>
            <Paper>xs=12 sm=6</Paper>
          </Grid>
        </Grid>
        <form noValidate autoComplete="off">
          <TextField id="outlined-basic" label="Outlined" variant="outlined" />
        </form>
      </Container>
    );
  }
}
