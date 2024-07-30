import { useState, useEffect} from "react";
import axios, {AxiosResponse} from 'axios';
import { ITour } from "../../interfaces/ITour";
import {Link} from "react-router-dom";
import {toursEndpoint} from "../../utils/apiEndpoints";
import TourCard from "../TourCard/TourCard";

const Tours = () => {
    const [tours, setTours] = useState<ITour[]>([]);

    useEffect(()=>{
        fetchTours();
    },[]);

    const fetchTours = async () => {
        const toursData: ITour[] = await axios.get("http://localhost:30001/tours")
                                            .then((response: AxiosResponse) => response.data);

        setTours(toursData);
    }

    return (
        <div className={"container"}>
            {tours.map((tour: ITour) =>  (
                <TourCard key={tour.id} id={tour.id}
                          name={tour.name}
                          height={tour.height} maxNumberOfPeople={tour.maxNumberOfPeople}
                          minNumberOfPeople={tour.minNumberOfPeople}
                          description={tour.description}
                          date={tour.date}
                          status={tour.status} />
            ))}
        </div>
    )
}

export default Tours;