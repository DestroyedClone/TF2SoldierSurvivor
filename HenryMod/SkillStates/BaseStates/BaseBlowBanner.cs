using EntityStates;
using RoR2;
using RoR2.Projectile;
using UnityEngine;
using System;
using UnityEngine.Networking;

namespace HenryMod.SkillStates
{
    public class BaseBlowBanner : BaseSkillState
	{
		public static float baseDuration = 3.5f;
		public static float buffDuration = 8f;
		public static GameObject defenseUpPrefab;
		private Animator modelAnimator;
		private float duration;
		private bool hasCastBuff;

		public BuffDef buffDef;

		public override void OnEnter()
		{
			base.OnEnter();
			this.duration = BaseBlowBanner.baseDuration / this.attackSpeedStat;
			this.modelAnimator = base.GetModelAnimator();
			if (this.modelAnimator)
			{
				base.PlayCrossfade("Body", "DefenseUp", "DefenseUp.playbackRate", this.duration, 0.2f);
			}
		}

		// Token: 0x060046EF RID: 18159 RVA: 0x0011FC90 File Offset: 0x0011DE90
		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (this.modelAnimator && this.modelAnimator.GetFloat("DefenseUp.activate") > 0.5f && !this.hasCastBuff)
			{
				ScaleParticleSystemDuration component = UnityEngine.Object.Instantiate<GameObject>(defenseUpPrefab, base.transform.position, Quaternion.identity, base.transform).GetComponent<ScaleParticleSystemDuration>();
				if (component)
				{
					component.newDuration = buffDuration;
				}
				this.hasCastBuff = true;
				if (NetworkServer.active)
				{
					base.characterBody.AddTimedBuff(buffDef, buffDuration);
				}
			}
			if (base.fixedAge >= this.duration && base.isAuthority)
			{
				this.outer.SetNextStateToMain();
				return;
			}
		}

		// Token: 0x060046F0 RID: 18160 RVA: 0x0006E4AF File Offset: 0x0006C6AF
		public override InterruptPriority GetMinimumInterruptPriority()
		{
			return InterruptPriority.PrioritySkill;
		}
	}
}