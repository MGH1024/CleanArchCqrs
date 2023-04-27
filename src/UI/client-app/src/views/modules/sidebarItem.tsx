import Icon from "../components/public/icon";
import SpanText from "../components/public/spanText";
import { Link } from "react-router-dom";

const SidebarItem = (props:any) => {
  return (
    <li className={props.liClass}>
      <Link to={props.to} className={props.linkClass}>
        <Icon icon={props.icon} className={props.iconClassName} />
        <SpanText className={props.spanClass} text={props.spanText} />
      </Link>
    </li>
  );
};

export default SidebarItem;
