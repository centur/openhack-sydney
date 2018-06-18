FROM mcr.microsoft.com/powershell

COPY LogAnalytics.ps1 /LogAnalytics.ps1

CMD [ "pwsh", "/LogAnalytics.ps1" ]