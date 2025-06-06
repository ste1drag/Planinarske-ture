import {NavLink} from "react-router-dom";
import {addTourEndpoint, homeEndpoint, toursEndpoint} from "../../utils/apiEndpoints";

const Nav = () => {
    return (
        <nav className="bg-blue-600 p-4 shadow-lg">
            <ul className="flex space-x-6 justify-center">
                <li>
                    <NavLink 
                        to={homeEndpoint}
                        className={({isActive}) => 
                            isActive 
                                ? "text-white font-bold px-3 py-2 rounded-lg bg-blue-700" 
                                : "text-blue-100 hover:text-white px-3 py-2 rounded-lg hover:bg-blue-700"
                        }
                    >
                        Home
                    </NavLink>
                </li>
                <li>
                    <NavLink 
                        to={toursEndpoint}
                        className={({isActive}) => 
                            isActive 
                                ? "text-white font-bold px-3 py-2 rounded-lg bg-blue-700" 
                                : "text-blue-100 hover:text-white px-3 py-2 rounded-lg hover:bg-blue-700"
                        }
                    >
                        Tours
                    </NavLink>
                </li>
                <li>
                    <NavLink 
                        to={addTourEndpoint}
                        className={({isActive}) => 
                            isActive 
                                ? "text-white font-bold px-3 py-2 rounded-lg bg-blue-700" 
                                : "text-blue-100 hover:text-white px-3 py-2 rounded-lg hover:bg-blue-700"
                        }
                    >
                        Add Tour
                    </NavLink>
                </li>
            </ul>
        </nav>
    );
}

export default Nav;