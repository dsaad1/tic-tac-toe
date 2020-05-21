#import "myManager.h"

void UnityPause(int pause);
void UnitySetAudioSessionActive(bool active);
UIViewController *UnityGetGLViewController();

@interface myManager()

@property(nonatomic,retain)UIImpactFeedbackGenerator *impactGenerator;
@property(nonatomic,retain)UISelectionFeedbackGenerator *selectionGenerator;
@property(nonatomic,retain)UINotificationFeedbackGenerator *notificationGenerator;

@end

@implementation myManager

+(myManager*)HapticManager
{
    static myManager *sharedSingleton;
    
    if(!sharedSingleton)
        sharedSingleton = [[myManager alloc] init];
    
    return sharedSingleton;
}

-(id)init
{
    if((self = [super init]))
    {
        [self SetupHapticGenerators];
    }
    
    return self;
}

-(void)SetupHapticGenerators
{
    _impactGenerator = [[UIImpactFeedbackGenerator alloc] initWithStyle:UIImpactFeedbackStyleLight];
    _selectionGenerator = [[UISelectionFeedbackGenerator alloc] init];
    _notificationGenerator = [[UINotificationFeedbackGenerator alloc] init];
}

-(void)PrepareHapticEngine
{
    if(_impactGenerator)
        [_impactGenerator prepare];
    
    if(_selectionGenerator)
        [_selectionGenerator prepare];
    
    if(_notificationGenerator)
        [_notificationGenerator prepare];
}

-(void)TriggerImpactLight
{
    _impactGenerator = [[UIImpactFeedbackGenerator alloc] initWithStyle:UIImpactFeedbackStyleLight];
    [_impactGenerator impactOccurred];
}

-(void)TriggerImpactMedium
{
    _impactGenerator = [[UIImpactFeedbackGenerator alloc] initWithStyle:UIImpactFeedbackStyleMedium];
    [_impactGenerator impactOccurred];
}

-(void)TriggerImpactHeavy
{
    _impactGenerator = [[UIImpactFeedbackGenerator alloc] initWithStyle:UIImpactFeedbackStyleHeavy];
    [_impactGenerator impactOccurred];
}

-(void)TriggerNotificationSuccess
{
    [_notificationGenerator notificationOccurred:UINotificationFeedbackTypeSuccess];
}

-(void)TriggerNotificationWarning
{
    [_notificationGenerator notificationOccurred:UINotificationFeedbackTypeWarning];
}

-(void)TriggerNotificationError
{
    [_notificationGenerator notificationOccurred:UINotificationFeedbackTypeError];
}

-(void)TriggerSelectionChange
{
    [_selectionGenerator selectionChanged];
}

-(void)ReleaseHapticGenerators
{
    if(_impactGenerator)
        _impactGenerator = nil;
    
    if(_notificationGenerator)
        _notificationGenerator = nil;
    
    if(_selectionGenerator)
        _selectionGenerator = nil;
}

@end
