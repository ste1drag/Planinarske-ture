export interface AddTourDto {
  name: string;
  mountainId: string;
  description: string;
  minNumberOfPeople: number;
  maxNumberOfPeople: number;
  date: string;
}

export interface AddTourCommand {
  addTourDTO: AddTourDto;
  createdBy: string;
}
