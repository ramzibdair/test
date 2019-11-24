FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS publish
WORKDIR /app
COPY . ./
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS final
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HelloContainers.Web.dll"]