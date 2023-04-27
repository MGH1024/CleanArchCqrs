import Cards from "./templates/cards";
import {Sidebar} from "./templates/sidebar";
import {Navbar} from "./templates/navbar";
import {Footer} from "./templates/footer";

const Main = () => {
  return (
    <div className="d-flex" id="wrapper">
      <Sidebar />
      <div className="main-content">
        <Navbar />
        <Cards />
        <Footer />
      </div>
    </div>
  );
};

export default Main;
