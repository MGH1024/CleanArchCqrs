import {Link} from "react-router-dom";
import {FunctionComponent} from 'react'
import {IFooterItem} from "../../../types/footerItem";
export const FooterItem = ({to, liClass, linkClass, text}: IFooterItem) => {
    return (
        <li className={liClass}>
            <Link to={to} className={linkClass}>
                {text}
            </Link>
        </li>
    );
};

export default FooterItem;
