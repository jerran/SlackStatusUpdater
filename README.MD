# SlackStatusUpdater
## Project description

A lightweight Windows application that runs in the system tray for automatically updating your status on Slack messaging app based on the wifi network you're
connected to.

### Features
* User friendly installation, configuration and usage
* Runs in the background, UI accessible from the system tray
* Quicksave current Slack status as a profile for current wifi connection
* Set custom statuses for any number of wifis
* Set default status to be used for unknown wifis
* Can be set to autostart when Windows starts

### Quick Start Guide

1. Request permission for generating a Slack Legacy API Token from your slack admin [here](https://api.slack.com/custom-integrations/legacy-tokens).
2. Once slackbot tells you permission has been granted, generate the token on the [same page](https://api.slack.com/custom-integrations/legacy-tokens).
3. Copy & paste your Legacy API Token to SlackStatusUpdater settings window
4. Create wifi profiles to automate your status updates

### Prerequisites

#### For usage

* Windows OS
* .NET framework 4.5.2 or newer
* Slack Legacy API Token

#### For development

* .NET SDK 4.5.2 or newer

#### For installer compilation

* Inno Setup 5.6.1 or newer

## Built With
* [RestSharp](http://restsharp.org/) – A simple REST and HTTP Client for .NET
* [ManagedWifi](https://archive.codeplex.com/?p=managedwifi) – A .NET managed wrapper around the Windows Native Wifi API.
* [Json.NET](https://www.newtonsoft.com/json) - Popular high-performance JSON framework for .NET

## Authors

* Jerri Rantio - [jerran](https://github.com/jerran)

## License
This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details.

The licenses of the 3rd party libraries used in this project are listed in [3RD-PARTY-LICENSES.md](3RD-PARTY-LICENSES.md).