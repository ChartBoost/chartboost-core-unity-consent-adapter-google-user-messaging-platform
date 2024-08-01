namespace Chartboost.Core.Google.UserMessagingPlatform
{
    /// <summary>
    /// Utilized for testing Google User Messaging Platform.
    /// </summary>
    public struct ConsentDebugSettings
    {
        /// <summary>
        /// Provides a way to test your app's behavior as though the device was located in the EEA or UK. Note that debug settings only work on test devices.
        /// </summary>
        public readonly DebugGeography DebugGeography;

        /// <summary>
        /// Check the log output for a message containing the set device identifier, then set through this field.
        /// </summary>
        public readonly string[] TestDeviceIdentifiers;

        public ConsentDebugSettings(DebugGeography debugGeography, string[] testDeviceIdentifiers)
        {
            DebugGeography = debugGeography;
            TestDeviceIdentifiers = testDeviceIdentifiers;
        }
    }
}
