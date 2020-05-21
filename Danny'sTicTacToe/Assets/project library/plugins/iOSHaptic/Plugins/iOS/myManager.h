#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

@interface myManager : NSObject

+(myManager*)HapticManager;

-(void)SetupHapticGenerators;
-(void)PrepareHapticEngine;
-(void)TriggerImpactLight;
-(void)TriggerImpactMedium;
-(void)TriggerImpactHeavy;
-(void)TriggerNotificationSuccess;
-(void)TriggerNotificationWarning;
-(void)TriggerNotificationError;
-(void)TriggerSelectionChange;
-(void)ReleaseHapticGenerators;

@end
