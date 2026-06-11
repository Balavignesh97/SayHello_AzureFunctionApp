# SayHello_AzureFunctionApp

Azure Functions | Azure DevOps | CI/CD Pipeline — A hands-on project for learning serverless app development, cloud hosting, and automated deployments triggered on code push.

---

## What it does

A simple Azure Function that responds with a greeting based on the input you send. It reads the `Greet` value from the request body and returns a time-aware message.

---

## API Usage

**Endpoint**
```
POST https://sayhello-g0d3cbb8hhbmcxgj.southindia-01.azurewebsites.net/api/SayHello
```

**Request Body**
```json
{
    "Greet": "HI"
}
```

**Response**
```json
{
    "message": "Good Afternoon! Thanks for saying 'HI'."
}
```

> The greeting in the response changes based on the time of day (Morning / Afternoon / Evening).

---

## Try it out

You can test this using [Postman](https://www.postman.com/) or any HTTP client.

**Postman setup:**
1. Set method to `POST`
2. URL: `https://sayhello-g0d3cbb8hhbmcxgj.southindia-01.azurewebsites.net/api/SayHello`
3. Go to **Body** → select **raw** → choose **JSON**
4. Paste the request body and hit **Send**

---

## What I learned

- Creating and structuring an **Azure Function App** (HTTP trigger)
- Hosting the function on **Azure App Service**
- Managing source code with **Azure DevOps Repos**
- Setting up a **CI/CD pipeline** to automatically build and deploy on every push

---

## Tech Stack

| Tool | Purpose |
|------|---------|
| Azure Functions | Serverless compute |
| Azure App Service | Cloud hosting |
| Azure DevOps | Version control & CI/CD |
| C# / .NET | Function implementation |
