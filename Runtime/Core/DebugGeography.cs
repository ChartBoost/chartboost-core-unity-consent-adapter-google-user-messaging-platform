namespace Chartboost.Core.Google.UserMessagingPlatform
{
    /// <summary>
    /// Provides a way to test your app's behavior as though the device was located in the EEA or UK. Note that debug settings only work on test devices.
    /// </summary>
    public enum DebugGeography 
    {
       Disabled = 0,
       // Geography appears as in EEA for debug devices.
       EEA = 1,
       // Geography appears as in Not EEA for debug devices.
       NotEEA = 2
    }
}
