#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
#COPY ["SceptrumProject.Web/SceptrumProject.Web.csproj", "SceptrumProject.Web/"]
#COPY ["SceptrumProject.Infra.IoC/SceptrumProject.Infra.IoC.csproj", "SceptrumProject.Infra.IoC/"]
#COPY ["SceptrumProject.Infra.Data/SceptrumProject.Infra.Data.csproj", "SceptrumProject.Infra.Data/"]
#COPY ["SceptrumProject.Domain/SceptrumProject.Domain.csproj", "SceptrumProject.Domain/"]
#COPY ["SceptrumProject.Application/SceptrumProject.Application.csproj", "SceptrumProject.Application/"]
COPY ["SceptrumProject.Web/SceptrumProject.Web.csproj", "SceptrumProject.Web/"]
COPY ["SceptrumProject.Infra.IoC/SceptrumProject.Infra.IoC.csproj", "SceptrumProject.Infra.IoC/"]
COPY ["SceptrumProject.Infra.Data/SceptrumProject.Infra.Data.csproj", "SceptrumProject.Infra.Data/"]
COPY ["SceptrumProject.Domain/SceptrumProject.Domain.csproj", "SceptrumProject.Domain/"]
COPY ["SceptrumProject.Application/SceptrumProject.Application.csproj", "SceptrumProject.Application/"]
RUN dotnet restore "SceptrumProject.Web/SceptrumProject.Web.csproj"
COPY . .
WORKDIR "/src/SceptrumProject.Web"
RUN dotnet build "SceptrumProject.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SceptrumProject.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SceptrumProject.Web.dll"]