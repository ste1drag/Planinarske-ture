import { useState, useEffect } from "react";
import { IAddTour } from "../../interfaces/ITour";
import { IMountain } from "../../interfaces/IMountain";
import axios from "axios";

const AddTour = () => {
    const initialTourState: IAddTour = {
        name: "",
        maxNumberOfPeople: 0,
        minNumberOfPeople: 0,
        description: "",
        mountainId: "",
        date: ""
    }

    const [tour, setTour] = useState<IAddTour>(initialTourState);
    const [mountains, setMountains] = useState<IMountain[]>([]);

    useEffect(() => {
        const fetchMountains = async () => {
            const response = await axios.get("http://localhost:8080/api/Mountains");
            setMountains(response.data);
        };
        fetchMountains();
    }, []);

    const onAddTour = async (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        debugger;
        await axios.post("http://localhost:8080/tours", {"addTourDTO": tour});
    }

    const handleNumberChange = (e: React.ChangeEvent<HTMLInputElement>, field: 'minNumberOfPeople' | 'maxNumberOfPeople') => {
        const value = e.target.value;
        setTour({
            ...tour,
            [field]: value === '' ? 0 : parseInt(value)
        });
    };

    return (
        <div className="max-w-md mx-auto mt-10 p-6 bg-white rounded-lg shadow-lg">
            <h2 className="text-2xl font-bold mb-6 text-center">Add New Tour</h2>
            <form onSubmit={onAddTour} className="space-y-4">
                <div className="space-y-2">
                    <label htmlFor="name" className="block text-sm font-medium text-gray-700">Name:</label>
                    <input
                        type="text"
                        id="name"
                        value={tour.name}
                        onChange={(e) => setTour({...tour, name: e.target.value})}
                        className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                    />
                </div>

                <div className="space-y-2">
                    <label htmlFor="mountain" className="block text-sm font-medium text-gray-700">Mountain:</label>
                    <select
                        id="mountain"
                        value={tour.mountainId}
                        onChange={(e) => setTour({...tour, mountainId: e.target.value})}
                        className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                    >
                        <option value="">Select a mountain</option>
                        {mountains.map((mountain) => (
                            <option key={mountain.id} value={mountain.id}>
                                {mountain.name} ({mountain.height}m)
                            </option>
                        ))}
                    </select>
                </div>

                <div className="space-y-2">
                    <label htmlFor="minNumberOfPeople" className="block text-sm font-medium text-gray-700">Minimum number of people:</label>
                    <input
                        type="number"
                        id="minNumberOfPeople"
                        value={tour.minNumberOfPeople}
                        onChange={(e) => handleNumberChange(e, 'minNumberOfPeople')}
                        className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                        min="0"
                    />
                </div>

                <div className="space-y-2">
                    <label htmlFor="maxNumberOfPeople" className="block text-sm font-medium text-gray-700">Maximum number of people:</label>
                    <input
                        type="number"
                        id="maxNumberOfPeople"
                        value={tour.maxNumberOfPeople}
                        onChange={(e) => handleNumberChange(e, 'maxNumberOfPeople')}
                        className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                        min="0"
                    />
                </div>

                <div className="space-y-2">
                    <label htmlFor="description" className="block text-sm font-medium text-gray-700">Tour Description:</label>
                    <textarea
                        id="description"
                        value={tour.description}
                        onChange={(e) => setTour({...tour, description: e.target.value})}
                        className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                        rows={4}
                    />
                </div>

                <div className="space-y-2">
                    <label htmlFor="date" className="block text-sm font-medium text-gray-700">Tour Date:</label>
                    <input
                        type="date"
                        id="date"
                        value={tour.date}
                        onChange={(e) => setTour({...tour, date: e.target.value})}
                        className="w-full px-3 py-2 border border-gray-300 rounded-md focus:outline-none focus:ring-2 focus:ring-blue-500"
                    />
                </div>

                <button
                    type="submit"
                    className="w-full bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600 focus:outline-none focus:ring-2 focus:ring-blue-500 focus:ring-offset-2"
                >
                    Add Tour
                </button>
            </form>
        </div>
    );
}

export default AddTour;