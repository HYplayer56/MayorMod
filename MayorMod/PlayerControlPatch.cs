using System.Collections.Generic;
using HarmonyLib;
using Hazel;
using UnhollowerBaseLib;
using PlayerControl = FFGALNAPKCD;
using GameDataPlayerInfo = EGLJNOMOGNP.DCJMABDDJCF;
using AmongUsClient = FMLLKEACGIO;
using GameOptionsData = KMOGFLPJLLK;

namespace MayorMod
{
	[HarmonyPatch]
	public static class PlayerControlPatch
	{
		public static PlayerControl Mayor;
		
		[HarmonyPatch(typeof(PlayerControl), "HandleRpc")]
		public static void Postfix([HarmonyArgument(0)] byte callId, [HarmonyArgument(1)] MessageReader reader)
		{
			if (callId == 41)
			{
				byte readByte = reader.ReadByte();
				foreach (PlayerControl player in PlayerControl.AllPlayerControls)
				{
					if (player.PlayerId == readByte)
					{
						Mayor = player;
					}
				}
			}
		}

		public static bool IsMayor(PlayerControl player)
		{
			return player.PlayerId == PlayerControlPatch.Mayor.PlayerId;
		}

		public static List<PlayerControl> GetCrewMates(Il2CppReferenceArray<GameDataPlayerInfo> infection)
		{
			List<PlayerControl> list = new List<PlayerControl>();
			foreach (PlayerControl player in PlayerControl.AllPlayerControls)
			{
				bool isImpostor = false;
				foreach (GameDataPlayerInfo player1 in infection)
				{
					if (player.PlayerId == player1.LAOEJKHLKAI.PlayerId)
					{
						isImpostor = true;
						break;
					}
				}
				if (!isImpostor)
				{
					list.Add(player);
				}
			}
			return list;
		}

		public static PlayerControl GetPlayer(byte id)
		{
			foreach (PlayerControl player in PlayerControl.AllPlayerControls)
			{
				if (player.PlayerId == id)
				{
					return player;
				}
			}
			return null;
		}

		[HarmonyPatch(typeof(PlayerControl), "RpcSetInfected")]
		public static void Postfix([HarmonyArgument(0)] Il2CppReferenceArray<GameDataPlayerInfo> infected)
		{
			MessageWriter messageWriter = AmongUsClient.Instance.StartRpcImmediately(PlayerControl.LocalPlayer.NetId, 41, SendOption.None, -1);
			List<PlayerControl> crewMates = PlayerControlPatch.GetCrewMates(infected);
			System.Random random = new System.Random();
			PlayerControlPatch.Mayor = crewMates[random.Next(0, crewMates.Count)];
			byte playerId = PlayerControlPatch.Mayor.PlayerId;
			messageWriter.Write(playerId);
			AmongUsClient.Instance.FinishRpcImmediately(messageWriter);
		}
	}
}
