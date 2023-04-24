# AZ-204: ASP.NET Web App
Web app created to practice deploying to Azure App Services using automatic deploys and manual deploys from the VS Code Azure extension

## Deploy to Windows App Service
The list of steps I followed to practice this parts where:
1. Create Windows app service
2. Create managed SQL database in Azure
3. Set my IP address to connect to the SQL Server database and the IP address of the App Service
4. Created this .NET app with model, repo and service
5. Use DI to get the Azure connection string introduced into the App Service configuration
6. Test with a manual deploy first
7. Set automatic deploy in the configuration tab of the App Service and use this specific Github repository

## IaC
Bicep repo to set up the whole [infrastructure](https://github.com/matyiu/azure-iac-resouces)