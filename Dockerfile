FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build
WORKDIR /app

COPY Api/*.csproj ./Api/
COPY Model/*.csproj ./Model/
COPY Service/*.csproj ./Service/

RUN dotnet restore "Api/Api.csproj"
COPY . ./

WORKDIR /app/Api
RUN dotnet publish -c release -o out

FROM mcr.microsoft.com/dotnet/core/runtime:3.1
WORKDIR /app
COPY --from=build /app/Api/out/ .
ENTRYPOINT [ "dotnet","Api.dll" ]




