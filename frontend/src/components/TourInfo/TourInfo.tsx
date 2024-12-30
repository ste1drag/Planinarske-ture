import {useParams} from "react-router-dom";
import { useTour } from "../../hooks/useTours";

type TourParam = {
    id: string;
}

const TourInfo = () => {
    const { id } = useParams<TourParam>();
    
    const tourInfo = useTour(id as string);

    return <>
        <div >
            <h1>{tourInfo?.name}</h1>
            <h3>{tourInfo?.date}</h3>
            <h4>{tourInfo?.description}</h4>
        </div>
    </>
}

export default TourInfo;