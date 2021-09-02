using R2API;
using RoR2;
using RoR2.Projectile;
using UnityEngine;
using UnityEngine.Networking;

using System;
using HG;
using RoR2.Audio;

namespace HenryMod.Modules
{
    internal static class Projectiles
    {
        internal static GameObject stockRocketPrefab;
        internal static GameObject fastRocketPrefab;
        internal static GameObject healRocketPrefab;
        internal static GameObject noDamageRocketPrefab;

        internal static GameObject damageBuffWard;
        internal static GameObject healBuffWard;
        internal static GameObject tankBuffWard;

        internal static void RegisterProjectiles()
        {
            CreateStockRocket();
            CreateFastRocket();
            CreateHealRocket();
            CreateNoDamageRocket();

            CreateDamageBuffWard();
            CreateDamageHealWard();
            CreateDamageTankWard();

            foreach (var proj in new GameObject[] { stockRocketPrefab , fastRocketPrefab , healRocketPrefab})
            {
                //AddProjectile(proj);
                if (proj)
                Modules.Prefabs.projectilePrefabs.Add(proj);
            }
        }

        internal static void AddProjectile(GameObject projectileToAdd)
        {
            Modules.Prefabs.projectilePrefabs.Add(projectileToAdd);
        }

        private static void CreateStockRocket()
        {
            stockRocketPrefab = CloneProjectilePrefab("PaladinRocket", "SoldierStockRocketProjectile");

            ProjectileImpactExplosion bombImpactExplosion = stockRocketPrefab.GetComponent<ProjectileImpactExplosion>();
            InitializeImpactExplosion(bombImpactExplosion);

            bombImpactExplosion.blastRadius = 6f;
            bombImpactExplosion.destroyOnEnemy = true;
            bombImpactExplosion.destroyOnWorld = true;
            bombImpactExplosion.lifetime = 12f;
            //bombImpactExplosion.impactEffect = Modules.Assets.bombExplosionEffect;
            bombImpactExplosion.timerAfterImpact = false;
            bombImpactExplosion.lifetimeAfterImpact = 0.1f;

            ProjectileDamage projectileDamage = stockRocketPrefab.GetComponent<ProjectileDamage>();
            var moddedDamageTypeComponent = stockRocketPrefab.AddComponent<DamageAPI.ModdedDamageTypeHolderComponent>();
            moddedDamageTypeComponent.Add(Modules.DamageTypes.soldierRocketDamageType);

            ProjectileController bombController = stockRocketPrefab.GetComponent<ProjectileController>();
            bombController.startSound = "";

            RocketJumpBlastComponent rocketJumpBlastComponent = stockRocketPrefab.AddComponent<RocketJumpBlastComponent>();
            rocketJumpBlastComponent.projectileImpactExplosion = bombImpactExplosion;
        }
        private static void CreateFastRocket()
        {
            fastRocketPrefab = CloneProjectilePrefab("PaladinRocket", "SoldierFastRocketProjectile");

            ProjectileImpactExplosion impactExplosion = fastRocketPrefab.GetComponent<ProjectileImpactExplosion>();
            InitializeImpactExplosion(impactExplosion);

            impactExplosion.blastRadius = 6f;
            impactExplosion.destroyOnEnemy = true;
            impactExplosion.destroyOnWorld = true;
            impactExplosion.lifetime = 12f;
            //impactExplosion.impactEffect = Modules.Assets.bombExplosionEffect;
            impactExplosion.timerAfterImpact = false;
            impactExplosion.lifetimeAfterImpact = 0.1f;

            ProjectileController bombController = fastRocketPrefab.GetComponent<ProjectileController>();
            bombController.startSound = "";

            var moddedDamageTypeComponent = stockRocketPrefab.AddComponent<DamageAPI.ModdedDamageTypeHolderComponent>();
            moddedDamageTypeComponent.Add(Modules.DamageTypes.airshotDamageType);

            RocketJumpBlastComponent rocketJumpBlastComponent = stockRocketPrefab.AddComponent<RocketJumpBlastComponent>();
            rocketJumpBlastComponent.projectileImpactExplosion = impactExplosion;

        }
        private static void CreateHealRocket()
        {
            healRocketPrefab = CloneProjectilePrefab("PaladinRocket", "SoldierHealRocketProjectile");

            ProjectileImpactExplosion bombImpactExplosion = healRocketPrefab.GetComponent<ProjectileImpactExplosion>();
            InitializeImpactExplosion(bombImpactExplosion);

            bombImpactExplosion.blastRadius = 6f;
            bombImpactExplosion.destroyOnEnemy = true;
            bombImpactExplosion.destroyOnWorld = true;
            bombImpactExplosion.lifetime = 12f;
            //bombImpactExplosion.impactEffect = Modules.Assets.bombExplosionEffect;
            bombImpactExplosion.timerAfterImpact = false;
            bombImpactExplosion.lifetimeAfterImpact = 0.1f;

            ProjectileController bombController = healRocketPrefab.GetComponent<ProjectileController>();
            bombController.startSound = "";

            ProjectileHealOwnerOnDamageInflicted projectileHeal = healRocketPrefab.AddComponent<ProjectileHealOwnerOnDamageInflicted>();
            projectileHeal.projectileController = bombController;
            projectileHeal.fractionOfDamage = StaticValues.healRocketRecoverPercentage;

            RocketJumpBlastComponent rocketJumpBlastComponent = stockRocketPrefab.AddComponent<RocketJumpBlastComponent>();
            rocketJumpBlastComponent.projectileImpactExplosion = bombImpactExplosion;
        }
        private static void CreateNoDamageRocket()
        {
            noDamageRocketPrefab = CloneProjectilePrefab("PaladinRocket", "SoldierNoDamageRocketProjectile");

            ProjectileImpactExplosion bombImpactExplosion = stockRocketPrefab.GetComponent<ProjectileImpactExplosion>();
            InitializeImpactExplosion(bombImpactExplosion);

            bombImpactExplosion.blastRadius = 6f;
            bombImpactExplosion.destroyOnEnemy = true;
            bombImpactExplosion.destroyOnWorld = true;
            bombImpactExplosion.lifetime = 12f;
            //bombImpactExplosion.impactEffect = Modules.Assets.bombExplosionEffect;
            bombImpactExplosion.timerAfterImpact = false;
            bombImpactExplosion.lifetimeAfterImpact = 0.1f;

            ProjectileDamage projectileDamage = stockRocketPrefab.GetComponent<ProjectileDamage>();

            ProjectileController bombController = stockRocketPrefab.GetComponent<ProjectileController>();
            bombController.startSound = "";

            RocketJumpBlastComponent rocketJumpBlastComponent = stockRocketPrefab.AddComponent<RocketJumpBlastComponent>();
            rocketJumpBlastComponent.projectileImpactExplosion = bombImpactExplosion;
            rocketJumpBlastComponent.shouldDealDamage = false;
        }

