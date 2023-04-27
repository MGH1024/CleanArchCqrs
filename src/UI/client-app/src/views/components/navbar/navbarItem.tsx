import {Icon} from "../public/icon";
import {Link} from "react-router-dom";
import INavbarItem from "../../../types/navbarItem";

export const NavbarItem = ({to, linkClassName, dataToggle, navbarIcon, iconClassName}: INavbarItem) => {
    return (
        <li className="nav-item ">
            <Link
                to={to}
                className={linkClassName}
                data-toggle={dataToggle}
            >
                <Icon icon={navbarIcon} className={iconClassName}/>
            </Link>
        </li>
    );
};
