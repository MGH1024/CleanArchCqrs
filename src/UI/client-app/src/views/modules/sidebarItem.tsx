import {Link} from "react-router-dom";
import {Icon} from "../components/public/icon";
import {SpanText} from "../components/public/spanText";
import ISideBarItem from "../../types/sideBarItem";

const SidebarItem = ({
                         liClass, to, linkClass, sidebarItemIcon, iconClassName,
                         spanClass, sideBarItemSpanText
                     }: ISideBarItem) => {
    return (
        <li className={liClass}>
            <Link to={to} className={linkClass}>
                <Icon icon={sidebarItemIcon} className={iconClassName}/>
                <SpanText className={spanClass} text={sideBarItemSpanText}/>
            </Link>
        </li>
    );
};

export default SidebarItem;
