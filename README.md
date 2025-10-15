# Planinarske Ture (Mountain Tours)

A microservices-based web application for managing mountain tours, reviews, and real-time notifications.

## 🏗️ Architecture Overview

This project follows a **microservices architecture** with:
- **Backend**: Multiple .NET 8 microservices
- **Frontend**: React with TypeScript
- **Gateway**: API Gateway with SignalR for real-time notifications
- **Messaging**: RabbitMQ for event-driven communication
- **Databases**: SQL Server, PostgreSQL, MongoDB

### System Architecture

```
┌─────────────┐
│   Frontend  │ (React + TypeScript + SignalR)
│  Port: 3000 │
└──────┬──────┘
       │
       ↓
┌──────────────────────────────┐
│    Gateway (Port: 8084)      │ ← API Gateway + SignalR Hub
└──────┬───────────────────────┘
       │
       ├─→ Tours Service (8080)         → SQL Server (1434)
       ├─→ Identity Service (8081)      → SQL Server (1435)
       ├─→ Reviewing Service (8082)     → PostgreSQL (6543)
       └─→ Notifications Service (8083) → MongoDB (27018)
                    ↑
                    │
            ┌───────┴────────┐
            │   RabbitMQ     │ (5672, 15672)
            └────────────────┘
```

## 📁 Project Structure

```
Planinarske-ture/
├── backend/
│   ├── docker-compose.yml              # Infrastructure orchestration
│   ├── MountainToursGateway/           # API Gateway + SignalR Hub
│   └── Services/
│       ├── Tours/                      # Tours microservice
│       ├── Identity/                   # Authentication & Users
│       ├── Review/                     # Reviews microservice
│       ├── Notifications/              # Notifications microservice
│       └── Shared.Events/              # Shared event contracts
└── frontend/                           # React SPA
```

## 🚀 Running the Application

### Prerequisites

- **Docker Desktop** installed and running
- **Node.js 16+** and **npm**
- **Git**

### Option 1: Quick Start (Recommended)

#### 1. Start Backend Services

```bash
cd backend
docker-compose up --build
```

