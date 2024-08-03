type Status = "active" | "canceled";

export interface ITour {
    id: number;
    name: string;
    height: number;
    maxNumberOfPeople: number;
    minNumberOfPeople: number;
    description: string;
    date: string;
    status: Status;
}

export interface IAddTour {
    tourName: string;
    height: number;
    maxNumberOfPeople: number;
    minNumberOfPeople: number;
    description: string;
    datum: string;
}
