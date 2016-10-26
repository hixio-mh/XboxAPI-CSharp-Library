# XboxAPI C# Library
### Overview
This XboxAPI library is designed to handle all endpoints of the XboxAPI in a handy and easy to use object oriented form. Endpoint data is returned in objects that can then be manipulated as needed. THIS PROJECT IS A WORK IN PROGRESS, AND DOES NOT YET COMPLETELY SUPPORT XBOXAPI.


### Sample Implementation
```
// Set XboxAPI key
XAPI.SetXboxAPIKey("api_key_goes_here");

// Access available endpoints
var myXuid = await XAPI.GetMyAccountXuid();
var myMessages = await XAPI.GetMyMessages();
var myConversations = await XAPI.GetMyConversations();

var presence = await XAPI.GetPresenceFromXuid("xuid");
MessageBox.Show($"XUID: {presence.XUID}\nState: {presence.State}\nLast Seen on: {presence.LastSeen.DeviceType}\nTitle Id: {presence.LastSeen.TitleId}\n TitleName: {presence.LastSeen.TitleName}\nTimeStamp: {presence.LastSeen.TimeStamp}");
```

### Availability
Available via Nuget: Not yet, in a few days when more support is developed.

### Implemented Endpoints
- GetMyAccountProfile() - Returns AccountProfile object that has all of your (api key owner) information.
- GetMyAccountXuid() - Returns AccountXuid object that has XUID and two Gamertag properties.
- GetMyMessages() - Returns a list of all available messages.
- GetMyConversations() - Returns a list of all available conversations (including the most recent message in each conversation)
- GetXuidFromGamertag(string gamertag) - Returns an AccountXuid object housing the gamertag and XUID.
- GetGamertagFromXuid(string xuid) - Returns string of gamertag.
- GetGamercardFromXuid(string xuid) - Returns all information found on a gamercard.
- GetPresenceFromXuid(string xuid) - Returns all information regarding the presence of a gamertag.

### Examples and Implementations
- XboxAPI Example Application - This project is included in this repo as a master example project.

### Libraries Utilized
- Newtonsoft.Json - JSON parsing class.  Used to parse XboxAPI calls.

### Family
XboxAPI C# Library is one of a few libraries that support XboxAPI. You can find them all here: ([github.com/xboxapi](https://github.com/xboxapi))

### Contributors
 * Cole ([@swiftyspiffy](http://twitter.com/swiftyspiffy))
 
### License
MIT License. &copy; 2016 Cole
