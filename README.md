## HandsOnTest

requirements to run:
--SQL Server Express 2019 LocalDB
--dotnet sdk 6

example instructions to install dependency in Setup.ps1 file.
uncomment the top 3 lines to install chocolatey, sql server express localdb, dotnet sdk as needed... 

if dependencies are already installed, you can run Setup.ps1 to launch the HandsOnTest.Ui project

### Project Details

* Used ef core migrations to create the database and seed data.
* Utilized 3 layer architecture 


### Todo, what could be better

* Utilize repository pattern
* Utilize interfaces in models