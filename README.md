# PostgresConnString.NET

[![Build status](https://ci.appveyor.com/api/projects/status/grtkl701lefkykrl?svg=true)](https://ci.appveyor.com/project/BolorunduroWinnerTimothy/postgresconnstring-net)
 [![codecov](https://codecov.io/gh/bolorundurowb/PostgresConnString.NET/branch/master/graph/badge.svg)](https://codecov.io/gh/bolorundurowb/PostgresConnString.NET) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE) [![NuGet Badge](https://buildstats.info/nuget/PostgresConnString.NET)](https://www.nuget.org/packages/PostgresConnString.NET)

This library aims to give as accurate an estimate of the read time for an article in HTML or Markdown.

## Installation

You can install the package from nuget

```
Install-Package PostgresConnString.NET
```

or

```
dotnet add package PostgresConnString.NET
```

or for paket

```
paket add PostgresConnString.NET
```

## Usage

### Parsing Urls

To parse a url

```csharp
using PostgresConnString.NET;
...
var details = ConnectionDetails.Parse("postgres://someuser:somepassword@somehost:381/somedatabase");
```

The resulting details contains a subset of the following properties:

* `Host` - Postgres server hostname
* `Port` - port on which to connect
* `User` - User with which to authenticate to the server
* `Password` - Corresponding password
* `Database` - Database name within the server

### Exports

Currently, this library allows for generating an NPGSQL compatible connection string.

```csharp
using PostgresConnString.NET;
...
var details = ConnectionDetails.Parse("postgres://someuser:somepassword@somehost:381/somedatabase");
var connString = details.ToNpgsqlSConnectionString(); //User ID=someuser;Password=somepassword;Server=somehost;Port=381;Database=somedatabase;Pooling=true;SSL Mode=Prefer;Trust Server Certificate=true
```

## Contributing

Feel free to make requests and to open P=pull requests with fixes and updates.
