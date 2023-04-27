import SpanText from "../public/spanText";

const CurrentUser = (props:any) => {
  return (
    <div className="bottom-border">
      <div className="me-4 py-4">
        <img
          src={props.imageSrc}
          className={props.imageClass}
          alt={props.userName}
        />
        <a className="text-white" style={{ textDecoration: "none" }} href="/#">
          <SpanText text={props.userName} spanClass="sidebar-li-span" />
        </a>
      </div>
    </div>
  );
};

export default CurrentUser;
