# RightDecision

ASP.NET Core Event-Driven API for interactive narrative games.

## About

Right now the project is a functional PoC for a text-based RPG platform, but the goal is to evolve it into a full narrative engine where players can navigate complex branching stories online or offline.

The architecture decouples content creation from gameplay using microservices and asynchronous messaging: an Editor service publishes narrative graphs, while a Player service consumes and serves them.

At the moment, the focus is on the backend architecture, event synchronization, and core navigation business rules.

Once the API and test suite are solid, a front-end may be developed.

## Architecture & Data Flow

[ Editor Service ]

       │
       ▼ (Publishes GamePublishedEvent)
[ RabbitMQ / MassTransit ]
       
       │
       ▼ (Consumes)
[ Player Service ] ──(Saves JSON Aggregate)──► [ SQL Server ]
       
       │
       ▼ (In-Memory Navigation)
 [ Client / API ]

## Stack

- ASP.NET Core Web API
- EF Core (Document-Relational Hybrid with `.ToJson()`)
- MassTransit & RabbitMQ (Docker)
- SQL Server (Docker)

## How to run the project

### Requirements
- SDK .NET 10.0
- Docker

### 1. Run Docker infrastructure
```bash
docker compose up -d
```

### 2. Configure Database and User Secrets (for both projects)
#### Editor 
```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=sqlserver-rd-editor;User Id=sa;Password=yourpassword;TrustServerCertificate=True;"
```
#### Player
```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1434;Database=sqlserver-rd-player;User Id=sa;Password=yourpassword;TrustServerCertificate=True;"
```
#### Both
```bash
dotnet ef database update
```

### 3. Run the APIs (for both projects)
```bash
dotnet run
```

### 4. Testing the Game Flow

1. Use the **Editor API** Swagger to create and publish a game. This emits a `GamePublishedEvent` via RabbitMQ.
2. The **Player Service** consumes the event and creates the game aggregate in SQL Server.
3. Query the `Games` table or the Editor response to retrieve the published `gameId`.
4. Use the **Player API** Swagger (`http://localhost:<port>/swagger`) with the `gameId` to fetch the first scene (`/GetFirstScene`) and navigate through choices (`/GetScene`).
