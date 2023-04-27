import {FontAwesomeIcon} from "@fortawesome/react-fontawesome";
import IIconType from "../../../types/icontype";

export const Icon = ({icon, className}: IIconType) => {
    return (
        <FontAwesomeIcon
            icon={icon}
            className={className}
        ></FontAwesomeIcon>
    );
};
