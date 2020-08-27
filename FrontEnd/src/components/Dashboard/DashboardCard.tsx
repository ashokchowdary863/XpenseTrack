import React from "react";

interface DashboardCardProps {
  type: CardType;
  amount: number;
  currency: string;
  text: string;
}

export class CardType {
  static Info: string = "info";
  static Primary: string = "primary";
  static Success: string = "success";
  static Danger: string = "danger";
}

class DashboardCard extends React.Component<DashboardCardProps> {
    
  formatCurrency = (money: number, currency: string) => {
    return Intl.NumberFormat("en-US", {
      style: "currency",
      currency: currency,
    }).format(money);
  };

  render() {
    return (
      <div className="col-md-12">
        <div className={"card-counter " + this.props.type}>
          <i className="fa fa-users"></i>
          <span className="count-numbers">
            {this.formatCurrency(this.props.amount, this.props.currency)}{" "}
          </span>
          <span className="count-name">{this.props.text}</span>
        </div>
      </div>
    );
  }
}

export default DashboardCard;
