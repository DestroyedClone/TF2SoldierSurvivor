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

        internal static GameObject damageBuffWard;
        internal static GameObject healBuffWard;
        internal static GameObject tankBuffWard;

        internal static void RegisterProjectiles()
        {
            // only separating into separate methods for my sanity
            CreateStockRocket();
            CreateFastRocket();
            CreateHealRocket();

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
            //InitializeImpactExplosion(bombImpactExplosion);

            bombImpactExplosion.blastRadius = 16f;
            bombImpactExplosion.destroyOnEnemy = true;
            bombImpactExplosion.destroyOnWorld = true;
            bombImpactExplosion.lifetime = 12f;
            bombImpactExplosion.impactEffect = Modules.Assets.bombExplosionEffect;
            bombImpactExplosion.timerAfterImpact = false;
            bombImpactExplosion.lifetimeAfterImpact = 0.1f;

            ProjectileController bombController = stockRocketPrefab.GetComponent<ProjectileController>();
            bombController.startSound = "";
        }
        private static void CreateFastRocket()
        {
            fastRocketPrefab = CloneProjectilePrefab("PaladinRocket", "SoldierFastRocketProjectile");

            ProjectileImpactExplosion impactExplosion = fastRocketPrefab.GetComponent<ProjectileImpactExplosion>();
            ProjectileImpactExplosionAirshot airshotImpactExplosion = stockRocketPrefab.AddComponent<ProjectileImpactExplosionAirshot>();
            InitializeAirshotImpactExplosion(airshotImpactExplosion, impactExplosion);
            UnityEngine.Object.Destroy(impactExplosion);

            airshotImpactExplosion.blastRadius = 16f;
            airshotImpactExplosion.destroyOnEnemy = true;
            airshotImpactExplosion.destroyOnWorld = true;
            airshotImpactExplosion.lifetime = 12f;
            airshotImpactExplosion.impactEffect = Modules.Assets.bombExplosionEffect;
            airshotImpactExplosion.timerAfterImpact = false;
            airshotImpactExplosion.lifetimeAfterImpact = 0.1f;

            ProjectileController bombController = fastRocketPrefab.GetComponent<ProjectileController>();
            bombController.startSound = "";


        }
        private static void CreateHealRocket()
        {
            healRocketPrefab = CloneProjectilePrefab("PaladinRocket", "SoldierHealRocketProjectile");

            ProjectileImpactExplosion bombImpactExplosion = healRocketPrefab.GetComponent<ProjectileImpactExplosion>();
            //InitializeImpactExplosion(bombImpactExplosion);

            bombImpactExplosion.blastRadius = 16f;
            bombImpactExplosion.destroyOnEnemy = true;
            bombImpactExplosion.destroyOnWorld = true;
            bombImpactExplosion.lifetime = 12f;
            bombImpactExplosion.impactEffect = Modules.Assets.bombExplosionEffect;
            bombImpactExplosion.timerAfterImpact = false;
            bombImpactExplosion.lifetimeAfterImpact = 0.1f;

            ProjectileController bombController = healRocketPrefab.GetComponent<ProjectileController>();
            bombController.startSound = "";

            ProjectileHealOwnerOnDamageInflicted projectileHeal = healRocketPrefab.AddComponent<ProjectileHealOwnerOnDamageInflicted>();
            projectileHeal.projectileController = bombController;
            projectileHeal.fractionOfDamage = 0.15f;
        }

        private static void CreateDamageBuffWard()
        {
            damageBuffWard = PrefabAPI.InstantiateClone(Resources.Load<GameObject>("prefabs/networkedobjects/WarbannerWard"), "SoldierDamageBuffWard");
            var buffWard = damageBuffWard.GetComponent<BuffWard>();
            buffWard.buffDef = Buffs.soldierBannerCrit;
            var timer = damageBuffWard.AddComponent<DestroyOnTimer>();
            timer.duration = 8f;
        }

        private static void CreateDamageHealWard()
        {
            healBuffWard = CloneProjectilePrefab("WarbannerWard", "SoldierHealBuffWard");
            var buffWard = damageBuffWard.GetComponent<BuffWard>();
            buffWard.buffDef = Buffs.soldierBannerHeal;
            var timer = damageBuffWard.AddComponent<DestroyOnTimer>();
            timer.duration = 8f;
        }

        private static void CreateDamageTankWard()
        {
            damageBuffWard = CloneProjectilePrefab("WarbannerWard", "SoldierTankBuffWard");
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
            projectileImpactExplosion.falloffModel = RoR2.BlastAttack.FalloffModel.None;
            projectileImpactExplosion.fireChildren = false;
            projectileImpactExplosion.impactEffect = null;
            projectileImpactExplosion.lifetime = 0f;
            projectileImpactExplosion.lifetimeAfterImpact = 0f;
            projectileImpactExplosion.lifetimeExpiredSound = null;
            projectileImpactExplosion.lifetimeRandomOffset = 0f;
            projectileImpactExplosion.offsetForLifetimeExpiredSound = 0f;
            projectileImpactExplosion.timerAfterImpact = false;

            projectileImpactExplosion.GetComponent<ProjectileDamage>().damageType = DamageType.Generic;
        }

        private static void InitializeAirshotImpactExplosion(ProjectileImpactExplosionAirshot projectileImpactExplosionAirshot, ProjectileImpactExplosion projectileImpactExplosion)
        {
            projectileImpactExplosionAirshot.alive = projectileImpactExplosion.alive;
            projectileImpactExplosionAirshot.blastAttackerFiltering = projectileImpactExplosion.blastAttackerFiltering;
            projectileImpactExplosionAirshot.explosionEffect = projectileImpactExplosion.explosionEffect;
            projectileImpactExplosionAirshot.hasImpact = projectileImpactExplosion.hasImpact;
            projectileImpactExplosionAirshot.hasPlayedLifetimeExpiredSound = projectileImpactExplosion.hasPlayedLifetimeExpiredSound;
            projectileImpactExplosionAirshot.impactNormal = projectileImpactExplosion.impactNormal;
            projectileImpactExplosionAirshot.maxAngleOffset = projectileImpactExplosion.maxAngleOffset;
            projectileImpactExplosionAirshot.minAngleOffset = projectileImpactExplosion.minAngleOffset;
            projectileImpactExplosionAirshot.projectileController = projectileImpactExplosion.projectileController;
            projectileImpactExplosionAirshot.projectileDamage = projectileImpactExplosion.projectileDamage;
            projectileImpactExplosionAirshot.projectileHealthComponent = projectileImpactExplosion.projectileHealthComponent;
            projectileImpactExplosionAirshot.stopwatch = projectileImpactExplosion.stopwatch;
            projectileImpactExplosionAirshot.stopwatchAfterImpact = projectileImpactExplosion.stopwatchAfterImpact;
            projectileImpactExplosionAirshot.transformSpace = projectileImpactExplosion.transformSpace;
            projectileImpactExplosionAirshot.useLocalSpaceForChildren = projectileImpactExplosion.useLocalSpaceForChildren;

            /*projectileImpactExplosionAirshot.blastDamageCoefficient = 1f;
            projectileImpactExplosionAirshot.blastProcCoefficient = 1f;
            projectileImpactExplosionAirshot.blastRadius = 1f;
            projectileImpactExplosionAirshot.bonusBlastForce = Vector3.zero;
            projectileImpactExplosionAirshot.childrenCount = 0;
            projectileImpactExplosionAirshot.childrenDamageCoefficient = 0f;
            projectileImpactExplosionAirshot.childrenProjectilePrefab = null;
            projectileImpactExplosionAirshot.destroyOnEnemy = false;
            projectileImpactExplosionAirshot.destroyOnWorld = false;
            projectileImpactExplosionAirshot.falloffModel = RoR2.BlastAttack.FalloffModel.None;
            projectileImpactExplosionAirshot.fireChildren = false;
            projectileImpactExplosionAirshot.impactEffect = null;
            projectileImpactExplosionAirshot.lifetime = 0f;
            projectileImpactExplosionAirshot.lifetimeAfterImpact = 0f;
            projectileImpactExplosionAirshot.lifetimeExpiredSound = null;
            projectileImpactExplosionAirshot.lifetimeRandomOffset = 0f;
            projectileImpactExplosionAirshot.offsetForLifetimeExpiredSound = 0f;
            projectileImpactExplosionAirshot.timerAfterImpact = false;

            projectileImpactExplosionAirshot.GetComponent<ProjectileDamage>().damageType = DamageType.Generic;*/
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
        [RequireComponent(typeof(ProjectileController))]
        private class ProjectileImpactExplosionAirshot : ProjectileImpactExplosion
        {
            public new void OnProjectileImpact(ProjectileImpactInfo impactInfo)
            {
                if (!this.alive)
                {
                    return;
                }
                Collider collider = impactInfo.collider;
                this.impactNormal = impactInfo.estimatedImpactNormal;
                if (collider)
                {
                    DamageInfo damageInfo = new DamageInfo();
                    if (this.projectileDamage)
                    {

                        var comp = collider.GetComponent<HurtBox>();
                        if (comp && comp?.healthComponent?.body?.characterMotor && !comp.healthComponent.body.characterMotor.isGrounded)
                        {
                            damageInfo.damage = this.projectileDamage.damage * 2f;
                            damageInfo.crit = true;
                        } else
                        {
                            damageInfo.damage = this.projectileDamage.damage;
                            damageInfo.crit = this.projectileDamage.crit;
                        }

                        damageInfo.attacker = (this.projectileController.owner ? this.projectileController.owner.gameObject : null);
                        damageInfo.inflictor = base.gameObject;
                        damageInfo.position = impactInfo.estimatedPointOfImpact;
                        damageInfo.force = this.projectileDamage.force * base.transform.forward;
                        damageInfo.procChainMask = this.projectileController.procChainMask;
                        damageInfo.procCoefficient = this.projectileController.procCoefficient;
                    }
                    else
                    {
                        Debug.Log("No projectile damage component!");
                    }
                    HurtBox component = collider.GetComponent<HurtBox>();
                    if (component)
                    {
                        if (this.destroyOnEnemy)
                        {
                            HealthComponent healthComponent = component.healthComponent;
                            if (healthComponent)
                            {
                                if (healthComponent.gameObject == this.projectileController.owner)
                                {
                                    return;
                                }
                                if (this.projectileHealthComponent && healthComponent == this.projectileHealthComponent)
                                {
                                    return;
                                }
                                this.alive = false;
                            }
                        }
                    }
                    else if (this.destroyOnWorld)
                    {
                        this.alive = false;
                    }
                    this.hasImpact = true;
                    if (NetworkServer.active)
                    {
                        GlobalEventManager.instance.OnHitAll(damageInfo, collider.gameObject);
                    }
                }
            }
        }
        #endregion
    }
}