import { Link } from "react-router-dom";
import {homeEndpoint, toursEndpoint} from "../../utils/apiEndpoints";

const Nav = () => {
    <>
        <nav>
            <ul>
                <li><Link to={ homeEndpoint }/>Home</li>
                <li><Link to={ toursEndpoint }/>Tours</li>
            </ul>
        </nav>
    </>
}

export default Nav;