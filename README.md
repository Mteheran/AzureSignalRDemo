# AzureSignalRDemo
Azure SignalR demo using Azure functions 


[![alt](http://link)]

Within the project FuctionChat.csproj Create or Update "local.settings.json" using the following information:

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureSignalRConnectionString": "YourAzureConnectionString",
    "AzureWebJobsStorage": "",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet"
  },
  "Host": {
    "LocalHttpPort": 7071,
    "CORS": "*"
  }
}
```

Within the project SignalRChat.csproj Create or Update "local.settings.json" using the following information:

```json
{
  "iisSettings": {
    "windowsAuthentication": false,
    "anonymousAuthentication": true,
    "iisExpress": {
      "applicationUrl": "http://localhost:53733",
      "sslPort": 0
    }
  },
  "profiles": {
    "IIS Express": {
      "commandName": "IISExpress",
      "launchBrowser": true,
      "environmentVariables": {
        "ASPNETCORE_ENVIRONMENT": "Development"
      }
    }
  }
}
```
