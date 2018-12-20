# Bullhorn.Net
C# bullhorn .net sdk for the APi. Based on the java sdk

A c# client library for working with the Bullhorn REST API. Handles authentication and objectifies API operations.
Based on [https://github.com/bullhorn/sdk-rest](Bullhorn sdk rest) java library. 

## Status

Library is still work in progress, but functional on finding single entities, querying entities and searching. We made it also possible to
upload a cv.

## Running Test

Add a settings.config to your project with your credentials. Like:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <add key="RestAuthorizeUrl" value="YOUR-AUTHORIZE-URL"/>
    <add key="RestLoginUrl" value="YOUR-LOGIN-URL"/>
    <add key="RestTokenUrl" value="YOUR-TOKEN-URL"/>
    <add key="RestSessionMinutesToLive" value="1400"/>
    <add key="RestUsername" value="YOUR-USERNAME"/>
    <add key="RestPassword" value="YOUR-PASSWORD"/>
    <add key="RestClientId" value="YOUR-CLIENTID"/>
    <add key="RestClientSecret" value="YOUR-CLIENTSECRET"/>
  </appSettings>
</configuration>
```


