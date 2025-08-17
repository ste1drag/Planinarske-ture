import { Tour } from './tour';

export interface Mountain {
  id: string;
  name: string;
  height: number;
  tours: Tour[];
}
