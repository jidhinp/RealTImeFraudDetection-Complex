# FinTech Real-Time Fraud Detection

## Overview
This project is a modern FinTech web application built with ASP.NET Core (.NET 8) that demonstrates real-time fraud detection using machine learning (ML.NET), SignalR for live alerts, and SQL Server for data storage. It provides both a REST API and a simple web UI for submitting transactions and receiving fraud alerts.

---

## Features
- **REST API** for submitting and storing transactions
- **ML.NET integration** for fraud detection using a pre-trained model (`fraudModel.zip`)
- **Real-time fraud alerts** via SignalR
- **SQL Server database** for transactions and alerts
- **Web UI** for demo and testing

---

## Project Structure
- `Controllers/TransactionController.cs` — Handles transaction API requests and fraud detection
- `Models/MLModels.cs` — Defines ML input/output classes (`TransactionData`, `TransactionPrediction`)
- `Models/Transaction.cs` — Transaction entity for the database
- `Models/FraudAlert.cs` — Fraud alert entity for the database
- `Models/FinanceDbContext.cs` — Entity Framework Core database context
- `Models/TransactionDto.cs` — DTO for API requests
- `Hubs/FraudAlertHub.cs` — SignalR hub for real-time alerts
- `wwwroot/index.html` — Simple web UI for submitting transactions and viewing alerts
- `fraudModel.zip` — Pre-trained ML.NET model for fraud detection

---

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (or use SQL Server Express/localdb)

### Setup
1. **Clone the repository**
2. **Configure the database connection**
   - Edit `appsettings.json` and set the `DefaultConnection` string to your SQL Server instance:
     ```json
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=FinanceDb;Trusted_Connection=True;TrustServerCertificate=True;"
     }
     ```
3. **Apply database migrations** (if using migrations):
   ```bash
   dotnet ef database update
   ```
4. **Build and run the project**:
   ```bash
   dotnet run
   ```
5. **Access the web UI**:
   - Open [http://localhost:5276](http://localhost:5276) (or the port shown in your terminal)

---

## Usage

### Web UI
- Go to the root URL. Use the form to submit a transaction.
- If the transaction is flagged as fraud, a real-time alert will appear below.

### API
- **POST** `/api/transaction`
  - **Request Body:**
    ```json
    {
      "transactionId": "string",
      "amount": 123.45,
      "accountNumber": "string"
    }
    ```
  - **Response:**
    - `200 OK` if successful
    - `400 Bad Request` with a reason if fraud is detected

---

## Database
- **Tables:**
  - `Transactions`: Stores all submitted transactions
  - `FraudAlerts`: Stores fraud alerts for flagged transactions
- **Entities:**
  - `Transaction`:
    - `Id`, `TransactionId`, `Amount`, `AccountNumber`, `Timestamp`, `IsFraud`
  - `FraudAlert`: 
    - `Id`, `TransactionId`, `Reason`, `AlertTime`

---

## Machine Learning Model
- **Model file:** `fraudModel.zip`
- **Input class:** `TransactionData`
  - `Amount` (float)
  - `AccountNumber` (string)
- **Output class:** `TransactionPrediction`
  - `PredictedLabel` (bool)
  - `Probability` (float)
  - `Score` (float)
- The model is loaded at startup and used to predict fraud for each transaction.

---

## Real-Time Alerts
- **SignalR Hub:** `/fraudAlertHub`
- When a transaction is flagged as fraud, all connected clients receive a real-time alert with the transaction ID and reason.

---

## Extending the Project
- Add more features to `TransactionData` and retrain the ML model for better accuracy.
- Add authentication/authorization for production use.
- Expand the web UI for more features (transaction history, user management, etc.).

---

## License
This project is for educational/demo purposes. Please adapt as needed for production use. 