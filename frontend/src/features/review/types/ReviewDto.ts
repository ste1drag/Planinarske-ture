export interface ReadReviewDto {
  id: number;
  userId: number;
  tourId: string;
  title: string;
  comment?: string;
  difficulty?: number;
  score?: number;
  createdDate: string;
  updatedDate: string;
}

export interface CreateReviewDto {
  userId: number;
  tourId: string;
  title: string;
  comment?: string;
  difficulty?: number;
  score?: number;
}
