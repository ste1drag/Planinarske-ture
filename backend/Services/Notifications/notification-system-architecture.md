# Notification System Architecture - Event-Driven CQRS Pattern

## Overview
This document explains the complete flow of the notification system, from consuming RabbitMQ events to persisting data in MongoDB, using Clean Architecture principles with CQRS pattern.

---

## Complete Data Flow

### Visual Flow Diagram
```
┌─────────────┐
│ Tours API   │
│ creates tour│
└──────┬──────┘
       │ publishes TourCreatedEvent
       ▼
┌─────────────────┐
│   RabbitMQ      │
│  (Exchange)     │
└──────┬──────────┘
       │ routes to queue
       ▼
┌─────────────────────────────────┐
│ MassTransit Infrastructure      │
│ - Deserializes JSON message     │
│ - Finds TourCreatedEventConsumer│
└──────┬──────────────────────────┘
       │
       ▼
┌─────────────────────────────────┐
│ TourCreatedEventConsumer        │
│ - Translates event → DTO        │
│ - Wraps DTO in command          │
│ - Sends via MediatR             │
└──────┬──────────────────────────┘
       │
       ▼
┌─────────────────────────────────┐
│ MediatR Pipeline                │
│ - Finds handler                 │
│ - Runs behaviors (validation)   │
└──────┬──────────────────────────┘
       │
       ▼
┌─────────────────────────────────┐
│ CreateInAppNotificationHandler  │
│ - Creates domain entity         │
│ - Applies business rules        │
│ - Calls repository              │
└──────┬──────────────────────────┘
       │
       ▼
┌─────────────────────────────────┐
│ IInAppNotificationRepository    │
│ (MongoDB Implementation)        │
│ - Inserts document              │
└──────┬──────────────────────────┘
       │
       ▼
┌─────────────────────────────────┐
│ MongoDB Database                │
│ InAppNotifications collection   │
└─────────────────────────────────┘
```

---

## Step-by-Step Flow Explanation

### 1. Event Publishing (Tours Service)
```
Tours Service → Publishes TourCreatedEvent → RabbitMQ Exchange
```
- When a tour is created, the Tours service publishes a `TourCreatedEvent` to RabbitMQ
- Event contains: `TourId`, `Title`, `CreateByUserId`, `OccuredOn`

### 2. MassTransit Receives Message
```
RabbitMQ Queue → MassTransit Infrastructure → Deserializes to TourCreatedEvent
```
- MassTransit listens to a specific RabbitMQ queue
- Deserializes JSON message into strongly-typed `TourCreateEvent.TourCreatedEvent` object
- Automatically routes to registered consumer

### 3. Consumer Receives Event
```csharp
public async Task Consume(ConsumeContext<TourCreateEvent.TourCreatedEvent> context)
{
    var message = context.Message; // Event data available here
```
- `context.Message` contains all event properties
- Consumer acts as **translation layer** between external events and internal commands

### 4. Create DTO Request
```csharp
var request = new CreateInAppNotificationRequest
{
    UserId = message.CreateByUserId,
    Type = NotificationTypeEnum.TourCreated,
    Title = "New Tour Created",
    Message = $"Tour '{message.Title}' has been created successfully.",
    RelatedEntityId = message.TourId,
    RelatedEntityType = "Tour"
};
```
- Translates external event data into internal DTO
- Adds notification-specific context (title, message format)
- Decouples external event structure from internal commands

### 5. Create Command & Send via MediatR
```csharp
var command = new CreateInAppNotificationCommand(request);
var response = await _mediator.Send(command);
```
- Wraps DTO in MediatR command
- MediatR pipeline executes:
  - Finds `CreateInAppNotificationCommandHandler`
  - Runs registered behaviors (validation, logging)
  - Calls handler's `Handle()` method

