using System;
using System.Collections.Generic;
using System.Text;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace HenryMod.Modules.SurvivorComponents
{
    public class BaseBannerComponent : MonoBehaviour
    {
        public static GameObject buffWardPrefab = Resources.Load<GameObject>("Prefabs/NetworkedObjects/AffixHauntedWard");
        public BuffDef buffDef;

        public GameObject buffWardInstance;
        public float bannerCharge = 0f;
        public float stopwatch = 0f;
        public float damageRequired = 600f;
        public float damageStored = 0f;
        public float duration = 10f;
        public bool isBlown = false;

        public CharacterBody characterBody;
        public SkillLocator skillLocator;

        public virtual void Start()
        {
            GetAssociatedBuffDef();
            if (characterBody)
            {
                UpdateDamageRequirement();
            }
            GlobalEventManager.onServerDamageDealt += AddBannerCharge;
            GlobalEventManager.onCharacterLevelUp += IncreaseDamageRequirementOnLevelUp;
        }

        public void GetAssociatedBuffDef()
        {
            if (skillLocator && skillLocator.utility)
            {
                var skillDef = skillLocator.utility.skillDef;
                if (skillDef == Survivors.Soldier.damageBannerSkillDef)
                {
                    buffDef = Buffs.soldierBannerCrit;
                }
                else if (skillDef == Survivors.Soldier.healBannerSkillDef)
                {
                    buffDef = Buffs.soldierBannerHeal;
                }
            }
        }

        private void IncreaseDamageRequirementOnLevelUp(CharacterBody obj)
        {
            if (obj == characterBody)
            {
                UpdateDamageRequirement();
            }
        }

        public void Blow()
        {
            stopwatch = 0f;
            isBlown = true;
        }

        private void AddBannerCharge(DamageReport damageReport)
        {
            if (!isBlown)
            {
                if (damageReport.attacker == gameObject && damageReport.victim != characterBody.healthComponent)
                {
                    damageStored += damageReport.damageDealt;
                }
            }
        }

        public void Update()
        {
            // Display
            bannerCharge = Mathf.Min(1f, damageStored / damageRequired);
            characterBody.SetBuffCount(Buffs.bannerChargeStack.buffIndex, (int)(bannerCharge*100));

            stopwatch += Time.deltaTime;
            if (isBlown && stopwatch >= duration)
            {
                isBlown = false;
                damageStored = 0;
            }
        }

        private void UpdateDamageRequirement()
        {
            if (characterBody)
                damageRequired = characterBody.damage * StaticValues.stockRocketDamageCoefficient * 20;
        }

        private void FixedUpdate()
        {
            if (!NetworkServer.active)
            {
                return;
            }
            if (damageRequired == 0)
            {
                UpdateDamageRequirement();
            }
            if (!buffDef)
                GetAssociatedBuffDef();
            if (buffWardInstance != isBlown)
            {
                if (isBlown)
                {
                    buffWardInstance = Instantiate(buffWardPrefab);
                    buffWardInstance.GetComponent<TeamFilter>().teamIndex = characterBody.teamComponent.teamIndex;
                    buffWardInstance.GetComponent<BuffWard>().Networkradius = 8f + characterBody.radius;
                    buffWardInstance.GetComponent<BuffWard>().buffDef = Modules.Buffs.soldierBannerHeal;
                    buffWardInstance.GetComponent<NetworkedBodyAttachment>().AttachToGameObjectAndSpawn(characterBody.gameObject);
                    stopwatch = 0f;
                    return;
                }
                UnityEngine.Object.Destroy(buffWardInstance);
                buffWardInstance = null;
            }
        }

        private void OnDisable()
        {
            if (buffWardInstance)
            {
                UnityEngine.Object.Destroy(buffWardInstance);
            }
            GlobalEventManager.onServerDamageDealt -= AddBannerCharge;
            GlobalEventManager.onCharacterLevelUp -= IncreaseDamageRequirementOnLevelUp;
        }
    }
}
