import * as signalR from '@microsoft/signalr';
import { InAppNotificationResponse } from '../types';

export type NotificationHandler = (
  notification: InAppNotificationResponse
) => void;

class NotificationHub {
  private connection: signalR.HubConnection | null = null;
  private handlers: NotificationHandler[] = [];

  async start(
    hubUrl = 'http://localhost:8084/hubs/notifications'
  ): Promise<void> {
    if (this.connection?.state === signalR.HubConnectionState.Connected) {
      console.log('SignalR already connected');
      return;
    }

    const token = localStorage.getItem('auth_token');
    if (!token) {
      console.warn('Cannot start SignalR: no auth token found');
      return;
    }

    this.connection = new signalR.HubConnectionBuilder()
      .withUrl(hubUrl, {
        accessTokenFactory: () => token,
        transport: signalR.HttpTransportType.WebSockets,
      })
      .withAutomaticReconnect({
        nextRetryDelayInMilliseconds: () => {
          // Retry: 0s, 2s, 10s, 30s
          return Math.min(
            1000 * Math.pow(2, this.getReconnectAttempts()),
            30000
          );
        },
      })
      .configureLogging(signalR.LogLevel.Information)
      .build();

    this.connection.on(
      'NotificationCreated',
      (notification: InAppNotificationResponse) => {
        console.log('Received notification:', notification);
        this.handlers.forEach(handler => handler(notification));
      }
    );

    this.connection.onreconnecting(error => {
      console.warn('SignalR reconnecting...', error);
    });

    this.connection.onreconnected(connectionId => {
      console.log('SignalR reconnected:', connectionId);
    });

    this.connection.onclose(error => {
      console.error('SignalR connection closed:', error);
    });

    try {
      await this.connection.start();
      console.log('SignalR connected successfully');
    } catch (error) {
      console.error('SignalR connection failed:', error);
      throw error;
    }
  }

  async stop(): Promise<void> {
    if (this.connection) {
      await this.connection.stop();
      console.log('SignalR disconnected');
      this.connection = null;
    }
  }

  subscribe(handler: NotificationHandler): () => void {
    this.handlers.push(handler);
    return () => {
      this.handlers = this.handlers.filter(h => h !== handler);
    };
  }

  getConnectionState(): signalR.HubConnectionState | null {
    return this.connection?.state ?? null;
  }

  private getReconnectAttempts(): number {
    return 0;
  }
}

export const notificationHub = new NotificationHub();
