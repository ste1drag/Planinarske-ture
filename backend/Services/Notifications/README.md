# Notifications Service

## Overview
The Notifications Service is a microservice responsible for managing in-app notifications in the Mountain Tours application. It listens to events from other services (e.g., Tour creation) and creates, stores, and broadcasts notifications to users via SignalR through the Gateway.

## Architecture

### Clean Architecture (Layered)
The service follows **Clean Architecture** with clear separation of concerns:

```
┌─────────────────────────────────────┐
│      Notifications.API              │  ← Entry point, HTTP endpoints
├─────────────────────────────────────┤
│   Notifications.Presentation        │  ← Controllers (API interface)
├─────────────────────────────────────┤
│   Notifications.Application         │  ← Business logic, Use Cases, DTOs
├─────────────────────────────────────┤
│   Notifications.Domain              │  ← Core entities, Enums, Interfaces
├─────────────────────────────────────┤
│   Notifications.Infrastructure      │  ← Database, External services
└─────────────────────────────────────┘
```

### Key Patterns
- **CQRS** (Command Query Responsibility Segregation) using MediatR
- **Repository Pattern** for data access abstraction
- **Event-Driven Architecture** with RabbitMQ/MassTransit
- **Domain-Driven Design** principles

## Data Flow

### 1. Tour Created Event Flow
```
Tours Service → RabbitMQ → Notifications Service → MongoDB → RabbitMQ → Gateway → SignalR → Frontend
```

**Step by step:**
1. **Event Published**: Tours Service publishes `TourCreatedEvent` to RabbitMQ
2. **Event Consumed**: `TourCreatedEventConsumer` receives the event
3. **Command Created**: Consumer creates `CreateInAppNotificationCommand`
4. **Command Handled**: `CreateInAppNotificationCommandHandler` processes it:
   - Maps event data to `InAppNotification` entity
   - Applies business rules (sets status to Pending, CreatedAt timestamp)
   - Saves to MongoDB
   - Publishes `InAppNotificationCreatedTourEvent` to RabbitMQ
5. **Gateway Receives**: Gateway's `InAppNotificationEventConsumer` receives event
6. **SignalR Broadcast**: Gateway broadcasts to all connected clients via SignalR
7. **Frontend Displays**: React app receives and displays notification popup

### 2. CRUD Operations Flow
```
Frontend → Gateway (Reverse Proxy) → Notifications API → Repository → MongoDB
```

## Project Structure

### Domain Layer (`Notifications.Domain`)
**Purpose**: Core business entities and rules (framework-independent)

- **Entities**:
  - `InAppNotification`: Main notification entity with properties (Id, TourId, Type, Title, Content, Status, timestamps)

- **Enums**:
  - `NotificationTypeEnum`: TourCreated, ReviewCreated, etc.
  - `DeliveryStatusEnum`: Pending, Sent, Failed, Read
  - `DeliveryChannelEnum`: InApp, Email, Push

- **Interfaces**:
  - `INotification`: Base notification contract

### Application Layer (`Notifications.Application`)
**Purpose**: Business logic, use cases, DTOs

- **Use Cases** (CQRS):
  - Commands: `CreateInAppNotificationCommand`, `UpdateInAppNotificationCommand`, `DeleteInAppNotificationCommand`
  - Queries: `GetAllInAppNotificationsQuery`, `GetInAppNotificationByIdQuery`

- **Consumers**:
  - `TourCreatedEventConsumer`: Listens to tour creation events from RabbitMQ

- **Business Rules**:
  - `NotificationDeliveryRules`: Applies creation/delivery rules (status, timestamps)

- **DTOs**:
  - Request DTOs: `CreateInAppNotificationRequest`, `UpdateInAppNotificationRequest`
  - Response DTOs: `InAppNotificationResponse`

- **Contracts**: Repository interfaces

### Infrastructure Layer (`Notifications.Infrastructure`)
**Purpose**: External concerns (database, messaging)

- **Repositories**:
  - `InAppNotificationRepository`: MongoDB implementation

- **Configuration**:
  - Database context setup
  - MassTransit/RabbitMQ configuration

### Presentation Layer (`Notifications.Presentation`)
**Purpose**: API Controllers

- **Controllers**:
  - `InAppNotificationsController`: REST endpoints for CRUD operations

### API Layer (`Notifications.API`)
**Purpose**: Application entry point

- Configuration of dependency injection
- Middleware setup (Swagger, Serilog logging)
- Host configuration

## Technology Stack

- **Framework**: .NET 8
- **Database**: MongoDB
- **Messaging**: RabbitMQ with MassTransit
- **Logging**: Serilog (Console + File)
- **Mapping**: AutoMapper
- **Mediator**: MediatR (CQRS pattern)
- **Real-time**: SignalR (via Gateway)

## API Endpoints

### In-App Notifications
- `GET /api/inappnotifications` - Get all notifications
- `GET /api/inappnotifications/{id}` - Get notification by ID
- `POST /api/inappnotifications` - Create notification (manual)
- `PUT /api/inappnotifications/{id}` - Update notification
- `DELETE /api/inappnotifications/{id}` - Delete notification

## Configuration

### RabbitMQ
- **Queue**: `notifications-tour-created-queue`
- **Exchange**: Default (direct)
- **Event Published**: `InAppNotificationCreatedTourEvent`

### MongoDB
Configured in `appsettings.json`:
```json
{
  "MongoDbSettings": {
    "ConnectionString": "mongodb://localhost:27017",
    "DatabaseName": "NotificationsDb"
  }
}
```

## Running the Service

### Prerequisites
- .NET 8 SDK
- MongoDB running on `localhost:27017`
- RabbitMQ running on `localhost:5672`

### Development
```bash
cd src/Notifications.API
dotnet build
dotnet run
```

### Docker
```bash
docker build -t notifications-service .
docker run -p 5003:80 notifications-service
```

## Business Rules

### Notification Creation
1. New notifications start with `Status = Pending`
2. `CreatedAt` timestamp is set automatically
3. Unique `Id` (GUID) is generated

### Notification Delivery
1. When successfully sent to Gateway: `Status = Sent`, `SentAt` set
2. When delivery fails: `Status = Failed`
3. When user reads: `Status = Read`, `ReadAt` set (future implementation)

## Event Integration

### Consumes Events
- `TourCreatedEvent` from Tours Service

### Publishes Events
- `InAppNotificationCreatedTourEvent` to Gateway

## Logging
Structured logging with Serilog:
- Console output for development
- Daily rolling file logs in `/logs/` directory
- Request/Response logging enabled
