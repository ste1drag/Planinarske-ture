import * as signalR from '@microsoft/signalr';
import { Notification } from '../types/notification';

class SignalRService {
  private connection: signalR.HubConnection | null = null;
  private listeners: Array<(notification: Notification) => void> = [];
  private reconnectAttempts = 0;
  private maxReconnectAttempts = 5;

  async startConnection(): Promise<void> {
    if (
      this.connection &&
      this.connection.state === signalR.HubConnectionState.Connected
    ) {
      console.log('SignalR already connected');
      return;
    }

    // If connection exists but is disconnected, clean it up
    if (this.connection) {
      try {
        await this.connection.stop();
      } catch (error) {
        console.warn('Error stopping existing connection:', error);
      }
      this.connection = null;
    }

    this.connection = new signalR.HubConnectionBuilder()
      .withUrl('http://localhost:8084/notificationHub', {
        skipNegotiation: false,
        transport:
          signalR.HttpTransportType.WebSockets |
          signalR.HttpTransportType.ServerSentEvents |
          signalR.HttpTransportType.LongPolling,
      })
      .withAutomaticReconnect([0, 2000, 5000, 10000, 30000])
      .configureLogging(signalR.LogLevel.Information)
      .build();

    this.connection.on('ReceiveNotification', (notification: any) => {
      console.log('Raw notification received from SignalR:', notification);

      // Map lowercase properties to match our Notification interface
      const mappedNotification: Notification = {
        id: notification.id || notification.Id,
        title: notification.title || notification.Title,
        description: notification.description || notification.Description,
        content: notification.content || notification.Content,
        timestamp: notification.timestamp || notification.Timestamp,
      };

      console.log('Mapped notification:', mappedNotification);
      this.listeners.forEach(listener => listener(mappedNotification));
    });

    this.connection.onreconnecting(error => {
      console.warn('SignalR reconnecting...', error?.message);
      this.reconnectAttempts++;
    });

    this.connection.onreconnected(connectionId => {
      console.log('SignalR reconnected successfully:', connectionId);
      this.reconnectAttempts = 0;
    });

    this.connection.onclose(async error => {
      console.error('SignalR connection closed:', error?.message);
      this.connection = null;

      // Attempt manual reconnection if automatic reconnect fails
      if (this.reconnectAttempts < this.maxReconnectAttempts) {
        console.log(
          `Attempting manual reconnection (${this.reconnectAttempts + 1}/${this.maxReconnectAttempts})...`
        );
        setTimeout(() => {
          this.startConnection().catch(err =>
            console.error('Manual reconnection failed:', err)
          );
        }, 5000);
      } else {
        console.error(
          'Max reconnection attempts reached. Please refresh the page.'
        );
      }
    });

    try {
      await this.connection.start();
      console.log('SignalR connected successfully');
      this.reconnectAttempts = 0;
    } catch (error: any) {
      console.error(
        'Error starting SignalR connection:',
        error?.message || error
      );
      this.connection = null;

      // Log more helpful error information
      if (error?.message?.includes('negotiate')) {
        console.error(
          'Negotiation failed. Please ensure the backend Gateway is running on http://localhost:8084'
        );
      } else if (error?.message?.includes('CORS')) {
        console.error(
          'CORS error. Please check CORS configuration in the Gateway'
        );
      }

      throw error;
    }
  }

  async stopConnection(): Promise<void> {
    if (this.connection) {
      await this.connection.stop();
      this.connection = null;
      console.log('SignalR connection stopped');
    }
  }

  onNotification(callback: (notification: Notification) => void): () => void {
    this.listeners.push(callback);

    return () => {
      this.listeners = this.listeners.filter(listener => listener !== callback);
    };
  }

  isConnected(): boolean {
    return this.connection?.state === signalR.HubConnectionState.Connected
      ? true
      : false;
  }
}

export const signalRService = new SignalRService();
