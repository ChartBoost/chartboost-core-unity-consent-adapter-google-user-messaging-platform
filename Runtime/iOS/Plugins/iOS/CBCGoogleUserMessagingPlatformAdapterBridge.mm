#import "CBCUnityObserver.h"
#import "ChartboostCoreConsentAdapterGoogleUserMessagingPlatform-Swift.h"
#import "UserMessagingPlatform/UserMessagingPlatform.h"


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
        [debugSettings setGeography:(UMPDebugGeography)debugGeography];

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

