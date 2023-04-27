import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
const Icon = (props:any) => {
  return (
    <FontAwesomeIcon
      icon={props.icon}
      className={props.className}
    ></FontAwesomeIcon>
  );
};

export default Icon;
