#import "CBCUnityObserver.h"
#import "ChartboostCoreConsentAdapterGoogleUserMessagingPlatform-Swift.h"
#import "UserMessagingPlatform/UserMessagingPlatform.h"

NSString* const CBCGoogleUMPTAG = @"CBCGoogleUMP";

extern "C" {

    const void* _CBCGetUserMessagingPlatformAdapterDebug(int debugGeography, const char ** identifiers, int testDeviceIdentifiersSize){

        UMPDebugSettings *debugSettings = [[UMPDebugSettings alloc] init];

        NSMutableArray *testDeviceIdentifiers = [NSMutableArray new];
        if (testDeviceIdentifiersSize > 0) {
            for (int x = 0; x < testDeviceIdentifiersSize; x++)
            {
                if(strlen(identifiers[x]) > 0)
                    [testDeviceIdentifiers addObject:toNSStringOrNull(identifiers[x])];
            }
        }

        [debugSettings setTestDeviceIdentifiers:testDeviceIdentifiers];
        [[CBLUnityLoggingBridge sharedLogger] logWithTag:CBCGoogleUMPTAG log:@"Test Device Identifiers set" logLevel:CBLLogLevelVerbose];
        [debugSettings setGeography:(UMPDebugGeography)debugGeography];
        [[CBLUnityLoggingBridge sharedLogger] logWithTag:CBCGoogleUMPTAG log:[NSString stringWithFormat:@"DebugGeography set to %ld", (UMPDebugGeography)debugGeography] logLevel:CBLLogLevelVerbose];

        [CBCGoogleUserMessagingPlatformAdapter setDebugSettings:debugSettings];
        id<CBCModule> userMessagingPlatformAdapter = [[CBCGoogleUserMessagingPlatformAdapter alloc] init];
        [[CBCUnityObserver sharedObserver] storeModule:userMessagingPlatformAdapter];
        return (__bridge void*)userMessagingPlatformAdapter;
    }


    const void* _CBCGetUserMessagingPlatformAdapter(){
        [CBCGoogleUserMessagingPlatformAdapter setDebugSettings:nil];
        id<CBCModule> userMessagingPlatformAdapter = [[CBCGoogleUserMessagingPlatformAdapter alloc] init];
        [[CBCUnityObserver sharedObserver] storeModule:userMessagingPlatformAdapter];
        return (__bridge void*)userMessagingPlatformAdapter;
    }
}

