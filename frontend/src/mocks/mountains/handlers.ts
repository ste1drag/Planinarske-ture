import { http, HttpResponse } from 'msw';
import { mountainMocks } from './mocks';
import { MOUNTAINS_ENDPOINTS } from '@/features/mountain/api/mountain-endpoints';

export const mountainsHandlers = [
  http.get(MOUNTAINS_ENDPOINTS.GET_ALL_MOUNTAINS, () => {
    return HttpResponse.json(mountainMocks);
  }),
];
