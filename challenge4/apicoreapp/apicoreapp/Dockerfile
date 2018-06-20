FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 58557
EXPOSE 44324

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
#COPY apicoreapp/config /app/config
COPY apicoreapp/minecraft /app/minecraft
COPY apicoreapp/apicoreapp.csproj apicoreapp/
RUN dotnet restore apicoreapp/apicoreapp.csproj
COPY . .
WORKDIR /src/apicoreapp
RUN dotnet build apicoreapp.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish apicoreapp.csproj -c Release -o /app



FROM base AS final
WORKDIR /app
COPY --from=publish /app .
RUN mkdir /root/.kube
RUN cp /app/config /root/.kube/config
RUN curl https://raw.githubusercontent.com/kubernetes/helm/master/scripts/get > /app/get_helm.sh
RUN chmod 700 /app/get_helm.sh
RUN /app/get_helm.sh
RUN helm init --client-only
ENTRYPOINT ["dotnet", "apicoreapp.dll"]
