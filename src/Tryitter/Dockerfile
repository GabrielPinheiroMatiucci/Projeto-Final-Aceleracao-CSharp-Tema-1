FROM mcr.microsoft.com/dotnet/sdk:6.0 AS builder

WORKDIR /App

COPY . ./

RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /App

COPY --from=builder /App/out .

ENTRYPOINT ["dotnet", "Tryitter.dll"]