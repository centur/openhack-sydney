FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 58557
EXPOSE 44324

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
#COPY apicoreapp/config /app/config
COPY apicoreapp/apicoreapp.csproj apicoreapp/
RUN dotnet restore apicoreapp/apicoreapp.csproj
RUN curl https://raw.githubusercontent.com/kubernetes/helm/master/scripts/get > get_helm.sh
RUN chmod 700 get_helm.sh
RUN ./get_helm.sh
COPY . .
WORKDIR /src/apicoreapp
RUN dotnet build apicoreapp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish apicoreapp.csproj -c Release -o /app
COPY ./minecraft /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "apicoreapp.dll"]
