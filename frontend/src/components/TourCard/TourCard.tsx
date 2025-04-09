import { ITour } from "../../interfaces/ITour";
import { NavLink } from "react-router-dom";
import { toursEndpoint } from "../../utils/apiEndpoints";

const TourCard = (tourProps: ITour) => {
    return (
        <div className="bg-white rounded-xl shadow-lg p-6 m-4 w-80 hover:shadow-xl transition-shadow duration-300">
            <NavLink to={toursEndpoint+"/"+tourProps.id}>
                <h1 className="text-2xl font-bold text-blue-600 hover:text-blue-800 mb-2">
                    {tourProps.name}
                </h1>
            </NavLink>
            <h2 className="text-gray-600 text-lg mb-2">{tourProps.date}</h2>
            <div className="mt-4 pt-4 border-t border-gray-100">
                <span className="inline-block bg-blue-100 text-blue-800 text-sm px-3 py-1 rounded-full">
                    {tourProps.status}
                </span>
            </div>
        </div>
    );
}

export default TourCard;