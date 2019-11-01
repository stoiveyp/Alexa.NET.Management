# Alexa.NET.Management
A .NET SDK for the Alexa Skills Management API

![Current Build](https://ci.appveyor.com/api/projects/status/tx6l1m4hcdjelu5a/branch/master?svg=true)

## Nuget Package
[Alexa.Net.Management](https://www.nuget.org/packages/Alexa.NET.Management/)

## Retrieving Skill Information
```csharp
var manager = new ManagementApi(amazonLoginAccessToken);
var skillDetail = manager.Skills.Get(skillId);
var skillPublishingInformation = skillDetail.Manifest.PublishingInformation.Locales.First().Value;
var skillName = skillPublishingInformation.Name;
```

### Get Vendors
```csharp
var manager = new ManagementApi(amazonLoginAccessToken);
var vendors = await manager.Vendors.Get()
```

### Create Skill Beta & Add Tester
```csharp
var beta = await manager.Beta.Create(skillId,"feedbackemail@example.com")
await manager.Beta.AddTesters(skillId,new[]{"test1@example.com","test2@example.com"})
```
 
