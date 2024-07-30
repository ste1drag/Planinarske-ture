import { ITour } from "../../interfaces/ITour";
import { Link } from "react-router-dom";
import {tourEndpoint} from "../../utils/apiEndpoints";

const TourCard = (tourProps: ITour) => {
    return <>
        <div className={"card"}>
            <h1><Link to={tourEndpoint+"/"+tourProps.id}/>{tourProps.name}</h1>
            <h2>{tourProps.height}</h2>
        </div>
    </>
}

export default TourCard;