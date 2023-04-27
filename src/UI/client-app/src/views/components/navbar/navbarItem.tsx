import Icon from "../public/icon";
import { Link } from "react-router-dom";

const NavbarItem = (props:any) => {
  return (
    <li className="nav-item ">
      <Link
        to={props.to}
        className={props.linkClassName}
        data-toggle={props.dataToggle}
      >
        <Icon icon={props.icon} className={props.iconClassName} />
      </Link>
    </li>
  );
};

export default NavbarItem;
