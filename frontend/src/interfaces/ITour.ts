type Status = "active" | "canceled";

interface ITour {
    id: number;
    name: string;
    height: number;
    maxNumberOfPeople: number;
    minNumberOfPeople: number;
    description: string;
    date: string;
    status: Status;
}

export default ITour;