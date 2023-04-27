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
import {SiteTitle} from "../components/sidebar/siteTitle";
import {SidebarSearch} from "../components/sidebar/sidebarSearch";

export const Sidebar = () => {
  return (
    <div className="sidebar collapse show" id="sidebar">
      <SiteTitle
        to="/#"
        siteName="site name"
        className="navbar-brand text-white d-block text-center mx-auto"
      />

      <CurrentUser
        imageSrc=""
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
          sidebarItemIcon={faHome}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          sideBarItemSpanText={"dashboard"}
        />

        <SidebarItem
          liClass="nav-item custom-nav-item"
          to="/#"
          linkClass="nav-link text-white mb-2"
          sidebarItemIcon={faUser}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          sideBarItemSpanText={"profile"}
        />

        <SidebarItem
          liClass="nav-item custom-nav-item"
          to="/#"
          linkClass="nav-link text-white mb-2"
          sidebarItemIcon={faEnvelope}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          sideBarItemSpanText={"messages"}
        />

        <SidebarItem
          liClass="nav-item custom-nav-item"
          to="/#"
          linkClass="nav-link text-white mb-2"
          sidebarItemIcon={faShoppingCart}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          sideBarItemSpanText={"Sell"}
        />

        <SidebarItem
          liClass="nav-item custom-nav-item"
          to="/#"
          linkClass="nav-link text-white mb-2"
          sidebarItemIcon={faChartLine}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          sideBarItemSpanText={"analyze"}
        />

        <SidebarItem
          liClass="nav-item custom-nav-item"
          to="/#"
          linkClass="nav-link text-white mb-2"
          sidebarItemIcon={faChartBar}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          sideBarItemSpanText={"charts"}
        />

        <SidebarItem
          liClass="nav-item custom-nav-item"
          to="/#"
          linkClass="nav-link text-white mb-2"
          sidebarItemIcon={faTable}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          sideBarItemSpanText={"tables"}
        />
        <SidebarItem
          liClass="nav-item custom-nav-item"
          to="/#"
          linkClass="nav-link text-white mb-2"
          sidebarItemIcon={faWrench}
          iconClassName={"ms-3 2xl"}
          spanClass={"sidebar-li-span"}
          sideBarItemSpanText={"settings"}
        />
      </ul>
    </div>
  );
};
