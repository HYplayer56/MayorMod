using HarmonyLib;
using ExileController = CNNGMDOPELD;
using GameDataPlayerInfo = EGLJNOMOGNP.DCJMABDDJCF;
using GameOptionsData = KMOGFLPJLLK;

namespace MayorMod
{
	[HarmonyPatch(typeof(ExileController), "Begin")]
	public static class ExileControllerPatch
	{
		public static void Postfix([HarmonyArgument(0)] GameDataPlayerInfo exiled, ExileController __instance)
		{
			if (exiled.JKOMCOJCAID == PlayerControlPatch.Mayor.PlayerId && !(__instance.EOFFAJKKDMI.Substring(__instance.EOFFAJKKDMI.LastIndexOf(".")-11) == "was ejected."))
            {
				__instance.EOFFAJKKDMI = exiled.EIGEKHDAKOH + " was The Mayor.";
			}
		}
	}
}