### 6. Command Handler Executes
```csharp
public async Task<InAppNotificationResponse> Handle(
    CreateInAppNotificationCommand request,
    CancellationToken cancellationToken)
{
    // a. Create domain entity
    var notification = new InAppNotification(
        request.Request.UserId,
        request.Request.Type,
        request.Request.Title,
        request.Request.Message,
        request.Request.Content
    );

    // b. Apply business rules
    NotificationDeliveryRules.ApplyCreationRules(notification);

    // c. Save to MongoDB
    var created = await _repository.CreateAsync(notification);

    // d. Map to response DTO
    return _mapper.Map<InAppNotificationResponse>(created);
}
```

### 7. Repository Saves to MongoDB
```csharp
await _repository.CreateAsync(notification);
```
- Infrastructure layer implementation uses MongoDB driver
- Inserts document into `InAppNotifications` collection
- Returns saved entity with MongoDB-generated ID

### 8. Response Flows Back
```
Handler → InAppNotificationResponse → MediatR → Consumer → (Future: SignalR Hub)
```

---

## Architectural Decisions & Rationale

### 1. CQRS Pattern Structure ✅

**Decision**: Use vertical slice architecture with feature folders

**Structure**:
```
UseCases/
  InAppNotifications/
    Commands/
      CreateInAppNotification/
        CreateInAppNotificationCommand.cs
        CreateInAppNotificationCommandHandler.cs
    Queries/
      GetNotifications/
        GetNotificationsQuery.cs
        GetNotificationsQueryHandler.cs
```

**Why**:
- ✅ Each feature is self-contained
- ✅ Easy to locate related code
- ✅ Follows Single Responsibility Principle
- ✅ Supports independent feature development

---

### 2. DTO → Command Pattern ✅

**Decision**: Translate event to DTO, then wrap DTO in command

**Flow**:
```
External Event → DTO → Command → Handler
```

**Why NOT directly map event to command**:

#### ❌ Direct Approach (Not Used):
```csharp
var command = new CreateInAppNotificationCommand(
    UserId: message.CreateByUserId,
    Type: NotificationTypeEnum.TourCreated,
    Title: "New Tour Created",
    Message: $"Tour '{message.Title}'...",
    Content: "...",
    RelatedEntityId: message.TourId,
    RelatedEntityType: "Tour"
);
```
**Problems**:
- Duplication when API also creates notifications
- Long parameter lists
- Fragile when adding new fields

#### ✅ DTO Approach (Used):
```csharp
var request = new CreateInAppNotificationRequest { ... };
var command = new CreateInAppNotificationCommand(request);
```

**Benefits**:
- ✅ **Reusability**: Same DTO used from API and event consumers
- ✅ **Validation**: FluentValidation rules defined once on DTO
- ✅ **Maintainability**: Changes to structure happen in one place
- ✅ **Separation**: Consumer doesn't know command internals
- ✅ **Consistency**: Both API and events use same creation logic

**Example of reusability**:
```csharp
// From API Controller
[HttpPost]
public async Task<IActionResult> Create([FromBody] CreateInAppNotificationRequest request)
{
    var command = new CreateInAppNotificationCommand(request);
    var response = await _mediator.Send(command);
    return Ok(response);
}

// From Event Consumer (same DTO!)
var request = new CreateInAppNotificationRequest { ... };
var command = new CreateInAppNotificationCommand(request);
var response = await _mediator.Send(command);
```

---

### 3. Response DTOs ✅

**Decision**: Return DTOs instead of domain entities

**Why**:

#### A. Separation of Concerns
```csharp
// Domain Entity (internal representation)
public class InAppNotification
{
    public string Id { get; set; }
    public DeliveryStatusEnum Status { get; set; }
    public DateTime CreatedAt { get; set; }
    // MongoDB-specific fields
    // Internal business methods
}

// Response DTO (external contract)
public class InAppNotificationResponse
{
    public string Id { get; set; }
    public string Status { get; set; } // String for easier consumption
    public DateTime CreatedAt { get; set; }
    // Only fields clients need
}
```

