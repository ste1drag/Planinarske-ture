import { useState } from "react";
import { IAddTour } from "../../interfaces/ITour";
import axios from "axios";

const AddTour = () => {

    const initialTourState: IAddTour = {
        tourName : "",
        height : 0,
        maxNumberOfPeople : 0,
        minNumberOfPeople : 0,
        description : "",
        datum : ""
    }

    const [tour, setTour] = useState<IAddTour>(initialTourState);

    const onAddTour = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        await axios.post("https://localhost:30001/tours",tour);
    }

    return (
        <>
            <form onSubmit={onAddTour}>
                <div>
                    <label htmlFor="tourName">Name:</label>
                    <input type="text" value ={tour.tourName} onChange={(e: React.FormEvent<HTMLInputElement>) => { setTour({...tour, tourName: e.currentTarget.value})}}/>
                </div>
                <div>
                    <label htmlFor="height">Height:</label>
                    <input type="text" value ={tour.height} onChange={(e: React.FormEvent<HTMLInputElement>) => { setTour({...tour, height: parseInt(e.currentTarget.value)})}}/>
                </div>
                <div>
                    <label htmlFor="minNumberOfPeople">Minimum number of people:</label>
                    <input type="text" value ={tour.minNumberOfPeople} onChange={(e: React.FormEvent<HTMLInputElement>) => { setTour({...tour, minNumberOfPeople: parseInt(e.currentTarget.value)})}}/>
                </div>
                <div>
                    <label htmlFor="maxNumberOfPeople">Max number of people:</label>
                    <input type="text" value ={tour.maxNumberOfPeople} onChange={(e: React.FormEvent<HTMLInputElement>) => { setTour({...tour, maxNumberOfPeople: parseInt(e.currentTarget.value)})}}/>
                </div>
                <div>
                    <label htmlFor="description">Tour Description:</label>
                    <input type="text" value ={tour.description} onChange={(e: React.FormEvent<HTMLInputElement>) => { setTour({...tour, description: e.currentTarget.value})}}/>
                </div>
                <div>
                    <label htmlFor="tourName">Tour Date:</label>
                    <input type="text" value ={tour.datum} onChange={(e: React.FormEvent<HTMLInputElement>) => { setTour({...tour, datum: e.currentTarget.value})}}/>
                </div>
                <input type="submit" value="Post"/>
            </form>
        </>
    )
}

export default AddTour;