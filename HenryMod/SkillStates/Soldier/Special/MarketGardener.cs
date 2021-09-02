using HenryMod.SkillStates.BaseStates;
using RoR2;
using UnityEngine;
using HenryMod.Modules.SurvivorComponents;

namespace HenryMod.SkillStates
{
    public class MarketGardener : BaseMeleeAttack
    {
        public RocketJumpComponent rocketJumpComponent;

        public override void OnEnter()
        {
            this.hitboxName = "Sword";

            this.damageCoefficient = Modules.StaticValues.gardenDamageCoefficient;
            rocketJumpComponent = gameObject.GetComponent<RocketJumpComponent>();
            if (rocketJumpComponent && rocketJumpComponent.isRocketJumping)
            {
                this.damageCoefficient = Modules.StaticValues.gardenJumpDamageCoefficient;
            }

            this.damageType = DamageType.Generic;

            this.procCoefficient = 1f;
            this.bonusForce = Vector3.zero;
            this.baseDuration = 1f;
            this.attackStartTime = 0.2f;
            this.attackEndTime = 0.4f;
            this.baseEarlyExitTime = 0.4f;
            this.hitStopDuration = 0.012f;
            this.attackRecoil = 0.5f;
            this.hitHopVelocity = 0f;

            this.swingSoundString = "HenrySwordSwing";
            this.hitSoundString = "";
            this.muzzleString = swingIndex % 2 == 0 ? "SwingLeft" : "SwingRight";
            this.swingEffectPrefab = Modules.Assets.swordSwingEffect;
            this.hitEffectPrefab = Modules.Assets.swordHitImpactEffect;

            this.impactSound = Modules.Assets.swordHitSoundEvent.index;

            base.OnEnter();
        }

        protected override void PlayAttackAnimation()
        {
            base.PlayAttackAnimation();
        }

        protected override void PlaySwingEffect()
        {
            base.PlaySwingEffect();
        }

        protected override void OnHitEnemyAuthority()
        {
            base.OnHitEnemyAuthority();
        }

        protected override void SetNextState()
        {
            int index = this.swingIndex;
            if (index == 0) index = 1;
            else index = 0;

            this.outer.SetNextState(new MarketGardener
            {
                swingIndex = index
            });
        }

        public override void OnExit()
        {
            base.OnExit();
        }
    }
}