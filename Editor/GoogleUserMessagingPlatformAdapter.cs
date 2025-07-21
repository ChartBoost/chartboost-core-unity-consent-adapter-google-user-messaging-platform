using System.Threading.Tasks;
using Chartboost.Core.Error;
using Chartboost.Core.Google.UserMessagingPlatform;
using Chartboost.Core.Initialization;
using Chartboost.Json;
using Chartboost.Logging;
using UnityEngine;

namespace Chartboost.Core.Consent.Google.UserMessagingPlatform.Editor
{
    /// <summary>
    /// Google User Messaging Platform Adapter Editor Class
    /// </summary>
    public class GoogleUserMessagingPlatformAdapter : Module
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void SetInstance()
        {
            if (!Application.isEditor)
                return;
            Chartboost.Core.Google.UserMessagingPlatform.GoogleUserMessagingPlatformAdapter.InstanceType = typeof(GoogleUserMessagingPlatformAdapter);
        }

        public GoogleUserMessagingPlatformAdapter()
        {
            ModuleId = null;
            ModuleVersion = null;
        }

        public GoogleUserMessagingPlatformAdapter(ConsentDebugSettings debugSettings)
        {
            LogController.Log($"Creating Google User Messaging Platform Adapter, with Debug Settings: {JsonTools.SerializeObject(debugSettings)}", LogLevel.Verbose);
            ModuleId = null;
            ModuleVersion = null;
        }

        public override string ModuleId { get; }
        public override string ModuleVersion { get; }
        protected override Task<ChartboostCoreError?> Initialize(ModuleConfiguration configuration)
            => Task.FromResult<ChartboostCoreError?>(new ChartboostCoreError(999, "Google User Messaging Platform Adapter cannot be initialized on the Editor environment"));
    }
}