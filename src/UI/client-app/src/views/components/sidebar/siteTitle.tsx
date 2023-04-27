import { Link } from "react-router-dom";
const SiteTitle = (props:any) => {
  return (
    <div className="bottom-border py-2 mt-0.9 mb-2">
      <Link to={props.to} className={props.className}>
        {props.siteName}
      </Link>
    </div>
  );
};

export default SiteTitle;
