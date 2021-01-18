using HarmonyLib;
using UnityEngine;
using IntroCutscene_CoBegin_d__10 = PENEIDJGGAF.CKACLKCOJFO;
using PlayerControl = FFGALNAPKCD;

namespace MayorMod
{
	[HarmonyPatch]
	public static class IntroCutScenePatch
	{
		[HarmonyPatch(typeof(IntroCutscene_CoBegin_d__10), "MoveNext")]
		public static void Postfix(IntroCutscene_CoBegin_d__10 __instance)
		{
			if (PlayerControlPatch.IsMayor(PlayerControl.LocalPlayer))
			{
				__instance.field_Public_PENEIDJGGAF_0.Title.Text = "Mayor";
				__instance.field_Public_PENEIDJGGAF_0.Title.Color = new Color(0.44f, 0.31f, 0.66f, 1f);
				__instance.field_Public_PENEIDJGGAF_0.ImpostorText.Text = "Your vote counts twice";
				__instance.field_Public_PENEIDJGGAF_0.BackgroundBar.material.color = new Color(0.44f, 0.31f, 0.66f, 1f);
			}
		}
	}
}
