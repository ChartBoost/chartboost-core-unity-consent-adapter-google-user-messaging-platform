using Chartboost.Core.Initialization;
using UnityEngine.Scripting;

namespace Chartboost.Core.Google.UserMessagingPlatform
{
    /// <summary>
    /// mediates Google User Messaging Platform via the Chartboost Core SDK.
    /// </summary>
    public sealed class GoogleUserMessagingPlatformAdapter : NativeModuleWrapper<GoogleUserMessagingPlatformAdapter>
    {
        protected override string DefaultModuleId => "google_user_messaging_platform";
        protected override string DefaultModuleVersion => "1.0.3";

        /// <inheritdoc cref="ConsentDebugSettings"/>
        public ConsentDebugSettings? DebugSettings { get; }

        [Preserve]
        public GoogleUserMessagingPlatformAdapter() 
            => DebugSettings = null;

        [Preserve]
        public GoogleUserMessagingPlatformAdapter(ConsentDebugSettings debugSettings) : base(debugSettings) 
            => DebugSettings = debugSettings;
    }
}
