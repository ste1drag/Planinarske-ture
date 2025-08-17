import { setupWorker } from 'msw/browser';
import { mountainsHandlers } from './mountains/handlers';
import { toursHandlers } from './tours/handlers';
// import { toursHandlers } from './tours/handlers'; // Uncomment when you create tours handlers

// Combine all handlers
export const handlers = [
  ...mountainsHandlers,
  ...toursHandlers, // Uncomment when ready
];

export const worker = setupWorker(...handlers);

// Helper function to start MSW conditionally
export const enableMocking = async () => {
  if (process.env.REACT_APP_USE_MOCKS !== 'true') {
    return;
  }
  return worker.start({
    onUnhandledRequest: 'warn', // Warns about requests not handled by MSW
    quiet: false, // Set to true to reduce console logs
  });
};
