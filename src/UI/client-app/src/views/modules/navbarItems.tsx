import {
    faComments,
    faBell,
    faSignOut,
} from "@fortawesome/free-solid-svg-icons";
import {NavbarItem} from "../components/navbar/navbarItem";


export const NavbarItems = () => {
    return (
        <>
            <NavbarItem
                to="/#"
                linkClassName="nav-link"
                navbarIcon={faComments}
                iconClassName="2xl text-muted"
                dataToggle=""
            />

            <NavbarItem
                to="/#"
                linkClassName="nav-link"
                navbarIcon={faBell}
                iconClassName="2xl text-muted"
                dataToggle=""
            />

            <NavbarItem
                to="#logoutModal"
                linkClassName="nav-link"
                navbarIcon={faSignOut}
                iconClassName="2xl text-danger"
                dataToggle="modal"
            />
        </>
    );
};
