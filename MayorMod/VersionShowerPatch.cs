using HarmonyLib;
using VersionShower = BOCOFLHKCOJ;

namespace MayorMod
{
	[HarmonyPatch(typeof(VersionShower), "Start")]
	public static class VersionShowerPatch
	{
		public static void Postfix(VersionShower __instance)
		{
			AELDHKGBIFD text = __instance.text;
			text.Text += " + [704FA8FF]Mayor[] Mod by Tomozbot";
		}
	}
}
