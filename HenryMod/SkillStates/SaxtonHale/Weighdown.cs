﻿using EntityStates;
using RoR2;
using UnityEngine;
using System;
using UnityEngine.Networking;
using RoR2.Projectile;
using EntityStates.Merc;

namespace HenryMod.SkillStates
{
    public class Weighdown : BaseSkillState //uppercut
    {
        private readonly float downwardForceScale = 65f;
		private bool hasSwung = false;

		public override void OnEnter()
		{
			base.OnEnter();
		}

		public override void OnExit()
		{
			base.OnExit();
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
			if (base.isAuthority)
			{
				if (!this.hasSwung)
				{
					this.hasSwung = true;
					this.characterBody.AddBuff(Modules.Buffs.weighdownBuff);
					if (base.characterMotor && base.characterDirection)
					{
						base.characterMotor.velocity.y = 0;
						base.characterMotor.velocity.y = -downwardForceScale;
					}
				}
				if (this.hasSwung)
				{

				}
				if (base.isGrounded)
				{
					this.outer.SetNextStateToMain();
					this.characterBody.RemoveBuff(Modules.Buffs.weighdownBuff);
				}
			}
		}
	}
}
