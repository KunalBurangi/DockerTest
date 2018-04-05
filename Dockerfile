from microsoft/dotnet:latest
copy . app
workdir /app

run dotnet restore
run dotnet build

expose 5000
ENV ASPNETCORE_URLS http://*:5000
ENV ASPNETCORE_ENVIRONMENT docker

ENTRYPOINT dotnet run
