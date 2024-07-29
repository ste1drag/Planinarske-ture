import { useState, useEffect} from "react";
import axios from 'axios';
import ITour from "../../interfaces/ITour";
import {Link} from "react-router-dom";
import {toursEndpoint} from "../../utils/apiEndpoints";

const Tours = () => {
    const [tours, setTours] = useState<ITour[]>([]);

    useEffect(()=>{
        fetchTours();
    },[]);

    const fetchTours = async () => {
        const toursData:ITour[] = await axios.get("http://localhost:3000/tours");

        setTours(toursData);
    }

    let tourElements = tours.map(tour => {
        <>
        <Link to={toursEndpoint + "/" +tour.id}></Link>
        </>
    })

    return (
        <div class="container">

        </div>
    )



}