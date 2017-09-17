# Alexa.NET.Management
A .NET SDK for the Alexa Skills Management API

![Current Build](https://ci.appveyor.com/api/projects/status/tx6l1m4hcdjelu5a/branch/master?svg=true)


## Retrieving Skill Information
```csharp
var manager = new ManagementApi(amazonLoginAccessToken);
var skillDetail = manager.Skills.Get(skillId);
var skillPublishingInformation = skillDetail.Manifest.PublishingInformation.Locales.First().Value;
var skillName = skillPublishingInformation.Name;
```
