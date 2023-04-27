import {
  faComments,
  faBell,
  faSignOut,
} from "@fortawesome/free-solid-svg-icons";
import NavbarItem from "../components/navbar/navbarItem";
const NavbarItems = () => {
  return (
    <>
      <NavbarItem
        to="/#"
        linkClassName="nav-link"
        icon={faComments}
        iconClassName="2xl text-muted"
        dataToggle=""
      />

      <NavbarItem
        to="/#"
        linkClassName="nav-link"
        icon={faBell}
        iconClassName="2xl text-muted"
        dataToggle=""
      />

      <NavbarItem
        to="#logoutModal"
        linkClassName="nav-link"
        icon={faSignOut}
        iconClassName="2xl text-danger"
        dataToggle="modal"
      />
    </>
  );
};

export default NavbarItems;
