using System.ComponentModel;
using System.IO;
using BepInEx;
using BepInEx.Configuration;
using Menu.HarmonyPatches;
using UnityEngine;
using Utilla;

namespace MenuLibs;

[Description("HauntedModMenu")]
[BepInPlugin("org.legoandmars.gorillatag.modmenupatch", "ShibaGT Mod Menu-X", "1.0.0")]
[BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
[ModdedGamemode]
public class ModMenuPatch : BaseUnityPlugin
{
	public static bool allowSpaceMonke;

	public static ConfigEntry<float> multiplier;

	public static ConfigEntry<float> speedMultiplier;

	public static ConfigEntry<float> jumpMultiplier;

	public static ConfigEntry<bool> RandomColor;

	public static ConfigEntry<float> CycleSpeed;

	public static ConfigEntry<float> GlowAmount;

	public static ConfigEntry<float> sp;

	public static ConfigEntry<float> dp;

	public static ConfigEntry<float> ms;

	public static ConfigEntry<Color> rc;

	internal static object randomColor;

	internal static object glowAmount;

	private void OnEnable()
	{
		ModMenuPatches.ApplyHarmonyPatches();
		ConfigFile configFile = new ConfigFile(Path.Combine(Paths.ConfigPath, "ModMonkeyPatch.cfg"), saveOnInit: true);
		speedMultiplier = configFile.Bind("Configuration", "SpeedMultiplier", 100f, "How much to multiply the speed. 10 = 10x higher jumps");
		jumpMultiplier = configFile.Bind("Configuration", "JumpMultiplier", 1.5f, "How much to multiply the jump height/distance by. 10 = 10x higher jumps");
		RandomColor = configFile.Bind("rgb_monke", "RandomColor", defaultValue: false, "Whether to cycle through colours of rainbow or choose random colors");
		CycleSpeed = configFile.Bind("rgb_monke", "CycleSpeed", 0.004f, "The speed the color cycles at each frame (1=Full colour cycle). If random colour is enabled, this is the time in seconds before switching color");
		GlowAmount = configFile.Bind("rgb_monke", "GlowAmount", 1f, "The brightness of your monkey. The higher the value, the more emissive your monkey is");
		sp = configFile.Bind("Configuration", "Spring", 10f, "spring");
		dp = configFile.Bind("Configuration", "Damper", 30f, "damper");
		ms = configFile.Bind("Configuration", "MassScale", 12f, "massscale");
		rc = configFile.Bind("Configuration", "webColor", Color.white, "webcolor hex code");
	}

	private void OnDisable()
	{
		ModMenuPatches.RemoveHarmonyPatches();
	}

	[ModdedGamemodeJoin]
	private void RoomJoined()
	{
		allowSpaceMonke = true;
	}

	[ModdedGamemodeLeave]
	private void RoomLeft()
	{
		allowSpaceMonke = true;
	}

	static ModMenuPatch()
	{
		allowSpaceMonke = true;
	}
}