#### B. Encapsulation
- ✅ Domain entities can evolve without breaking API contracts
- ✅ Hide sensitive/internal fields
- ✅ Control data exposure outside the service

#### C. Different Representations
```csharp
// Entity uses enums
public DeliveryStatusEnum Status { get; set; }

// DTO uses strings (frontend-friendly)
public string Status { get; set; }

// AutoMapper handles conversion
Status = notification.Status.ToString()
```

#### D. API Versioning Support
```csharp
// v1 API
public class InAppNotificationResponseV1 { ... }

// v2 API (different structure)
public class InAppNotificationResponseV2 { ... }

// Same entity, different DTOs
```

#### E. Performance Optimization
```csharp
// Entity might have lazy-loaded properties
public class InAppNotification
{
    public User User { get; set; } // EF navigation property
    public List<DeliveryAttempt> Attempts { get; set; } // Not needed in response
}

// DTO only includes what's necessary
public class InAppNotificationResponse
{
    public string UserId { get; set; } // Just the ID
    // No heavy navigation properties
}
```

#### F. Future Use (SignalR Integration)
```csharp
var response = await _mediator.Send(command);

// Can be directly sent to SignalR clients
await _hubContext.Clients.User(response.UserId)
    .SendAsync("NotificationCreated", response);

// Lightweight, serializable, no circular references
```

---

## Clean Architecture Compliance

### Layer Dependencies
```
✅ Domain        → No dependencies (pure business logic)
✅ Application   → Domain + Shared.Events + MassTransit.Abstractions
✅ Infrastructure→ Application + Domain + External libs (MongoDB, RabbitMQ)
✅ Presentation  → Application + Infrastructure
```

### Why Shared.Events in Application is OK
- **Shared.Events** is an **integration contract** (shared kernel pattern)
- Similar to having a shared DTO library between microservices
- **NOT** part of core domain logic
- Acts as communication protocol between services

**Key Rule**: Domain must **never** depend on Infrastructure ✅

---

## Key Architectural Benefits

### 1. Separation of Concerns
- **Consumer**: Translates events (integration concern)
- **Handler**: Executes business logic (application concern)
- **Repository**: Handles persistence (infrastructure concern)

### 2. Testability
```csharp
// Test consumer in isolation
var consumer = new TourCreatedEventConsumer(mockMediator);
await consumer.Consume(context);
verify(mockMediator.Send(It.IsAny<CreateInAppNotificationCommand>()));

// Test handler in isolation
var handler = new CreateInAppNotificationCommandHandler(mockRepo, mockMapper);
var result = await handler.Handle(command, CancellationToken.None);
```

### 3. Reusability
- Same command works for API requests and event consumers
- Same handler logic regardless of entry point
- Same validation rules applied everywhere

### 4. Maintainability
- Changes to notification creation logic happen in **one place** (handler)
- Adding new event sources only requires new consumers
- Business rules isolated in domain layer

### 5. Scalability
- Easy to add more event consumers
- MassTransit handles message distribution
- Horizontal scaling of notification service instances

---

## Summary Checklist

✅ **CQRS Structure**: Vertical slices with commands/queries separated
✅ **DTO Pattern**: Reusable DTOs wrapped in commands
✅ **Response DTOs**: Protect domain, enable API versioning
✅ **Clean Architecture**: Dependencies flow inward
✅ **Event-Driven**: Decoupled microservices via RabbitMQ
✅ **Testability**: Each layer independently testable
✅ **Maintainability**: Single responsibility, easy to extend

---

## Next Steps

1. ✅ Consumer created and follows CQRS pattern
2. ⏳ Configure MassTransit in Infrastructure (Step 3)
3. ⏳ Set up MongoDB repository implementation
4. ⏳ Integrate SignalR for real-time notifications
5. ⏳ Add integration tests