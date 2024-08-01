using System;
using System.Runtime.InteropServices;
using Chartboost.Constants;
using Chartboost.Core.iOS;
using Chartboost.Core.iOS.Modules;
using UnityEngine;
using UnityEngine.Scripting;

namespace Chartboost.Core.Google.UserMessagingPlatform.iOS
{
    internal sealed class GoogleUserMessagingPlatformAdapter : NativeModule
    {
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

        private static IntPtr CreateInstance() => _CBCGetUserMessagingPlatformAdapter();

        private static IntPtr CreateInstance(ConsentDebugSettings debugSettings)
        {
            var identifiers = debugSettings.TestDeviceIdentifiers ?? new string [] { };
            return _CBCGetUserMessagingPlatformAdapterDebug((int)debugSettings.DebugGeography, identifiers, identifiers.Length);
        }
        
        [DllImport(SharedIOSConstants.DLLImport)] private static extern IntPtr _CBCGetUserMessagingPlatformAdapter();
        [DllImport(SharedIOSConstants.DLLImport)] private static extern IntPtr _CBCGetUserMessagingPlatformAdapterDebug(int debugGeography, string[] identifiers, int identifiersCount);
    }
}
