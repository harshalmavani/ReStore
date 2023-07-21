# Use the official .NET SDK image as the build image
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
# Set the working directory
WORKDIR /app
# Copy the project file and restore the dependencies
COPY *.csproj ./
RUN dotnet restore
# Copy the rest of the source code and build the project
COPY . ./

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet ef database update

RUN dotnet publish -c Release -o build


# Use the official ASP.NET Core runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
# Expose port 80 for the web server
EXPOSE 80
# Set the working directory
WORKDIR /app


# Use the base image as the final image
FROM base AS final
# Copy the build output from the build image
COPY --from=build-env /app/build .
RUN echo $(ls -1 /tmp/dir)
# Set the entrypoint command to run the application
ENTRYPOINT ["dotnet", "API.dll"]