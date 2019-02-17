#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["RdlDocSvc/RdlDocSvc.csproj", "RdlDocSvc/"]
COPY ["RdlNet2018.Common/RdlNet2018.Common.csproj", "RdlNet2018.Common/"]
RUN dotnet restore "RdlDocSvc/RdlDocSvc.csproj"
COPY . .
WORKDIR "/src/RdlDocSvc"
RUN dotnet build "RdlDocSvc.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RdlDocSvc.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RdlDocSvc.dll"]