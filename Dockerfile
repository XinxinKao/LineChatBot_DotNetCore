FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["LineChatBot_DotNetCore/LineChatBot_DotNetCore.csproj", "LineChatBot_DotNetCore/"]
RUN dotnet restore "LineChatBot_DotNetCore/LineChatBot_DotNetCore.csproj"
COPY . .
WORKDIR "/src/LineChatBot_DotNetCore"
RUN dotnet build "LineChatBot_DotNetCore.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LineChatBot_DotNetCore.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LineChatBot_DotNetCore.dll"]