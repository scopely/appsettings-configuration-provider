# AppSettings Configuration Provider
.NET Core configuration provider for old AppSettings.config files.

## Usage
Given a file `AppSettings.config`
```xml
<appSettings>
  <add key="someKey" value="someValue" />
</appSettings>
```

Include it as configuration via:
```csharp
using Microsoft.Extensions.Configuration;
using Scopely.Configuration;

var config = new ConfigurationBuilder()
    .AddAppSettingsFile("AppSettings.config", false)
    .Build();

var someValue = config["someKey"];
// ...
```

It also supports `<clear />` and `<remove key="foo" />` elements.

## Install Package

On Nuget: [Scopely.Configuration.AppSettings](https://www.nuget.org/packages/Scopely.Configuration.AppSettings/)

```bash
# install using the dotnet CLI
dotnet add package Scopely.Configuration.AppSettings
```
