import {NavLink} from "react-router-dom";
import {homeEndpoint, toursEndpoint} from "../../utils/apiEndpoints";

const Nav = () => {
    return (<>
        <nav>
                <li><NavLink to={ homeEndpoint }/>Home</li>
                <li><NavLink to={ toursEndpoint }/>Tours</li>
        </nav>
    </>)
}

export default Nav;