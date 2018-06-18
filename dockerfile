FROM mcr.microsoft.com/powershell

COPY minecraft-monitor.ps1 /minecraft-monitor.ps1

CMD [ "pwsh", "/minecraft-monitor.ps1" ]