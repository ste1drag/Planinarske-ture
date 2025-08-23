import { http, HttpResponse } from 'msw';
import { tourMocks, generateTourId } from './mocks';
import { Weather } from '@/features/mountains/enums/weather';
import { TOURS_ENDPOINTS } from '@/features/tour/api/TourEndpoints';
import { TourStatus } from '@/features/tour/enums/TourStatus';
import { AddTourDto } from '@/features/tour/types/AddTourDto';
import { DeleteTourDto } from '@/features/tour/types/DeleteTourDto';
import { TourViewModel } from '@/features/tour/types/TourDto';

// In-memory storage for runtime changes
const tours = [...tourMocks];

export const toursHandlers = [
  // GET all tours
  http.get(TOURS_ENDPOINTS.GET_ALL_TOURS, () => {
    return HttpResponse.json(tours, {
      status: 200,
      headers: { 'Content-Type': 'application/json' },
    });
  }),

  // GET tour by ID
  http.get('/api/tours/:tourId', ({ params }) => {
    const { tourId } = params;
    const tour = tours.find(t => t.id === tourId);
    if (!tour) {
      return HttpResponse.json(
        { message: `Tour with id ${tourId} not found` },
        { status: 404 }
      );
    }
    return HttpResponse.json(tour, { status: 200 });
  }),

  // GET tours by mountain ID
  http.get('/api/tours/:mountainId/tours', ({ params }) => {
    const { mountainId } = params;
    const mountainTours = tours.filter(t => t.mountainId === mountainId);
    return HttpResponse.json(mountainTours, { status: 200 });
  }),

  // POST add tour
  http.post(TOURS_ENDPOINTS.ADD_TOUR, async ({ request }) => {
    try {
      const addTourData = (await request.json()) as AddTourDto;
      // Validate required fields
      if (!addTourData.name || !addTourData.mountainId) {
        return HttpResponse.json(
          { message: 'Name and mountainId are required' },
          { status: 400 }
        );
      }
      // Create new tour
      const newTour: TourViewModel = {
        id: generateTourId(),
        name: addTourData.name,
        mountainId: addTourData.mountainId,
        description: addTourData.description,
        date: addTourData.date,
        status: TourStatus.ACTIVE, // Default status
        weather: Weather.SUNNY, // Default weather
      };
      // Add to tours array
      tours.push(newTour);
      return HttpResponse.json(newTour, { status: 202 });
    } catch (error) {
      return HttpResponse.json(
        { message: 'Invalid tour data provided' },
        { status: 400 }
      );
    }
  }),

  // DELETE tour
  http.delete(TOURS_ENDPOINTS.DELETE_TOUR, async ({ request }) => {
    try {
      const deleteData = (await request.json()) as DeleteTourDto;

      const tourIndex = tours.findIndex(t => t.id === deleteData.tourId);

      if (tourIndex === -1) {
        return HttpResponse.json(
          { message: `Tour with id ${deleteData.tourId} not found` },
          { status: 404 }
        );
      }
      return HttpResponse.json(
        { message: 'Tour deleted successfully' },
        { status: 200 }
      );
    } catch (error) {
      return HttpResponse.json(
        { message: 'Invalid delete request' },
        { status: 400 }
      );
    }
  }),
];