        private static void CreateDamageBuffWard()
        {
            //damageBuffWard = PrefabAPI.InstantiateClone(Resources.Load<GameObject>("prefabs/networkedobjects/WarbannerWard"), "SoldierDamageBuffWard");
            damageBuffWard = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/NetworkedObjects/WarbannerWard"));
            damageBuffWard.name = "SoldierDamageBuffWard";
            var buffWard = damageBuffWard.GetComponent<BuffWard>();
            buffWard.buffDef = Buffs.soldierBannerCrit;
            var timer = damageBuffWard.AddComponent<DestroyOnTimer>();
            timer.duration = 8f;
        }

        private static void CreateDamageHealWard()
        {
            //healBuffWard = CloneProjectilePrefab("WarbannerWard", "SoldierHealBuffWard");
            healBuffWard = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/NetworkedObjects/WarbannerWard"));
            healBuffWard.name = "SoldierHealBuffWard";
            var buffWard = damageBuffWard.GetComponent<BuffWard>();
            buffWard.buffDef = Buffs.soldierBannerHeal;
            var timer = damageBuffWard.AddComponent<DestroyOnTimer>();
            timer.duration = 8f;
        }

        private static void CreateDamageTankWard()
        {
            //damageBuffWard = CloneProjectilePrefab("WarbannerWard", "SoldierTankBuffWard");
            tankBuffWard = UnityEngine.Object.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/NetworkedObjects/WarbannerWard"));
            tankBuffWard.name = "SoldierTankBuffWard";
            var buffWard = damageBuffWard.GetComponent<BuffWard>();
            buffWard.buffDef = Buffs.soldierBannerTank;
            var timer = damageBuffWard.AddComponent<DestroyOnTimer>();
            timer.duration = 8f;
        }

