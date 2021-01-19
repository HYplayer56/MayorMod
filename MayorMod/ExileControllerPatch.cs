using HarmonyLib;
using ExileController = CNNGMDOPELD;
using GameDataPlayerInfo = EGLJNOMOGNP.DCJMABDDJCF;
using PlayerControl = FFGALNAPKCD;

namespace MayorMod
{
	[HarmonyPatch(typeof(ExileController), "Begin")]
	public static class ExileControllerPatch
	{
		public static void Postfix([HarmonyArgument(0)] GameDataPlayerInfo exiled, ExileController __instance)
		{
			if (exiled.JKOMCOJCAID == PlayerControlPatch.Mayor.PlayerId && PlayerControl.GameOptions.HGOMOAAPHNJ)
            {
				__instance.EOFFAJKKDMI = exiled.EIGEKHDAKOH + " was The Mayor.";
			}
		}
	}
}
