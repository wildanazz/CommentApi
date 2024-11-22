---

# CommentApi

A Web API built using .NET Core to handle CRUD operations on a MongoDB database for managing the comment section of a personal website. The API provides endpoints for creating, retrieving, updating, and deleting user comments.

## Features

- **RESTful API**: Provides clear, structured endpoints for CRUD operations on comments.
- **MongoDB Integration**: Uses MongoDB for persistent comment storage.
- **Validation**: Basic input validation for comment fields.
- **Error Handling**: Returns appropriate HTTP status codes for success, errors, and edge cases.
- **Dockerized**: Easily deployable through Docker.
  
## Endpoints

### 1. GET /comments
Retrieves all comments from the database.
- Example Response:
  ```json
  [
    {
      "id": "1",
      "username": "user123",
      "message": "This is a test comment.",
      "createdAt": "2024-09-30T12:00:00Z"
    }
  ]
  ```

### 2. GET /comments/{id}
Retrieves a specific comment by ID.
- Example Response:
  ```json
  {
    "id": "1",
    "username": "user123",
    "message": "This is a test comment.",
    "createdAt": "2024-09-30T12:00:00Z"
  }
  ```

### 3. POST /comments
Adds a new comment.
- Example Request:
  ```json
  {
    "username": "user123",
    "message": "Great post!"
  }
  ```
- Example Response:
  ```json
  {
    "id": "2",
    "username": "user123",
    "message": "Great post!",
    "createdAt": "2024-09-30T12:10:00Z"
  }
  ```

### 4. PUT /comments/{id}
Updates an existing comment by ID.
- Example Request:
  ```json
  {
    "message": "Updated comment text."
  }
  ```
- Example Response:
  ```json
  {
    "id": "1",
    "username": "user123",
    "message": "Updated comment text.",
    "createdAt": "2024-09-30T12:00:00Z",
    "updatedAt": "2024-09-30T12:15:00Z"
  }
  ```

### 5. DELETE /comments/{id}
Deletes a specific comment by ID.
- Example Response:
  ```json
  {
    "message": "Comment deleted successfully."
  }
  ```

## Getting Started

### Prerequisites

- .NET Core 3.1 SDK or higher
- MongoDB (local or remote instance)
- Docker (optional for containerization)

### Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/wildanazz/CommentApi.git
   cd CommentApi
   ```

2. Restore packages:
   ```bash
   dotnet restore
   ```

3. Set up MongoDB:
   - Ensure MongoDB is running locally or provide a connection string to a remote MongoDB instance in `appsettings.json`.
   - Modify the `ConnectionStrings:DefaultConnection` to match your MongoDB instance.

4. Build and run the application:
   ```bash
   dotnet run
   ```

   The application will start at `http://localhost:5000`.

### Running with Docker

1. Build the Docker image:
   ```bash
   docker build -t comment-api .
   ```

2. Run the Docker container:
   ```bash
   docker run -d -p 5000:5000 --name comment-api comment-api
   ```

3. The API will be accessible at `http://localhost:5000`.

## Configuration

- The main configuration file is `appsettings.json` where you can configure MongoDB connection strings and other environment-specific settings.
- For development configurations, you can use `appsettings.Development.json`.

---
