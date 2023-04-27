import ICurrentUser from "../../../types/currentUser";
import {SpanText} from "../public/spanText";


const CurrentUser = ({imageSrc,imageClass,userName}: ICurrentUser) => {
    return (
        <div className="bottom-border">
            <div className="me-4 py-4">
                <img
                    src={imageSrc}
                    className={imageClass}
                    alt={userName}
                />
                <a className="text-white" style={{textDecoration: "none"}} href="/#">
                    <SpanText text={userName} className="sidebar-li-span"/>
                </a>
            </div>
        </div>
    );
};

export default CurrentUser;
