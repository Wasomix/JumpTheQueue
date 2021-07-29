#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 8085
EXPOSE 1422

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Templates/WebAPI/Devon4Net.Application.WebAPI/Devon4Net.Application.WebAPI.csproj", "Templates/WebAPI/Devon4Net.Application.WebAPI/"]
COPY ["Templates/WebAPI/Devon4Net.WebAPI.Implementation/Devon4Net.WebAPI.Implementation.csproj", "Templates/WebAPI/Devon4Net.WebAPI.Implementation/"]
RUN dotnet restore "Templates/WebAPI/Devon4Net.Application.WebAPI/Devon4Net.Application.WebAPI.csproj"
COPY . .
WORKDIR "/src/Templates/WebAPI/Devon4Net.Application.WebAPI"
RUN dotnet build "Devon4Net.Application.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Devon4Net.Application.WebAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Devon4Net.Application.WebAPI.dll"]