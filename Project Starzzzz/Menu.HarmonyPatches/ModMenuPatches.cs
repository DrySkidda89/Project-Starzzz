using System.Reflection;
using HarmonyLib;

namespace Menu.HarmonyPatches;

public class ModMenuPatches
{
	private static Harmony instance;

	public const string InstanceId = "com.legoandmars.gorillatag.modmenupatch";

	public static bool IsPatched { get; private set; }

	internal static void ApplyHarmonyPatches()
	{
		if (!IsPatched)
		{
			if (instance == null)
			{
				instance = new Harmony("com.legoandmars.gorillatag.modmenupatch");
			}
			instance.PatchAll(Assembly.GetExecutingAssembly());
			IsPatched = true;
		}
	}

	internal static void RemoveHarmonyPatches()
	{
		if (instance != null && IsPatched)
		{
			instance.UnpatchSelf();
			IsPatched = false;
		}
	}
}
