using System;
using System.Collections.Generic;
using System.IO;
using BepInEx.Configuration;
using ExitGames.Client.Photon;
using GorillaLocomotion;
using HarmonyLib;
using MenuLibs;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

namespace Menu.HarmonyPatches;

[HarmonyPatch(typeof(GorillaLocomotion.Player))]
[HarmonyPatch("LateUpdate", MethodType.Normal)]
internal class GTAGMenu
{
	public enum PhotonEventCodes
	{
		left_jump_photoncode = 69,
		right_jump_photoncode,
		left_jump_deletion,
		right_jump_deletion
	}

	public class TimedBehaviour : MonoBehaviour
	{
		[HarmonyPatch(typeof(GorillaLocomotion.Player), "GetSlidePercentage")]
		private class slidepatch
		{
			private static void Postfix(ref float __result)
			{
				if (buttonsActive3[4] == true)
				{
					__result = 0f;
				}
			}
		}

		public bool complete;

		public bool loop = true;

		public float progress;

		protected bool paused;

		protected float startTime;

		protected float duration = 2f;

		public virtual void Start()
		{
			startTime = Time.time;
		}

		public virtual void Update()
		{
			if (complete)
			{
				return;
			}
			progress = Mathf.Clamp((Time.time - startTime) / duration, 0f, 1f);
			if (Time.time - startTime > duration)
			{
				if (loop)
				{
					OnLoop();
				}
				else
				{
					complete = true;
				}
			}
		}

		public virtual void OnLoop()
		{
			startTime = Time.time;
		}
	}

	public class ColorChanger : TimedBehaviour
	{
		public Renderer gameObjectRenderer;

		public Gradient colors;

		public Color color;

		public bool timeBased = true;

		public override void Start()
		{
			base.Start();
			gameObjectRenderer = GetComponent<Renderer>();
		}

		public override void Update()
		{
			base.Update();
			if (colors != null)
			{
				if (timeBased)
				{
					color = colors.Evaluate(progress);
				}
				gameObjectRenderer.material.SetColor("_Color", color);
				gameObjectRenderer.material.SetColor("_EmissionColor", color);
			}
		}
	}

	public static bool ResetSpeed;

	private static string[] buttons;

	private static bool?[] buttonsActive;

	private static bool gripDown;

	private static bool grip;

	private static GameObject menu;

	private static GameObject canvasObj;

	private static GameObject reference;

	public static int framePressCooldown;

	private static GameObject pointer;

	private static bool gravityToggled;

	private static bool flying;

	private static int btnCooldown;

	private static int speedPlusCooldown;

	private static int speedMinusCooldown;

	private static float? maxJumpSpeed;

	private static float? jumpMultiplier;

	private static Vector3? leftHandOffsetInitial;

	private static Vector3? rightHandOffsetInitial;

	private static float? maxArmLengthInitial;

	private static Color color;

	private static float updateTimer;

	private static float updateRate;

	private static float timer;

	private static float hue;

	private static Harmony harmony;

	private static Vector3 scale;

	private static bool gripDown_left;

	private static bool gripDown_right;

	private static bool once_left;

	private static bool once_right;

	private static bool once_left_false;

	private static bool once_right_false;

	private static bool once_networking;

	private static GameObject[] jump_left_network;

	private static GameObject[] jump_right_network;

	private static GameObject jump_left_local;

	private static GameObject jump_right_local;

	private static bool flag2;

	private static bool flag1;

	public static float triggerpressed;

	public static float lefttriggerpressed;

	public static bool cangrapple;

	public static bool canleftgrapple;

	public static bool wackstart;

	public static bool start;

	public static bool inAllowedRoom;

	public static float maxDistance;

	public static float Spring;

	public static float Damper;

	public static float MassScale;

	public static Vector3 grapplePoint;

	public static Vector3 leftgrapplePoint;

	public static SpringJoint joint;

	public static SpringJoint leftjoint;

	public static LineRenderer lr;

	public static LineRenderer leftlr;

	public static Color grapplecolor;

	private static bool ghostToggled;

	private static bool up;

	private static bool down;

	private static bool trigger;

	private static float myVarY1;

	private static float myVarY2;

	private static bool fastr;

	private static float timeSinceLastChange;

	private static bool reset;

	private static float gainSpeed;

	private static bool gain;

	private static bool less;

	private static string[] buttons2;

	private static bool?[] buttonsActive2;

	private static bool page;

	private static bool dont;

	private static int x;

	private static int y;

	private static GameObject C4;

	private static float BoomGrip;

	private static float SpawnGrip;

	private static bool spawned;

	private static GameObject dagger;

	public static int currentPage;

	private static bool verified;

	private static int pbtnCooldown;

	private static float m;

	private static bool inRoom;

	private static GameObject katanae;

	private static float? jumpMultiplierxd;

	private static object index;

	public static int BlueMaterial;

	public static int TransparentMaterial;

	public static int LavaMaterial;

	public static int RockMaterial;

	public static int DefaultMaterial;

	public static int NeonRed;

	public static int RedTransparent;

	public static int self;

	private static bool noClipDisabledOneshot;

	private static bool noClipEnabledAtLeastOnce;

	public static bool modmenupatch;

	private static bool once_networkingd;

	private static GameObject pointerthing;

	private static GameObject[] kunai_network;

	private static GameObject[] knife_network;

	private static Vector3? checkpointPos;

	private static bool checkpointTeleportAntiRepeat;

	private bool onceEnabled;

	private bool onceDisabled;

	private static int layers;

	private static Vector3 head_direction;

	private static Vector3 roll_direction;

	private static Vector2 left_joystick;

	private static float acceleration;

	private static float maxs;

	private static float distance;

	private static float multiplier;

	private static float speed;

	private static bool Start;

	private static GradientColorKey[] colorKeys;

	private static bool speed1;

	private static bool canGrapple;

	public bool hauntedModMenuEnabled = true;

	private static bool canPull;

	public static Vector3 grappleDirection;

	public static Color grapplecolor2;

	private static bool checkedProps;

	private static bool teleportGunAntiRepeat;

	private static bool foundPlayer;

	public static bool umbrellaOpened;

	public static bool canFreeze;

	public static Vector3 lastVel;

	public static Vector3 lastAngVel;

	private static string[] buttons3;

	private static bool?[] buttonsActive3;

	public static int page2;

	private static bool antiRepeat;

	private static bool modEnabled;

	private static bool passThrough;

	private static bool inPrivate;

	private static bool netOffDocumented;

	private static bool netOff;

	private static bool netOffKey;

	private static Vector3 recordedPos;

	private static GameObject TreeRoom;

	private static GameObject Forest1;

	private static GameObject Forest2;

	private static GameObject Caves;

	private static GameObject Canyons;

	private static GameObject City1;

	private static GameObject City2;

	private static GameObject City3;

	private static GameObject City4;

	private static GameObject Mountain1;

	private static GameObject Mountain2;

	private static GameObject NetworkingTrigger;

	private static GameObject QuitBox;

	public static bool isModEnabled;

	private static GameObject banana;

	private static Vector3 gravityWas;

	private static float dist;

	private static Vector3 vel;

	private static Vector3 normal;

	private static float maxD;

	private static bool DoOnce;

	private static ConfigEntry<float> max;

	private static bool LeftClose;

	public int codedbyshibagt;

	public int dontstealmymenu;

	public int itsmineSHlBAsmenuplsnosteal;

	public static Color theme;

	public static Color btntheme;

	public static Color btnthemeactivated;

	public static int themenumber;

	private static string[] buttons4;

	private static bool?[] buttonsActive4;

	private static string[] PBBVNames;

	public static float num;

	public static float num2;

	private static bool Thumb1;

	private static bool Thumb2;

	private static Rigidbody rig;

	public static Rigidbody RB;

	public static Transform headTransform;

	private static Vector3 scalesmall;

	private static Vector3 scalebig;

	private static readonly string[] lastCosmetics;

	private static bool firstHide;

	private static Coroutine GetText;

	private static Coroutine wait1;

	private static string[] buttons5;

	private static bool?[] buttonsActive5;

	private static bool nodestroy;

	private static string[] buttons6;

	private static bool?[] buttonsActive6;

	private static string[] buttons7;

	private static bool?[] buttonsActive7;

	public static bool INFPLATS;

	private static GameObject[] jump_left_network2;

	private static GameObject[] jump_right_network2;

	private static GameObject jump_left_local2;

	private static GameObject jump_right_local2;

	public static bool transparenttheme;

	private static float timeS;

	private static float timeF;

	private static float bomb;

	private static float fast1;

	private static float fast2;

	private static float fast3;

	private static float bigScale;

	private static int timmer;

	private static bool flipped;

	public static List<Vector3> positions;

	private static float RewindHelp;

	private static bool gripDownR;

	public static string name;

	public static bool katanaduped;

	private static string[] buttons8;

	private static bool?[] buttonsActive8;

	private static bool dash;

	private static string[] buttons9;

	private static bool?[] buttonsActive9;

	private static bool clipped;

	private static bool righthand;

	public static List<Vector3> Macro;

	private static float MacroHelp;

	public static bool toggleplats;

	private static bool gripDownright;

	private static string[] buttonsban;

	private static bool?[] buttonsActiveban;

	private static string[] buttons10;

	private static bool?[] buttonsActive10;

	private static bool Jetpack;

	private static XRNode rNode;

	private static XRNode lNode;

	private static Transform rHandT;

	private static Transform lHandT;

	private static float thrust;

	private static float maxSpeed;

	private static GameObject quitBox;

	private static Transform quitBoxT;

	private static string[] buttons11;

	private static bool?[] buttonsActive11;

	public static int openmenubutton;

	public static bool rgbtheme;

	private static float Teletime;

	public static float minlag;

	public static float maxlag;

	public static Color purple => new Color(0.7f, 0f, 0.9f, 1f);

