using BepInEx;
using GorillaLocomotion;
using HarmonyLib;

[BepInPlugin("org.ivy.gtag.gripmonke", "GripMonke", "2.1.1")]
public class Plugin : BaseUnityPlugin
{
	[HarmonyPatch(typeof(Player), "GetSlidePercentage")]
	private class slidepatch
	{
	}

	private static Harmony harmony;
}
