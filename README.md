# PostgresConnString.NET

[![Build status](https://ci.appveyor.com/api/projects/status/m47qrpg43t5l9mo3?svg=true)](https://ci.appveyor.com/project/BolorunduroWinnerTimothy/postgresconnstring-net)
 [![codecov](https://codecov.io/gh/bolorundurowb/PostgresConnString.NET/branch/master/graph/badge.svg)](https://codecov.io/gh/bolorundurowb/PostgresConnString.NET) [![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE) [![NuGet Badge](https://buildstats.info/nuget/PostgresConnString.NET)](https://www.nuget.org/packages/PostgresConnString.NET)

This library aims to give as accurate an estimate of the read time for an article in HTML or Markdown.

## Installation

You can install the package from nuget

```
Install-Package ReadTimeEstimator
```

or

```
dotnet add package ReadTimeEstimator
```

or for paket

```
paket add ReadTimeEstimator
```

## Usage

This package provided two estimators, one for HTML and one for Markdown, `HtmlEstimator` and `MarkdownEstimator` respectively. On each estimator, two methods are provided for retrieving the time estimates. `ReadTimeInMinutes` returns a `double` value which is the estimated read time in minutes. `HumanFriendlyReadTime` returns a `string` which is  the read time in human friendly form.
 
A classic usage example:

```csharp
using ReadTimeEstimator.Implementations.Estimators;

...

var htmlEstimator = new HtmlEstimator();
var markdownEstimator = new MarkdownEstimator();
var htmlReadTime = htmlEstimator.ReadTimeInMinutes("<div>Hello World</div>"); // 0.00727
var markdownReadTime = markdownEstimator.HumanFriendlyReadTime("# Hello World"); // less than a minute
```
