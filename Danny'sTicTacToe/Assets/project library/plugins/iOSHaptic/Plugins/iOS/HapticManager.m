#import "myManager.h"

// Converts NSString to C style string by way of copy (Mono will free it)
#define MakeStringCopy( _x_ ) ( _x_ != NULL && [_x_ isKindOfClass:[NSString class]] ) ? strdup( [_x_ UTF8String] ) : NULL

// Converts C style string to NSString
#define GetStringParam( _x_ ) ( _x_ != NULL ) ? [NSString stringWithUTF8String:_x_] : [NSString stringWithUTF8String:""]

// Converts C style string to NSString as long as it isn't empty
#define GetStringParamOrNil( _x_ ) ( _x_ != NULL && strlen( _x_ ) ) ? [NSString stringWithUTF8String:_x_] : nil

void _setupHapticGenerators()
{
    [[myManager HapticManager] SetupHapticGenerators];
}

void _prepareHapticEngine()
{
    [[myManager HapticManager] PrepareHapticEngine];
}

void _triggerImpactLight()
{
    [[myManager HapticManager] TriggerImpactLight];
}

void _triggerImpactMedium()
{
    [[myManager HapticManager] TriggerImpactMedium];
}

void _triggerImpactHeavy()
{
    [[myManager HapticManager] TriggerImpactHeavy];
}

void _triggerNotificationSuccess()
{
    [[myManager HapticManager] TriggerNotificationSuccess];
}

void _triggerNotificationWarning()
{
    [[myManager HapticManager] TriggerNotificationWarning];
}

void _triggerNotificationError()
{
    [[myManager HapticManager] TriggerNotificationError];
}

void _triggerSelectionChange()
{
    [[myManager HapticManager] TriggerSelectionChange];
}

void _releaseHapticGenerators()
{
    [[myManager HapticManager] ReleaseHapticGenerators];
}
