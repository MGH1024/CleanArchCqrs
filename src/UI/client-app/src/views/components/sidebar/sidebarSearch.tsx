import ISidebarSearch from "../../../types/sidebarSearch";

export const SidebarSearch = ({placeHolder}: ISidebarSearch) => {
    return (
        <div className="mt-1 mb-4">
            <form className="" action="">
                <div className="input-group">
                    <input
                        type="text"
                        placeholder={placeHolder}
                        className="search-input-sidebar text-white"
                    />
                </div>
            </form>
        </div>
    );
};
