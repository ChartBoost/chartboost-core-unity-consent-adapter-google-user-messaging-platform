using Chartboost.Editor;
using NUnit.Framework;

namespace Chartboost.Core.Consent.GoogleUserMessagingPlatform.Tests.Editor
{
    public class VersionValidator
    {
        private const string UnityPackageManagerPackageName = "com.chartboost.core.consent.google-user-messaging-platform";
        private const string NuGetPackageName = "Chartboost.CSharp.Core.Unity.Consent.GoogleUserMessagingPlatform";
        
        [Test]
        public void ValidateVersion() 
            => VersionCheck.ValidateVersions(UnityPackageManagerPackageName, NuGetPackageName);
    }
}
