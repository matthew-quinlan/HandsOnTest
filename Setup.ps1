
# install chocolatey
# Set-ExecutionPolicy Bypass -Scope Process -Force; [System.Net.ServicePointManager]::SecurityProtocol = [System.Net.ServicePointManager]::SecurityProtocol -bor 3072; iex ((New-Object System.Net.WebClient).DownloadString('https://community.chocolatey.org/install.ps1'))

# install sql server express
# choco install sql-server-express

# install dotnet core sdk
# choco install dotnet-sdk

dotnet run --project .\HandsOnTest.UI\HandsOnTest.UI.csproj