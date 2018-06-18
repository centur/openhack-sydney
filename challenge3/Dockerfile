FROM mcr.microsoft.com/powershell
WORKDIR /sidecar
ADD . /sidecar
#ENV ServerIp 1.1.1.1
#ENV ServerPort 25565
#ENV ServerAdminPort 25575
#ENV Message "Via Monitoring Sidecar"
#ENV WorkspaceId ""
#ENV OmsSecret ""
CMD ["pwsh", "-c", "/sidecar/monitoring.ps1"]
