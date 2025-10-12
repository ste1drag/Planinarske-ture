export interface ReadReviewDto {
  id: number;
  userId: number;
  tourId: number;
  title: string;
  comment?: string;
  difficulty?: number;
  score?: number;
  createdDate: string;
  updatedDate: string;
}
