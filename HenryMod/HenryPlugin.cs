using BepInEx;
using HenryMod.Modules.Survivors;
using R2API.Utils;
using RoR2;
using System.Collections.Generic;
using System.Security;
using System.Security.Permissions;
using static R2API.RecalculateStatsAPI;
using R2API;
using UnityEngine;
using HenryMod.Modules;

[module: UnverifiableCode]
#pragma warning disable CS0618 // Type or member is obsolete
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618 // Type or member is obsolete

namespace HenryMod
{
    [BepInDependency("com.bepis.r2api", BepInDependency.DependencyFlags.HardDependency)]
    [NetworkCompatibility(CompatibilityLevel.EveryoneMustHaveMod, VersionStrictness.EveryoneNeedSameModVersion)]
    [BepInPlugin(MODUID, MODNAME, MODVERSION)]
    [R2APISubmoduleDependency(new string[]
    {
        "PrefabAPI",
        "LanguageAPI",
        "SoundAPI",
        "DamageAPI"
    })]
    [R2APISubmoduleDependency(nameof(LanguageAPI))]

    public class HenryPlugin : BaseUnityPlugin
    {
        // if you don't change these you're giving permission to deprecate the mod-
        //  please change the names to your own stuff, thanks
        //   this shouldn't even have to be said
        public const string MODUID = "com.DestroyedClone.Soldier";
        public const string MODNAME = "Soldier";
        public const string MODVERSION = "1.0.0";

        // a prefix for name tokens to prevent conflicts- please capitalize all name tokens for convention
        public const string developerPrefix = "DESCLO";

        internal List<SurvivorBase> Survivors = new List<SurvivorBase>();

        public static HenryPlugin instance;

        public static R2API.DamageAPI.ModdedDamageType zatoichiKillDamageType;

        private void Awake()
        {
            instance = this;

            // load assets and read config
            Modules.Assets.Initialize();
            Modules.Config.ReadConfig();
            Modules.States.RegisterStates(); // register states for networking
            Modules.Buffs.RegisterBuffs(); // add and register custom buffs/debuffs
            Modules.Projectiles.RegisterProjectiles(); // add and register custom projectiles
            Modules.Tokens.AddTokens(); // register name tokens
            Modules.ItemDisplays.PopulateDisplays(); // collect item display prefabs for use in our display rules
            Modules.DamageTypes.SetupDamageTypes();

            // survivor initialization
            new Soldier().Initialize();

            // now make a content pack and add it- this part will change with the next update
            new Modules.ContentPacks().Initialize();

            RoR2.ContentManagement.ContentManager.onContentPacksAssigned += LateSetup;

            Hook();
        }

        private void LateSetup(HG.ReadOnlyArray<RoR2.ContentManagement.ReadOnlyContentPack> obj)
        {
            // have to set item displays later now because they require direct object references..
            Modules.Survivors.Soldier.instance.SetItemDisplays();
        }

        private void Hook()
        {
            GetStatCoefficients += HenryPlugin_GetStatCoefficients;
            GlobalEventManager.onCharacterDeathGlobal += GlobalEventManager_onCharacterDeathGlobal;
            GlobalEventManager.onServerDamageDealt += GlobalEventManager_onServerDamageDealt;
            GlobalEventManager.onServerDamageDealt += ConchHealOnHit;
            On.RoR2.BlastAttack.Fire += BlastAttack_Fire;
        }

        private void ConchHealOnHit(DamageReport obj)
        {
            if (obj.attackerBody && obj.attackerBody.healthComponent)
            {
                if (obj.attackerBody.GetBuffCount(Modules.Buffs.soldierBannerHeal) > 0)
                {
                    obj.attackerBody.healthComponent.Heal(StaticValues.healBuffRecoverCoefficient * obj.damageDealt, default);
                }
            }
        }

        private BlastAttack.Result BlastAttack_Fire(On.RoR2.BlastAttack.orig_Fire orig, BlastAttack self)
        {
            // done because i cant intercept and have it collect the 
            if (self.attacker)
            {
                var cm = self.attacker.GetComponent<CharacterMotor>();
                if (cm)
                {
                    var attackerPos = self.attacker.gameObject.transform.position;
                    var dist = Vector3.Distance(attackerPos, self.position);
                    if (dist <= self.radius)
                    {
                        var distFraction = 1 / (self.radius - dist / self.radius);
                        var power = distFraction * StaticValues.selfPushForce;

                        Vector3 forceDirection = (attackerPos- self.position).normalized;

                        cm.ApplyForce(forceDirection * power);
                    }
                }
            }
            return orig(self);
        }

        private Vector3 tracker = new Vector3(3.132f, 3.23f, 3.214f);

        private void GlobalEventManager_onServerDamageDealt(DamageReport obj)
        {
            if (obj.damageInfo.HasModdedDamageType(Modules.DamageTypes.zatoichiKillDamageType))
            {
                var enemy = obj.victimBody;
                if (enemy.healthComponent && !enemy.healthComponent.godMode)
                {
                    var skillLocator = enemy.healthComponent.GetComponent<SkillLocator>();
                    if (skillLocator && skillLocator.special && skillLocator.special.skillDef == HenryMod.Modules.Survivors.Soldier.swordSkillDef)
                    {
                        //enemy.healthComponent.Suicide(gameObject);
                        enemy.healthComponent.TakeDamage(new DamageInfo{
                            attacker = gameObject,
                            inflictor = gameObject,
                            crit = true,
                            damage = enemy.healthComponent.health*9,
                            position = enemy.transform.position,
                            force = new Vector3(3f, 3f, 3f),
                        });
                    }
                }
            }
        }

        private void GlobalEventManager_onCharacterDeathGlobal(DamageReport obj)
        {
            if (obj.damageInfo.HasModdedDamageType(Modules.DamageTypes.zatoichiKillDamageType))
            {
                var hc = obj.damageInfo.attacker.GetComponent<HealthComponent>();
                if (obj.damageInfo.attacker && hc)
                {
                    if (obj.damageInfo.force == tracker)
                    {
                        hc.HealFraction(StaticValues.swordHealDuo, default);
                    }
                    hc.HealFraction(obj.victimIsBoss ? StaticValues.swordHealBoss : StaticValues.swordHealNormal, default);
                }
            }
        }

        private void HenryPlugin_GetStatCoefficients(CharacterBody sender, StatHookEventArgs args)
        {
            if (sender)
            {
                if (sender.HasBuff(Modules.Buffs.soldierBannerCrit))
                {
                    args.damageMultAdd += Modules.StaticValues.damageBuffDamageCoefficient;
                }

                if (sender.HasBuff(Modules.Buffs.soldierBannerHeal))
                {
                    args.moveSpeedMultAdd += Modules.StaticValues.healBuffSpeedCoefficient;
                }

                if (sender.HasBuff(Modules.Buffs.soldierBannerTank))
                {
                    args.armorAdd += Modules.StaticValues.tankBuffArmorBoost;
                }
            }
        }
    }
}