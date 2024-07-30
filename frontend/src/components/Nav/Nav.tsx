import { Link } from "react-router-dom";
import {homeEndpoint, toursEndpoint} from "../../utils/apiEndpoints";

const Nav = () => {
    return (<>
        <nav>
                <li><Link to={ homeEndpoint }/>Home</li>
                <li><Link to={ toursEndpoint }/>Tours</li>
        </nav>
    </>)
}

export default Nav;