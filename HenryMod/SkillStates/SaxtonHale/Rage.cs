﻿using System;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;
using EntityStates;
using System.Collections.ObjectModel;

namespace HenryMod.SkillStates
{
	public class Rage : BaseSkillState //from EntityStates.BeetleGuardMonster.DefenseUp
	{
		public static float buffDuration = 8f;
		private bool hasCastBuff = false;
		private static readonly BuffDef[] debuffList =
		{
			Modules.Buffs.scaredDebuff,
			RoR2.RoR2Content.Buffs.Slow60
		};
		private static readonly BuffDef buildingDebuff = Modules.Buffs.scaredBuildingDebuff;


		// Token: 0x0600401F RID: 16415 RVA: 0x0010D9D0 File Offset: 0x0010BBD0
		public override void OnEnter()
		{
			base.OnEnter();
		}

		// Token: 0x06004020 RID: 16416 RVA: 0x0010DA30 File Offset: 0x0010BC30
		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (!this.hasCastBuff)
			{
				this.hasCastBuff = true;
				if (NetworkServer.active)
				{
					if (teamComponent)
					{
						BuffTeam(Modules.Helpers.GetEnemyTeam(teamComponent.teamIndex), debuffList);
					}
				}
			}
			if (base.isAuthority)
			{
				this.outer.SetNextStateToMain();
				return;
			}
		}

		private void BuffTeam(TeamIndex teamIndex, BuffDef[] buffDefs)
		{
			ReadOnlyCollection<TeamComponent> teamComponents = TeamComponent.GetTeamMembers(teamIndex);
			foreach (var teamComponent in teamComponents)
			{
				CharacterBody body = teamComponent.body;
				if (body)
				{
					if (body.bodyFlags.HasFlag(CharacterBody.BodyFlags.Mechanical))
                    {
						body.AddTimedBuff(buildingDebuff, buffDuration);
						var modelAnimator = Modules.Helpers.GetModelAnimator(body);
						modelAnimator.bodyRotation = Util.QuaternionSafeLookRotation(Vector3.zero, Vector3.down);
						modelAnimator.enabled = false;
                    } else
					{
						foreach (BuffDef buffDef in buffDefs)
						{
							body.AddTimedBuff(buffDef, buffDuration);
						}
					}
				}
			}
		}

		// Token: 0x06004021 RID: 16417 RVA: 0x0000D742 File Offset: 0x0000B942
		public override InterruptPriority GetMinimumInterruptPriority()
		{
			return InterruptPriority.PrioritySkill;
		}
	}
}
