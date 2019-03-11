# PubLeage Tracker

## Setting up the Database
If you're running on MacOs or Linux, you'll have to run SQL Server from inside of Docker. 

This article details how to get everything setup: https://docs.microsoft.com/en-us/sql/linux/quickstart-install-connect-docker?view=sql-server-2017&pivots=cs1-bash

This command will create a new SQL server in docker:

```
sudo docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=Password!' \
   -p 1433:1433 --name sql1 \
   -d mcr.microsoft.com/mssql/server:2017-latest
```

The database must be running before you can start the application.