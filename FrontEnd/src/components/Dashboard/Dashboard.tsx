import React from "react";
import { Container, Card } from "react-bootstrap";
import DashboardCard, { CardType } from "./DashboardCard";
export default class Dashboard extends React.Component {

  render() {
    return (
      <Container>
        <Card className="vertical-spacing">
          <Card.Header>Expenses Overview</Card.Header>
          <Card.Body>
            <div className="col-md-12 row">
              <div className="col-md-4">
                <DashboardCard
                  amount={1000}
                  text="This Month"
                  currency="INR"
                  type={CardType.Info}
                />
              </div>
              <div className="col-md-4">
                <DashboardCard
                  amount={1500}
                  text="Last Month"
                  currency="INR"
                  type={CardType.Primary}
                />
              </div>
              <div className="col-md-4">
                <DashboardCard
                  amount={100000}
                  text="This Year"
                  currency="INR"
                  type={CardType.Success}
                />
              </div>
            </div>
          </Card.Body>
        </Card>
      </Container>
    );
  }
}
