import {Link} from "react-router-dom";
import ISiteTitle from "../../../types/siteTitle";

export const SiteTitle = ({to, className, siteName}: ISiteTitle) => {
    return (
        <div className="bottom-border py-2 mt-0.9 mb-2">
            <Link to={to} className={className}>
                {siteName}
            </Link>
        </div>
    );
};
