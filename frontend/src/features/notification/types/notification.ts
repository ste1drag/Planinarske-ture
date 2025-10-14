export interface Notification {
  id: string;
  title: string;
  description: string;
  content: string;
  timestamp: string;
}

export interface SignalRNotificationPayload {
  ClientMethod: string;
  Data: Notification[];
}
