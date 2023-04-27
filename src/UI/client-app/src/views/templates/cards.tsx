import Card from "../modules/card";
import {
  faShoppingCart,
  faSync,
  faMoneyBillAlt,
  faChartLine,
  faUsers,
} from "@fortawesome/free-solid-svg-icons";
const Cards = () => {
  return (
    <section>
      <div className="container-fluid">
        <div className="col-sm-12">
          <div className="row">
            <Card
              text="Sell"
              icon1={faShoppingCart}
              icon1Class="fa-3x text-danger"
              icon2={faSync}
              icon2Class="m-1 me-2 ms-3"
            />

            <Card
              text="Prices"
              icon1={faMoneyBillAlt}
              icon1Class="fa-3x text-success"
              icon2={faSync}
              icon2Class="m-1 me-2 ms-3"
            />

            <Card
              text="users"
              icon1={faUsers}
              icon1Class="fa-3x text-info"
              icon2={faSync}
              icon2Class="m-1 me-2 ms-3"
            />

            <Card
              text="View"
              icon1={faChartLine}
              icon1Class="fa-3x text-danger"
              icon2={faSync}
              icon2Class="m-1 me-2 ms-3"
            />
          </div>
        </div>
      </div>
    </section>
  );
};

export default Cards;
