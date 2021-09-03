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

using Mono.Cecil.Cil;
using MonoMod.Cil;
using System;

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
            // Passive
            On.RoR2.HealthComponent.TakeDamageForce_DamageInfo_bool_bool += Mantreads_ReduceKnockbackDI;
            On.RoR2.HealthComponent.TakeDamageForce_Vector3_bool_bool += Mantreads_ReduceKnockbackVector3;
            // Primary

            // Secondary

            // Utility
            GlobalEventManager.onServerDamageDealt += ConchHealOnHit;
            // Special
            GlobalEventManager.onCharacterDeathGlobal += SwordHealOnKill;
            GlobalEventManager.onServerDamageDealt += SwordMurderSword;
            // Other
            On.RoR2.HealthComponent.TakeDamage += AirshotDamageIncrease;
            On.RoR2.CharacterMotor.Start += GiveRocketJumpComponent;
            On.RoR2.UI.LoadoutPanelController.Row.FromSkillSlot += Row_FromSkillSlot;
            
            //IL.RoR2.UI.LoadoutPanelController.Row.FromSkillSlot += RenameMiscToPassive;

            LanguageAPI.Add("LOADOUT_SKILL_PASSIVE", "Passive");
        }

        private void AirshotDamageIncrease(On.RoR2.HealthComponent.orig_TakeDamage orig, HealthComponent self, DamageInfo damageInfo)
        {
            if (DamageAPI.HasModdedDamageType(damageInfo, Modules.DamageTypes.airshotDamageType))
            {
                damageInfo.damage *= StaticValues.airshotDamageMultiplier;
            }
            orig(self, damageInfo);
        }

        #region passive
        private void Mantreads_ReduceKnockbackVector3(On.RoR2.HealthComponent.orig_TakeDamageForce_Vector3_bool_bool orig, HealthComponent self, Vector3 force, bool alwaysApply, bool disableAirControlUntilCollision)
        {
            if (Skills.HasSkillInCustomFamily(self.gameObject, Soldier.mantreadSkillDef))
            {
                force *= StaticValues.mantreadsPushForceResistance;
            }
            orig(self, force, alwaysApply, disableAirControlUntilCollision);
        }

        private void Mantreads_ReduceKnockbackDI(On.RoR2.HealthComponent.orig_TakeDamageForce_DamageInfo_bool_bool orig, HealthComponent self, DamageInfo damageInfo, bool alwaysApply, bool disableAirControlUntilCollision)
        {
            if (Skills.HasSkillInCustomFamily(self.gameObject, Soldier.mantreadSkillDef))
            {
                damageInfo.force *= 1f - StaticValues.mantreadsPushForceResistance;
            }
            orig(self, damageInfo, alwaysApply, disableAirControlUntilCollision);
        }
        #endregion
        private void RenameMiscToPassive(ILContext il)
        {
            var c = new ILCursor(il);
            c.GotoNext(
                x => x.MatchLdstr("LOADOUT_SKILL_MISC"),
                x => x.MatchStloc(2)
                );
            c.Remove();
            c.Emit(OpCodes.Ldfld);
            c.EmitDelegate<Func<BodyIndex, string>>((bi) =>
            {
                var bodyPrefab = BodyCatalog.GetBodyPrefabBodyComponent(bi);
                if (bodyPrefab)
                {
                    int bars = 1;
                    if (bars > 0)
                    {
                        return "other";
                    }
                }
                return "";
            });
        }

        private object Row_FromSkillSlot(On.RoR2.UI.LoadoutPanelController.Row.orig_FromSkillSlot orig, RoR2.UI.LoadoutPanelController owner, BodyIndex bodyIndex, int skillSlotIndex, GenericSkill skillSlot)
        {
            RoR2.Skills.SkillFamily skillFamily = skillSlot.skillFamily;
            SkillLocator component = BodyCatalog.GetBodyPrefabBodyComponent(bodyIndex).GetComponent<SkillLocator>();
            bool addWIPIcons = false;
            string titleToken;
            switch (component.FindSkillSlot(skillSlot))
            {
                case SkillSlot.None:
                    var bodyPrefab = BodyCatalog.GetBodyPrefabBodyComponent(bodyIndex);
                    if ((skillSlot.skillFamily as ScriptableObject).name == bodyPrefab.name + "PassiveFamily")
                    {
                        titleToken = "LOADOUT_SKILL_PASSIVE";
                        addWIPIcons = false;
                        break;
                    }
                    titleToken = "LOADOUT_SKILL_MISC";
                    addWIPIcons = false;
                    break;
                case SkillSlot.Primary:
                    titleToken = "LOADOUT_SKILL_PRIMARY";
                    addWIPIcons = false;
                    break;
                case SkillSlot.Secondary:
                    titleToken = "LOADOUT_SKILL_SECONDARY";
                    break;
                case SkillSlot.Utility:
                    titleToken = "LOADOUT_SKILL_UTILITY";
                    break;
                case SkillSlot.Special:
                    titleToken = "LOADOUT_SKILL_SPECIAL";
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
            RoR2.UI.LoadoutPanelController.Row row = new RoR2.UI.LoadoutPanelController.Row(owner, bodyIndex, titleToken);
            for (int i = 0; i < skillFamily.variants.Length; i++)
            {
                ref RoR2.Skills.SkillFamily.Variant ptr = ref skillFamily.variants[i];
                uint skillVariantIndexToAssign = (uint)i;
                RoR2.UI.LoadoutPanelController.Row row2 = row;
                Sprite icon = ptr.skillDef.icon;
                string skillNameToken = ptr.skillDef.skillNameToken;
                string skillDescriptionToken = ptr.skillDef.skillDescriptionToken;
                Color tooltipColor = row.primaryColor;
                UnityEngine.Events.UnityAction callback = delegate ()
                {
                    Loadout loadout = new Loadout();
                    row.userProfile.CopyLoadout(loadout);
                    loadout.bodyLoadoutManager.SetSkillVariant(bodyIndex, skillSlotIndex, skillVariantIndexToAssign);
                    row.userProfile.SetLoadout(loadout);
                };
                UnlockableDef unlockableDef = ptr.unlockableDef;
                row2.AddButton(owner, icon, skillNameToken, skillDescriptionToken, tooltipColor, callback, ((unlockableDef != null) ? unlockableDef.cachedName : null) ?? "", ptr.viewableNode, false);
            }
            row.findCurrentChoice = ((Loadout loadout) => (int)loadout.bodyLoadoutManager.GetSkillVariant(bodyIndex, skillSlotIndex));
            row.FinishSetup(addWIPIcons);
            return row;
        }


        private void GiveRocketJumpComponent(On.RoR2.CharacterMotor.orig_Start orig, CharacterMotor self)
        {
            orig(self);
            if (self)
            {
                var comp = self.GetComponent<Modules.SurvivorComponents.RocketJumpComponent>();
                if (!comp)
                {
                    comp = self.gameObject.AddComponent<Modules.SurvivorComponents.RocketJumpComponent>();
                }
                comp.characterMotor = self;
            }
        }

        #region utility
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
        #endregion

        private Vector3 tracker = new Vector3(3.132f, 3.23f, 3.214f);

        #region specials
        private void SwordMurderSword(DamageReport obj)
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

        private void SwordHealOnKill(DamageReport obj)
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
        #endregion

        private void HenryPlugin_GetStatCoefficients(CharacterBody sender, StatHookEventArgs args)
        {
            if (sender)
            {
                // Banners
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

                // Specials
                if (sender.skillLocator && sender.skillLocator.special && sender.skillLocator.special.skillDef == Soldier.pickSkillDef)
                {
                    var healthLost = sender.healthComponent.fullHealth - sender.healthComponent.health;
                    var fraction = healthLost / sender.healthComponent.fullHealth;

                    args.moveSpeedMultAdd += fraction * StaticValues.pickSpeedScaleCoefficient;
                }
            }
        }

    }
}