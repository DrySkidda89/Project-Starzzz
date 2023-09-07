using UnityEngine;

namespace Menu.HarmonyPatches;

internal class BtnCollider : MonoBehaviour
{
	public string relatedText;

	private void OnTriggerEnter(Collider collider)
	{
		if (GTAGMenu.page2 == 0 && Time.frameCount >= GTAGMenu.framePressCooldown + 30)
		{
			GTAGMenu.Toggle(relatedText);
			GTAGMenu.framePressCooldown = Time.frameCount;
		}
		if (GTAGMenu.page2 == 1 && Time.frameCount >= GTAGMenu.framePressCooldown + 30)
		{
			GTAGMenu.Toggle2(relatedText);
			GTAGMenu.framePressCooldown = Time.frameCount;
		}
		if (GTAGMenu.page2 == 2 && Time.frameCount >= GTAGMenu.framePressCooldown + 30)
		{
			GTAGMenu.Toggle3(relatedText);
			GTAGMenu.framePressCooldown = Time.frameCount;
		}
		if (GTAGMenu.page2 == 3 && Time.frameCount >= GTAGMenu.framePressCooldown + 30)
		{
			GTAGMenu.Toggle4(relatedText);
			GTAGMenu.framePressCooldown = Time.frameCount;
		}
		if (GTAGMenu.page2 == 4 && Time.frameCount >= GTAGMenu.framePressCooldown + 30)
		{
			GTAGMenu.Toggle5(relatedText);
			GTAGMenu.framePressCooldown = Time.frameCount;
		}
		if (GTAGMenu.page2 == 5 && Time.frameCount >= GTAGMenu.framePressCooldown + 30)
		{
			GTAGMenu.Toggle6(relatedText);
			GTAGMenu.framePressCooldown = Time.frameCount;
		}
		if (GTAGMenu.page2 == 6 && Time.frameCount >= GTAGMenu.framePressCooldown + 30)
		{
			GTAGMenu.Toggle7(relatedText);
			GTAGMenu.framePressCooldown = Time.frameCount;
		}
		if (GTAGMenu.page2 == 7 && Time.frameCount >= GTAGMenu.framePressCooldown + 30)
		{
			GTAGMenu.Toggle8(relatedText);
			GTAGMenu.framePressCooldown = Time.frameCount;
		}
		if (GTAGMenu.page2 == 8 && Time.frameCount >= GTAGMenu.framePressCooldown + 30)
		{
			GTAGMenu.Toggle9(relatedText);
			GTAGMenu.framePressCooldown = Time.frameCount;
		}
		if (GTAGMenu.page2 == 9 && Time.frameCount >= GTAGMenu.framePressCooldown + 30)
		{
			GTAGMenu.Toggle10(relatedText);
			GTAGMenu.framePressCooldown = Time.frameCount;
		}
		if (GTAGMenu.page2 == 10 && Time.frameCount >= GTAGMenu.framePressCooldown + 30)
		{
			GTAGMenu.Toggle11(relatedText);
			GTAGMenu.framePressCooldown = Time.frameCount;
		}
		if (GTAGMenu.page2 == 99 && Time.frameCount >= GTAGMenu.framePressCooldown + 30)
		{
			GTAGMenu.Toggleban(relatedText);
			GTAGMenu.framePressCooldown = Time.frameCount;
		}
	}
}
