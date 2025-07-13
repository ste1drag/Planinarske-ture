type Status = "active" | "canceled";

export interface ITour {
    id: number;
    name: string;
    mountainId: string;
    description: string;
    date: string;
    status: Status;
}

export interface IAddTour {
    name: string;
    mountainId: string;
    description: string;
    minNumberOfPeople: number;
    maxNumberOfPeople: number;
    date: string;
}
