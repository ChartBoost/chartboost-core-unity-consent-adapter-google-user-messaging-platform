# Chartboost Core - Google User Messaging Platform Adapter

The Chartboost Core - Google User Messaging Platform Adapter mediates [Google User Messaging Platform - Android](https://developers.google.com/admob/android/privacy) and [Google User Messaging Platform - iOS](https://developers.google.com/admob/ios/privacy) via the Chartboost Core SDK.

## Minimum Requirements

| Plugin | Version |
| ------ | ------ |
| Cocoapods | 1.11.3+ |
| iOS | 11.0+ |
| Xcode | 14.1+ |
| Android API | 21+ |
| Unity | 2022.3.+ |


## Integration

Chartboost Core - Google User Messaging Platform Adapter is distributed using the public [npm registry](https://www.npmjs.com/search?q=com.chartboost.core.consent.google-user-messaging-platform) as such it is compatible with the Unity Package Manager (UPM). In order to add the Chartboost Core - Google User Messaging Platform Adapter to your project, just add the following to your Unity Project's ***manifest.json*** file. The scoped registry section is required in order to fetch packages from the NpmJS registry.

```json
  "dependencies": {
    "com.chartboost.core.consent.google-user-messaging-platform": "1.2.0",
    ...
  },
  "scopedRegistries": [
    {
      "name": "NpmJS",
      "url": "https://registry.npmjs.org",
      "scopes": [
        "com.chartboost"
      ]
    }
  ]
```

## Using the public [NuGet package](https://www.nuget.org/packages/Chartboost.CSharp.Core.Unity.Consent.GoogleUserMessagingPlatform)

To add the Chartboost Core Unity SDK to your project using the NuGet package, you will first need to add the [NugetForUnity](https://github.com/GlitchEnzo/NuGetForUnity) package into your Unity Project.

This can be done by adding the following to your Unity Project's ***manifest.json***

```json
  "dependencies": {
    "com.github-glitchenzo.nugetforunity": "https://github.com/GlitchEnzo/NuGetForUnity.git?path=/src/NuGetForUnity",
    ...
  },
```

Once <code>NugetForUnity</code> is installed, search for `Chartboost.CSharp.Core.Unity.Consent.GoogleUserMessagingPlatform` in the search bar of Nuget Explorer window(Nuget -> Manage Nuget Packages).
You should be able to see the `Chartboost.CSharp.Core.Unity.Consent.GoogleUserMessagingPlatform` package. Choose the appropriate version and install.

# Usage

## Client Module
In order to use the `GoogleUserMessagingPlatformAdapter`, a client instance can be passed along with the `ChartboostCore.Initialize` call as seen in the example below:

```csharp
string chartboostApplicationIdentifier = "CHARTBOOST_APPLICATION_IDENTIFIER";

List<Module> modulesToInitialize = new List<Module>();

var googleUserMessagingPlatform = new GoogleUserMessagingPlatformAdapter();

modulesToInitialize.Add(googleUserMessagingPlatform);

SDKConfiguration sdkConfig = new SDKConfiguration(chartboostApplicationIdentifier, modulesToInitialize);

// Initialize Chartboost Core and Google User Messaging Platform.
ChartboostCore.Initialize(sdkConfig);
```

## ConsentDebugSettings

### DebugGeography

Provides a way to test your app's behavior as though the device was located in the EEA or UK. Note that debug settings only work on test devices.

```csharp
// Disabled
ConsentDebugSettings consentDebugSettings = new ConsentDebugSettings(DebugGeography.Disabled, null);

// Geography appears as in EEA for debug devices.
ConsentDebugSettings consentDebugSettings = new ConsentDebugSettings(DebugGeography.EEA, null);

// Geography appears as in Not EEA for debug devices.
ConsentDebugSettings consentDebugSettings = new ConsentDebugSettings(DebugGeography.NotEEA, null);

GoogleUserMessagingPlatformAdapter googleUserMessagingPlatform = new GoogleUserMessagingPlatformAdapter(consentDebugSettings);
```

### TestDeviceIdentifiers

Check the log output for a message containing the set device identifier, then set through this field.

```csharp
ConsentDebugSettings consentDebugSettings = new ConsentDebugSettings(DebugGeography.Disabled, new {"TEST-DEVICE-HASHED-ID"});

GoogleUserMessagingPlatformAdapter googleUserMessagingPlatform = new GoogleUserMessagingPlatformAdapter(consentDebugSettings);
```

# Chartboost - Google Utilities for AndroidManifest.xml & Info.plist
In order for the Google User Messaging Platform to initialize the `application ID` must be added to the `AndroidManifest.xml` & `Info.plist`. Chartboost provides this functionality through its dependency package for Google adapters. 

Simply click on the Editor menu: `Chartboost/Google/Configure` and set your `application ID` as needed. This configuration is shared for all Google packages possibly integrated, e.g: Google User Messaging Platform, AdMob, Google Bidding, etc.

# Contributions

We are committed to a fully transparent development process and highly appreciate any contributions. Our team regularly monitors and investigates all submissions for the inclusion in our official adapter releases.

Refer to our [CONTRIBUTING](CONTRIBUTING.md) file for more information on how to contribute.

# License

Refer to our [LICENSE](LICENSE.md) file for more information.