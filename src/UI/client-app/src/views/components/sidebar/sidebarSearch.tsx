const SidebarSearch = (props:any) => {
  return (
    <div className="mt-1 mb-4">
      <form className="" action="">
        <div className="input-group">
          <input
            type="text"
            placeholder={props.placeHolder}
            className="search-input-sidebar text-white"
          />
        </div>
      </form>
    </div>
  );
};

export default SidebarSearch;
