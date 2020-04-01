FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
WORKDIR /application
COPY . .
RUN dotnet build
RUN dotnet publish --configuration Release -o out BookMark.RestApi/BookMark.RestApi.csproj

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /www
COPY --from=build /application/out .
CMD ["dotnet", "BookMark.RestApi.dll"]
