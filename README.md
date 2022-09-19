# SnAuthDemo
Simple .NET 6 console application to demonstrate the sensenet's authentication feature.
The app connects to your SNaaS repository by clientId-cleindSecret pair and gets the names of the root's children.

## Steps for personalization:
1. Configure the app: change the `sensenet/Url` value to yours in the *appSettings.json*.
2. Change the ClientId and ClientSecret in *appSettings.json* or in your user secret.
3. If you use the user secret, ensure that the `AddUserSecrets` method's parameter in the *Program.cs* line 9 equals to `UserSecretsId` in the *SnAuthDemo.csproj*. If not, copy the value from the csproj and paste it into the code.