	private static void Prefix()
	{
		_ = ModMenuPatch.allowSpaceMonke;
		try
		{
			if (btnCooldown > 0 && Time.frameCount > btnCooldown)
			{
				btnCooldown = 0;
				buttonsActive2[7] = false;
				buttonsActive2[8] = false;
				buttonsActive[8] = false;
				buttonsActive3[7] = false;
				buttonsActive4[7] = false;
				buttonsActive4[8] = false;
				buttonsActive3[8] = false;
				buttonsActive5[7] = false;
				buttonsActive5[8] = false;
				buttonsActive6[7] = false;
				buttonsActive6[8] = false;
				buttonsActive7[7] = false;
				buttonsActive7[8] = false;
				buttonsActive8[7] = false;
				buttonsActive8[8] = false;
				buttonsActive9[7] = false;
				buttonsActive9[8] = false;
				buttonsActive10[7] = false;
				buttonsActive10[8] = false;
				buttonsActive11[7] = false;
				UnityEngine.Object.Destroy(menu);
				menu = null;
				if (page2 == 0)
				{
					Draw();
				}
				if (page2 == 1)
				{
					Draw2();
				}
				if (page2 == 2)
				{
					Draw3();
				}
				if (page2 == 3)
				{
					Draw4();
				}
				if (page2 == 4)
				{
					Draw5();
				}
				if (page2 == 5)
				{
					Draw6();
				}
				if (page2 == 6)
				{
					Draw7();
				}
				if (page2 == 7)
				{
					Draw8();
				}
				if (page2 == 8)
				{
					Draw9();
				}
				if (page2 == 9)
				{
					Draw10();
				}
				if (page2 == 10)
				{
					Draw11();
				}
				if (page2 == 99)
				{
					Drawban();
				}
			}
			if (buttonsActive[8] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2++;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw2();
			}
			if (buttonsActive2[7] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2--;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw();
			}
			if (buttonsActive9[7] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2--;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw8();
			}
			if (buttonsActive9[8] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2++;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw10();
			}
			if (buttonsActive10[7] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2--;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw9();
			}
			if (buttonsActive8[7] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2--;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw7();
			}
			if (buttonsActive8[8] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2++;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw9();
			}
			if (buttonsActiveban[1] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2 = 8;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw9();
			}
			if (buttonsActive2[8] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2++;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw3();
			}
			if (buttonsActive5[8] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2++;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw6();
			}
			if (buttonsActive6[7] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2--;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw5();
			}
			if (buttonsActive3[7] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2--;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw2();
			}
			if (buttonsActive5[7] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2--;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw4();
			}
			if (buttonsActive3[8] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2++;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw4();
			}
			if (buttonsActive10[8] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2++;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw11();
			}
			if (buttonsActive11[7] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2--;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw10();
			}
			if (buttonsActive4[8] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2++;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw5();
			}
			if (buttonsActive6[8] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2++;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw7();
			}
			if (buttonsActive7[8] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2++;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw8();
			}
			if (buttonsActive4[7] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2--;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw3();
			}
			if (buttonsActive7[7] == true)
			{
				if (btnCooldown == 0)
				{
					btnCooldown = Time.frameCount + 1;
					page2--;
				}
				UnityEngine.Object.Destroy(menu);
				menu = null;
				Draw6();
			}
			if (!maxJumpSpeed.HasValue)
			{
				maxJumpSpeed = GorillaLocomotion.Player.Instance.maxJumpSpeed;
			}
			if (!jumpMultiplier.HasValue)
			{
				jumpMultiplier = GorillaLocomotion.Player.Instance.jumpMultiplier;
			}
			if (!maxArmLengthInitial.HasValue)
			{
				maxArmLengthInitial = GorillaLocomotion.Player.Instance.maxArmLength;
				leftHandOffsetInitial = GorillaLocomotion.Player.Instance.leftHandOffset;
				rightHandOffsetInitial = GorillaLocomotion.Player.Instance.rightHandOffset;
			}
			if (RewindHelp > 0f && (float)Time.frameCount > RewindHelp)
			{
				RewindHelp = 0f;
			}
			if (MacroHelp > 0f && (float)Time.frameCount > MacroHelp)
			{
				MacroHelp = 0f;
			}
			if (Teletime > 0f && (float)Time.frameCount > Teletime)
			{
				Teletime = 0f;
			}
			GameObject gameObject = GameObject.Find("Shoulder Camera");
			if (gameObject != null)
			{
				gameObject.GetComponent<Camera>();
			}
			List<InputDevice> list = new List<InputDevice>();
			InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, list);
			list[0].TryGetFeatureValue(CommonUsages.secondaryButton, out gripDown);
			InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
			list[0].TryGetFeatureValue(CommonUsages.secondaryButton, out gripDownright);
			InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
			list[0].TryGetFeatureValue(CommonUsages.trigger, out SpawnGrip);
			InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, list);
			list[0].TryGetFeatureValue(CommonUsages.gripButton, out gripDownR);
			InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
			list[0].TryGetFeatureValue(CommonUsages.grip, out BoomGrip);
			list[0].TryGetFeatureValue(CommonUsages.gripButton, out gain);
			list[0].TryGetFeatureValue(CommonUsages.triggerButton, out less);
			list[0].TryGetFeatureValue(CommonUsages.primaryButton, out reset);
			list[0].TryGetFeatureValue(CommonUsages.secondaryButton, out fastr);
			if (gripDown && menu == null && !righthand)
			{
				if (page2 == 0)
				{
					Draw();
				}
				if (page2 == 1)
				{
					Draw2();
				}
				if (page2 == 2)
				{
					Draw3();
				}
				if (page2 == 3)
				{
					Draw4();
				}
				if (page2 == 4)
				{
					Draw5();
				}
				if (page2 == 5)
				{
					Draw6();
				}
				if (page2 == 6)
				{
					Draw7();
				}
				if (page2 == 7)
				{
					Draw8();
				}
				if (page2 == 8)
				{
					Draw9();
				}
				if (page2 == 9)
				{
					Draw10();
				}
				if (page2 == 10)
				{
					Draw11();
				}
				if (page2 == 99)
				{
					Drawban();
				}
				if (reference == null && !righthand)
				{
					reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					UnityEngine.Object.Destroy(reference.GetComponent<MeshRenderer>());
					reference.transform.parent = GorillaLocomotion.Player.Instance.rightControllerTransform;
					reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
					reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
				}
				if (reference == null && righthand)
				{
					reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					UnityEngine.Object.Destroy(reference.GetComponent<MeshRenderer>());
					reference.transform.parent = GorillaLocomotion.Player.Instance.leftControllerTransform;
					reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
					reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
				}
			}
			if (gripDownright && menu == null && righthand)
			{
				if (page2 == 0)
				{
					Draw();
				}
				if (page2 == 1)
				{
					Draw2();
				}
				if (page2 == 2)
				{
					Draw3();
				}
				if (page2 == 3)
				{
					Draw4();
				}
				if (page2 == 4)
				{
					Draw5();
				}
				if (page2 == 5)
				{
					Draw6();
				}
				if (page2 == 6)
				{
					Draw7();
				}
				if (page2 == 7)
				{
					Draw8();
				}
				if (page2 == 8)
				{
					Draw9();
				}
				if (page2 == 9)
				{
					Draw10();
				}
				if (page2 == 10)
				{
					Draw11();
				}
				if (page2 == 99)
				{
					Drawban();
				}
				if (reference == null && !righthand)
				{
					reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					UnityEngine.Object.Destroy(reference.GetComponent<MeshRenderer>());
					reference.transform.parent = GorillaLocomotion.Player.Instance.rightControllerTransform;
					reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
					reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
				}
				if (reference == null && righthand)
				{
					reference = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					UnityEngine.Object.Destroy(reference.GetComponent<MeshRenderer>());
					reference.transform.parent = GorillaLocomotion.Player.Instance.leftControllerTransform;
					reference.transform.localPosition = new Vector3(0f, -0.1f, 0f);
					reference.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
				}
			}
			else if (!gripDown && menu != null && !nodestroy && !righthand)
			{
				UnityEngine.Object.Destroy(menu);
				menu = null;
				UnityEngine.Object.Destroy(reference);
				reference = null;
			}
			else if (!gripDownright && menu != null && !nodestroy && righthand)
			{
				UnityEngine.Object.Destroy(menu);
				menu = null;
				UnityEngine.Object.Destroy(reference);
				reference = null;
			}
			if (gripDown && menu != null && !righthand)
			{
				menu.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
				menu.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
				if (flipped)
				{
					menu.transform.RotateAround(menu.transform.position, menu.transform.forward, 180f);
				}
				else if (!flipped && !righthand)
				{
					menu.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
				}
			}
			if (gripDownright && menu != null && righthand)
			{
				menu.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
				menu.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
				if (flipped)
				{
					menu.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
				}
				else if (!flipped && righthand)
				{
					menu.transform.RotateAround(menu.transform.position, menu.transform.forward, 180f);
				}
			}
			if (buttonsActive[0] == true)
			{
				PhotonNetwork.Disconnect();
			}
			if (buttonsActive[1] == true)
			{
				PhotonNetwork.JoinRandomRoom();
			}
			if (buttonsActive[2] == true)
			{
				Application.Quit();
			}
			if (buttonsActive[3] == true)
			{
				righthand = true;
			}
			else
			{
				righthand = false;
			}
		}
		catch (Exception ex)
		{
			File.WriteAllText("shibagtmodmenuerror.log", ex.ToString());
		}
	}

	private static void ProcessPlatformMonke()
	{
		colorKeys[0].color = Color.red;
		colorKeys[0].time = 0f;
		colorKeys[1].color = Color.green;
		colorKeys[1].time = 0.3f;
		colorKeys[2].color = Color.blue;
		colorKeys[2].time = 0.6f;
		colorKeys[3].color = Color.red;
		colorKeys[3].time = 1f;
		if (!once_networking)
		{
			PhotonNetwork.NetworkingClient.EventReceived += PlatformNetwork;
			once_networking = true;
		}
		List<InputDevice> list = new List<InputDevice>();
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, list);
		list[0].TryGetFeatureValue(CommonUsages.gripButton, out gripDown_left);
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
		list[0].TryGetFeatureValue(CommonUsages.gripButton, out gripDown_right);
		if (gripDown_right)
		{
			if (!once_right && jump_right_local == null)
			{
				jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
				jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
				jump_right_local.transform.localScale = scale;
				jump_right_local.transform.position = new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
				jump_right_local.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
				object[] eventContent = new object[2]
				{
					new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position,
					GorillaLocomotion.Player.Instance.rightControllerTransform.rotation
				};
				RaiseEventOptions raiseEventOptions = new RaiseEventOptions
				{
					Receivers = ReceiverGroup.Others
				};
				PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
				once_right = true;
				once_right_false = false;
				ColorChanger colorChanger = jump_right_local.AddComponent<ColorChanger>();
				colorChanger.colors = new Gradient
				{
					colorKeys = colorKeys
				};
				colorChanger.Start();
			}
		}
		else if (!once_right_false && jump_right_local != null)
		{
			UnityEngine.Object.Destroy(jump_right_local);
			jump_right_local = null;
			once_right = false;
			once_right_false = true;
			RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
			{
				Receivers = ReceiverGroup.Others
			};
			PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
		}
		if (gripDown_left)
		{
			if (!once_left && jump_left_local == null)
			{
				jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
				jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
				jump_left_local.transform.localScale = scale;
				jump_left_local.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
				jump_left_local.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
				object[] eventContent2 = new object[2]
				{
					GorillaLocomotion.Player.Instance.leftControllerTransform.position,
					GorillaLocomotion.Player.Instance.leftControllerTransform.rotation
				};
				RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
				{
					Receivers = ReceiverGroup.Others
				};
				PhotonNetwork.RaiseEvent(69, eventContent2, raiseEventOptions3, SendOptions.SendReliable);
				once_left = true;
				once_left_false = false;
				ColorChanger colorChanger2 = jump_left_local.AddComponent<ColorChanger>();
				colorChanger2.colors = new Gradient
				{
					colorKeys = colorKeys
				};
				colorChanger2.Start();
			}
		}
		else if (!once_left_false && jump_left_local != null)
		{
			UnityEngine.Object.Destroy(jump_left_local);
			jump_left_local = null;
			once_left = false;
			once_left_false = true;
			RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
			{
				Receivers = ReceiverGroup.Others
			};
			PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
		}
		if (!PhotonNetwork.InRoom)
		{
			for (int i = 0; i < jump_right_network.Length; i++)
			{
				UnityEngine.Object.Destroy(jump_right_network[i]);
			}
			for (int j = 0; j < jump_left_network.Length; j++)
			{
				UnityEngine.Object.Destroy(jump_left_network[j]);
			}
		}
	}

	private static void PlatformNetwork(EventData eventData)
	{
		switch (eventData.Code)
		{
		case 69:
		{
			object[] array2 = (object[])eventData.CustomData;
			jump_left_network[eventData.Sender] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			jump_left_network[eventData.Sender].GetComponent<Renderer>().material.SetColor("_Color", Color.black);
			jump_left_network[eventData.Sender].transform.localScale = scale;
			jump_left_network[eventData.Sender].transform.position = (Vector3)array2[0];
			jump_left_network[eventData.Sender].transform.rotation = (Quaternion)array2[1];
			ColorChanger colorChanger2 = jump_left_network[eventData.Sender].AddComponent<ColorChanger>();
			colorChanger2.colors = new Gradient
			{
				colorKeys = colorKeys
			};
			colorChanger2.Start();
			break;
		}
		case 70:
		{
			object[] array = (object[])eventData.CustomData;
			jump_right_network[eventData.Sender] = GameObject.CreatePrimitive(PrimitiveType.Cube);
			jump_right_network[eventData.Sender].GetComponent<Renderer>().material.SetColor("_Color", Color.black);
			jump_right_network[eventData.Sender].transform.localScale = scale;
			jump_right_network[eventData.Sender].transform.position = (Vector3)array[0];
			jump_right_network[eventData.Sender].transform.rotation = (Quaternion)array[1];
			ColorChanger colorChanger = jump_left_network[eventData.Sender].AddComponent<ColorChanger>();
			colorChanger.colors = new Gradient
			{
				colorKeys = colorKeys
			};
			colorChanger.Start();
			break;
		}
		case 71:
			UnityEngine.Object.Destroy(jump_left_network[eventData.Sender]);
			jump_left_network[eventData.Sender] = null;
			break;
		case 72:
			UnityEngine.Object.Destroy(jump_right_network[eventData.Sender]);
			jump_right_network[eventData.Sender] = null;
			break;
		}
	}

	private static void ProcessNoClip()
	{
		bool value = false;
		List<InputDevice> list = new List<InputDevice>();
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
		list[0].TryGetFeatureValue(CommonUsages.triggerButton, out value);
		if (value)
		{
			if (!flag2)
			{
				MeshCollider[] array = Resources.FindObjectsOfTypeAll<MeshCollider>();
				foreach (MeshCollider meshCollider in array)
				{
					meshCollider.transform.localScale = meshCollider.transform.localScale / 10000f;
				}
				flag2 = true;
				flag1 = false;
			}
		}
		else if (!flag1)
		{
			MeshCollider[] array = Resources.FindObjectsOfTypeAll<MeshCollider>();
			foreach (MeshCollider meshCollider2 in array)
			{
				meshCollider2.transform.localScale = meshCollider2.transform.localScale * 10000f;
			}
			flag1 = true;
			flag2 = false;
		}
	}

	private static void ProcessTeleportGun()
	{
		bool value = false;
		bool value2 = false;
		List<InputDevice> list = new List<InputDevice>();
		InputDevices.GetDevices(list);
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
		list[0].TryGetFeatureValue(CommonUsages.triggerButton, out value);
		list[0].TryGetFeatureValue(CommonUsages.gripButton, out value2);
		if (!value2)
		{
			UnityEngine.Object.Destroy(pointer);
			pointer = null;
			antiRepeat = false;
			return;
		}
		Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out var hitInfo);
		if (pointer == null)
		{
			pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
			UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
			pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
		}
		pointer.transform.position = hitInfo.point;
		if (!value)
		{
			antiRepeat = false;
		}
		else if (!antiRepeat)
		{
			GorillaLocomotion.Player.Instance.transform.position = hitInfo.point;
			GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
			antiRepeat = true;
		}
	}

	private static void ProcessRGB()
	{
		updateTimer += Time.deltaTime;
		if (ModMenuPatch.RandomColor.Value)
		{
			if ((double)Time.time > (double)timer)
			{
				color = UnityEngine.Random.ColorHSV(0f, 1f, ModMenuPatch.GlowAmount.Value, ModMenuPatch.GlowAmount.Value, ModMenuPatch.GlowAmount.Value, ModMenuPatch.GlowAmount.Value);
				timer = Time.time + ModMenuPatch.CycleSpeed.Value;
			}
		}
		else
		{
			if ((double)hue >= 1.0)
			{
				hue = 0f;
			}
			hue += ModMenuPatch.CycleSpeed.Value;
			color = Color.HSVToRGB(hue, 1f * ModMenuPatch.GlowAmount.Value, 1f * ModMenuPatch.GlowAmount.Value);
		}
		if ((double)updateTimer > (double)updateRate)
		{
			updateTimer = 999f;
			GorillaTagger.Instance.UpdateColor(color.r, color.g, color.b);
					
		}
	}

	private static void AddButton(float offset, string text)
	{
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		gameObject.GetComponent<BoxCollider>().isTrigger = true;
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
		gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.29f - offset / 1.2f);
		gameObject.AddComponent<BtnCollider>().relatedText = text;
		int num = -1;
		for (int i = 0; i < buttons.Length; i++)
		{
			if (text == buttons[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive[num] == false)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btntheme);
		}
		else if (buttonsActive[num] == true)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btnthemeactivated);
		}
		else
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
		}
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text2 = gameObject2.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = text;
		text2.color = Color.white;
		text2.fontSize = 1;
		text2.alignment = TextAnchor.MiddleCenter;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component = text2.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.2f, 0.03f);
		component.localPosition = new Vector3(0.064f, 0f, 0.111f - offset / 3.05f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Draw()
	{
		menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
		UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
		menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f);
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.1f, 1f, 1.2f);
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", theme);
		if (themenumber == 7)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
		gameObject.transform.position = new Vector3(0.05f, 0f, -0.05f);
		canvasObj = new GameObject();
		canvasObj.transform.parent = menu.transform;
		Canvas canvas = canvasObj.AddComponent<Canvas>();
		CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
		canvasObj.AddComponent<GraphicRaycaster>();
		canvas.renderMode = RenderMode.WorldSpace;
		canvasScaler.dynamicPixelsPerUnit = 1000f;
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text = gameObject2.AddComponent<Text>();
		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.text = name;
		text.fontSize = 1;
		text.color = Color.yellow;
		text.alignment = TextAnchor.MiddleCenter;
		text.resizeTextForBestFit = true;
		text.resizeTextMinSize = 0;
		RectTransform component = text.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.28f, 0.05f);
		component.position = new Vector3(0.06f, 0f, 0.175f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		for (int i = 0; i < buttons.Length; i++)
		{
			AddButton((float)i * 0.13f, buttons[i]);
		}
		GameObject gameObject3 = new GameObject();
		gameObject3.transform.parent = canvasObj.transform;
		Text text2 = gameObject3.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = " ";
		text2.fontSize = 1;
		text2.color = Color.red;
		text2.alignment = TextAnchor.UpperLeft;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component2 = text2.GetComponent<RectTransform>();
		component2.localPosition = Vector3.zero;
		component2.sizeDelta = new Vector2(0.28f, 0.05f);
		component2.position = new Vector3(0.06f, -0.01f, -0.29f);
		component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		GameObject gameObject4 = new GameObject();
		gameObject4.transform.parent = canvasObj.transform;
		Text text3 = gameObject4.AddComponent<Text>();
		text3.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text3.text = " ";
		text3.fontSize = 1;
		text3.color = Color.blue;
		text3.alignment = TextAnchor.UpperLeft;
		text3.resizeTextForBestFit = true;
		text3.resizeTextMinSize = 0;
		RectTransform component3 = text3.GetComponent<RectTransform>();
		component3.localPosition = Vector3.zero;
		component3.sizeDelta = new Vector2(0.28f, 0.05f);
		component3.position = new Vector3(0.06f, -0.01f, -0.33f);
		component3.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Toggle(string relatedText)
	{
		int num = -1;
		for (int i = 0; i < buttons.Length; i++)
		{
			if (relatedText == buttons[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive[num].HasValue)
		{
			buttonsActive[num] = !buttonsActive[num];
			UnityEngine.Object.Destroy(menu);
			menu = null;
			Draw();
		}
	}

	static GTAGMenu()
	{
		ResetSpeed = false;
		buttons = new string[9] { "Disconnect", "Join Random Public", "Quit Gtag", "Right Hand", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "--Page-2-->" };
		buttonsActive = new bool?[14]
		{
			false, false, false, false, false, false, false, false, false, false,
			false, false, false, false
		};
		Teletime = 0f;
		rNode = XRNode.RightHand;
		lNode = XRNode.LeftHand;
		maxSpeed = 50f;
		rgbtheme = false;
		clipped = false;
		righthand = false;
		toggleplats = false;
		timeS = 0.4f;
		timeF = 2f;
		bomb = 50000f;
		fast1 = 15f;
		fast2 = 35f;
		fast3 = 60f;
		bigScale = 2f;
		timmer = 10;
		flipped = false;
		positions = new List<Vector3>();
		Macro = new List<Vector3>();
		MacroHelp = 0f;
		RewindHelp = 0f;
		name = "Project Starzzz";
		katanaduped = false;
		lastCosmetics = new string[3];
		firstHide = false;
		nodestroy = false;
		INFPLATS = false;
		transparenttheme = false;
		num = 75f;
		num2 = 1000f;
		dist = 100f;
		DoOnce = false;
		themenumber = 0;
		modEnabled = true;
		inPrivate = PhotonNetwork.InRoom;
		netOffDocumented = false;
		netOff = true;
		netOffKey = false;
		antiRepeat = false;
		buttons3 = new string[9] { "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "<--Page-2--", "--Page-4-->" };
		buttonsActive3 = new bool?[18]
		{
			false, false, false, false, false, false, false, false, false, false,
			false, false, false, false, false, false, false, false
		};
		buttons4 = new string[9] { "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "<--Page-3--", "--Page-5-->" };
		buttonsActive4 = new bool?[18]
		{
			false, false, false, false, false, false, false, false, false, false,
			false, false, false, false, false, false, false, false
		};
		buttons5 = new string[9] { "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "<--Page-4--", "--Page-6-->" };
		buttonsActive5 = new bool?[18]
		{
			false, false, false, false, false, false, false, false, false, false,
			false, false, false, false, false, false, false, false
		};
		buttons6 = new string[9] { "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "<--Page-5--", "--Page-7-->" };
		buttonsActive6 = new bool?[18]
		{
			false, false, false, false, false, false, false, false, false, false,
			false, false, false, false, false, false, false, false
		};
		buttons7 = new string[9] { "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "<--Page-6--", "--Page-8-->" };
		buttonsActive7 = new bool?[18]
		{
			false, false, false, false, false, false, false, false, false, false,
			false, false, false, false, false, false, false, false
		};
		buttons8 = new string[9] { "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "<--Page-7--", "--Page-9-->" };
		buttonsActive8 = new bool?[18]
		{
			false, false, false, false, false, false, false, false, false, false,
			false, false, false, false, false, false, false, false
		};
		buttons9 = new string[9] { "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "<--Page-8--", "--Page-10-->" };
		buttonsActive9 = new bool?[18]
		{
			false, false, false, false, false, false, false, false, false, false,
			false, false, false, false, false, false, false, false
		};
		buttons10 = new string[9] { "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "<--Page-9--", "--Page-11-->" };
		buttonsActive10 = new bool?[18]
		{
			false, false, false, false, false, false, false, false, false, false,
			false, false, false, false, false, false, false, false
		};
		buttons11 = new string[8] { "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "PlaceHolder", "<--Page-10--" };
		buttonsActive11 = new bool?[13]
		{
			false, false, false, false, false, false, false, false, false, false,
			false, false, false
		};
		dagger = null;
		currentPage = 0;
		verified = false;
		pbtnCooldown = 0;
		m = 100f;
		inRoom = true;
		katanae = null;
		jumpMultiplierxd = null;
		BlueMaterial = 5;
		TransparentMaterial = 6;
		LavaMaterial = 2;
		RockMaterial = 1;
		DefaultMaterial = 5;
		NeonRed = 3;
		RedTransparent = 4;
		self = 0;
		noClipDisabledOneshot = false;
		noClipEnabledAtLeastOnce = false;
		modmenupatch = true;
		pointerthing = null;
		kunai_network = new GameObject[9999];
		knife_network = new GameObject[9999];
		checkpointTeleportAntiRepeat = false;
		layers = 512;
		acceleration = 5f;
		maxs = 10f;
		distance = 0.35f;
		multiplier = 1f;
		speed = 0f;
		Start = false;
		colorKeys = new GradientColorKey[4];
		speed1 = true;
		PBBVNames = new string[123]
		{
			"932423487", "932423487", "932423487", "932423487", "932423487", "932423487", "932423487", "932423487", "932423487", "234234772",
			"234234772", "234234772", "234234772", "234234772", "234234772", "234234772", "234234772", "234234772", "PBBV", "PBBV",
			"PBBV", "PBBV", "PBBV", "PBBV", "PBBV", "PBBV", "PBBV", "PBBV", "PBBV", "PBBV",
			"PBBV", "PBBV", "IS", "IS", "IS", "IS", "IS", "IS", "IS", "IS",
			"IS", "IS", "HERE", "HERE", "HERE", "HERE", "HERE", "HERE", "HERE", "HERE",
			"HERE", "HERE", "HERE", "HERE", "HERE", "HERE", "RUN", "RUN", "RUN", "RUN",
			"RUN", "RUN", "RUN", "RUN", "RUN", "RUN", "RUN", "RUN", "HIDE", "HIDE",
			"HIDE", "HIDE", "HIDE", "HIDE", "HIDE", "HIDE", "HIDE", "HIDE", "HIDE", "HIDE",
			"I", "I", "I", "I", "I", "I", "I", "I", "I", "I",
			"I", "I", "I", "I", "AM", "AM", "AM", "AM", "AM", "AM",
			"AM", "AM", "AM", "AM", "AM", "AM", "AM", "AM", "PBBV", "PBBV",
			"PBBV", "PBBV", "PBBV", "PBBV", "PBBV", "PBBV", "PBBV", "PBBV", "PBBV", "PBBV",
			"PBBV", "PBBV", "PBBV"
		};
		checkedProps = false;
		teleportGunAntiRepeat = true;
		foundPlayer = false;
		canFreeze = false;
		canGrapple = true;
		canPull = true;
		grapplecolor2 = Color.black;
		spawned = false;
		C4 = null;
		x = 0;
		y = 0;
		buttons2 = new string[9] { "Fly [D]", "Turn Off Tag Freeze", "TP Gun [D?]", "NoClip [D]", "Checkpoint [D]", "Invis Platforms", "Sticky Platforms", "<--Page-1--", "--Page-3-->" };
		buttonsActive2 = new bool?[23]
		{
			false, false, false, false, false, false, false, false, false, false,
			false, false, false, false, false, false, false, false, false, false,
			false, false, false
		};
		buttonsban = new string[2] { "Yes im sure, Enable Rig Spammer", "No go back." };
		buttonsActiveban = new bool?[10] { false, false, false, false, false, false, false, false, false, false };
		grip = false;
		menu = null;
		canvasObj = null;
		reference = null;
		framePressCooldown = 0;
		pointer = null;
		gravityToggled = false;
		flying = false;
		btnCooldown = 0;
		speedPlusCooldown = 0;
		speedMinusCooldown = 0;
		maxJumpSpeed = null;
		jumpMultiplier = null;
		leftHandOffsetInitial = null;
		rightHandOffsetInitial = null;
		maxArmLengthInitial = null;
		color = new Color(0f, 0f, 0f);
		page = false;
		dont = false;
		ghostToggled = false;
		myVarY1 = 0f;
		myVarY2 = 0f;
		fastr = false;
		timeSinceLastChange = 0f;
		reset = false;
		gainSpeed = 1f;
		gain = false;
		less = false;
		updateTimer = 0f;
		updateRate = 0f;
		timer = 0f;
		hue = 0f;
		scale = new Vector3(0.0125f, 0.28f, 0.3825f);
		scalesmall = new Vector3(0.01f, 0.28f, 0.379f);
		scalebig = new Vector3(0.017f, 0.28f, 0.3955f);
		jump_left_network = new GameObject[9999];
		jump_right_network = new GameObject[9999];
		jump_left_local = null;
		jump_right_local = null;
		flag2 = false;
		flag1 = true;
		cangrapple = true;
		canleftgrapple = true;
		wackstart = false;
		start = true;
		inAllowedRoom = false;
		maxDistance = 100f;
	}

	public static void ProcessCheckPoint()
	{
		List<InputDevice> list = new List<InputDevice>();
		bool value = false;
		bool value2 = false;
		bool value3 = false;
		list = new List<InputDevice>();
		InputDevices.GetDevices(list);
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
		list[0].TryGetFeatureValue(CommonUsages.triggerButton, out value);
		list[0].TryGetFeatureValue(CommonUsages.gripButton, out value2);
		list[0].TryGetFeatureValue(CommonUsages.secondaryButton, out value3);
		if (value2)
		{
			value3 = false;
			if (pointer == null)
			{
				pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
				UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
				pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
			}
			pointer.transform.position = GorillaLocomotion.Player.Instance.rightControllerTransform.position;
		}
		if (!value2 && value)
		{
			value3 = false;
			pointer.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
			buttonsActive2[3] = true;
			GorillaLocomotion.Player.Instance.transform.position = pointer.transform.position;
		}
		else if (!value)
		{
			pointer.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
			buttonsActive2[3] = false;
		}
	}

	private static void ProcessInvisPlatformMonke()
	{
		List<InputDevice> list = new List<InputDevice>();
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, list);
		list[0].TryGetFeatureValue(CommonUsages.gripButton, out gripDown_left);
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
		list[0].TryGetFeatureValue(CommonUsages.gripButton, out gripDown_right);
		if (gripDown_right)
		{
			if (!once_right && jump_right_local == null)
			{
				jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
				jump_right_local.GetComponent<Renderer>().enabled = false;
				jump_right_local.transform.localScale = scale;
				jump_right_local.transform.position = new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
				jump_right_local.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
				_ = new object[2]
				{
					new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position,
					GorillaLocomotion.Player.Instance.rightControllerTransform.rotation
				};
				once_right = true;
				once_right_false = false;
			}
		}
		else if (!once_right_false && jump_right_local != null)
		{
			UnityEngine.Object.Destroy(jump_right_local);
			jump_right_local = null;
			once_right = false;
			once_right_false = true;
		}
		if (gripDown_left)
		{
			if (!once_left && jump_left_local == null)
			{
				jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
				jump_left_local.GetComponent<Renderer>().enabled = false;
				jump_left_local.transform.localScale = scale;
				jump_left_local.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
				jump_left_local.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
				_ = new object[2]
				{
					GorillaLocomotion.Player.Instance.leftControllerTransform.position,
					GorillaLocomotion.Player.Instance.leftControllerTransform.rotation
				};
				once_left = true;
				once_left_false = false;
			}
		}
		else if (!once_left_false && jump_left_local != null)
		{
			UnityEngine.Object.Destroy(jump_left_local);
			jump_left_local = null;
			once_left = false;
			once_left_false = true;
		}
		if (!PhotonNetwork.InRoom)
		{
			for (int i = 0; i < jump_right_network.Length; i++)
			{
				UnityEngine.Object.Destroy(jump_right_network[i]);
			}
			for (int j = 0; j < jump_left_network.Length; j++)
			{
				UnityEngine.Object.Destroy(jump_left_network[j]);
			}
		}
	}

	private static void AddButton2(float offset, string text)
	{
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		gameObject.GetComponent<BoxCollider>().isTrigger = true;
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
		gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.29f - offset / 1.2f);
		gameObject.AddComponent<BtnCollider>().relatedText = text;
		int num = -1;
		for (int i = 0; i < buttons2.Length; i++)
		{
			if (text == buttons2[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive2[num] == false)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btntheme);
		}
		else if (buttonsActive2[num] == true)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btnthemeactivated);
		}
		else
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
		}
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text2 = gameObject2.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = text;
		text2.color = Color.white;
		text2.fontSize = 1;
		text2.alignment = TextAnchor.MiddleCenter;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component = text2.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.2f, 0.03f);
		component.localPosition = new Vector3(0.064f, 0f, 0.111f - offset / 3.05f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	private static void AddButton3(float offset, string text)
	{
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		gameObject.GetComponent<BoxCollider>().isTrigger = true;
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
		gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.29f - offset / 1.2f);
		gameObject.AddComponent<BtnCollider>().relatedText = text;
		int num = -1;
		for (int i = 0; i < buttons3.Length; i++)
		{
			if (text == buttons3[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive3[num] == false)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btntheme);
		}
		else if (buttonsActive3[num] == true)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btnthemeactivated);
		}
		else
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
		}
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text2 = gameObject2.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = text;
		text2.color = Color.white;
		text2.fontSize = 1;
		text2.alignment = TextAnchor.MiddleCenter;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component = text2.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.2f, 0.03f);
		component.localPosition = new Vector3(0.064f, 0f, 0.111f - offset / 3.05f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Draw2()
	{
		menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
		UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
		menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f);
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.1f, 1f, 1.2f);
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", theme);
		if (themenumber == 7)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
		gameObject.transform.position = new Vector3(0.05f, 0f, -0.05f);
		canvasObj = new GameObject();
		canvasObj.transform.parent = menu.transform;
		Canvas canvas = canvasObj.AddComponent<Canvas>();
		CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
		canvasObj.AddComponent<GraphicRaycaster>();
		canvas.renderMode = RenderMode.WorldSpace;
		canvasScaler.dynamicPixelsPerUnit = 1000f;
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text = gameObject2.AddComponent<Text>();
		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.text = name;
		text.fontSize = 1;
		text.color = Color.yellow;
		text.alignment = TextAnchor.MiddleCenter;
		text.resizeTextForBestFit = true;
		text.resizeTextMinSize = 0;
		RectTransform component = text.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.28f, 0.05f);
		component.position = new Vector3(0.06f, 0f, 0.175f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		for (int i = 0; i < buttons2.Length; i++)
		{
			AddButton2((float)i * 0.13f, buttons2[i]);
		}
		GameObject gameObject3 = new GameObject();
		gameObject3.transform.parent = canvasObj.transform;
		Text text2 = gameObject3.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = "";
		text2.fontSize = 1;
		text2.color = Color.red;
		text2.alignment = TextAnchor.UpperLeft;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component2 = text2.GetComponent<RectTransform>();
		component2.localPosition = Vector3.zero;
		component2.sizeDelta = new Vector2(0.28f, 0.05f);
		component2.position = new Vector3(0.06f, -0.01f, -0.29f);
		component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		GameObject gameObject4 = new GameObject();
		gameObject4.transform.parent = canvasObj.transform;
		Text text3 = gameObject4.AddComponent<Text>();
		text3.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text3.text = "";
		text3.fontSize = 1;
		text3.color = Color.blue;
		text3.alignment = TextAnchor.UpperLeft;
		text3.resizeTextForBestFit = true;
		text3.resizeTextMinSize = 0;
		RectTransform component3 = text3.GetComponent<RectTransform>();
		component3.localPosition = Vector3.zero;
		component3.sizeDelta = new Vector2(0.28f, 0.05f);
		component3.position = new Vector3(0.06f, -0.01f, -0.33f);
		component3.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Draw3()
	{
		menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
		UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
		menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f);
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.1f, 1f, 1.2f);
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", theme);
		if (themenumber == 7)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
		gameObject.transform.position = new Vector3(0.05f, 0f, -0.05f);
		canvasObj = new GameObject();
		canvasObj.transform.parent = menu.transform;
		Canvas canvas = canvasObj.AddComponent<Canvas>();
		CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
		canvasObj.AddComponent<GraphicRaycaster>();
		canvas.renderMode = RenderMode.WorldSpace;
		canvasScaler.dynamicPixelsPerUnit = 1000f;
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text = gameObject2.AddComponent<Text>();
		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.text = name;
		text.fontSize = 1;
		text.color = Color.yellow;
		text.alignment = TextAnchor.MiddleCenter;
		text.resizeTextForBestFit = true;
		text.resizeTextMinSize = 0;
		RectTransform component = text.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.28f, 0.05f);
		component.position = new Vector3(0.06f, 0f, 0.175f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		for (int i = 0; i < buttons3.Length; i++)
		{
			AddButton3((float)i * 0.13f, buttons3[i]);
		}
		GameObject gameObject3 = new GameObject();
		gameObject3.transform.parent = canvasObj.transform;
		Text text2 = gameObject3.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = "";
		text2.fontSize = 1;
		text2.color = Color.red;
		text2.alignment = TextAnchor.UpperLeft;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component2 = text2.GetComponent<RectTransform>();
		component2.localPosition = Vector3.zero;
		component2.sizeDelta = new Vector2(0.28f, 0.05f);
		component2.position = new Vector3(0.06f, -0.01f, -0.29f);
		component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		GameObject gameObject4 = new GameObject();
		gameObject4.transform.parent = canvasObj.transform;
		Text text3 = gameObject4.AddComponent<Text>();
		text3.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text3.text = " ";
		text3.fontSize = 1;
		text3.color = Color.blue;
		text3.alignment = TextAnchor.UpperLeft;
		text3.resizeTextForBestFit = true;
		text3.resizeTextMinSize = 0;
		RectTransform component3 = text3.GetComponent<RectTransform>();
		component3.localPosition = Vector3.zero;
		component3.sizeDelta = new Vector2(0.28f, 0.05f);
		component3.position = new Vector3(0.06f, -0.01f, -0.33f);
		component3.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Toggle2(string relatedText)
	{
		int num = -1;
		for (int i = 0; i < buttons2.Length; i++)
		{
			if (relatedText == buttons2[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive2[num].HasValue)
		{
			buttonsActive2[num] = !buttonsActive2[num];
			UnityEngine.Object.Destroy(menu);
			menu = null;
			Draw2();
		}
	}

	public static void Toggle3(string relatedText)
	{
		int num = -1;
		for (int i = 0; i < buttons3.Length; i++)
		{
			if (relatedText == buttons3[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive3[num].HasValue)
		{
			buttonsActive3[num] = !buttonsActive3[num];
			UnityEngine.Object.Destroy(menu);
			menu = null;
			Draw3();
		}
	}

	private static void ProcessStickyPlatforms()
	{
		colorKeys[0].color = Color.red;
		colorKeys[0].time = 0f;
		colorKeys[1].color = Color.green;
		colorKeys[1].time = 0.3f;
		colorKeys[2].color = Color.blue;
		colorKeys[2].time = 0.6f;
		colorKeys[3].color = Color.red;
		colorKeys[3].time = 1f;
		if (!once_networking)
		{
			PhotonNetwork.NetworkingClient.EventReceived += PlatformNetwork;
			once_networking = true;
		}
		List<InputDevice> list = new List<InputDevice>();
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, list);
		list[0].TryGetFeatureValue(CommonUsages.gripButton, out gripDown_left);
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
		list[0].TryGetFeatureValue(CommonUsages.gripButton, out gripDown_right);
		if (gripDown_right)
		{
			if (!once_right && jump_right_local == null)
			{
				jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
				jump_right_local.transform.localScale = scale;
				jump_right_local.transform.position = new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
				jump_right_local.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
				object[] eventContent = new object[2]
				{
					new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position,
					GorillaLocomotion.Player.Instance.rightControllerTransform.rotation
				};
				RaiseEventOptions raiseEventOptions = new RaiseEventOptions
				{
					Receivers = ReceiverGroup.Others
				};
				PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
				once_right = true;
				once_right_false = false;
				ColorChanger colorChanger = jump_right_local.AddComponent<ColorChanger>();
				colorChanger.colors = new Gradient
				{
					colorKeys = colorKeys
				};
				colorChanger.Start();
			}
		}
		else if (!once_right_false && jump_right_local != null)
		{
			UnityEngine.Object.Destroy(jump_right_local);
			jump_right_local = null;
			once_right = false;
			once_right_false = true;
			RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
			{
				Receivers = ReceiverGroup.Others
			};
			PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
		}
		if (gripDown_left)
		{
			if (!once_left && jump_left_local == null)
			{
				jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Sphere);
				jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
				jump_left_local.transform.localScale = scale;
				jump_left_local.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
				jump_left_local.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
				object[] eventContent2 = new object[2]
				{
					GorillaLocomotion.Player.Instance.leftControllerTransform.position,
					GorillaLocomotion.Player.Instance.leftControllerTransform.rotation
				};
				RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
				{
					Receivers = ReceiverGroup.Others
				};
				PhotonNetwork.RaiseEvent(69, eventContent2, raiseEventOptions3, SendOptions.SendReliable);
				once_left = true;
				once_left_false = false;
				ColorChanger colorChanger2 = jump_left_local.AddComponent<ColorChanger>();
				colorChanger2.colors = new Gradient
				{
					colorKeys = colorKeys
				};
				colorChanger2.Start();
			}
		}
		else if (!once_left_false && jump_left_local != null)
		{
			UnityEngine.Object.Destroy(jump_left_local);
			jump_left_local = null;
			once_left = false;
			once_left_false = true;
			RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
			{
				Receivers = ReceiverGroup.Others
			};
			PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
		}
		if (!PhotonNetwork.InRoom)
		{
			for (int i = 0; i < jump_right_network.Length; i++)
			{
				UnityEngine.Object.Destroy(jump_right_network[i]);
			}
			for (int j = 0; j < jump_left_network.Length; j++)
			{
				UnityEngine.Object.Destroy(jump_left_network[j]);
			}
		}
	}

	public static void Draw4()
	{
		menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
		UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
		menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f);
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.1f, 1f, 1.2f);
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", theme);
		if (themenumber == 7)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
		gameObject.transform.position = new Vector3(0.05f, 0f, -0.05f);
		canvasObj = new GameObject();
		canvasObj.transform.parent = menu.transform;
		Canvas canvas = canvasObj.AddComponent<Canvas>();
		CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
		canvasObj.AddComponent<GraphicRaycaster>();
		canvas.renderMode = RenderMode.WorldSpace;
		canvasScaler.dynamicPixelsPerUnit = 1000f;
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text = gameObject2.AddComponent<Text>();
		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.text = name;
		text.fontSize = 1;
		text.color = Color.yellow;
		text.alignment = TextAnchor.MiddleCenter;
		text.resizeTextForBestFit = true;
		text.resizeTextMinSize = 0;
		RectTransform component = text.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.28f, 0.05f);
		component.position = new Vector3(0.06f, 0f, 0.175f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		for (int i = 0; i < buttons4.Length; i++)
		{
			AddButton4((float)i * 0.13f, buttons4[i]);
		}
		GameObject gameObject3 = new GameObject();
		gameObject3.transform.parent = canvasObj.transform;
		Text text2 = gameObject3.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = " ";
		text2.fontSize = 1;
		text2.color = Color.red;
		text2.alignment = TextAnchor.UpperLeft;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component2 = text2.GetComponent<RectTransform>();
		component2.localPosition = Vector3.zero;
		component2.sizeDelta = new Vector2(0.28f, 0.05f);
		component2.position = new Vector3(0.06f, -0.01f, -0.29f);
		component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		GameObject gameObject4 = new GameObject();
		gameObject4.transform.parent = canvasObj.transform;
		Text text3 = gameObject4.AddComponent<Text>();
		text3.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text3.text = " ";
		text3.fontSize = 1;
		text3.color = Color.blue;
		text3.alignment = TextAnchor.UpperLeft;
		text3.resizeTextForBestFit = true;
		text3.resizeTextMinSize = 0;
		RectTransform component3 = text3.GetComponent<RectTransform>();
		component3.localPosition = Vector3.zero;
		component3.sizeDelta = new Vector2(0.28f, 0.05f);
		component3.position = new Vector3(0.06f, -0.01f, -0.33f);
		component3.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	private static void AddButton4(float offset, string text)
	{
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		gameObject.GetComponent<BoxCollider>().isTrigger = true;
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
		gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.29f - offset / 1.2f);
		gameObject.AddComponent<BtnCollider>().relatedText = text;
		int num = -1;
		for (int i = 0; i < buttons4.Length; i++)
		{
			if (text == buttons4[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive4[num] == false)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btntheme);
		}
		else if (buttonsActive4[num] == true)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btnthemeactivated);
		}
		else
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
		}
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text2 = gameObject2.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = text;
		text2.color = Color.white;
		text2.fontSize = 1;
		text2.alignment = TextAnchor.MiddleCenter;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component = text2.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.2f, 0.03f);
		component.localPosition = new Vector3(0.064f, 0f, 0.111f - offset / 3.05f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Toggle4(string relatedText)
	{
		int num = -1;
		for (int i = 0; i < buttons4.Length; i++)
		{
			if (relatedText == buttons4[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive4[num].HasValue)
		{
			buttonsActive4[num] = !buttonsActive4[num];
			UnityEngine.Object.Destroy(menu);
			menu = null;
			Draw4();
		}
	}

	private static void ProcessXray()
	{
		if (less)
		{
			GameObject.Find("Level/forest/Uncover ForestCombined/CombinedMesh-GameObject (1)-mesh/GameObject (1)-mesh-mesh/").GetComponent<MeshRenderer>().enabled = false;
			GameObject.Find("Level/treeroom/tree/Uncover TreeAtlas/CombinedMesh-TreeAtlas-mesh/TreeAtlas-mesh-mesh/").GetComponent<MeshRenderer>().enabled = false;
			GameObject.Find("Level/forest/SmallTrees/").GetComponent<MeshRenderer>().enabled = false;
		}
		if (!less)
		{
			GameObject.Find("Level/forest/Uncover ForestCombined/CombinedMesh-GameObject (1)-mesh/GameObject (1)-mesh-mesh/").GetComponent<MeshRenderer>().enabled = true;
			GameObject.Find("Level/treeroom/tree/Uncover TreeAtlas/CombinedMesh-TreeAtlas-mesh/TreeAtlas-mesh-mesh/").GetComponent<MeshRenderer>().enabled = true;
			GameObject.Find("Level/forest/SmallTrees/").GetComponent<MeshRenderer>().enabled = true;
		}
	}

	private static void Slingshot()
	{
		List<InputDevice> list = new List<InputDevice>();
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
		list[0].TryGetFeatureValue(CommonUsages.triggerButton, out trigger);
		list[0].TryGetFeatureValue(CommonUsages.primaryButton, out Thumb1);
		list[0].TryGetFeatureValue(CommonUsages.secondaryButton, out Thumb2);
		list[0].TryGetFeatureValue(CommonUsages.gripButton, out grip);
		headTransform = GorillaLocomotion.Player.Instance.headCollider.gameObject.transform;
		RB = GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody;
		if (trigger)
		{
			GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity += GorillaLocomotion.Player.Instance.headCollider.transform.forward * Time.deltaTime * num;
		}
		if (grip && (Thumb1 || Thumb2))
		{
			rig = GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody;
			rig.AddForce(new Vector3(0f, 25f, 0f), ForceMode.Impulse);
		}
		if (Thumb2)
		{
			Thumb2 = false;
			GorillaLocomotion.Player.Instance.bodyCollider.attachedRigidbody.velocity = new Vector3(0f, 0.149f, 0f);
		}
	}

	private static void ProcessTriggerPlatformMonke()
	{
		colorKeys[0].color = Color.red;
		colorKeys[0].time = 0f;
		colorKeys[1].color = Color.green;
		colorKeys[1].time = 0.3f;
		colorKeys[2].color = Color.blue;
		colorKeys[2].time = 0.6f;
		colorKeys[3].color = Color.red;
		colorKeys[3].time = 1f;
		if (!once_networking)
		{
			PhotonNetwork.NetworkingClient.EventReceived += PlatformNetwork;
			once_networking = true;
		}
		List<InputDevice> list = new List<InputDevice>();
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, list);
		list[0].TryGetFeatureValue(CommonUsages.triggerButton, out gripDown_left);
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
		list[0].TryGetFeatureValue(CommonUsages.triggerButton, out gripDown_right);
		if (gripDown_right)
		{
			if (!once_right && jump_right_local == null)
			{
				jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
				jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
				jump_right_local.transform.localScale = scale;
				jump_right_local.transform.position = new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
				jump_right_local.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
				object[] eventContent = new object[2]
				{
					new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position,
					GorillaLocomotion.Player.Instance.rightControllerTransform.rotation
				};
				RaiseEventOptions raiseEventOptions = new RaiseEventOptions
				{
					Receivers = ReceiverGroup.Others
				};
				PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
				once_right = true;
				once_right_false = false;
				ColorChanger colorChanger = jump_right_local.AddComponent<ColorChanger>();
				colorChanger.colors = new Gradient
				{
					colorKeys = colorKeys
				};
				colorChanger.Start();
			}
		}
		else if (!once_right_false && jump_right_local != null)
		{
			UnityEngine.Object.Destroy(jump_right_local);
			jump_right_local = null;
			once_right = false;
			once_right_false = true;
			RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
			{
				Receivers = ReceiverGroup.Others
			};
			PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
		}
		if (gripDown_left)
		{
			if (!once_left && jump_left_local == null)
			{
				jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
				jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
				jump_left_local.transform.localScale = scale;
				jump_left_local.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
				jump_left_local.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
				object[] eventContent2 = new object[2]
				{
					GorillaLocomotion.Player.Instance.leftControllerTransform.position,
					GorillaLocomotion.Player.Instance.leftControllerTransform.rotation
				};
				RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
				{
					Receivers = ReceiverGroup.Others
				};
				PhotonNetwork.RaiseEvent(69, eventContent2, raiseEventOptions3, SendOptions.SendReliable);
				once_left = true;
				once_left_false = false;
				ColorChanger colorChanger2 = jump_left_local.AddComponent<ColorChanger>();
				colorChanger2.colors = new Gradient
				{
					colorKeys = colorKeys
				};
				colorChanger2.Start();
			}
		}
		else if (!once_left_false && jump_left_local != null)
		{
			UnityEngine.Object.Destroy(jump_left_local);
			jump_left_local = null;
			once_left = false;
			once_left_false = true;
			RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
			{
				Receivers = ReceiverGroup.Others
			};
			PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
		}
		if (!PhotonNetwork.InRoom)
		{
			for (int i = 0; i < jump_right_network.Length; i++)
			{
				UnityEngine.Object.Destroy(jump_right_network[i]);
			}
			for (int j = 0; j < jump_left_network.Length; j++)
			{
				UnityEngine.Object.Destroy(jump_left_network[j]);
			}
		}
	}

	private static void AddButton5(float offset, string text)
	{
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		gameObject.GetComponent<BoxCollider>().isTrigger = true;
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
		gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.29f - offset / 1.2f);
		gameObject.AddComponent<BtnCollider>().relatedText = text;
		int num = -1;
		for (int i = 0; i < buttons5.Length; i++)
		{
			if (text == buttons5[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive5[num] == false)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btntheme);
		}
		else if (buttonsActive5[num] == true)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btnthemeactivated);
		}
		else
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
		}
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text2 = gameObject2.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = text;
		text2.color = Color.white;
		text2.fontSize = 1;
		text2.alignment = TextAnchor.MiddleCenter;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component = text2.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.2f, 0.03f);
		component.localPosition = new Vector3(0.064f, 0f, 0.111f - offset / 3.05f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Draw5()
	{
		menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
		UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
		menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f);
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.1f, 1f, 1.2f);
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", theme);
		if (themenumber == 7)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
		gameObject.transform.position = new Vector3(0.05f, 0f, -0.05f);
		canvasObj = new GameObject();
		canvasObj.transform.parent = menu.transform;
		Canvas canvas = canvasObj.AddComponent<Canvas>();
		CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
		canvasObj.AddComponent<GraphicRaycaster>();
		canvas.renderMode = RenderMode.WorldSpace;
		canvasScaler.dynamicPixelsPerUnit = 1000f;
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text = gameObject2.AddComponent<Text>();
		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.text = name;
		text.fontSize = 1;
		text.color = Color.yellow;
		text.alignment = TextAnchor.MiddleCenter;
		text.resizeTextForBestFit = true;
		text.resizeTextMinSize = 0;
		RectTransform component = text.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.28f, 0.05f);
		component.position = new Vector3(0.06f, 0f, 0.175f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		for (int i = 0; i < buttons5.Length; i++)
		{
			AddButton5((float)i * 0.13f, buttons5[i]);
		}
		GameObject gameObject3 = new GameObject();
		gameObject3.transform.parent = canvasObj.transform;
		Text text2 = gameObject3.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = " ";
		text2.fontSize = 1;
		text2.color = Color.red;
		text2.alignment = TextAnchor.UpperLeft;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component2 = text2.GetComponent<RectTransform>();
		component2.localPosition = Vector3.zero;
		component2.sizeDelta = new Vector2(0.28f, 0.05f);
		component2.position = new Vector3(0.06f, -0.01f, -0.29f);
		component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		GameObject gameObject4 = new GameObject();
		gameObject4.transform.parent = canvasObj.transform;
		Text text3 = gameObject4.AddComponent<Text>();
		text3.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text3.text = " ";
		text3.fontSize = 1;
		text3.color = Color.blue;
		text3.alignment = TextAnchor.UpperLeft;
		text3.resizeTextForBestFit = true;
		text3.resizeTextMinSize = 0;
		RectTransform component3 = text3.GetComponent<RectTransform>();
		component3.localPosition = Vector3.zero;
		component3.sizeDelta = new Vector2(0.28f, 0.05f);
		component3.position = new Vector3(0.06f, -0.01f, -0.33f);
		component3.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Toggle5(string relatedText)
	{
		int num = -1;
		for (int i = 0; i < buttons5.Length; i++)
		{
			if (relatedText == buttons5[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive5[num].HasValue)
		{
			buttonsActive5[num] = !buttonsActive5[num];
			UnityEngine.Object.Destroy(menu);
			menu = null;
			Draw5();
		}
	}

	private static void AddButton6(float offset, string text)
	{
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		gameObject.GetComponent<BoxCollider>().isTrigger = true;
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
		gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.29f - offset / 1.2f);
		gameObject.AddComponent<BtnCollider>().relatedText = text;
		int num = -1;
		for (int i = 0; i < buttons6.Length; i++)
		{
			if (text == buttons6[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive6[num] == false)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btntheme);
		}
		else if (buttonsActive6[num] == true)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btnthemeactivated);
		}
		else
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
		}
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text2 = gameObject2.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = text;
		text2.color = Color.white;
		text2.fontSize = 1;
		text2.alignment = TextAnchor.MiddleCenter;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component = text2.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.2f, 0.03f);
		component.localPosition = new Vector3(0.064f, 0f, 0.111f - offset / 3.05f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Draw6()
	{
		menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
		UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
		menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f);
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.1f, 1f, 1.2f);
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", theme);
		if (themenumber == 7)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
		gameObject.transform.position = new Vector3(0.05f, 0f, -0.05f);
		canvasObj = new GameObject();
		canvasObj.transform.parent = menu.transform;
		Canvas canvas = canvasObj.AddComponent<Canvas>();
		CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
		canvasObj.AddComponent<GraphicRaycaster>();
		canvas.renderMode = RenderMode.WorldSpace;
		canvasScaler.dynamicPixelsPerUnit = 1000f;
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text = gameObject2.AddComponent<Text>();
		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.text = name;
		text.fontSize = 1;
		text.color = Color.yellow;
		text.alignment = TextAnchor.MiddleCenter;
		text.resizeTextForBestFit = true;
		text.resizeTextMinSize = 0;
		RectTransform component = text.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.28f, 0.05f);
		component.position = new Vector3(0.06f, 0f, 0.175f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		for (int i = 0; i < buttons6.Length; i++)
		{
			AddButton6((float)i * 0.13f, buttons6[i]);
		}
		GameObject gameObject3 = new GameObject();
		gameObject3.transform.parent = canvasObj.transform;
		Text text2 = gameObject3.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = " ";
		text2.fontSize = 1;
		text2.color = Color.red;
		text2.alignment = TextAnchor.UpperLeft;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component2 = text2.GetComponent<RectTransform>();
		component2.localPosition = Vector3.zero;
		component2.sizeDelta = new Vector2(0.28f, 0.05f);
		component2.position = new Vector3(0.06f, -0.01f, -0.29f);
		component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		GameObject gameObject4 = new GameObject();
		gameObject4.transform.parent = canvasObj.transform;
		Text text3 = gameObject4.AddComponent<Text>();
		text3.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text3.text = " ";
		text3.fontSize = 1;
		text3.color = Color.blue;
		text3.alignment = TextAnchor.UpperLeft;
		text3.resizeTextForBestFit = true;
		text3.resizeTextMinSize = 0;
		RectTransform component3 = text3.GetComponent<RectTransform>();
		component3.localPosition = Vector3.zero;
		component3.sizeDelta = new Vector2(0.28f, 0.05f);
		component3.position = new Vector3(0.06f, -0.01f, -0.33f);
		component3.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Toggle6(string relatedText)
	{
		int num = -1;
		for (int i = 0; i < buttons6.Length; i++)
		{
			if (relatedText == buttons6[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive6[num].HasValue)
		{
			buttonsActive6[num] = !buttonsActive6[num];
			UnityEngine.Object.Destroy(menu);
			menu = null;
			Draw6();
		}
	}

	private static void AddButton7(float offset, string text)
	{
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		gameObject.GetComponent<BoxCollider>().isTrigger = true;
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
		gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.29f - offset / 1.2f);
		gameObject.AddComponent<BtnCollider>().relatedText = text;
		int num = -1;
		for (int i = 0; i < buttons7.Length; i++)
		{
			if (text == buttons7[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive7[num] == false)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btntheme);
		}
		else if (buttonsActive7[num] == true)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btnthemeactivated);
		}
		else
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
		}
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text2 = gameObject2.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = text;
		text2.color = Color.white;
		text2.fontSize = 1;
		text2.alignment = TextAnchor.MiddleCenter;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component = text2.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.2f, 0.03f);
		component.localPosition = new Vector3(0.064f, 0f, 0.111f - offset / 3.05f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Draw7()
	{
		menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
		UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
		menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f);
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.1f, 1f, 1.2f);
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", theme);
		if (themenumber == 7)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
		gameObject.transform.position = new Vector3(0.05f, 0f, -0.05f);
		canvasObj = new GameObject();
		canvasObj.transform.parent = menu.transform;
		Canvas canvas = canvasObj.AddComponent<Canvas>();
		CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
		canvasObj.AddComponent<GraphicRaycaster>();
		canvas.renderMode = RenderMode.WorldSpace;
		canvasScaler.dynamicPixelsPerUnit = 1000f;
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text = gameObject2.AddComponent<Text>();
		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.text = name;
		text.fontSize = 1;
		text.color = Color.yellow;
		text.alignment = TextAnchor.MiddleCenter;
		text.resizeTextForBestFit = true;
		text.resizeTextMinSize = 0;
		RectTransform component = text.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.28f, 0.05f);
		component.position = new Vector3(0.06f, 0f, 0.175f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		for (int i = 0; i < buttons7.Length; i++)
		{
			AddButton7((float)i * 0.13f, buttons7[i]);
		}
		GameObject gameObject3 = new GameObject();
		gameObject3.transform.parent = canvasObj.transform;
		Text text2 = gameObject3.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = " ";
		text2.fontSize = 1;
		text2.color = Color.red;
		text2.alignment = TextAnchor.UpperLeft;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component2 = text2.GetComponent<RectTransform>();
		component2.localPosition = Vector3.zero;
		component2.sizeDelta = new Vector2(0.28f, 0.05f);
		component2.position = new Vector3(0.06f, -0.01f, -0.29f);
		component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		GameObject gameObject4 = new GameObject();
		gameObject4.transform.parent = canvasObj.transform;
		Text text3 = gameObject4.AddComponent<Text>();
		text3.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text3.text = " ";
		text3.fontSize = 1;
		text3.color = Color.blue;
		text3.alignment = TextAnchor.UpperLeft;
		text3.resizeTextForBestFit = true;
		text3.resizeTextMinSize = 0;
		RectTransform component3 = text3.GetComponent<RectTransform>();
		component3.localPosition = Vector3.zero;
		component3.sizeDelta = new Vector2(0.28f, 0.05f);
		component3.position = new Vector3(0.06f, -0.01f, -0.33f);
		component3.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Toggle7(string relatedText)
	{
		int num = -1;
		for (int i = 0; i < buttons7.Length; i++)
		{
			if (relatedText == buttons7[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive7[num].HasValue)
		{
			buttonsActive7[num] = !buttonsActive7[num];
			UnityEngine.Object.Destroy(menu);
			menu = null;
			Draw7();
		}
	}

	private static void ProcessPlankPlatforms()
	{
		colorKeys[0].color = Color.red;
		colorKeys[0].time = 0f;
		colorKeys[1].color = Color.green;
		colorKeys[1].time = 0.3f;
		colorKeys[2].color = Color.blue;
		colorKeys[2].time = 0.6f;
		colorKeys[3].color = Color.red;
		colorKeys[3].time = 1f;
		List<InputDevice> list = new List<InputDevice>();
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, list);
		list[0].TryGetFeatureValue(CommonUsages.gripButton, out gripDown_left);
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
		list[0].TryGetFeatureValue(CommonUsages.gripButton, out gripDown_right);
		if (gripDown_right)
		{
			if (!once_right && jump_right_local == null)
			{
				jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
				jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
				jump_right_local.transform.localScale = new Vector3(0.017f, 0.28f, 0.9999f);
				jump_right_local.transform.position = new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
				jump_right_local.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
				object[] eventContent = new object[2]
				{
					new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position,
					GorillaLocomotion.Player.Instance.rightControllerTransform.rotation
				};
				RaiseEventOptions raiseEventOptions = new RaiseEventOptions
				{
					Receivers = ReceiverGroup.Others
				};
				PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
				once_right = true;
				once_right_false = false;
				ColorChanger colorChanger = jump_right_local.AddComponent<ColorChanger>();
				colorChanger.colors = new Gradient
				{
					colorKeys = colorKeys
				};
				colorChanger.Start();
			}
		}
		else if (!once_right_false && jump_right_local != null)
		{
			UnityEngine.Object.Destroy(jump_right_local);
			jump_right_local = null;
			once_right = false;
			once_right_false = true;
			RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
			{
				Receivers = ReceiverGroup.Others
			};
			PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
		}
		if (gripDown_left)
		{
			if (!once_left && jump_left_local == null)
			{
				jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
				jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
				jump_left_local.transform.localScale = new Vector3(0.017f, 0.28f, 0.9999f);
				jump_left_local.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
				jump_left_local.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
				object[] eventContent2 = new object[2]
				{
					GorillaLocomotion.Player.Instance.leftControllerTransform.position,
					GorillaLocomotion.Player.Instance.leftControllerTransform.rotation
				};
				RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
				{
					Receivers = ReceiverGroup.Others
				};
				PhotonNetwork.RaiseEvent(69, eventContent2, raiseEventOptions3, SendOptions.SendReliable);
				once_left = true;
				once_left_false = false;
				ColorChanger colorChanger2 = jump_left_local.AddComponent<ColorChanger>();
				colorChanger2.colors = new Gradient
				{
					colorKeys = colorKeys
				};
				colorChanger2.Start();
			}
		}
		else if (!once_left_false && jump_left_local != null)
		{
			UnityEngine.Object.Destroy(jump_left_local);
			jump_left_local = null;
			once_left = false;
			once_left_false = true;
			RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
			{
				Receivers = ReceiverGroup.Others
			};
			PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
		}
		if (!PhotonNetwork.InRoom)
		{
			for (int i = 0; i < jump_right_network.Length; i++)
			{
				UnityEngine.Object.Destroy(jump_right_network[i]);
			}
			for (int j = 0; j < jump_left_network.Length; j++)
			{
				UnityEngine.Object.Destroy(jump_left_network[j]);
			}
		}
	}

	private static void ProcessPrimaryPlatforms()
	{
		colorKeys[0].color = Color.red;
		colorKeys[0].time = 0f;
		colorKeys[1].color = Color.green;
		colorKeys[1].time = 0.3f;
		colorKeys[2].color = Color.blue;
		colorKeys[2].time = 0.6f;
		colorKeys[3].color = Color.red;
		colorKeys[3].time = 1f;
		if (!once_networking)
		{
			PhotonNetwork.NetworkingClient.EventReceived += PlatformNetwork;
			once_networking = true;
		}
		List<InputDevice> list = new List<InputDevice>();
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, list);
		list[0].TryGetFeatureValue(CommonUsages.primaryButton, out gripDown_left);
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
		list[0].TryGetFeatureValue(CommonUsages.primaryButton, out gripDown_right);
		if (gripDown_right)
		{
			if (!once_right && jump_right_local == null)
			{
				jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
				jump_right_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
				jump_right_local.transform.localScale = scale;
				jump_right_local.transform.position = new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
				jump_right_local.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
				object[] eventContent = new object[2]
				{
					new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position,
					GorillaLocomotion.Player.Instance.rightControllerTransform.rotation
				};
				RaiseEventOptions raiseEventOptions = new RaiseEventOptions
				{
					Receivers = ReceiverGroup.Others
				};
				PhotonNetwork.RaiseEvent(70, eventContent, raiseEventOptions, SendOptions.SendReliable);
				once_right = true;
				once_right_false = false;
				ColorChanger colorChanger = jump_right_local.AddComponent<ColorChanger>();
				colorChanger.colors = new Gradient
				{
					colorKeys = colorKeys
				};
				colorChanger.Start();
			}
		}
		else if (!once_right_false && jump_right_local != null)
		{
			UnityEngine.Object.Destroy(jump_right_local);
			jump_right_local = null;
			once_right = false;
			once_right_false = true;
			RaiseEventOptions raiseEventOptions2 = new RaiseEventOptions
			{
				Receivers = ReceiverGroup.Others
			};
			PhotonNetwork.RaiseEvent(72, null, raiseEventOptions2, SendOptions.SendReliable);
		}
		if (gripDown_left)
		{
			if (!once_left && jump_left_local == null)
			{
				jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
				jump_left_local.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
				jump_left_local.transform.localScale = scale;
				jump_left_local.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
				jump_left_local.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
				object[] eventContent2 = new object[2]
				{
					GorillaLocomotion.Player.Instance.leftControllerTransform.position,
					GorillaLocomotion.Player.Instance.leftControllerTransform.rotation
				};
				RaiseEventOptions raiseEventOptions3 = new RaiseEventOptions
				{
					Receivers = ReceiverGroup.Others
				};
				PhotonNetwork.RaiseEvent(69, eventContent2, raiseEventOptions3, SendOptions.SendReliable);
				once_left = true;
				once_left_false = false;
				ColorChanger colorChanger2 = jump_left_local.AddComponent<ColorChanger>();
				colorChanger2.colors = new Gradient
				{
					colorKeys = colorKeys
				};
				colorChanger2.Start();
			}
		}
		else if (!once_left_false && jump_left_local != null)
		{
			UnityEngine.Object.Destroy(jump_left_local);
			jump_left_local = null;
			once_left = false;
			once_left_false = true;
			RaiseEventOptions raiseEventOptions4 = new RaiseEventOptions
			{
				Receivers = ReceiverGroup.Others
			};
			PhotonNetwork.RaiseEvent(71, null, raiseEventOptions4, SendOptions.SendReliable);
		}
		if (!PhotonNetwork.InRoom)
		{
			for (int i = 0; i < jump_right_network.Length; i++)
			{
				UnityEngine.Object.Destroy(jump_right_network[i]);
			}
			for (int j = 0; j < jump_left_network.Length; j++)
			{
				UnityEngine.Object.Destroy(jump_left_network[j]);
			}
		}
	}

	public static void ProcessInvisTriggerPlatforms()
	{
		List<InputDevice> list = new List<InputDevice>();
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Left, list);
		list[0].TryGetFeatureValue(CommonUsages.triggerButton, out gripDown_left);
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
		list[0].TryGetFeatureValue(CommonUsages.triggerButton, out gripDown_right);
		if (gripDown_right)
		{
			if (!once_right && jump_right_local == null)
			{
				jump_right_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
				jump_right_local.GetComponent<Renderer>().enabled = false;
				jump_right_local.transform.localScale = scale;
				jump_right_local.transform.position = new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position;
				jump_right_local.transform.rotation = GorillaLocomotion.Player.Instance.rightControllerTransform.rotation;
				_ = new object[2]
				{
					new Vector3(0f, -0.0075f, 0f) + GorillaLocomotion.Player.Instance.rightControllerTransform.position,
					GorillaLocomotion.Player.Instance.rightControllerTransform.rotation
				};
				once_right = true;
				once_right_false = false;
			}
		}
		else if (!once_right_false && jump_right_local != null)
		{
			UnityEngine.Object.Destroy(jump_right_local);
			jump_right_local = null;
			once_right = false;
			once_right_false = true;
		}
		if (gripDown_left)
		{
			if (!once_left && jump_left_local == null)
			{
				jump_left_local = GameObject.CreatePrimitive(PrimitiveType.Cube);
				jump_left_local.GetComponent<Renderer>().enabled = false;
				jump_left_local.transform.localScale = scale;
				jump_left_local.transform.position = GorillaLocomotion.Player.Instance.leftControllerTransform.position;
				jump_left_local.transform.rotation = GorillaLocomotion.Player.Instance.leftControllerTransform.rotation;
				_ = new object[2]
				{
					GorillaLocomotion.Player.Instance.leftControllerTransform.position,
					GorillaLocomotion.Player.Instance.leftControllerTransform.rotation
				};
				once_left = true;
				once_left_false = false;
			}
		}
		else if (!once_left_false && jump_left_local != null)
		{
			UnityEngine.Object.Destroy(jump_left_local);
			jump_left_local = null;
			once_left = false;
			once_left_false = true;
		}
		if (!PhotonNetwork.InRoom)
		{
			for (int i = 0; i < jump_right_network.Length; i++)
			{
				UnityEngine.Object.Destroy(jump_right_network[i]);
			}
			for (int j = 0; j < jump_left_network.Length; j++)
			{
				UnityEngine.Object.Destroy(jump_left_network[j]);
			}
		}
	}

	private static void AddButton8(float offset, string text)
	{
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		gameObject.GetComponent<BoxCollider>().isTrigger = true;
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
		gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.29f - offset / 1.2f);
		gameObject.AddComponent<BtnCollider>().relatedText = text;
		int num = -1;
		for (int i = 0; i < buttons8.Length; i++)
		{
			if (text == buttons8[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive8[num] == false)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btntheme);
		}
		else if (buttonsActive8[num] == true)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btnthemeactivated);
		}
		else
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
		}
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text2 = gameObject2.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = text;
		text2.color = Color.white;
		text2.fontSize = 1;
		text2.alignment = TextAnchor.MiddleCenter;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component = text2.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.2f, 0.03f);
		component.localPosition = new Vector3(0.064f, 0f, 0.111f - offset / 3.05f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Draw8()
	{
		menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
		UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
		menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f);
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.1f, 1f, 1.2f);
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", theme);
		if (themenumber == 7)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
		gameObject.transform.position = new Vector3(0.05f, 0f, -0.05f);
		canvasObj = new GameObject();
		canvasObj.transform.parent = menu.transform;
		Canvas canvas = canvasObj.AddComponent<Canvas>();
		CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
		canvasObj.AddComponent<GraphicRaycaster>();
		canvas.renderMode = RenderMode.WorldSpace;
		canvasScaler.dynamicPixelsPerUnit = 1000f;
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text = gameObject2.AddComponent<Text>();
		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.text = name;
		text.fontSize = 1;
		text.color = Color.yellow;
		text.alignment = TextAnchor.MiddleCenter;
		text.resizeTextForBestFit = true;
		text.resizeTextMinSize = 0;
		RectTransform component = text.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.28f, 0.05f);
		component.position = new Vector3(0.06f, 0f, 0.175f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		for (int i = 0; i < buttons8.Length; i++)
		{
			AddButton8((float)i * 0.13f, buttons8[i]);
		}
		GameObject gameObject3 = new GameObject();
		gameObject3.transform.parent = canvasObj.transform;
		Text text2 = gameObject3.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = " ";
		text2.fontSize = 1;
		text2.color = Color.red;
		text2.alignment = TextAnchor.UpperLeft;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component2 = text2.GetComponent<RectTransform>();
		component2.localPosition = Vector3.zero;
		component2.sizeDelta = new Vector2(0.28f, 0.05f);
		component2.position = new Vector3(0.06f, -0.01f, -0.29f);
		component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		GameObject gameObject4 = new GameObject();
		gameObject4.transform.parent = canvasObj.transform;
		Text text3 = gameObject4.AddComponent<Text>();
		text3.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text3.text = " ";
		text3.fontSize = 1;
		text3.color = Color.blue;
		text3.alignment = TextAnchor.UpperLeft;
		text3.resizeTextForBestFit = true;
		text3.resizeTextMinSize = 0;
		RectTransform component3 = text3.GetComponent<RectTransform>();
		component3.localPosition = Vector3.zero;
		component3.sizeDelta = new Vector2(0.28f, 0.05f);
		component3.position = new Vector3(0.06f, -0.01f, -0.33f);
		component3.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Toggle8(string relatedText)
	{
		int num = -1;
		for (int i = 0; i < buttons8.Length; i++)
		{
			if (relatedText == buttons8[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive8[num].HasValue)
		{
			buttonsActive8[num] = !buttonsActive8[num];
			UnityEngine.Object.Destroy(menu);
			menu = null;
			Draw8();
		}
	}

	private static void ProcessLongArms()
	{
		List<InputDevice> list = new List<InputDevice>();
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
		list[0].TryGetFeatureValue(CommonUsages.gripButton, out gain);
		list[0].TryGetFeatureValue(CommonUsages.triggerButton, out less);
		list[0].TryGetFeatureValue(CommonUsages.primaryButton, out reset);
		list[0].TryGetFeatureValue(CommonUsages.secondaryButton, out fastr);
		timeSinceLastChange += Time.deltaTime;
		if (!(timeSinceLastChange > 0.2f))
		{
			return;
		}
		GorillaLocomotion.Player.Instance.leftHandOffset = new Vector3(0f, myVarY1, 0f);
		GorillaLocomotion.Player.Instance.rightHandOffset = new Vector3(0f, myVarY2, 0f);
		GorillaLocomotion.Player.Instance.maxArmLength = 70f;
		if (gain)
		{
			timeSinceLastChange = 0f;
			myVarY1 += gainSpeed;
			myVarY2 += gainSpeed;
			if (myVarY1 >= 201f)
			{
				myVarY1 = 200f;
				myVarY2 = 200f;
			}
		}
		if (less)
		{
			timeSinceLastChange = 0f;
			myVarY1 -= gainSpeed;
			myVarY2 -= gainSpeed;
			if (myVarY2 <= -6f)
			{
				myVarY1 = -5f;
				myVarY2 = -5f;
			}
		}
		if (reset)
		{
			timeSinceLastChange = 0f;
			myVarY1 = 0f;
			myVarY2 = 0f;
		}
		if (fastr && myVarY1 == 5f)
		{
			myVarY1 = 10f;
			myVarY2 = 10f;
		}
	}

	private static void AddButton9(float offset, string text)
	{
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		gameObject.GetComponent<BoxCollider>().isTrigger = true;
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
		gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.29f - offset / 1.2f);
		gameObject.AddComponent<BtnCollider>().relatedText = text;
		int num = -1;
		for (int i = 0; i < buttons9.Length; i++)
		{
			if (text == buttons9[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive9[num] == false)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btntheme);
		}
		else if (buttonsActive9[num] == true)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btnthemeactivated);
		}
		else
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
		}
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text2 = gameObject2.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = text;
		text2.color = Color.white;
		text2.fontSize = 1;
		text2.alignment = TextAnchor.MiddleCenter;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component = text2.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.2f, 0.03f);
		component.localPosition = new Vector3(0.064f, 0f, 0.111f - offset / 3.05f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Draw9()
	{
		menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
		UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
		menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f);
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.1f, 1f, 1.2f);
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", theme);
		if (themenumber == 7)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
		gameObject.transform.position = new Vector3(0.05f, 0f, -0.05f);
		canvasObj = new GameObject();
		canvasObj.transform.parent = menu.transform;
		Canvas canvas = canvasObj.AddComponent<Canvas>();
		CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
		canvasObj.AddComponent<GraphicRaycaster>();
		canvas.renderMode = RenderMode.WorldSpace;
		canvasScaler.dynamicPixelsPerUnit = 1000f;
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text = gameObject2.AddComponent<Text>();
		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.text = name;
		text.fontSize = 1;
		text.color = Color.yellow;
		text.alignment = TextAnchor.MiddleCenter;
		text.resizeTextForBestFit = true;
		text.resizeTextMinSize = 0;
		RectTransform component = text.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.28f, 0.05f);
		component.position = new Vector3(0.06f, 0f, 0.175f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		for (int i = 0; i < buttons9.Length; i++)
		{
			AddButton9((float)i * 0.13f, buttons9[i]);
		}
		GameObject gameObject3 = new GameObject();
		gameObject3.transform.parent = canvasObj.transform;
		Text text2 = gameObject3.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = " ";
		text2.fontSize = 1;
		text2.color = Color.red;
		text2.alignment = TextAnchor.UpperLeft;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component2 = text2.GetComponent<RectTransform>();
		component2.localPosition = Vector3.zero;
		component2.sizeDelta = new Vector2(0.28f, 0.05f);
		component2.position = new Vector3(0.06f, -0.01f, -0.29f);
		component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		GameObject gameObject4 = new GameObject();
		gameObject4.transform.parent = canvasObj.transform;
		Text text3 = gameObject4.AddComponent<Text>();
		text3.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text3.text = " ";
		text3.fontSize = 1;
		text3.color = Color.blue;
		text3.alignment = TextAnchor.UpperLeft;
		text3.resizeTextForBestFit = true;
		text3.resizeTextMinSize = 0;
		RectTransform component3 = text3.GetComponent<RectTransform>();
		component3.localPosition = Vector3.zero;
		component3.sizeDelta = new Vector2(0.28f, 0.05f);
		component3.position = new Vector3(0.06f, -0.01f, -0.33f);
		component3.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Toggle9(string relatedText)
	{
		int num = -1;
		for (int i = 0; i < buttons9.Length; i++)
		{
			if (relatedText == buttons9[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive9[num].HasValue)
		{
			buttonsActive9[num] = !buttonsActive9[num];
			UnityEngine.Object.Destroy(menu);
			menu = null;
			Draw9();
		}
	}

	private static void ProcessAirStrike()
	{
		bool value = false;
		bool value2 = false;
		List<InputDevice> list = new List<InputDevice>();
		InputDevices.GetDevices(list);
		InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right, list);
		list[0].TryGetFeatureValue(CommonUsages.triggerButton, out value);
		list[0].TryGetFeatureValue(CommonUsages.gripButton, out value2);
		if (!value2)
		{
			UnityEngine.Object.Destroy(pointer);
			pointer = null;
			antiRepeat = false;
			return;
		}
		Physics.Raycast(GorillaLocomotion.Player.Instance.rightControllerTransform.position - GorillaLocomotion.Player.Instance.rightControllerTransform.up, -GorillaLocomotion.Player.Instance.rightControllerTransform.up, out var hitInfo);
		if (pointer == null)
		{
			pointer = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			UnityEngine.Object.Destroy(pointer.GetComponent<Rigidbody>());
			UnityEngine.Object.Destroy(pointer.GetComponent<SphereCollider>());
			pointer.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
		}
		pointer.transform.position = hitInfo.point;
		if (!value)
		{
			antiRepeat = false;
		}
		else if (!antiRepeat)
		{
			GorillaLocomotion.Player.Instance.transform.position = hitInfo.point;
			GorillaLocomotion.Player.Instance.GetComponent<Rigidbody>().velocity = new Vector3(0f, 55f, 0f);
			antiRepeat = true;
		}
	}

	private static void AddButtonban(float offset, string text)
	{
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		gameObject.GetComponent<BoxCollider>().isTrigger = true;
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
		gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.29f - offset / 1.2f);
		gameObject.AddComponent<BtnCollider>().relatedText = text;
		int num = -1;
		for (int i = 0; i < buttonsban.Length; i++)
		{
			if (text == buttonsban[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActiveban[num] == false)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btntheme);
		}
		else if (buttonsActiveban[num] == true)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btnthemeactivated);
		}
		else
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
		}
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text2 = gameObject2.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = text;
		text2.color = Color.white;
		text2.fontSize = 1;
		text2.alignment = TextAnchor.MiddleCenter;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component = text2.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.2f, 0.03f);
		component.localPosition = new Vector3(0.064f, 0f, 0.111f - offset / 3.05f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Drawban()
	{
		menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
		UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
		menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f);
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.1f, 1f, 1.2f);
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", theme);
		if (themenumber == 7)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
		gameObject.transform.position = new Vector3(0.05f, 0f, -0.05f);
		canvasObj = new GameObject();
		canvasObj.transform.parent = menu.transform;
		Canvas canvas = canvasObj.AddComponent<Canvas>();
		CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
		canvasObj.AddComponent<GraphicRaycaster>();
		canvas.renderMode = RenderMode.WorldSpace;
		canvasScaler.dynamicPixelsPerUnit = 1000f;
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text = gameObject2.AddComponent<Text>();
		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.text = "This Mod Could BAN you VERY quickly Unless ur in a Priv or Modded Lobby!";
		text.fontSize = 1;
		text.color = Color.yellow;
		text.alignment = TextAnchor.MiddleCenter;
		text.resizeTextForBestFit = true;
		text.resizeTextMinSize = 0;
		RectTransform component = text.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.28f, 0.05f);
		component.position = new Vector3(0.06f, 0f, 0.175f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		for (int i = 0; i < buttonsban.Length; i++)
		{
			AddButtonban((float)i * 0.13f, buttonsban[i]);
		}
		GameObject gameObject3 = new GameObject();
		gameObject3.transform.parent = canvasObj.transform;
		Text text2 = gameObject3.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = " ";
		text2.fontSize = 1;
		text2.color = Color.red;
		text2.alignment = TextAnchor.UpperLeft;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component2 = text2.GetComponent<RectTransform>();
		component2.localPosition = Vector3.zero;
		component2.sizeDelta = new Vector2(0.28f, 0.05f);
		component2.position = new Vector3(0.06f, -0.01f, -0.29f);
		component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		GameObject gameObject4 = new GameObject();
		gameObject4.transform.parent = canvasObj.transform;
		Text text3 = gameObject4.AddComponent<Text>();
		text3.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text3.text = " ";
		text3.fontSize = 1;
		text3.color = Color.blue;
		text3.alignment = TextAnchor.UpperLeft;
		text3.resizeTextForBestFit = true;
		text3.resizeTextMinSize = 0;
		RectTransform component3 = text3.GetComponent<RectTransform>();
		component3.localPosition = Vector3.zero;
		component3.sizeDelta = new Vector2(0.28f, 0.05f);
		component3.position = new Vector3(0.06f, -0.01f, -0.33f);
		component3.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Toggleban(string relatedText)
	{
		int num = -1;
		for (int i = 0; i < buttonsban.Length; i++)
		{
			if (relatedText == buttonsban[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActiveban[num].HasValue)
		{
			buttonsActiveban[num] = !buttonsActiveban[num];
			UnityEngine.Object.Destroy(menu);
			menu = null;
			Drawban();
		}
	}

	private static void AddButton10(float offset, string text)
	{
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		gameObject.GetComponent<BoxCollider>().isTrigger = true;
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
		gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.29f - offset / 1.2f);
		gameObject.AddComponent<BtnCollider>().relatedText = text;
		int num = -1;
		for (int i = 0; i < buttons10.Length; i++)
		{
			if (text == buttons10[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive10[num] == false)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btntheme);
		}
		else if (buttonsActive10[num] == true)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btnthemeactivated);
		}
		else
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
		}
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text2 = gameObject2.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = text;
		text2.color = Color.white;
		text2.fontSize = 1;
		text2.alignment = TextAnchor.MiddleCenter;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component = text2.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.2f, 0.03f);
		component.localPosition = new Vector3(0.064f, 0f, 0.111f - offset / 3.05f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Draw10()
	{
		menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
		UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
		menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f);
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.1f, 1f, 1.2f);
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", theme);
		if (themenumber == 7)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
		gameObject.transform.position = new Vector3(0.05f, 0f, -0.05f);
		canvasObj = new GameObject();
		canvasObj.transform.parent = menu.transform;
		Canvas canvas = canvasObj.AddComponent<Canvas>();
		CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
		canvasObj.AddComponent<GraphicRaycaster>();
		canvas.renderMode = RenderMode.WorldSpace;
		canvasScaler.dynamicPixelsPerUnit = 1000f;
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text = gameObject2.AddComponent<Text>();
		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.text = name;
		text.fontSize = 1;
		text.color = Color.yellow;
		text.alignment = TextAnchor.MiddleCenter;
		text.resizeTextForBestFit = true;
		text.resizeTextMinSize = 0;
		RectTransform component = text.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.28f, 0.05f);
		component.position = new Vector3(0.06f, 0f, 0.175f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		for (int i = 0; i < buttons10.Length; i++)
		{
			AddButton10((float)i * 0.13f, buttons10[i]);
		}
		GameObject gameObject3 = new GameObject();
		gameObject3.transform.parent = canvasObj.transform;
		Text text2 = gameObject3.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = " ";
		text2.fontSize = 1;
		text2.color = Color.red;
		text2.alignment = TextAnchor.UpperLeft;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component2 = text2.GetComponent<RectTransform>();
		component2.localPosition = Vector3.zero;
		component2.sizeDelta = new Vector2(0.28f, 0.05f);
		component2.position = new Vector3(0.06f, -0.01f, -0.29f);
		component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		GameObject gameObject4 = new GameObject();
		gameObject4.transform.parent = canvasObj.transform;
		Text text3 = gameObject4.AddComponent<Text>();
		text3.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text3.text = " ";
		text3.fontSize = 1;
		text3.color = Color.blue;
		text3.alignment = TextAnchor.UpperLeft;
		text3.resizeTextForBestFit = true;
		text3.resizeTextMinSize = 0;
		RectTransform component3 = text3.GetComponent<RectTransform>();
		component3.localPosition = Vector3.zero;
		component3.sizeDelta = new Vector2(0.28f, 0.05f);
		component3.position = new Vector3(0.06f, -0.01f, -0.33f);
		component3.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Toggle10(string relatedText)
	{
		int num = -1;
		for (int i = 0; i < buttons10.Length; i++)
		{
			if (relatedText == buttons10[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive10[num].HasValue)
		{
			buttonsActive10[num] = !buttonsActive10[num];
			UnityEngine.Object.Destroy(menu);
			menu = null;
			Draw10();
		}
	}

	private static void AddButton11(float offset, string text)
	{
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		gameObject.GetComponent<BoxCollider>().isTrigger = true;
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.09f, 0.8f, 0.08f);
		gameObject.transform.localPosition = new Vector3(0.56f, 0f, 0.29f - offset / 1.2f);
		gameObject.AddComponent<BtnCollider>().relatedText = text;
		int num = -1;
		for (int i = 0; i < buttons11.Length; i++)
		{
			if (text == buttons11[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive11[num] == false)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btntheme);
		}
		else if (buttonsActive11[num] == true)
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", btnthemeactivated);
		}
		else
		{
			gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
		}
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text2 = gameObject2.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = text;
		text2.color = Color.white;
		text2.fontSize = 1;
		text2.alignment = TextAnchor.MiddleCenter;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component = text2.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.2f, 0.03f);
		component.localPosition = new Vector3(0.064f, 0f, 0.111f - offset / 3.05f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Draw11()
	{
		menu = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(menu.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(menu.GetComponent<BoxCollider>());
		UnityEngine.Object.Destroy(menu.GetComponent<Renderer>());
		menu.transform.localScale = new Vector3(0.1f, 0.3f, 0.4f);
		GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
		UnityEngine.Object.Destroy(gameObject.GetComponent<Rigidbody>());
		UnityEngine.Object.Destroy(gameObject.GetComponent<BoxCollider>());
		gameObject.transform.parent = menu.transform;
		gameObject.transform.rotation = Quaternion.identity;
		gameObject.transform.localScale = new Vector3(0.1f, 1f, 1.2f);
		gameObject.GetComponent<Renderer>().material.SetColor("_Color", theme);
		if (themenumber == 7)
		{
			gameObject.GetComponent<Renderer>().enabled = false;
		}
		else
		{
			gameObject.GetComponent<Renderer>().enabled = true;
		}
		gameObject.transform.position = new Vector3(0.05f, 0f, -0.05f);
		canvasObj = new GameObject();
		canvasObj.transform.parent = menu.transform;
		Canvas canvas = canvasObj.AddComponent<Canvas>();
		CanvasScaler canvasScaler = canvasObj.AddComponent<CanvasScaler>();
		canvasObj.AddComponent<GraphicRaycaster>();
		canvas.renderMode = RenderMode.WorldSpace;
		canvasScaler.dynamicPixelsPerUnit = 1000f;
		GameObject gameObject2 = new GameObject();
		gameObject2.transform.parent = canvasObj.transform;
		Text text = gameObject2.AddComponent<Text>();
		text.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text.text = name;
		text.fontSize = 1;
		text.color = Color.yellow;
		text.alignment = TextAnchor.MiddleCenter;
		text.resizeTextForBestFit = true;
		text.resizeTextMinSize = 0;
		RectTransform component = text.GetComponent<RectTransform>();
		component.localPosition = Vector3.zero;
		component.sizeDelta = new Vector2(0.28f, 0.05f);
		component.position = new Vector3(0.06f, 0f, 0.175f);
		component.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		for (int i = 0; i < buttons11.Length; i++)
		{
			AddButton11((float)i * 0.13f, buttons11[i]);
		}
		GameObject gameObject3 = new GameObject();
		gameObject3.transform.parent = canvasObj.transform;
		Text text2 = gameObject3.AddComponent<Text>();
		text2.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text2.text = " ";
		text2.fontSize = 1;
		text2.color = Color.red;
		text2.alignment = TextAnchor.UpperLeft;
		text2.resizeTextForBestFit = true;
		text2.resizeTextMinSize = 0;
		RectTransform component2 = text2.GetComponent<RectTransform>();
		component2.localPosition = Vector3.zero;
		component2.sizeDelta = new Vector2(0.28f, 0.05f);
		component2.position = new Vector3(0.06f, -0.01f, -0.29f);
		component2.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
		GameObject gameObject4 = new GameObject();
		gameObject4.transform.parent = canvasObj.transform;
		Text text3 = gameObject4.AddComponent<Text>();
		text3.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		text3.text = " ";
		text3.fontSize = 1;
		text3.color = Color.blue;
		text3.alignment = TextAnchor.UpperLeft;
		text3.resizeTextForBestFit = true;
		text3.resizeTextMinSize = 0;
		RectTransform component3 = text3.GetComponent<RectTransform>();
		component3.localPosition = Vector3.zero;
		component3.sizeDelta = new Vector2(0.28f, 0.05f);
		component3.position = new Vector3(0.06f, -0.01f, -0.33f);
		component3.rotation = Quaternion.Euler(new Vector3(180f, 90f, 90f));
	}

	public static void Toggle11(string relatedText)
	{
		int num = -1;
		for (int i = 0; i < buttons11.Length; i++)
		{
			if (relatedText == buttons11[i])
			{
				num = i;
				break;
			}
		}
		if (buttonsActive11[num].HasValue)
		{
			buttonsActive11[num] = !buttonsActive11[num];
			UnityEngine.Object.Destroy(menu);
			menu = null;
			Draw11();
		}
	}

	public static VRRig FindVRRigForPlayer(Photon.Realtime.Player player)
	{
		foreach (VRRig vrrig in GorillaParent.instance.vrrigs)
		{
			if (!vrrig.isOfflineVRRig && vrrig.GetComponent<PhotonView>().Owner == player)
			{
				return vrrig;
			}
		}
		return null;
	}
}
