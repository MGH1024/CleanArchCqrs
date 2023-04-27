import FooterLeftSide from "../components/footer/footerLeftSide";
import {FooterRightSide} from "../modules/footerRightSide";

export const Footer = () => {
    return (
        <footer className="bg-warning">
            <div className="container-fluid">
                <div className="row p-3">
                    <div className="col-sm-12 me-auto">
                        <div className="row">
                            <FooterRightSide/>
                            <FooterLeftSide/>
                        </div>
                    </div>
                </div>
            </div>
        </footer>
    );
};
