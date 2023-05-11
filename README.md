# Mx.NET.SDK.SmartSend
⚡ MultiversX .NET NativeAuth Client SDK: Library for generating native login Token for client app

<br>

## How to install?
The content is delivered via nuget packages:
##### RemarkableTools.Mx.NativeAuthClient [![Package](https://img.shields.io/nuget/v/RemarkableTools.Mx.NativeAuthClient)](https://www.nuget.org/packages/RemarkableTools.Mx.NativeAuthClient/)

<br>

## Main Features
- Generate Client Token

<br>

## Quick start guide
### Basic example
```csharp
var _nativeAuthClient = new NativeAuthClient(new NativeAuthClientConfig()
{
    Origin = "https://remarkable.tools"
});

var token = await _nativeAuthClient.GenerateToken();
```
