using EntityStates;
using RoR2;
using UnityEngine;

namespace HenryMod.SkillStates
{
    public class FireShotgun : BaseSkillState
    {
        public static float damageCoefficient = Modules.StaticValues.shotgunDamageCoefficient;
        public static float procCoefficient = 1f;
        public static float baseDuration = 0.6f;
        public static float force = 800f;
        public static float recoil = 3f;
        public static float range = 128f;
        public static uint bulletCount = 5U;
        public static GameObject tracerEffectPrefab = Resources.Load<GameObject>("Prefabs/Effects/Tracers/TracerGoldGat");

        private float duration;
        private float fireTime;
        private bool hasFired;
        private string muzzleString;

        public override void OnEnter()
        {
            base.OnEnter();
            this.duration = FireShotgun.baseDuration / this.attackSpeedStat;
            this.fireTime = 0.2f * this.duration;
            base.characterBody.SetAimTimer(2f);
            this.muzzleString = "Muzzle";

            base.PlayAnimation("LeftArm, Override", "ShootGun", "ShootGun.playbackRate", 1.8f);
        }

        public override void OnExit()
        {
            base.OnExit();
        }

        private void Fire()
        {
            if (!this.hasFired)
            {
                this.hasFired = true;

                base.characterBody.AddSpreadBloom(1.5f);
                EffectManager.SimpleMuzzleFlash(EntityStates.Commando.CommandoWeapon.FirePistol2.muzzleEffectPrefab, base.gameObject, this.muzzleString, false);
                Util.PlaySound("HenryShootPistol", base.gameObject);

                if (base.isAuthority)
                {
                    Ray aimRay = base.GetAimRay();
                    base.AddRecoil(-1f * FireShotgun.recoil, -2f * FireShotgun.recoil, -0.5f * FireShotgun.recoil, 0.5f * FireShotgun.recoil);

                    new BulletAttack
                    {
                        bulletCount = bulletCount,
                        aimVector = aimRay.direction,
                        origin = aimRay.origin,
                        damage = FireShotgun.damageCoefficient * this.damageStat,
                        damageColorIndex = DamageColorIndex.Default,
                        damageType = DamageType.Generic,
                        falloffModel = BulletAttack.FalloffModel.DefaultBullet,
                        maxDistance = FireShotgun.range,
                        force = FireShotgun.force,
                        hitMask = LayerIndex.CommonMasks.bullet,
                        minSpread = 1f,
                        maxSpread = 5f,
                        isCrit = base.RollCrit(),
                        owner = base.gameObject,
                        muzzleName = muzzleString,
                        smartCollision = false,
                        procChainMask = default,
                        procCoefficient = procCoefficient / bulletCount,
                        radius = 1f,
                        sniper = false,
                        stopperMask = LayerIndex.CommonMasks.bullet,
                        weapon = null,
                        tracerEffectPrefab = FireShotgun.tracerEffectPrefab,
                        spreadPitchScale = 1f,
                        spreadYawScale = 1f,
                        queryTriggerInteraction = QueryTriggerInteraction.UseGlobal,
                        hitEffectPrefab = EntityStates.Commando.CommandoWeapon.FirePistol2.hitEffectPrefab,
                    }.Fire();
                }
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();

            if (base.fixedAge >= this.fireTime)
            {
                this.Fire();
            }

            if (base.fixedAge >= this.duration && base.isAuthority)
            {
                this.outer.SetNextStateToMain();
                return;
            }
        }

        public override InterruptPriority GetMinimumInterruptPriority()
        {
            return InterruptPriority.PrioritySkill;
        }
    }
}