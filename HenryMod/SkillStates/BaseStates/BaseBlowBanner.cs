using EntityStates;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace HenryMod.SkillStates
{
    public class BaseBlowBanner : BaseSkillState
    {
        public static float baseDuration = 1.5f;
        private Animator modelAnimator;
        private float duration;
        private bool hasCastBuff;
        public float stopwatch = 0;
        public Modules.SurvivorComponents.BaseBannerComponent bannerComponent;

        public override void OnEnter()
        {
            base.OnEnter();
            this.duration = baseDuration / this.attackSpeedStat;
            this.modelAnimator = base.GetModelAnimator();
            bannerComponent = gameObject.GetComponent<Modules.SurvivorComponents.BaseBannerComponent>();
            if (bannerComponent && (bannerComponent.bannerCharge < 1 || bannerComponent.isBlown))
            {
                characterBody.skillLocator.utility.AddOneStock();
                this.outer.SetNextStateToMain();
                return;
            }

            if (this.modelAnimator)
            {
                base.PlayCrossfade("LeftArm", "ShootGun", "ShootGun.playbackRate", this.duration, 0.2f);
            }
        }

        // Token: 0x060046EF RID: 18159 RVA: 0x0011FC90 File Offset: 0x0011DE90
        public override void FixedUpdate()
        {
            base.FixedUpdate();
            if (this.modelAnimator && stopwatch > 0.5f && !this.hasCastBuff)
            {
                Util.PlayAttackSpeedSound("Play_item_use_gainArmor", gameObject, 1/duration);
                this.hasCastBuff = true;
            }
            if (base.fixedAge >= this.duration && base.isAuthority && !base.inputBank.skill3.down)
            {
                //Replicating the "banner wont activate until you let go"
                if (NetworkServer.active)
                {
                    if (gameObject.GetComponent<Modules.SurvivorComponents.BaseBannerComponent>())
                    {
                        gameObject.GetComponent<Modules.SurvivorComponents.BaseBannerComponent>().Blow();
                    }
                }
                this.outer.SetNextStateToMain();
                return;
            }
        }

        public override void Update()
        {
            base.Update();
            stopwatch += Time.deltaTime;
        }

        // Token: 0x060046F0 RID: 18160 RVA: 0x0006E4AF File Offset: 0x0006C6AF
        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }
    }
}