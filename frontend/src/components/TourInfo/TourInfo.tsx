import {Link, useParams} from "react-router-dom";
import {ITourParams} from "../../interfaces/IParams";
import {useEffect, useState} from "react";
import {ITour} from "../../interfaces/ITour";
import axios, {AxiosResponse} from "axios";

type TourParam = {
    id: string;
}

const TourInfo = () => {
    const { id } = useParams<TourParam>();
    const [tourInfo, setTourInfo] = useState<ITour>();

    useEffect(()=>{
        fetchTour(id);
    },[]);

    const fetchTour = async (id?: string) => {
        if(!id)
            return;

        const toursData:ITour[] = await axios.get("http://localhost:30001/tours").then((response: AxiosResponse)=> response.data);
        const tourInfoData: ITour = toursData.filter((tour: ITour) => tour.id === parseInt(id))[0];
        if(!tourInfoData)
            return;

        setTourInfo(tourInfoData);
    }

    return <>
        <div >
            <h1>{tourInfo?.name}</h1>
            <h2>{tourInfo?.height}</h2>
            <h3>{tourInfo?.date}</h3>
            <h4>{tourInfo?.description}</h4>
        </div>
    </>
}

export default TourInfo;