        #region setup
        private static void InitializeImpactExplosion(ProjectileImpactExplosion projectileImpactExplosion)
        {
            projectileImpactExplosion.blastDamageCoefficient = 1f;
            projectileImpactExplosion.blastProcCoefficient = 1f;
            projectileImpactExplosion.blastRadius = 1f;
            projectileImpactExplosion.bonusBlastForce = Vector3.zero;
            projectileImpactExplosion.childrenCount = 0;
            projectileImpactExplosion.childrenDamageCoefficient = 0f;
            projectileImpactExplosion.childrenProjectilePrefab = null;
            projectileImpactExplosion.destroyOnEnemy = false;
            projectileImpactExplosion.destroyOnWorld = false;
            projectileImpactExplosion.falloffModel = RoR2.BlastAttack.FalloffModel.Linear;
            projectileImpactExplosion.fireChildren = false;
            //projectileImpactExplosion.impactEffect = null;
            projectileImpactExplosion.lifetime = 0f;
            projectileImpactExplosion.lifetimeAfterImpact = 0f;
            projectileImpactExplosion.lifetimeExpiredSound = null;
            projectileImpactExplosion.lifetimeRandomOffset = 0f;
            projectileImpactExplosion.offsetForLifetimeExpiredSound = 0f;
            projectileImpactExplosion.timerAfterImpact = false;

            projectileImpactExplosion.GetComponent<ProjectileDamage>().damageType = DamageType.Generic;
        }

        private static GameObject CreateGhostPrefab(string ghostName)
        {
            GameObject ghostPrefab = Modules.Assets.mainAssetBundle.LoadAsset<GameObject>(ghostName);
            if (!ghostPrefab.GetComponent<NetworkIdentity>()) ghostPrefab.AddComponent<NetworkIdentity>();
            if (!ghostPrefab.GetComponent<ProjectileGhostController>()) ghostPrefab.AddComponent<ProjectileGhostController>();

            Modules.Assets.ConvertAllRenderersToHopooShader(ghostPrefab);

            return ghostPrefab;
        }

        private static GameObject CloneProjectilePrefab(string prefabName, string newPrefabName)
        {
            GameObject newPrefab = PrefabAPI.InstantiateClone(Resources.Load<GameObject>("Prefabs/Projectiles/" + prefabName), newPrefabName);
            return newPrefab;
        }
        #endregion

        #region classes
        public class RocketJumpBlastComponent : MonoBehaviour, IProjectileImpactBehavior
        {
            public CharacterMotor characterMotor;
            public ProjectileImpactExplosion projectileImpactExplosion;
            public bool shouldDealDamage = true;

            public void Start()
            {
                if (!characterMotor)
                    characterMotor = projectileImpactExplosion.projectileController.owner.GetComponent<CharacterMotor>();
            }

            public void OnProjectileImpact(ProjectileImpactInfo projectileImpactInfo)
            {
                if (characterMotor)
                {
                    var blastRadius = projectileImpactExplosion.blastRadius;
                    var attackerPos = characterMotor.body.footPosition;
                    var dist = Vector3.Distance(attackerPos, projectileImpactInfo.estimatedPointOfImpact);
                    if (dist <= blastRadius) //within blast radius
                    {
                        var distFractionA = (blastRadius - dist) / blastRadius;
                        var distFractionB = 1 / distFractionA;
                        var power = distFractionB * StaticValues.selfPushForce;

                        Vector3 forceDirection = (attackerPos - projectileImpactInfo.estimatedPointOfImpact).normalized;

                        if (shouldDealDamage)
                        {
                            var hc = characterMotor.GetComponent<HealthComponent>();
                            hc.TakeDamage(new DamageInfo
                            {
                                attacker = characterMotor.gameObject,
                                damage = StaticValues.selfDamageCoefficient * hc.body.damage * distFractionA,
                                position = characterMotor.body.corePosition,
                            });
                        }

                        characterMotor.ApplyForce(forceDirection * power, true);

                        var comp = characterMotor.GetComponent<Modules.SurvivorComponents.RocketJumpComponent>();
                        if (comp)
                        {
                            comp.isRocketJumping = true;
                        }
                        //cm.rootMotion += forceDirection * distFraction;
                        //cm.rootMotion += forceDirection * distFraction * 100f;
                    }
                }
            }
        }
        #endregion
    }
}