This will start:
- ✅ Gateway (http://localhost:8084)
- ✅ Tours API (http://localhost:8080)
- ✅ Identity API (http://localhost:8081)
- ✅ Reviewing API (http://localhost:8082)
- ✅ Notifications API (http://localhost:8083)
- ✅ RabbitMQ (http://localhost:15672)
- ✅ All databases

**Wait for all services to be healthy** (check logs for "✅" or "healthy" messages)

#### 2. Start Frontend

In a new terminal:

```bash
cd frontend
npm install
npm start
```

Frontend will be available at: **http://localhost:3000**

#### 3. Access the Application

- **Application**: http://localhost:3000
- **Gateway Swagger**: http://localhost:8084/swagger
- **RabbitMQ Management**: http://localhost:15672 (guest/guest)

### Option 2: Development Mode (Individual Services)

If you prefer running services individually:

#### Backend Services

```bash
# Terminal 1 - Infrastructure
cd backend
docker-compose up rabbitmq tours_db identity_db reviewing-db notifications-mongo

# Terminal 2 - Gateway
cd backend/MountainToursGateway/MoutainToursGateway.API
dotnet run

# Terminal 3 - Tours Service
cd backend/Services/Tours/Tours.API
dotnet run

# Terminal 4 - Identity Service
cd backend/Services/Identity/Identity.API
dotnet run

# Terminal 5 - Reviewing Service
cd backend/Services/Review/Reviewing.Api
dotnet run

# Terminal 6 - Notifications Service
cd backend/Services/Notifications/src/Notifications.API
dotnet run
```

#### Frontend

```bash
# Terminal 7 - Frontend
cd frontend
npm install
npm start
```

## 🛠️ Technology Stack

### Backend
- **.NET 8** - Framework
- **MassTransit + RabbitMQ** - Event-driven messaging
- **SignalR** - Real-time notifications
- **YARP** - Reverse proxy (Gateway)
- **MediatR** - CQRS pattern
- **AutoMapper** - Object mapping
- **Serilog** - Structured logging
- **Entity Framework Core** - ORM (SQL Server, PostgreSQL)
- **MongoDB.Driver** - MongoDB access

### Frontend
- **React 18** - UI framework
- **TypeScript** - Type safety
- **Zustand** - State management
- **React Router** - Navigation
- **Axios** - HTTP client
- **SignalR Client** - Real-time updates
- **Tailwind CSS** - Styling
- **Radix UI** - Component library

### Databases
- **SQL Server** - Tours, Identity
- **PostgreSQL** - Reviews
- **MongoDB** - Notifications

## 📊 Service Ports

| Service | Port | Swagger | Description |
|---------|------|---------|-------------|
| Frontend | 3000 | - | React SPA |
| Gateway | 8084 | API Gateway + SignalR Hub |
| Tours API | 8080  | Tours management |
| Identity API | 8081  | Authentication & Users |
| Reviewing API | 8082  | Reviews & Ratings |
| Notifications API | 8083  | In-app notifications |
| RabbitMQ | 5672 | - | Message broker |
| RabbitMQ Management | 15672  | RabbitMQ admin UI |
| Tours DB (SQL) | 1434 | - | Tours database |
| Identity DB (SQL) | 1435 | - | Identity database |
| Reviewing DB (PostgreSQL) | 6543 | - | Reviews database |
| Notifications DB (MongoDB) | 27018 | - | Notifications database |

## 🔄 Key Features

### Event-Driven Notifications
When a new tour is created:
1. **Tours Service** publishes `TourCreatedEvent` → RabbitMQ
2. **Notifications Service** consumes event → saves to MongoDB → publishes to Gateway
3. **Gateway** receives event → broadcasts via SignalR to all connected clients
4. **Frontend** displays real-time notification popup

### Authentication Flow
- Users register/login via **Identity Service**
- JWT tokens are stored in localStorage
- Gateway uses YARP for reverse proxy routing
- SignalR connections are authenticated via JWT

### CQRS Pattern
All services use **CQRS** with MediatR:
- **Commands**: Create, Update, Delete operations
- **Queries**: Read operations
- **Handlers**: Business logic execution



### Frontend
```bash
cd frontend
npm run lint          # Lint check
npm run lint:fix      # Auto-fix lint issues
npm run format:check  # Format check
npm run format        # Auto-format code
```

## 🐳 Docker Commands

### Start all services
```bash
docker-compose up
```

### Start in detached mode
```bash
docker-compose up -d
```

### Rebuild and start
```bash
docker-compose up --build
```

### Stop all services
```bash
docker-compose down
```

### Stop and remove volumes (clean slate)
```bash
docker-compose down -v
```

### View logs
```bash
docker-compose logs -f                    # All services
docker-compose logs -f mountaintoursgateway.api  # Specific service
```

### Check service health
```bash
docker-compose ps
```

## 🔐 Default Credentials

### RabbitMQ Management
- **URL**: http://localhost:15672
- **Username**: `guest`
- **Password**: `guest`

### Databases
- **SQL Server SA Password**: `PlaninarskeTureToursDB*1` (Tours), `IdentityDB*1` (Identity)
- **PostgreSQL**: `postgres` / `postgres`
- **MongoDB**: `root` / `notificationspwd`

## 🛡️ Environment Variables

Key environment variables (set in `docker-compose.yml`):

```yaml
# Gateway
ASPNETCORE_URLS=http://+:8084
RabbitMq__Host=rabbitmq

# Tours Service
ConnectionStrings__ToursDB=Server=tours_db;...

# Notifications Service
MongoDb__ConnectionString=mongodb://root:notificationspwd@notifications-mongo:27017
RabbitMq__Host=rabbitmq
```

## 📝 Development Workflow

1. **Backend Changes**:
   - Make code changes
   - Rebuild container: `docker-compose up --build <service-name>`

2. **Frontend Changes**:
   - Changes auto-reload with hot-reload
   - No restart needed

3. **Database Changes**:
   - Migrations auto-apply on service startup
   - Or run manually: `dotnet ef database update`

## 🚨 Troubleshooting

### Services won't start
```bash
# Check if ports are already in use
lsof -i :8084  # Check specific port

# Clean Docker environment
docker-compose down -v
docker system prune -a
docker-compose up --build
```

### Frontend can't connect to backend
- Verify Gateway is running on port 8084
- Check CORS configuration in Gateway's `Program.cs`
- Ensure frontend is configured for `http://localhost:8084`

### SignalR notifications not working
- Check Gateway logs for connection attempts
- Verify JWT token in browser localStorage (`auth_token`)
- Check RabbitMQ has messages in queues (Management UI)
- Ensure all users are connected (check browser console for "✅ SignalR connected")

### Database connection issues
- Ensure databases are healthy: `docker-compose ps`
- Wait 10-30 seconds for databases to initialize
- Check connection strings in `docker-compose.yml`

## 📚 Additional Documentation

- [Notifications Service](./backend/Services/Notifications/README.md) - Detailed notification service documentation

## 👥 Project Information

**University Project** - Software Engineering
- Microservices Architecture
- Event-Driven Design
- Real-time Communication
- Clean Architecture Principles


