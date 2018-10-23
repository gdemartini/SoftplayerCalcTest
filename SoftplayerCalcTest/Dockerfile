FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
EXPOSE 80

COPY /home/vsts/work/1/a/SoftplayerCalcTest .
ENTRYPOINT ["dotnet", "SoftplayerCalcTest.dll"]


#FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
#WORKDIR /app
#EXPOSE 80
#
#FROM microsoft/dotnet:2.1-sdk AS build
#WORKDIR /src
#COPY SoftplayerCalcTest/SoftplayerCalcTest.csproj SoftplayerCalcTest/
#RUN dotnet restore SoftplayerCalcTest/SoftplayerCalcTest.csproj
#COPY . .
#WORKDIR /src/SoftplayerCalcTest
#RUN dotnet build SoftplayerCalcTest.csproj -c Release -o /app
#
#FROM build AS publish
#RUN dotnet publish SoftplayerCalcTest.csproj -c Release -o /app
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
#ENTRYPOINT ["dotnet", "SoftplayerCalcTest.dll"]
