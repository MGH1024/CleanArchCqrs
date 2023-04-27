import {
  faUser,
  faHome,
  faEnvelope,
  faShoppingCart,
  faChartLine,
  faChartBar,
  faTable,
  faWrench,
} from "@fortawesome/free-solid-svg-icons";
import CurrentUser from "../components/sidebar/currentUser";
//import CustomImage from "../../assets/images/profile.jpg";



import SidebarItem from "../modules/sidebarItem";
import SidebarSearch from "../components/sidebar/sidebarSearch";
import SiteTitle from "../components/sidebar/siteTitle";

const Sidebar = () => {
  return (
    <div className="sidebar collapse show" id="sidebar">
      <SiteTitle
        to="/#"
        siteName="site name"
        className="navbar-brand text-white d-block text-center mx-auto"
      />

      <CurrentUser
        //imageSrc={CustomImage}
        imageClass="rounded-circle ml-6 sidebar-user-image"
        imageAlt="MGH"
        userName="MGH"
      />

      <ul className="nav-bar list-unstyled flex-column mt-4 pe-2">
        <SidebarSearch placeHolder="search in menu" />
        <SidebarItem
          liClass="nav-item current custom-nav-item"
          to="/#"
          linkClass="nav-link text-white mb-2"
          icon={faHome}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          spanText={"dashboard"}
        />

        <SidebarItem
          liClass="nav-item custom-nav-item"
          to="/#"
          linkClass="nav-link text-white mb-2"
          icon={faUser}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          spanText={"profile"}
        />

        <SidebarItem
          liClass="nav-item custom-nav-item"
          to="/#"
          linkClass="nav-link text-white mb-2"
          icon={faEnvelope}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          spanText={"messages"}
        />

        <SidebarItem
          liClass="nav-item custom-nav-item"
          to="/#"
          linkClass="nav-link text-white mb-2"
          icon={faShoppingCart}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          spanText={"Sell"}
        />

        <SidebarItem
          liClass="nav-item custom-nav-item"
          to="/#"
          linkClass="nav-link text-white mb-2"
          icon={faChartLine}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          spanText={"analyze"}
        />

        <SidebarItem
          liClass="nav-item custom-nav-item"
          to="/#"
          linkClass="nav-link text-white mb-2"
          icon={faChartBar}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          spanText={"charts"}
        />

        <SidebarItem
          liClass="nav-item custom-nav-item"
          to="/#"
          linkClass="nav-link text-white mb-2"
          icon={faTable}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          spanText={"tables"}
        />
        <SidebarItem
          liClass="nav-item custom-nav-item"
          to="/#"
          linkClass="nav-link text-white mb-2"
          icon={faWrench}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          spanText={"settings"}
        />
      </ul>
    </div>
  );
};

export default Sidebar;
