using EntityStates;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace HenryMod.SkillStates
{
    public class ShootBison : BaseShootRocket
    {
        public override void OnEnter()
        {
            base.OnEnter();
            this.projectilePrefab = Modules.Projectiles.bisonProjectilePrefab;
            this.damageCoefficient = Modules.StaticValues.bisonDamageCoefficient;
        }
    }
}
