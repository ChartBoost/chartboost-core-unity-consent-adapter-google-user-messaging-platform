using Chartboost.Core.Android.Modules;
using UnityEngine;
using UnityEngine.Scripting;

namespace Chartboost.Core.Google.UserMessagingPlatform.Android
{
    internal sealed class GoogleUserMessagingPlatformAdapter : NativeModule
    {
        // ReSharper disable InconsistentNaming
        private const string ClassGoogleUserMessagingPlatform = "com.chartboost.core.consent.googleusermessagingplatform.GoogleUserMessagingPlatformAdapter";
        private const string ClassConsentDebugSettings = "com.google.android.ump.ConsentDebugSettings";
        private static readonly string ClassConsentDebugSettingsBuilder = $"{ClassConsentDebugSettings}$Builder";
        private const string FunSetDebugGeography = "setDebugGeography";
        private const string FunAddTestDeviceHashedId = "addTestDeviceHashedId";
        private const string FunBuild = "build";
        // ReSharper restore InconsistentNaming
        
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void SetInstance()
        {
            if (Application.isEditor)
                return;
            UserMessagingPlatform.GoogleUserMessagingPlatformAdapter.InstanceType = typeof(GoogleUserMessagingPlatformAdapter);
        }
        
        [Preserve]
        public GoogleUserMessagingPlatformAdapter() : base(CreateInstance()) { }

        [Preserve]
        public GoogleUserMessagingPlatformAdapter(ConsentDebugSettings debugSettings) : base(CreateInstance(debugSettings)) { }

        private static AndroidJavaObject CreateInstance() 
            => new(ClassGoogleUserMessagingPlatform);

        private static AndroidJavaObject CreateInstance(ConsentDebugSettings debugSettings)
        {
            using var debugSettingsBuilder = new AndroidJavaObject(ClassConsentDebugSettingsBuilder);
            debugSettingsBuilder.Call(FunSetDebugGeography, (int)debugSettings.DebugGeography);
            
            if (debugSettings.TestDeviceIdentifiers is { Length: > 0 })
                foreach (var testDeviceIdentifier in debugSettings.TestDeviceIdentifiers)
                    debugSettingsBuilder.Call(FunAddTestDeviceHashedId, testDeviceIdentifier);

            using var nativeDebugSettings = debugSettingsBuilder.Call<AndroidJavaObject>(FunBuild);
            return new AndroidJavaObject(ClassGoogleUserMessagingPlatform, nativeDebugSettings);
        }
    }
}
