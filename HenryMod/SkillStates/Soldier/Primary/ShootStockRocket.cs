using EntityStates;
using RoR2;
using RoR2.Projectile;
using UnityEngine;

namespace HenryMod.SkillStates
{
    public class ShootStockRocket : BaseShootRocket
    {
        public override void OnEnter()
        {
            base.OnEnter();
            this.projectilePrefab = Modules.Projectiles.stockRocketPrefab;
            this.damageCoefficient = Modules.StaticValues.stockRocketDamageCoefficient; 

        }
    }
}
