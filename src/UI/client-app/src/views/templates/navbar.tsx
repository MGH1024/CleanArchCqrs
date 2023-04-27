import NavbarItems from "../modules/navbarItems";

const Navbar = () => {
  return (
    <nav className="navbar navbar-expand-xs navbar-light bg-light custom-navbar">
      <div className="container-fluid">
        {/*<button*/}
        {/*  type="button"*/}
        {/*  className="navbar-toggler me-2"*/}
        {/*  data-bs-toggle="collapse"*/}
        {/*  ref="#sidebar"*/}
        {/*  aria-controls="sidebar"*/}
        {/*  aria-expanded="false"*/}
        {/*>*/}
        {/*  <span className="navbar-toggler-icon"></span>*/}
        {/*</button>*/}
        <div className="collapse navbar-collapse">
          <ul className="navbar-nav me-auto">
            <NavbarItems />
          </ul>
        </div>
      </div>
    </nav>
  );
};

export default Navbar;
