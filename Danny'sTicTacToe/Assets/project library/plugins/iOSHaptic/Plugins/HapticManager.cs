using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public class HapticManager {

	#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern void _setupHapticGenerators();
	#endif

	public static void SetupHapticGenerators()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		_setupHapticGenerators();
		#endif
	}

	#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern void _prepareHapticEngine();
	#endif

	public static void PrepareHapticEngine()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		_prepareHapticEngine();
		#endif
	}

	#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern void _triggerImpactLight();
	#endif

	public static void TriggerImpactLight()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		_triggerImpactLight();
		#endif
	}

	#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern void _triggerImpactMedium();
	#endif

	public static void TriggerImpactMedium()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		_triggerImpactMedium();
		#endif
	}

	#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern void _triggerImpactHeavy();
	#endif

	public static void TriggerImpactHeavy()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		_triggerImpactHeavy();
		#endif
	}

	#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern void _triggerNotificationSuccess();
	#endif

	public static void TriggerNotificationSuccess()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		_triggerNotificationSuccess();
		#endif
	}

	#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern void _triggerNotificationWarning();
	#endif

	public static void TriggerNotificationWarning()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		_triggerNotificationWarning();
		#endif
	}

	#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern void _triggerNotificationError();
	#endif

	public static void TriggerNotificationError()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		_triggerNotificationError();
		#endif
	}

	#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern void _triggerSelectionChange();
	#endif

	public static void TriggerSelectionChange()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		_triggerSelectionChange();
		#endif
	}

	#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern void _releaseHapticGenerators();
	#endif

	public static void ReleaseHapticGenerators()
	{
		#if UNITY_IOS && !UNITY_EDITOR
		_releaseHapticGenerators();
		#endif
	}
}
