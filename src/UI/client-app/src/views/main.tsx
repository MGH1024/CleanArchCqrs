import Footer from "./templates/footer";
import Navbar from "./templates/navbar";
import Sidebar from "./templates/sidebar";
import Cards from "./templates/cards";

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
