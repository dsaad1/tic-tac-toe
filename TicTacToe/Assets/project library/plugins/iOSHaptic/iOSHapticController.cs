using UnityEngine;
using System.Collections;

public class iOSHapticController : MonoBehaviour {

	public static iOSHapticController instance = null;

	void Awake()
	{
		if(instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		} else if (instance != this)
		{
			Destroy(gameObject);
		}
	}

	public void SetupHapticGenerators()
	{
		HapticManager.SetupHapticGenerators();
	}

	public void PrepareHapticEngine()
	{
		HapticManager.PrepareHapticEngine();
	}

	public void TriggerImpactLight()
	{
        if(GameSettings.self.UseHaptics())
		    HapticManager.TriggerImpactLight();
	}

	public void TriggerImpactMedium()
	{
        if (GameSettings.self.UseHaptics())
            HapticManager.TriggerImpactMedium();
	}

	public void TriggerImpactHeavy()
	{
        if (GameSettings.self.UseHaptics())
            HapticManager.TriggerImpactHeavy();
	}

	public void TriggerNotificationSuccess()
	{
        if (GameSettings.self.UseHaptics())
            HapticManager.TriggerNotificationSuccess();
	}

	public void TriggerNotificationWarning()
	{
        if (GameSettings.self.UseHaptics())
            HapticManager.TriggerNotificationWarning();
	}

	public void TriggerNotificationError()
	{
        if (GameSettings.self.UseHaptics())
            HapticManager.TriggerNotificationError();
	}

	public void TriggerSelectionChange()
	{
        if (GameSettings.self.UseHaptics())
            HapticManager.TriggerSelectionChange();
	}

	public void ReleaseHapticGenerators()
	{
		HapticManager.ReleaseHapticGenerators();
	}
}
