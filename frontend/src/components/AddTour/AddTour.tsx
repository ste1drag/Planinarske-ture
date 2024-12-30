import { useState } from "react";
import { IAddTour } from "../../interfaces/ITour";
import axios from "axios";

const AddTour = () => {

    const initialTourState: IAddTour = {
        name : "",
        maxNumberOfPeople : 0,
        minNumberOfPeople : 0,
        description : "",
        mountainId: "83725c0c-3ee3-4dc2-2a86-08dd165ab1c5",
        date : ""
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
                    <label htmlFor="name">Name:</label>
                    <input type="text" value ={tour.name} onChange={(e: React.FormEvent<HTMLInputElement>) => { setTour({...tour, name: e.currentTarget.value})}}/>
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
                    <input type="text" value ={tour.date} onChange={(e: React.FormEvent<HTMLInputElement>) => { setTour({...tour, date: e.currentTarget.value})}}/>
                </div>
                <input type="submit" value="Post"/>
            </form>
        </>
    )
}

export default AddTour;