using System;
using System.Collections.Generic;
using System.Text;
using RoR2;
using UnityEngine;

namespace HenryMod.Modules.SurvivorComponents
{
    public class BaseBannerComponent : MonoBehaviour, IOnDamageInflictedServerReceiver
    {
        protected GameObject buffWardPrefab;

        public GameObject buffWardInstance;
        public CharacterBody characterBody;
        public float bannerCharge = 0f;
        public float stopwatch = 0f;
        public float damageRequired = 600f;
        public float damageStored = 0f;

        public virtual void Awake()
        {
            //characterBody.onSkillActivatedServer += CharacterBody_onSkillActivatedServer;
        }

        private void CharacterBody_onSkillActivatedServer(GenericSkill obj)
        {
            //utility check to spawn the prefab
        }

        public void FixedUpdate()
        {
            if (buffWardInstance)
            {
                buffWardInstance.transform.position = characterBody.corePosition;
            }
        }

        public void Update()
        {
            bannerCharge = Mathf.Min(1f, damageStored / damageRequired);
            stopwatch += Time.deltaTime;

        }

        public void CreateInstance()
        {
            if (buffWardInstance)
                Destroy(buffWardInstance);
            buffWardInstance = Instantiate(buffWardPrefab);
            buffWardInstance.transform.position = gameObject.transform.position;
        }

        public void OnDamageInflictedServer(DamageReport damageReport)
        {
            var hc = gameObject.GetComponent<HealthComponent>();

            if (damageReport.attacker == gameObject && hc && damageReport.victim != hc)
            {
                damageStored += damageReport.damageDealt;
            }
        }
    }
}
