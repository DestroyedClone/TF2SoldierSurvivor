using EntityStates;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace HenryMod.SkillStates
{
    public class BaseBlowBanner : BaseSkillState
    {
        public static float baseDuration = 3.5f;
        public static float buffDuration = 8f;
        public static GameObject defenseUpPrefab = EntityStates.BeetleGuardMonster.DefenseUp.defenseUpPrefab;
        private Animator modelAnimator;
        private float duration;
        private bool hasCastBuff;
        public float stopwatch = 0;

        public BuffDef buffDef;

        public override void OnEnter()
        {
            base.OnEnter();
            this.duration = baseDuration / this.attackSpeedStat;
            this.modelAnimator = base.GetModelAnimator();
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
                ScaleParticleSystemDuration component = UnityEngine.Object.Instantiate<GameObject>(defenseUpPrefab, base.transform.position, Quaternion.identity, base.transform).GetComponent<ScaleParticleSystemDuration>();
                if (component)
                {
                    component.newDuration = buffDuration;
                }
                Util.PlayAttackSpeedSound("Play_item_use_gainArmor", gameObject, 1/duration);
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