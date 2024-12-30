import { useEffect, useState } from "react";
import { ITour } from "../interfaces/ITour";
import axios, {AxiosResponse} from "axios";

export const useTours = () : ITour[] => {
    const [tours, setTours] = useState<ITour[]>([]);
    useEffect(()=>{
        fetchTours();
    },[]);

    const fetchTours = async () => {
        const toursData: ITour[] = await axios.get("http://localhost:7075/Tours")
                                            .then((response: AxiosResponse) => response.data);

        setTours(toursData);
    }
    return tours;
}

export const useTour = (id: string) : (ITour | undefined) => {
    const [tourInfo, setTourInfo] = useState<ITour>();
    useEffect(()=>{
        fetchTour(id);
    },[id]);

    const fetchTour = async (id?: string) => {
        if(!id)
            return;

        const tourInfoData = await axios.get(`http://localhost:7075/${id}`).then((response: AxiosResponse)=> response.data);
        if(!tourInfoData)
            return;

        setTourInfo(tourInfoData);
    }
    return tourInfo;
}