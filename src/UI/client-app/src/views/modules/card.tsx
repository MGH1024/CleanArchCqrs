import {Icon} from "../components/public/icon";
import ICard from "../../types/cardType";

const Card = ({text,icon1,icon1Class,icon2}:ICard) => {
  return (
    <div className="col-lg-3 col-md-6 p-2">
      <div className="card card-common">
        <div className="card-body">
          <div className="d-flex justify-content-between align-items-center">
            <div className="text-secondary">
              <h5>{text}</h5>
              <h5 className="mt-4">25000</h5>
            </div>
            <Icon icon={icon1} className={icon1Class} />
          </div>
        </div>
        <div className="card-footer text-secondary text-left">
          <Icon icon={icon2} className="m-1 me-2 ms-3" />
          <span>updating...</span>
        </div>
      </div>
    </div>
  );
};

export default Card;
