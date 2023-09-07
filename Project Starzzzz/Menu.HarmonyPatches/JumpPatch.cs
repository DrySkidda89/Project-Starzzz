using GorillaLocomotion;
using HarmonyLib;

namespace Menu.HarmonyPatches;

[HarmonyPatch(typeof(Player))]
[HarmonyPatch("LateUpdate", MethodType.Normal)]
internal class JumpPatch
{
	public static bool ResetSpeed;

	private static void Prefix()
	{
	}
}
