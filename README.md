# IEX.Net
.Net object-oriented wrapper for the IEX Cloud Api

https://iexcloud.io/console/usage
https://iexcloud.io/docs/api/

## Documentations

## Nuget

## Builds and Tests
<!--
[![Build status](https://ci.appveyor.com/api/projects/status/7aiumqihtin1hmwg/branch/master?svg=true)](https://ci.appveyor.com/project/chriszumberge/slngen/branch/master)

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/95c5f5a4dfce4dde9cc76247a88a8190)](https://www.codacy.com/app/chriszumberge/SlnGen?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=chriszumberge/SlnGen&amp;utm_campaign=Badge_Grade)

CI NuGet Feed: (appveyor)
-->

## Platform Support
|Platform       | Version  |
|---------------|:--------:|
|.Net           | 4.5+  |
|.Net Core      | 1.0+  |
|.Net Standard  | 1.4+  |
|Xamarin.iOS    | 10.0+ |
|Xamarin.Android| 7.0+  |
|UWP            | 10.0+ |

## Setup
- Available on NuGet: (link)
- Install into .NET project

## API Usage

### Developer Tips

## Contribute
The library is open source so pull requests are encouraged.
- Report bugs by opening an issue
- Submit feature requests by opening an issue
- Fix bugs or add features by sending a pull request

### Known Issues
- (See issues)

### ToDos

### Project Roadmap

### Coding Conventions
In general, follow the style used by the [.Net Foundation](https://github.com/dotnet/corefx/blob/master/Documentation/coding-guidelines/coding-style.md)
with the following exceptions:
- Preference to use [expression bodied functions](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members#methods)
and [properties](https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/expression-bodied-members#property-get-statements)
where applicable
- Do not use the ```private``` keyword as it is the default accessibility level
- Hard tabs over spaces, *always*

Taking special note of:
- [Allman style](https://en.wikipedia.org/wiki/Indent_style#Allman_style) braces
- Use _camelCase for internal/private fields
- Use ```readonly``` where possible
- Prefix instance fields with ```_```
- Static fields start with ```s_```
- Fields should be specified at the top within type declarations
- Use ```nameof(...)``` whenever possible
- Avoid ```this.``` whenever possible
- Only use ```var``` when it's obvious what the variable type is
- Use PascalCasing to name constant variables and fields

### Architecture Conventions
- All services must implement an IService interface for both dependency injection and easier testing
- Where possible, services should have a configuration interface that a developer can implement to customize the service

### Project Conventions
- Sort and remove all assembly references